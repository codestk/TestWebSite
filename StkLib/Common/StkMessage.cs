using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stk.Common
{
    public class StkMessage
    {
        public static string DuplicatePS_Code()
        {
            return "มีรหัสการจัดเก็บนี้แล้วในระบบ กรุณาใช้รหัสอื่น";
        }
        public static string DuplicateSP_Code()
        {
            return "มีรหัสซัพพลายเออร์ นี้แล้วในระบบ กรุณาใช้รหัสอื่น";
        }

        public static string DuplicateLC_Code()
        {
            return "มีรหัสคลังสินค้า นี้แล้วในระบบ กรุณาใช้รหัสอื่น";
        }

        public static string DuplicatePR_Code()
        {
            return "มีรหัสสินค้า นี้แล้วในระบบ กรุณาใช้รหัสอื่น";
        }

        //public static string SaveComplete()
        //{
        //    return "ทำการบันทึกข้อมูลเรียบร้อยแล้ว";
        //}

        public static string SaveSuccess()
        {
            return "ทำการบันทึกข้อมูลเรียบร้อยแล้ว";
        }

        public static string SaveUnSuccess()
        {
            return "ทำการบันทึกข้อมูลไม่สำเร็จโปรดลองใหม่อีกทีหรือติดต่อ Admin";
        }

        public static string NoSpec()
        {
            return "ไม่ได้ระบุ";
        }
    }
}