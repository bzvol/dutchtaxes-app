using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DutchTaxesApp.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public abstract class TaxDiscount
{
    public string Id { get; }
    public string Name { get; }
    public TaxRatingType RatingType { get; }
    public TaxDiscountType DiscountType { get; } = TaxDiscountType.Unconditional;

    protected TaxDiscount(string id, string name, TaxRatingType ratingType,
        TaxDiscountType discountType = TaxDiscountType.Unconditional)
    {
        Id = id;
        Name = name;
        RatingType = ratingType;
        DiscountType = discountType;
    }
}

// TODO: Implement conditional discounts

public class SingleTaxDiscount : TaxDiscount
{
    public TaxDiscountValue Value { get; }

    public SingleTaxDiscount(string id, string name, TaxDiscountValue value) : base(id, name, TaxRatingType.Single)
    {
        Value = value;
    }
}

public class SingleCappedTaxDiscount : TaxDiscount
{
    public TaxDiscountValue Value { get; }
    [JsonProperty("income")] public IncomeRange Range { get; }

    public SingleCappedTaxDiscount(string id, string name, TaxDiscountValue value, IncomeRange range) : base(id, name,
        TaxRatingType.SingleCapped)
    {
        Value = value;
        Range = range;
    }
}

public class TieredTaxDiscount : TaxDiscount
{
    public IEnumerable<TaxDiscountTier> Values { get; }

    public TieredTaxDiscount(string id, string name, IEnumerable<TaxDiscountTier> values) : base(id, name,
        TaxRatingType.Tiered)
    {
        Values = values;
    }
}
