using System.Runtime.Serialization;

namespace RiseSharp.Mobile.Models
{
    [DataContract]
    public class Settings
    {

        [DataMember(Name = "isprotected")]
        public bool IsSecurityEnabled { get; set; }

    }
}
