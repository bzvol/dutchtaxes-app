using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DutchTaxesApp.Models;

// snake case for deserialize
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum TaxRatingType
{
    Single,
    SingleCapped,
    Tiered,
    TieredCapped
}