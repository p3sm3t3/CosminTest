using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuditInspect.Models.FormModels
{
   public class OtpTableInfo
    {
        [Key]
        public int Id { get; set; }

        public string userId { get; set; }
        public DateTime StartTime { get; set; }
        public string OtpToken { get; set; }
        
    }
}
