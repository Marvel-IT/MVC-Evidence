using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcEvidence.Data;
using System;
using System.Linq;

namespace MvcEvidence.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcOsobaContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcOsobaContext>>()))
            {
                // pohled pro všechny osoby.
                if (context.Osoba.Any())
                {
                    return; // nasazení DB
                }
                context.Osoba.AddRange(
                    new Osoba
                    {
                        Jmeno = "John",
                        Prijmeni = "Muller",
                        Vek = 31,
                        Telefon = 123456789,
                        Pojistovna = "Generali"
                    },
                    new Osoba
                    {
                        Jmeno = "Jana",
                        Prijmeni = "Nováková",
                        Vek = 26,
                        Telefon = 456789123,
                        Pojistovna = "Allianz"
                    },
                    new Osoba
                    {
                        Jmeno = "Karel",
                        Prijmeni = "Novák",
                        Vek = 29,
                        Telefon = 777888999,
                        Pojistovna = "Generali"
                    }                    
                );
                context.SaveChanges();
            }
    }
}