using LinkShortener.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Presentation.Controllers;

public class HomeController(IUrlService urlService) : Controller
{
    public async Task<ViewResult> Index() => View(await urlService.GetAll());

    public IActionResult Delete(int id)
    {
        urlService.Delete(id);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> ShortLink(string shortLink)
    {
        var url = await urlService.AddTransitionToUrl(shortLink);

        return Redirect(url.LongUrl);
    }
}