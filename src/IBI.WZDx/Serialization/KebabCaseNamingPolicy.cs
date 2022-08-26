using System.Linq;
using System.Text.Json;

namespace IBI.WZDx.Serialization;

internal class KebabCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => string
        .Concat
        (
            name.Select((x, i) => i > 0 && char.IsUpper(x) ? "-" + x.ToString() : x.ToString())
        )
        .ToLower();
}