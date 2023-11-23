using LinkShortener.Data.Entities;
using LinkShortener.Data.Repositories;
using LinkShortener.Models;
using LinkShortener.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers;

public class AddUrlController(UrlRepository urlRepository,
    LinkShorterService linkShorterService) : Controller
{
    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Add(UrlViewModel urlViewModel)
    {
        if (!ModelState.IsValid)
            return View("Index", urlViewModel);

        var url = new Url
        {
            LongUrl = urlViewModel.LongUrl,
            ShortenedUrl = linkShorterService.GenerateShortLink(urlViewModel.LongUrl, 8),
            DateOfCreation = DateTime.Now
        };
        
        urlRepository.Add(url);

        return RedirectToAction("Index", "Home");
    }
}