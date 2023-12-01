using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DutchTaxesApp.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public abstract class Tax
{
    public string Id { get; }
    public string Name { get; }
    [JsonProperty("rating")] public TaxRatingType RatingType { get; }
    [JsonProperty("type")] public TaxCollectionType CollectionType { get; } = TaxCollectionType.Single;

    protected Tax(string id, string name, TaxRatingType ratingType,
        TaxCollectionType collectionType = TaxCollectionType.Single)
    {
        Id = id;
        Name = name;
        RatingType = ratingType;
        CollectionType = collectionType;
    }
}

public class SingleTax : Tax
{
    public float Rate { get; }

    public SingleTax(string id, string name, float rate) : base(id, name, TaxRatingType.Single)
    {
        Rate = rate;
    }
}

public class SingleCollectiveTax : Tax
{
    public IEnumerable<TaxNamedRate> Rates { get; }

    public SingleCollectiveTax(string id, string name, IEnumerable<TaxNamedRate> rates) : base(id, name,
        TaxRatingType.Single, TaxCollectionType.Collective)
    {
        Rates = rates;
    }
}

public class SingleCappedTax : Tax
{
    public float Rate { get; }
    [JsonProperty("income")] public IncomeRange Range { get; }

    public SingleCappedTax(string id, string name, float rate, IncomeRange range) : base(id, name,
        TaxRatingType.SingleCapped)
    {
        Rate = rate;
        Range = range;
    }
}

public class SingleCollectiveCappedTax : Tax
{
    public IEnumerable<TaxNamedRate> Rates { get; }
    [JsonProperty("income")] public IncomeRange Range { get; }

    public SingleCollectiveCappedTax(string id, string name, IEnumerable<TaxNamedRate> rates, IncomeRange range) : base(
        id, name, TaxRatingType.SingleCapped, TaxCollectionType.Collective)
    {
        Rates = rates;
        Range = range;
    }
}

public class TieredTax : Tax
{
    public IEnumerable<TaxTier> Tiers { get; }

    public TieredTax(string id, string name, IEnumerable<TaxTier> tiers) : base(id, name, TaxRatingType.Tiered)
    {
        Tiers = tiers;
    }
}