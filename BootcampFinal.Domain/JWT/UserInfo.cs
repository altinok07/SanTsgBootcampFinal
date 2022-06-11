namespace BootcampFinal.Domain.JWT
{
    public class UserInfo
    {
        public MainAgency mainAgency { get; set; }
        public Agency agency { get; set; }
        public Office office { get; set; }
        public Operator @operator { get; set; }
        public Market market { get; set; }
        public int webSiteId { get; set; }
        public int marketWebSiteId { get; set; }
        public bool allowChangePassword { get; set; }
        public bool allowCreateNewUser { get; set; }
        public bool allowCreateAgency { get; set; }
        public bool allowMakeReservation { get; set; }
        public bool allowEditReservation { get; set; }
        public bool allowCancelReservation { get; set; }
        public bool allowB2BUpdate { get; set; }
        public bool allowApiAccess { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string code { get; set; }
    }
}