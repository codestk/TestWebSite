﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace Stk.Common
{
    public class StkString
    {

        /// <summary>
        /// Return Pure Numerric   ekoroew12334= 12334
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        string RemoveNonNumerric(string Text)
        {

            string OutPut = "";


            OutPut += Regex.Replace(Text, "[^0-9]", "");




            OutPut = OutPut.TrimEnd();

            return OutPut;
        }


        //Remove White Spaces
        public string TrimWhiteSpace(string str)
        {

            return  Regex.Replace(str, @"^\s+", string.Empty);
        }




        /// <summary>
        /// True = Null
        /// False = Not Null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        bool IsNull(string str)
        {
            return String.IsNullOrEmpty(str);

        }

    }
}