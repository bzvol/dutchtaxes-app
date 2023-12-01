using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DutchTaxesApp.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum FormulaInput
{
    Income
}