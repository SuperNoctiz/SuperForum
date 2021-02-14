using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEXT.Project.SuperForum.Web.ViewModels
{
    public class CreateTopicViewModel
    {
        [Required(ErrorMessage = "You need to give it a title")]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "This can't be empty")]
        public string Description { get; set; }

    }
}