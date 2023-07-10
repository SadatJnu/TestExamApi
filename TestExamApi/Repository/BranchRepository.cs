using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestExamApi.Data;

namespace TestExamApi.Repository
{
    public class BranchRepository : BaseRepository<Branch>, IDisposable
    {
        public static ApplicationDbContext _context;

        public BranchRepository() : base ( _context = new ApplicationDbContext())
        {
            //
        }

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }


        ~BranchRepository()
        {
            Dispose(true);
        }
        public void Dispose()
        {
            Dispose(true);
        }		
		
    }
}