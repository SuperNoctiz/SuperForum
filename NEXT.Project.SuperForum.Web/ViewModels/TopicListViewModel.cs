using NEXT.Project.SuperForum.Data;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace NEXT.Project.SuperForum.Web.ViewModels
{
    public class TopicListViewModel
    {
        public string Title { get; set; }

        [Display(Name = "Created")]
        public System.DateTime CreatedAt { get; set; }

        [Display(Name = "Updated")]
        public System.DateTime UpdatedAt { get; set; }

        [Display(Name = "Author")]
        public virtual User User { get; set; }

        [Display(Name = "Topics per page")]
        public int PageSize { get; set; }

        public SelectList PageSizeList { get; set; }

        public IPagedList<Topic> PagedTopics { get; set; }        

    }
}