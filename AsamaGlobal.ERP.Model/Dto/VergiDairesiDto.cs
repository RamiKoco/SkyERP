using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Dto
{
    [NotMapped]
    public class VergiDairesiS: VergiDairesi
    {
        public string IlAdi { get; set; }
    }
    public class VergiDairesiL: BaseEntity
    {
        public string Ad { get; set; }
        public string IlAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
