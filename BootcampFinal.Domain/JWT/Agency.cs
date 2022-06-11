using System.Text;

namespace BootcampFinal.Domain.JWT
{
    public class Agency
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string registerCode { get; set; }
        public string firmName { get; set; }
        public string licenseNo { get; set; }
        public bool ownAgency { get; set; }
        public int paymentFrom { get; set; }
        public string qcPcc { get; set; }
        public string qIdentNo { get; set; }
        public bool useOwnWebSettings { get; set; }
        public bool sendFlightInfoSms { get; set; }
        public int allowUnpaidRes { get; set; }
        public bool aceExport { get; set; }
        public string nationality { get; set; }
        public bool allowNon3DPayments { get; set; }
        public string webSetGrp { get; set; }
        public bool bonusUseSysParam { get; set; }
        public bool bonusUserSeeAgencyW { get; set; }
        public bool bonusUserSeeOwnW { get; set; }
        public bool allowAddCredit { get; set; }
    }
}
