using System;
using System.Collections.Generic;
using System.Text;
using AuditInspect.Models.FormModels;
using AuditInspect.DataAccess.IRepository.IFormRepository;
using AuditInspect.DataAccess.IRepository;
using AuditInspect.DataAccess.Data.Repository.FormRepository;

namespace AuditInspect.DataAccess.Data.Repository
{
    public class UnitOfWork:IUnitOfWork

    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Form = new FormRepository.FormRepository(_db);
            OtpTableInfo = new OtpTableInfoRepository(_db);
        }

        public IFormRepository Form { get; private set; }
        public IOtpTableInfoRepository OtpTableInfo { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
