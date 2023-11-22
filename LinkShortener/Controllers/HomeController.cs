using LinkShortener.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers;

public class HomeController(UrlRepository urlRepository) : Controller
{
    public async Task<ViewResult> Index() =>
        View(await urlRepository.GetAll());

    public IActionResult Delete(int id)
    {
        var url = urlRepository.GetById(id);

        if (url is not null)
        {
            urlRepository.Delete(url);
        }
        
        return RedirectToAction("Index");
    }
}