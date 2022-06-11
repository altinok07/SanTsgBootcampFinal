using System;

namespace BootcampFinal.Domain.JWT
{
    public class Body
    {
        public string token { get; set; }
        public DateTime expiresOn { get; set; }
        public int tokenId { get; set; }
        public UserInfo userInfo { get; set; }
    }
}