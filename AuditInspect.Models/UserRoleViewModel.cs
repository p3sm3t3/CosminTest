using System;
using System.Collections.Generic;
using System.Text;

namespace AuditInspect.Models
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
