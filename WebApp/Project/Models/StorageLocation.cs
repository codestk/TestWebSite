using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WMSNet.Model.Models
{
    public class StorageLocation : TrackableEntity
    {
        [Key]
        public int StorageLocationID { get; set; }
        public string AdditionalContent { get; set; }

        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int Zpos { get; set; }
        public decimal Allocation { get; set; }
        public int AllocationState { get; set; }
        public string Field { get; set; }
        public int FieldIndex { get; set; }
        public string Name { get; set; }
        public int OrderIndex { get; set; }
        public string PlCode { get; set; }
        public string ScanCode { get; set; }
        public DateTime StockTakingDate { get; set; }
        public int AreaID { get; set; }
        public int TypeID { get; set; }
        public int CurrentTcc { get; set; }
        public int ZoneID { get; set; }
        public int RackID { get; set; }
        public int ClientID { get; set; }
        public int ClusterID { get; set; }
    }
}
