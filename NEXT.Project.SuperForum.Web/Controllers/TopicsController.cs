using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NEXT.Project.SuperForum.Business;
using NEXT.Project.SuperForum.Data;
using NEXT.Project.SuperForum.Web.ViewModels;

namespace NEXT.Project.SuperForum.Web.Controllers
{
    public class TopicsController : Controller
    {
        private SuperForumContext db = new SuperForumContext();
        private readonly TopicBO topicService = new TopicBO();

        // GET: Topics
        public ActionResult Index()
        {
            var model = new TopicListViewModel
            {
                Topics = db.Topics.Include(t => t.User)
            };

            return View(model);
        }

        // GET: Topics/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: Topics/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTopicViewModel topic)
        {
            if (ModelState.IsValid)
            {
                var newTopic = new Topic
                {
                    Id = Guid.NewGuid(),
                    Title = topic.Title,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                var result = topicService.Create(newTopic);
                if (result.HasSucceeded)
                {
                    return RedirectToAction("Index");
                }
                
                return HttpNotFound();
            }

            //ViewBag.UserId = new SelectList(db.Users, "Id", "Name", topic.UserId);
            return View(topic);
        }

        // GET: Topics/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", topic.UserId);
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,UserId,CreatedAt,UpdatedAt,IsDeleted,Description")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", topic.UserId);
            return View(topic);
        }

        // GET: Topics/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
