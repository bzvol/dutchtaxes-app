using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DutchTaxesApp.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class TaxTable
{
    public string Name { get; }
    public Country Country { get; }
    public int Year { get; }
    public Dictionary<string, object> CustomProps { get; }
    public IEnumerable<Tax> Taxes { get; }
    [JsonProperty("tax_discounts")] public IEnumerable<TaxDiscount> Discounts { get; }

    public TaxTable(string name, Country country, int year, Dictionary<string, object> customProps,
        IEnumerable<Tax> taxes, IEnumerable<TaxDiscount> discounts)
    {
        Name = name;
        Country = country;
        Year = year;
        CustomProps = customProps;
        Taxes = taxes;
        Discounts = discounts;
    }
}

public class Country
{
    public string Name { get; }
    public string Code { get; }

    public Country(string name, string code)
    {
        Name = name;
        Code = code;
    }
}