

using System;
using System.ComponentModel.DataAnnotations;

namespace AuditInspect.Models.FormModels
{
   public class Form
    {
        [Key]
        public int Id { get; set; }
    
        public string FormName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreation { get; set; }
        public string UpdateUser { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
