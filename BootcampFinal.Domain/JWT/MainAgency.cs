namespace BootcampFinal.Domain.JWT
{
    public class MainAgency
    {
        public bool ownAgency { get; set; }
        public bool useOwnWebSettings { get; set; }
        public bool sendFlightInfoSms { get; set; }
        public int allowUnpaidRes { get; set; }
        public bool aceExport { get; set; }
        public bool allowNon3DPayments { get; set; }
        public bool bonusUseSysParam { get; set; }
        public bool bonusUserSeeAgencyW { get; set; }
        public bool bonusUserSeeOwnW { get; set; }
        public bool allowAddCredit { get; set; }
    }
}