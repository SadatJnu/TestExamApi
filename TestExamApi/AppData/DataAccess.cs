using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestExamApi.AppData
{
    public class DataAccess
    {
        private static DataAccess _DataAccess;

        //public CommonServices commonServices = new CommonServices();
        

        private static object _sync = new object();
        public static DataAccess Instance
        {
            get
            {
                if(_DataAccess == null)
                {
                    lock(_sync)
                    {
                        if(_DataAccess == null)
                        {
                            _DataAccess = new DataAccess();
                        }
                    }
                }
                return _DataAccess;
            }
        }
    }
}
