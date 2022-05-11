using AuditInspect.DataAccess.IRepository.IFormRepository;
using AuditInspect.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuditInspect.DataAccess.Data.Repository.FormRepository
{
   public class FormRepository:Repository<Form>,IFormRepository
    {
        private readonly ApplicationDbContext _db;
        public FormRepository( ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
