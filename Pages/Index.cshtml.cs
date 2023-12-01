using System.ComponentModel.DataAnnotations;
using DutchTaxesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DutchTaxesApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    [Required, Range(0, 1_000_000)]
    public float Income { get; set; }
    
    [BindProperty]
    [Required, EnumDataType(typeof(Period))]
    public Period Period { get; set; } = Period.Monthly;
    
    [BindProperty]
    [Required, Range(1, 112)]
    public int Hours { get; set; } = 40;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        /*if (hoursPerWeek != 40 && wagePeriod != Pages.WagePeriod.Hourly)
            wage *= 40f / hoursPerWeek;
        
        var annualWage = wagePeriod switch
        {
            Pages.WagePeriod.Annual => wage,
            Pages.WagePeriod.Monthly => wage * 12,
            Pages.WagePeriod.Hourly => wage * 40 * 4.33f * 12,
            _ => throw new ArgumentOutOfRangeException()
        };*/ // This is calculated on Calculation page
        
        return RedirectToPage("Calculation", new { Income, Hours, Period });
    }
}
