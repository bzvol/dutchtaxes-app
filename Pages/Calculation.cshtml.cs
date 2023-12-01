using System.Reflection;
using System.Text.Json;
using DutchTaxesApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DutchTaxesApp.Pages;

public class Calculation : PageModel
{
    private TaxTable _taxTable;
    private IEnumerable<Tax> _taxes;
    private IEnumerable<TaxDiscount> _discounts;

    public void OnGet(int income, int hours, int period)
    {
        _taxTable = LoadTaxTable("loonheffings.json");
        Calculate(income, hours, period);
    }

    private static TaxTable LoadTaxTable(string path)
    {
        var json = ReadFile(path);
        return JsonSerializer.Deserialize<TaxTable>(json) ??
               throw new InvalidOperationException("Could not deserialize tax table");
    }

    private static string ReadFile(string path)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"DutchTaxesApp.Resources.{path}";
        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream ?? throw new InvalidOperationException("Resource not found"));
        return reader.ReadToEnd();
    }

    public void Calculate(int income, int hours, int period)
    {
        throw new NotImplementedException();
    }
}