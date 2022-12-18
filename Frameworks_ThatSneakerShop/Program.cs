using Frameworks_ThatSneakerShop;
using Frameworks_ThatSneakerShop.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Program {
    public static void Main(string[] args) {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
                // Website will start with the config in the class StartUp
                webBuilder.UseStartup<StartUp>();
            });
}



