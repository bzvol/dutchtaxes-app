using Newtonsoft.Json;

namespace DutchTaxesApp.Models;

public class TaxTier
{
    public float Rate { get; }
    [JsonProperty("income")] public IncomeRange Range { get; }

    public TaxTier(float rate, IncomeRange range)
    {
        Rate = rate;
        Range = range;
    }
}