namespace DutchTaxesApp.Models;

public class IncomeRange
{
    public float Min { get; }
    private float _max;

    public float? Max
    {
        get => _max;
        set => _max = value ?? float.MaxValue;
    }

    public IncomeRange(float min, float? max = null)
    {
        Min = min;
        Max = max;
    }
}