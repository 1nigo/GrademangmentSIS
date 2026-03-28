using GradeMngntModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeMngmntDataService
{
    public interface IGradeMngmntDataService
    {

        public void AddLog(DModels account);
        public List<DModels> GetGradeLogs();

        //public DModels? GetById(Guid id);

        public void Update(DModels account);
        
    }
}
