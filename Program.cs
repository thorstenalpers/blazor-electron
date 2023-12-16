namespace X_Bot;

using ElectronNET.API;
using MudBlazor.Services;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.WebHost.UseElectron(args);

        builder.Services.AddElectron();
        builder.Services.AddMudServices();

        if (HybridSupport.IsElectronActive)
        {
            var window = await Electron.WindowManager.CreateWindowAsync();
            window.OnClosed += () =>
            {
                Electron.App.Quit();
            };
        }
        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<Components.App>()
            .AddInteractiveServerRenderMode();

        await app.RunAsync();
    }
}
