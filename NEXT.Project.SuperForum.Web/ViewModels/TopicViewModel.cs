using NEXT.Project.SuperForum.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEXT.Project.SuperForum.Web.ViewModels
{
    public class TopicViewModel
    {
        [Display(Name = "Created at")]
        public System.DateTime CreatedAt { get; set; }

        [Display(Name = "Last updated at")]
        public System.DateTime UpdatedAt { get; set; }

        [Display(Name = "Author")]
        public virtual User User { get; set; }

        public Topic Topic { get; set; }
    }
}