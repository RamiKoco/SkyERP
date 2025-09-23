using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Dto
{
    [NotMapped]
    public class VergiDairesiS: VergiDairesi
    {
       
    }
    public class VergiDairesiL : BaseEntity
    {
        public string VergiDairesiAdi { get; set; }
        public string VergiKodu { get; set; }
        public string Aciklama { get; set; }

    }
}
