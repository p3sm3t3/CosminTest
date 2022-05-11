using System;
using System.Collections.Generic;
using System.Text;
using AuditInspect.DataAccess.IRepository.IFormRepository;

namespace AuditInspect.DataAccess.IRepository
{
   public interface IUnitOfWork: IDisposable
    {
        IFormRepository.IFormRepository Form { get; }

        IOtpTableInfoRepository OtpTableInfo { get; }


        void Save();
    }
}
