using System.ComponentModel.DataAnnotations;
using DotNetEnv;
using SauceDemo.Enums;

namespace SauceDemo.Config;
//Esta clase lee los valores del.env, crea una instancia de la clase AppConfig y valida los valores
public abstract class ConfigLoader
{
    protected ConfigLoader() { }

    public static AppConfig LoadConfig()
    {
        // Cargar las variables del archivo .env 
        Env.TraversePath().Load();

        // Craer una instancia de la clase de AppConfig
        var config = new AppConfig
        {
            BaseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? string.Empty,
            UrlAfterLogin = Environment.GetEnvironmentVariable("AFTER_LOGING_URL") ?? string.Empty,
            //este valor no se utiliza, en su lugar se utiliza el metodo GetBrowsers para ejecutar las pruebas en diferentes navegadores
            Browsers =
                Environment.GetEnvironmentVariable("BROWSER")?.Split(',')
                ?? [nameof(BrowserType.Chrome)],
            Headless = bool.Parse(Environment.GetEnvironmentVariable("HEADLESS") ?? "false"),
            Mobile = bool.Parse(Environment.GetEnvironmentVariable("MOBILE") ?? "false"),
            Username = Environment.GetEnvironmentVariable("USERNAME") ?? string.Empty,
            Password = Environment.GetEnvironmentVariable("PASSWORD") ?? string.Empty,
            UsernameLocked = Environment.GetEnvironmentVariable("USERNAME_LOCKED") ?? string.Empty,
        };

        // Validar la Configuracion 
        ValidateConfig(config);

        return config;
    }

    public static IEnumerable<string> GetBrowsers()// me da los nombres de los navegadores definidos en el .env
    {
        //Lee del .env el valor que tiene la variable BROWSER en caso de estar definida y si no esta le asigan un valor por defecto
        Env.TraversePath().Load();

        string[] browsers =
            Environment.GetEnvironmentVariable("BROWSER")?.Split(',')
            ?? [nameof(BrowserType.Chrome)];
        string[] browserSet = [];
        //Garantiza que el navegador se valido y que no se repita 
        foreach (string browser in browsers)
        {
            if (browserSet.Contains(browser) && !IsValidBrowser(browser))
                continue;
            IEnumerable<string> enumerable = browserSet.Append(browser);
            yield return browser;
        }
    }
    // Validar la Configuracion 
    private static void ValidateConfig(AppConfig config)
    {
        var validationContext = new ValidationContext(config, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(
            config,
            validationContext,
            validationResults,
            true
        );

        var browserSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (string browser in config.Browsers)
        {
            if (!IsValidBrowser(browser))
            {
                validationResults.Add(
                    new ValidationResult(
                        $"Browser '{browser}' specified in 'BROWSERS' is not supported."
                    )
                );
                isValid = false;
                break;
            }
            browserSet.Add(browser);
        }

        config.Browsers = browserSet.ToArray();

        if (isValid)
            return;
        var errorMessages = validationResults.Select(vr => vr.ErrorMessage);
        throw new InvalidOperationException(
            "Configuration is invalid: " + string.Join("; ", errorMessages)
        );
    }

    //Verificar que el navegador esta entre los valores del Enum
    private static bool IsValidBrowser(string browser) =>
        Enum.TryParse(typeof(BrowserType), browser, true, out _);
}
