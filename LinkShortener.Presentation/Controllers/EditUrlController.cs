using AutoMapper;
using LinkShortener.Application.Interfaces;
using LinkShortener.Data.Entities;
using LinkShortener.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Presentation.Controllers;

public class EditUrlController(IUrlService urlService,
    IMapper mapper) : Controller
{
    public IActionResult Index(int id)
    {
        var url = urlService.GetById(id);

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

        var url = mapper.Map<Url>(urlViewModel);

        if (url is null)
        {
            ModelState.AddModelError("not-found",
                "Ссылка с данным идентификатором не найдена");
            return View("Index", urlViewModel);
        }
        
        urlService.Update(url);

        return RedirectToAction("Index", "Home");
    }
}