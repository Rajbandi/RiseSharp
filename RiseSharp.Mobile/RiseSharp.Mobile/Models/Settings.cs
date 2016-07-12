using System.Runtime.Serialization;

namespace RiseSharp.Mobile.Models
{
    [DataContract]
    public class Settings
    {
        [DataMember(Name = "password")]
        public string EncryptedPassword { get; set; }

        [DataMember(Name = "isprotected")]
        public bool IsSecurityEnabled { get; set; }

        [DataMember(Name = "bittrexapikey")]
        public string BittrexApiKey { get; set; }
        
    }
}
