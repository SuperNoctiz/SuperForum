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
using PagedList;

namespace NEXT.Project.SuperForum.Web.Controllers
{
    public class TopicsController : Controller
    {
        private SuperForumContext db = new SuperForumContext();
        private readonly TopicBO topicBO = new TopicBO();


        public ActionResult Index(string searchString, string currentFilter, int? pageSize, int? page)
        {
            int topicsPerPage = (pageSize ?? 3);
            int pageNumber = (page ?? 1);

            var topics = topicBO.Get().Result;

            var model = new TopicListViewModel
            {
                PageSize = topicsPerPage,
                PageSizeList = new SelectList(new int[] { 3, 5, 10 }),
                PagedTopics = topics.ToPagedList(pageNumber, topicsPerPage)
            };

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                model.PageSize = topicsPerPage;
                model.PagedTopics = topics.Where(t => t.User.Name.Contains(searchString) || t.Title.Contains(searchString)).ToPagedList(pageNumber, topicsPerPage);
            }

            return View(model);
        }

        // GET: Topics/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicViewModel topic = new TopicViewModel();
            var result = topicBO.Get(id);

            if (!result.HasSucceeded)
            {
                return HttpNotFound();
            }

            topic.Topic = result.Result;

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
        public ActionResult Create(CreateTopicViewModel topicVM)
        {
            if (ModelState.IsValid && Session["UserLoggedInId"] != null)
            {
                var userBO = new UserBO();
                var author = userBO.Get((Guid)Session["UserLoggedInId"]).Result;
                var newTopic = new Topic
                {
                    Id = Guid.NewGuid(),
                    UserId = author.Id,
                    Title = topicVM.Title,
                    Description = topicVM.Description,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                };
                var result = topicBO.Create(newTopic);
                if (result.HasSucceeded)
                {
                    return RedirectToAction("Index");
                }
                
                return HttpNotFound();
            }

            //ViewBag.UserId = new SelectList(db.Users, "Id", "Name", topic.UserId);
            return View(topicVM);
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
