using LinkShortener.Data.Repositories;
using LinkShortener.Models;
using LinkShortener.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers;

public class EditUrlController(UrlRepository urlRepository,
    LinkShorterService linkShorterService) : Controller
{
    public IActionResult Index(int id)
    {
        var url = urlRepository.GetById(id);

        if (url is null)
        {
            ModelState.AddModelError("not-found",
                "Ссылка с данным идентификатором не найдена");
            return View("Index");
        }
        
        return View(new UrlViewModel
        {
            Id = id,
            LongUrl = url.LongUrl
        });
    }
    
    [HttpPost]
    public IActionResult Edit(UrlViewModel urlViewModel)
    {
        if (!ModelState.IsValid)
            return View("Index", urlViewModel);

        var url = urlRepository.GetById(urlViewModel.Id);

        if (url is null)
        {
            ModelState.AddModelError("not-found",
                "Ссылка с данным идентификатором не найдена");
            return View("Index", urlViewModel);
        }

        url.LongUrl = urlViewModel.LongUrl;
        url.ShortenedUrl = linkShorterService.GenerateShortLink(urlViewModel.LongUrl, 8);
        url.DateOfCreation = DateTime.Now;
        
        urlRepository.Update(url);

        return RedirectToAction("Index", "Home");
    }
}