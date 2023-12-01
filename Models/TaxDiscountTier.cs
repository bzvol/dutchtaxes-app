using Newtonsoft.Json;

namespace DutchTaxesApp.Models;

public class TaxDiscountTier
{
    public TaxDiscountValue Value { get; }
    [JsonProperty("income")] public IncomeRange Range { get; }
    
    public TaxDiscountTier(TaxDiscountValue value, IncomeRange range)
    {
        Value = value;
        Range = range;
    }
}