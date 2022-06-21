using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DAL
{
    [Table("NguyenLieu")]
    public class tNguyenLieu
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_NguyenLieu { get; set; }
        public string Ten_NguyenLieu { get; set; }
        public bool TT_NguyenLieu { get; set; }

        public tNguyenLieu()
        {
            this.MA_NLs = new HashSet<tMA_NL>();
        }
        public virtual ICollection<tMA_NL> MA_NLs { get; set; }
    }
}
