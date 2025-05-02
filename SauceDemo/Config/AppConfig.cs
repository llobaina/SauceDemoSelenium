using System.ComponentModel.DataAnnotations;

namespace SauceDemo.Config;
//Esta clase es para mapiar el archivo .env y agregar las validaciones
public class AppConfig
{
    [Required(ErrorMessage = "BaseUrl is required.")]
    [Url(ErrorMessage = "BaseUrl must be a valid URL.")]
    public required string BaseUrl { get; init; }

    [Required(ErrorMessage = "Url after login is required.")]
    [Url(ErrorMessage = "Url must be a valid URL.")]
    public required string UrlAfterLogin { get; init; }

    [Required]
    public required string[] Browsers { get; set; }

    public bool Headless { get; init; }

    public bool Mobile { get; init; }

    [Required(ErrorMessage = "Admin username is required.")]
    public required string Username { get; init; }

    [Required(ErrorMessage = "Admin password is required.")]
    public required string Password { get; init; }

    [Required(ErrorMessage = "usernamelocked is required.")]
    public required string UsernameLocked { get; init; }
}
