using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Dto.CariDto.CariSubeDto
{
    [NotMapped]
    public class CariSubelerS : CariSubeler
    {
        public string CariSubeGrubuAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }

    public class CariSubelerL : BaseEntity
    {
        public string Ad { get; set; }
        public string CariSubeGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }
}
