using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class MontirServiceModel
    {
        public IEnumerable<ItemService> Datas { get; set; }

        public string NomorFaktur { get; }
        public DateTime? TanggalFaktur { get; }

        public MontirServiceModel(IGrouping<string, ItemService> item)
        {
            this.Datas= item.ToList();
            var first = item.FirstOrDefault();
            if(first!=null)
            {
                NomorFaktur = item.Key;
                TanggalFaktur = first != null ? first.Tanggal:null;
            }
        }

        public double Upah
        {
            get
            {
                return Datas.Sum(x => x.Biaya) * 10/100;
            }
        }

    }
}