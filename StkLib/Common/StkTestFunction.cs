using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPO.Code.Common;

namespace Stk.Common
{
    public class StkTestFunction
    {

        public static bool IsTest()
        {
            bool output;
            string flage = Config.GetForTest();

            if (flage == "Y")
            {
                output = true;
            }
            else

            {
                output = false;
            }
            return output;
        }

    }
}