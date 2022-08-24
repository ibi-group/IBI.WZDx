using System.Linq;
using System.Text.Json;

namespace IBI.WZDx.Serialization;

internal class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => string
        .Concat
        (
            name.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())
        )
        .ToLower();
}