namespace DutchTaxesApp.Models;

public class TaxNamedRate
{
    public string Id { get; }
    public string Name { get; }
    public float Rate { get; }
    
    public TaxNamedRate(string id, string name, float rate)
    {
        Id = id;
        Name = name;
        Rate = rate;
    }
}