using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TypedConfigurationSample.Models;
using Microsoft.Extensions.Options;

namespace TypedConfigurationSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppSettings _options;

    public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> options)
    {
        _logger = logger;
        _options = options.Value;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
