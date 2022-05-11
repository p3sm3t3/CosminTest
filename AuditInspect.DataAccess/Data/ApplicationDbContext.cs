using AuditInspect.Models;
using AuditInspect.Models.FormModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AuditInspect.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Form> Form {get;set;}
        public DbSet<OtpTableInfo> OtpTableInfo { get; set; }

    }
}
