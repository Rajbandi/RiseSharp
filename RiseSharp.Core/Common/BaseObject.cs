using Newtonsoft.Json;

namespace RiseSharp.Core.Common
{
    public abstract class BaseObject
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}