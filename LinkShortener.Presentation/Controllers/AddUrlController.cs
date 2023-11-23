using AutoMapper;
using LinkShortener.Application.Interfaces;
using LinkShortener.Data.Entities;
using LinkShortener.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Presentation.Controllers;

public class AddUrlController(IUrlService urlService,
    IMapper mapper) : Controller
{
    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Add(UrlViewModel urlViewModel)
    {
        if (!ModelState.IsValid)
            return View("Index", urlViewModel);

        var url = mapper.Map<Url>(urlViewModel);
        urlService.Add(url);

        // var url = new Url
        // {
        //     LongUrl = urlViewModel.LongUrl,
        //     ShortenedUrl = linkShorterService.GenerateShortLink(urlViewModel.LongUrl, 8),
        //     DateOfCreation = DateTime.Now
        // };

        return RedirectToAction("Index", "Home");
    }
}