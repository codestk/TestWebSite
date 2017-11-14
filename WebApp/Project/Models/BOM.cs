using System;

namespace WMSNet.Model.Models
{
    public class BOM : TrackableEntity
    {
        public int BOMID { get; set; }
        public string AdditionalContent { get; set; }
        public int Version { get; set; }
        public decimal Amount { get; set; }
        public int Index { get; set; }
        public bool Pickable { get; set; }
        public int ChildID { get; set; }
        public int ParentID { get; set; }
        public virtual ItemData ItemData { get; set; }

    }
}
