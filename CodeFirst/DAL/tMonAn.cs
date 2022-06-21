using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DAL
{
    [Table("MonAn")]
    public class tMonAn
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_MonAn { get; set; }
        public string Ten_MonAn { get; set; }

        public tMonAn()
        {
            this.MA_NLs = new HashSet<tMA_NL>();
        }
        public virtual ICollection<tMA_NL> MA_NLs { get; set; }
    }
}
