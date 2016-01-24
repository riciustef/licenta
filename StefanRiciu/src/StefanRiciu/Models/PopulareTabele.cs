using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace StefanRiciu.Models
{
    public class PopulareTabele
    {
        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    var context = serviceProvider.GetService<ApplicationDbContext>();
        //    context.Database.Migrate();

        //    if (!context.Sportiv.Any())
        //    {
        //        // trasee
        //        var elite = context.Traseu.Add(new Traseu { Denumire = "Elite" }).Entity;
        //        var hobby = context.Traseu.Add(new Traseu { Denumire = "Hobby" }).Entity;

        //        // categorii
        //        var openM = context.Categorie.Add(new Categorie { Nume = "Open Masculin" }).Entity;
        //        var openF = context.Categorie.Add(new Categorie { Nume = "Open Feminin" }).Entity;
        //        var sub35M = context.Categorie.Add(new Categorie { Nume = "Masculin <35" }).Entity;
        //        var sub35F = context.Categorie.Add(new Categorie { Nume = "Feminin <35" }).Entity;
        //        var peste35M = context.Categorie.Add(new Categorie { Nume = "Masculin 35+" }).Entity;
        //        var peste35F = context.Categorie.Add(new Categorie { Nume = "Feminin 35+" }).Entity;

        //        context.Sportiv.AddRange(
        //            new Sportiv()
        //            {
        //                Nume = "Rîciu",
        //                Prenume = "Ștefan",
        //                Localitate = "Iași",
        //                Club = "HPM Running Team",
        //                Email = "riciustef@gmail.com",
        //                Telefon = "0748550516",
        //                DataDeNastere = DateTime.Parse("1990-09-23"),
        //                Confirmat = true,
        //                DataInregistrare = DateTime.Parse("2016-01-01"),
        //                Observatii = "MPC 2015, 2012, Bate Toaca 2015, 2014, 2013, VMT 2015, RRR 2015 etc",
        //                CategorieID = sub35M.CategorieID,
        //                TraseuID = elite.TraseuID
        //            },
        //            new Sportiv()
        //            {
        //                Nume = "Roșu",
        //                Prenume = "Lucian",
        //                Localitate = "Iași",
        //                Club = "HPM Running Team",
        //                Email = "lucianrosu@gmail.com",
        //                Telefon = "555123456",
        //                DataDeNastere = DateTime.Parse("1987-04-22"),
        //                Confirmat = true,
        //                DataInregistrare = DateTime.Parse("2016-01-01"),
        //                Observatii = "MPC 2015, Bate Toaca 2015, 2014, 2013, VMT 2015, RRR 2015 etc",
        //                CategorieID = sub35M.CategorieID,
        //                TraseuID = elite.TraseuID
        //            },
        //            new Sportiv()
        //            {
        //                Nume = "Bejinariu",
        //                Prenume = "Mădălina",
        //                Localitate = "Iași",
        //                Club = "HPM Running Team",
        //                Email = "madalinabejinariu@gmail.com",
        //                Telefon = "555123456",
        //                DataDeNastere = DateTime.Parse("1986-01-06"),
        //                Confirmat = true,
        //                DataInregistrare = DateTime.Parse("2016-01-01"),
        //                Observatii = "MPC 2014, Bate Toaca 2015, 2014, 2013, VMT 2015, RRR 2015 etc",
        //                CategorieID = sub35F.CategorieID,
        //                TraseuID = elite.TraseuID
        //            },
        //            new Sportiv()
        //            {
        //                Nume = "Moroi",
        //                Prenume = "Daniel",
        //                Localitate = "Iași",
        //                Club = "IA ȘI urcă!",
        //                Email = "danielmoroi@gmail.com",
        //                Telefon = "555123456",
        //                DataDeNastere = DateTime.Parse("1992-01-01"),
        //                Confirmat = true,
        //                DataInregistrare = DateTime.Parse("2016-01-01"),
        //                Observatii = "MPC 2015, Bate Toaca 2015, 2014, 2013, VMT 2015, RRR 2015 etc",
        //                CategorieID = openM.CategorieID,
        //                TraseuID = hobby.TraseuID
        //            },
        //            new Sportiv()
        //            {
        //                Nume = "Vieru",
        //                Prenume = "Ludovic",
        //                Localitate = "Iași",
        //                Club = "IA ȘI urcă!",
        //                Email = "ludinamo@gmail.com",
        //                Telefon = "555123789",
        //                DataDeNastere = DateTime.Parse("1978-01-01"),
        //                Confirmat = true,
        //                DataInregistrare = DateTime.Parse("2016-01-01"),
        //                Observatii = "MPC 2013, Bate Toaca 2013 etc",
        //                CategorieID = openM.CategorieID,
        //                TraseuID = hobby.TraseuID
        //            },
        //            new Sportiv()
        //            {
        //                Nume = "Crudu",
        //                Prenume = "Valeriu",
        //                Localitate = "Iași",
        //                Club = "IA ȘI urcă!",
        //                Email = "valeriucrudu@gmail.com",
        //                Telefon = "555123986",
        //                DataDeNastere = DateTime.Parse("1975-01-01"),
        //                Confirmat = true,
        //                DataInregistrare = DateTime.Parse("2016-01-01"),
        //                Observatii = "Bate Toaca 2015, 2014, VMT 2015, RRR 2015 etc",
        //                CategorieID = peste35M.CategorieID,
        //                TraseuID = elite.TraseuID
        //            },
        //            new Sportiv()
        //            {
        //                Nume = "Gheorghică",
        //                Prenume = "Anca Elena",
        //                Localitate = "Iași",
        //                Club = "IA ȘI urcă!",
        //                Email = "ancaelena@gmail.com",
        //                Telefon = "555123457",
        //                DataDeNastere = DateTime.Parse("1985-01-01"),
        //                Confirmat = true,
        //                DataInregistrare = DateTime.Parse("2016-01-01"),
        //                Observatii = "Semimaraton Iași 2015 etc",
        //                CategorieID = openF.CategorieID,
        //                TraseuID = hobby.TraseuID
        //            },
        //            new Sportiv()
        //            {
        //                Nume = "Vasilache",
        //                Prenume = "Maria",
        //                Localitate = "Suceava",
        //                Club = null,
        //                Email = "mariavasilache@gmail.com",
        //                Telefon = "555123452",
        //                DataDeNastere = DateTime.Parse("1979-11-01"),
        //                Confirmat = true,
        //                DataInregistrare = DateTime.Parse("2016-01-01"),
        //                Observatii = null,
        //                CategorieID = openF.CategorieID,
        //                TraseuID = hobby.TraseuID
        //            }
        //            );
        //        context.SaveChanges();
        //    }
        //}
    }
}
