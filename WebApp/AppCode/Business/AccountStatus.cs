using System;
using WebApp.Code.Utility;

namespace WebApp.Code.Business
{
    public class  AccountStatus
        : BaseProperties{
        String _Status; 
        public String Status { get { return _Status; } set { _Status = value; } } 
 
        String _StatusName; 
        public String StatusName { get { return _StatusName; } set { _StatusName = value; } } 
 
    }
}

