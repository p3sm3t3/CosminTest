using AuditInspect.DataAccess.IRepository.IFormRepository;
using AuditInspect.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuditInspect.DataAccess.Data.Repository.FormRepository
{
    public class OtpTableInfoRepository : Repository<OtpTableInfo>, IOtpTableInfoRepository
    {
        private readonly ApplicationDbContext _db;
        public OtpTableInfoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
   
}
