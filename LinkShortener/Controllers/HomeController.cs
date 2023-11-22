using System.Diagnostics;
using LinkShortener.Data;
using LinkShortener.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using LinkShortener.Models;

namespace LinkShortener.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationContext _applicationContext;

    public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
    {
        _logger = logger;
        _applicationContext = applicationContext;
    }

    public IActionResult Index()
    {
        _applicationContext.Urls.Add(new Url
        {
            LongUrl = "wdwd",
            ShortenedUrl = "efef",
            TransitionCount = 2,
            DateOfCreation = DateTime.Now
        });

        _applicationContext.SaveChanges();
        
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