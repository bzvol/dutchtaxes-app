using Newtonsoft.Json;

namespace DutchTaxesApp.Models;

public abstract class TaxDiscountValue
{
    [JsonProperty("type")] public TaxDiscountValueType Type { get; }

    protected TaxDiscountValue(TaxDiscountValueType type)
    {
        Type = type;
    }
}

public class FixedTaxDiscountValue : TaxDiscountValue
{
    public float Amount { get; }

    public FixedTaxDiscountValue(float amount) : base(TaxDiscountValueType.Fixed)
    {
        Amount = amount;
    }
}

public class TaxDiscountValueWithFormula : TaxDiscountValue
{
    public string Formula { get; }
    public Dictionary<string, FormulaInput> Inputs { get; }

    public TaxDiscountValueWithFormula(string formula, Dictionary<string, FormulaInput> inputs) : base(
        TaxDiscountValueType.Formula)
    {
        Formula = formula;
        Inputs = inputs;
    }
}
