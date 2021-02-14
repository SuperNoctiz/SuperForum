using NEXT.Project.SuperForum.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

        public IQueryable<Topic> Topics { get; set; }
    }
}