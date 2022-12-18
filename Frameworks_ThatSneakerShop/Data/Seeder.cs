using Frameworks_ThatSneakerShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace Frameworks_ThatSneakerShop.Data {
    public class Seeder {
        public static void Initialize(IApplicationBuilder builder1) {
            using (var service = builder1.ApplicationServices.CreateScope()) {
                var context = service.ServiceProvider.GetService<ApplicationDbContext>();
                //  context.Database.Migrate();
                context.Database.EnsureCreated();

                if (!context.Category.Any()) {
                    context.Category.AddRange(
                        new Category { CategoryName = "Kids" },
                        new Category { CategoryName = "Women" },
                        new Category { CategoryName = "Men" });
                    context.SaveChanges();
                }

                if (!context.Shoe.Any()) {
                    context.Shoe.AddRange(
                        new Shoe { ShoeName = "Triple Pink Dunks", ShoeDescription = "The Nike Dunk Low Triple Pink has a full leather build, which makes use of three distinct shades of pink to complete the look. The base has a light shade of pink, with a slightly contrasting pink overlay.", ShoePrice = 221, Stock = 5, CategoryId = 1 },
                        new Shoe { ShoeName = "Nike SB Dunk Low Pro", ShoeDescription = "GREEN/METALLIC GOLD-WHITE-LIGHT GUM", ShoePrice = 147, Stock = 1, CategoryId = 2},
                        new Shoe { ShoeName = "Nike Dunk Low\r\nHalloween (2022)", ShoeDescription = "PHANTOM/BLACK-SAFETY ORANGE", ShoePrice = 210, Stock = 5, CategoryId = 3});
                    context.SaveChanges();
                }

                if (!context.Whislist.Any()){
                    context.Whislist.AddRange(
                        new Whislist { ShoeId = 1 },
                        new Whislist { ShoeId = 2 },
                        new Whislist { ShoeId = 3 });
                    context.SaveChanges();
                }
            }
        }
    }
}
