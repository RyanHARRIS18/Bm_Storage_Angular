using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if(await context.Users.AnyAsync()) return;
            var userData = await System.IO.File.ReadAllTextAsync("./Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach ( var user in users)
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }
            await context.SaveChangesAsync();

            //  if(await context.Units.AnyAsync()) return;
            // var unitsData = await System.IO.File.ReadAllTextAsync("./Data/UnitSeedData.json");
            // var units = JsonSerializer.Deserialize<List<Unit>>(unitsData);
            //  var i = 0;
            //  foreach ( var unit in units)
            // {
            //     i++;
            //     unit.UnitDescription = "Fair";
            //     unit.UnitID = i;
            //     unit.UnitTypeID = unit.UnitTypeID;
            //     unit.UnitNumber = i;
            //     unit.UnitLocation = i.ToString() + i.ToString();
            //     context.Units.Add(unit);
            // }
            
            // await context.SaveChangesAsync();
            
        }
    }
}