using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DAL
{
    [Table("MonAn_NguyenLieu")]
    public class tMA_NL
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public int ID_MonAn { get; set; }
        public int ID_NguyenLieu { get; set; }

        [ForeignKey("ID_NguyenLieu")]
        public virtual tNguyenLieu NguyenLieu { get; set; }
        [ForeignKey("ID_MonAn")]
        public virtual tMonAn MonAn { get; set; }
    }
}
