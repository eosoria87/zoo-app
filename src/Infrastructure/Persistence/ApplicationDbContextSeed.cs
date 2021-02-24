using ZooApp.Domain.Entities;
using ZooApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooApp.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Animals.Any())
            {
                context.AddRange(new List<AnimalEntity>() {
                new AnimalEntity {Nombre = "Tomy", Raza = "Perro", Genero = "Maculino", Comida = "Pepas",Edad = 5},
                new AnimalEntity {Nombre = "Lulu", Raza = "Gato", Genero = "Femenino", Comida = "Pezcado",Edad = 8},
                new AnimalEntity {Nombre = "Miky", Raza = "Ave", Genero = "Maculino", Comida = "Arroz",Edad = 5},
                new AnimalEntity {Nombre = "Benito", Raza = "Pez", Genero = "Maculino", Comida = "Comida Pez",Edad = 3},
                new AnimalEntity {Nombre = "Juan", Raza = "Le?n", Genero = "Maculino", Comida = "Carne",Edad = 10}
            });
                await context.SaveChangesAsync();
            }
        }
    }
}
