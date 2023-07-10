using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TestExamApi.Services
{
    public class PatientInfoService : IService<Branch>
    {
        private BranchRepository _BranchRepository;

        public PatientInfoService()
        {
            _BranchRepository = new BranchRepository();
        }

        public bool Add(Branch entity)
        {
            if (SessionClass.LangCultureName == "en")
            {
                entity.BranchNameEN = entity.BranchNameEN;
            }
            else
            {
                entity.BranchNameBN = entity.BranchNameBN;
            }
            entity.IsDeleted = false;
            entity.AddBy = Convert.ToInt32(SessionClass.Id);
            entity.AddDate = DateTime.Now;
            return _BranchRepository.Add(entity);
        }

        public bool Update(Branch entity)
        {
            entity.UpdateBy = Convert.ToInt32(SessionClass.Id);
            entity.UpdateDate = DateTime.Now;
            return _BranchRepository.Update(entity);
        }

        public IEnumerable<Branch> Filter(Expression<Func<Branch, bool>> filter, Func<IQueryable<Branch>, IOrderedQueryable<Branch>> orderBy = null, string[] Children = null)
        {
            return _BranchRepository.Filter(filter, orderBy);
        }

        public bool Remove(long id)
        {
            Branch entity = new Branch();
            entity = _BranchRepository.SingleOrDefault(e => e.Id == id);
            entity.IsDeleted = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = Convert.ToInt32(SessionClass.Id);
            return _BranchRepository.Update(entity);
        }

        public DataTable GetBySpWithParam(string SpName, params object[] parameterValues)
        {
            return this._BranchRepository.GetBySpWithParam(SpName, parameterValues);
        }

        public DataTable GetBySp(string SpName)
        {
            return this._BranchRepository.GetBySp(SpName);
        }

    }
}