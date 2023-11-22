using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models;

public class UrlViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Введите ссылку!")]
    [Url(ErrorMessage = "Введите корректную ссылку (по формату: 'http://url' или 'http://url')")]
    public string LongUrl { get; set; } = string.Empty;
}