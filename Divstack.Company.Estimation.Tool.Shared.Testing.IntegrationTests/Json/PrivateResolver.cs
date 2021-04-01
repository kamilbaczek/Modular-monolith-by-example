using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Json
{
    internal sealed class PrivateResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member
            , MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);

            if (!jsonProperty.Writable)
            {
                var property = member as PropertyInfo;
                if (property != null)
                {
                    var hasPrivateSetter = property.GetSetMethod(true) != null;
                    jsonProperty.Writable = hasPrivateSetter;
                }
            }

            return jsonProperty;
        }
    }
}
