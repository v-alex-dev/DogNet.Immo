using System;

namespace DogNet.Immo.Presentation.Site.Models
{
    public class ConnectedUser
    {
        public UserData UserData { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
