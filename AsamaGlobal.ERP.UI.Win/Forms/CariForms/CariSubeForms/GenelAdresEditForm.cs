using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Functions;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;
using System;
using System.Globalization;
using System.Linq;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms
{
    public partial class GenelAdresEditForm : BaseEditForm
    {
        #region Variables
        private readonly long _cariSubeId;
        private readonly string _cariSubeAdi;
        private long? _anaKayitId;
        private long? _kayitId;
        #endregion
        public GenelAdresEditForm(params object[] prm)
        {
            InitializeComponent();
            _cariSubeId = (long)prm[0];
            _cariSubeAdi = prm[1].ToString();
            DataLayoutControl = myDataLayoutControl;
            Bll = new GenelAdresBll(myDataLayoutControl);
            txtAdresTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<AdresTipi>());
            BaseKartTuru = KartTuru.GenelAdres;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new GenelAdresS() : ((GenelAdresBll)Bll).Single(FilterFunctions.Filter<GenelAdres>(Id));
            if (BaseIslemTuru != IslemTuru.EntityInsert)
            {
                var old = (GenelAdres)OldEntity;
                if (_kayitId == null)
                    _kayitId = old.KayitId;
                if (_anaKayitId == null)
                    _anaKayitId = old.AnaKayitId;
            }
            NesneyiKontrollereBagla();
            Text = Text + $" - ( {_cariSubeAdi} )";
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((GenelAdresBll)Bll).YeniKodVer(x => x.CariSubelerId == _cariSubeId);
            txtBaslik.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (GenelAdresS)OldEntity;
            txtKod.Text = entity.Kod;
            entity.KayitTuru = KayitTuru.CariSube;
            txtBaslik.Text = entity.Baslik;
            txtAdresNotu.Text = entity.AdresNotu;
            txtAdresTipi.SelectedItem = entity.AdresTipi.ToName();
            txtUlke.Id = entity.UlkeId;
            txtUlke.Text = entity.UlkeAdi;
            txtIl.Id = entity.IlId;
            txtIl.Text = entity.IlAdi;
            txtIlce.Id = entity.IlceId;
            txtIlce.Text = entity.IlceAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAdresTurleri.Id = entity.AdresTurleriId;
            txtAdresTurleri.Text = entity.AdresTurleriAdi;
            txtPostaKodu.Text = entity.PostaKodu;
            txtAdres.Text = entity.Adres;
            txtEnlem.Text = (entity.Enlem ?? 0m).ToString("F6", CultureInfo.InvariantCulture);
            txtBoylam.Text = (entity.Boylam ?? 0m).ToString("F6", CultureInfo.InvariantCulture);
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
            _kayitId = entity.KayitId;
            _anaKayitId = entity.AnaKayitId;
        }
        protected override void GuncelNesneOlustur()
        {
            var eskiEntity = OldEntity as GenelAdresS;
            decimal? enlem = null;
            if (!string.IsNullOrWhiteSpace(txtEnlem.Text))
                enlem = Math.Round(decimal.Parse(txtEnlem.Text, CultureInfo.InvariantCulture), 6);

            decimal? boylam = null;
            if (!string.IsNullOrWhiteSpace(txtBoylam.Text))
                boylam = Math.Round(decimal.Parse(txtBoylam.Text, CultureInfo.InvariantCulture), 6);

            long? kayitId = _cariSubeId;
            long? anaKayitId = null;
            if (eskiEntity != null && eskiEntity.CarilerId != null && eskiEntity.CarilerId != 0)
            {
                anaKayitId = eskiEntity.CarilerId;
            }
            else
            {
                using (var ctx = new ERPContext())
                {
                    anaKayitId = ctx.CariSubeler
                                    .Where(s => s.Id == _cariSubeId)
                                    .Select(s => (long?)s.CarilerId)
                                    .FirstOrDefault();
                }
            }
            string parentCariUnvan = null;
            if (eskiEntity != null && !string.IsNullOrEmpty(eskiEntity.KayitHesabiAdi))
                parentCariUnvan = eskiEntity.KayitHesabiAdi;
            else if (anaKayitId != null)
            {
                using (var ctx = new ERPContext())
                {
                    parentCariUnvan = ctx.Cariler
                                          .Where(c => c.Id == anaKayitId.Value)
                                          .Select(c => c.Unvan)
                                          .FirstOrDefault();
                }
            }

            CurrentEntity = new GenelAdres
            {
                Id = Id,
                Kod = txtKod.Text,
                KayitTuru = KayitTuru.CariSube,
                Baslik = txtBaslik.Text,
                AdresNotu = txtAdresNotu.Text,
                AdresTipi = txtAdresTipi.Text.GetEnum<AdresTipi>(),
                UlkeId = txtUlke.Id,
                IlId = txtIl.Id,
                IlceId = txtIlce.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                AdresTurleriId = txtAdresTurleri.Id,
                PostaKodu = txtPostaKodu.Text,
                Adres = txtAdres.Text,
                Enlem = enlem,
                Boylam = boylam,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn,
                CariSubelerId = BaseIslemTuru == IslemTuru.EntityInsert ? _cariSubeId : ((GenelAdresS)OldEntity).CariSubelerId,
                AnaKayitId = anaKayitId,
                KayitId = BaseIslemTuru == IslemTuru.EntityInsert ? _cariSubeId : ((GenelAdresS)OldEntity).CariSubelerId,
                KayitHesabiAdi = parentCariUnvan,
                AnaKayitHesabiAdi = _cariSubeAdi,
            };
            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            return ((GenelAdresBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.CariSubelerId == _cariSubeId);
        }
        protected override bool EntityUpdate()
        {
            return ((GenelAdresBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.CariSubelerId == _cariSubeId);
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtUlke)
                    sec.Sec(txtUlke);
                else if (sender == txtIl)
                    sec.Sec(txtIl);
                else if (sender == txtIlce)
                    sec.Sec(txtIlce, txtIl);
                else if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.AdresBilgileri);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.AdresBilgileri);
                else if (sender == txtAdresTurleri)
                    sec.Sec(txtAdresTurleri, KartTuru.AdresTurleri);

        }
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtIl) return;
            txtIl.ControlEnabledChange(txtIlce);
        }
    }
}