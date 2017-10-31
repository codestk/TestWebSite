using StkLib.CCEnum;

namespace WebApp.Code.FrameWork.Enum
{
    public enum EnumStkRole : int
    {
        //1.1 Admin เห็นหมดทุกรายการ
        //1.2 Seller (ขอเปลี่ยนเป็น Purchase) เห็นเฉพาะ Tab ใบสั่งซื้อ เพื่อทำรายการ และเห็นรายงานทั้งหมด
        //1.3 Store (ของเดิมถูกต้องแล้ว) และเห็นรายงานทั้งหมด
        //1.4 Production เห็นเฉพาะ Tab ใบเบิก เพื่อทำรายการ และเห็นรายงานทั้งหมด
        //1.5 User เปลี่ยนเป็น  (Super Visor)เห็นเฉพาะรายงานอย่างเดียวทำรายการไม่ได้
        [StringValue("A")]
        Admin = 1,
      
        [StringValue("S")]
        Store = 2,

        [StringValue("P")]
        Purchase = 3,

        [StringValue("D")]
        Production = 4,

        [StringValue("U")]
        User = 5,

        [StringValue("V")]
        SuperVisor = 6,

        [StringValue("Q")]
        QC = 7
    }
}