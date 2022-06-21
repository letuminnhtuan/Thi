using CodeFirst.DAL;
using CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.BLL
{
    public class BLL_QL
    {
        QLMA db;
        private static BLL_QL _Instance;
        public static BLL_QL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new BLL_QL(new QLMA());
                return _Instance;
            }
            private set { }
        }
        private BLL_QL(QLMA db)
        {
            this.db = db;
        }
        public List<CBBItem> GetCBBMonAn()
        {
            var list = db._MonAns.Select(p => p);
            List<CBBItem> data = new List<CBBItem>();
            foreach(tMonAn i in list)
            {
                data.Add(new CBBItem
                {
                    Key = i.ID_MonAn,
                    Value = i.Ten_MonAn
                });
            }
            return data;
        }
    }
}
