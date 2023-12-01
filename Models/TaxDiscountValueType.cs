using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DutchTaxesApp.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum TaxDiscountValueType
{
    Fixed,
    Rate,
    Formula
}