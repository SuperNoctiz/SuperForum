//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NEXT.Project.SuperForum.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Topic
    {
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public System.Guid UserId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
    
        public virtual User User { get; set; }
    }
}
