using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace StefanRiciu.Models
{
    public class PopulareTabele
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Sportiv.Any())
            {
                // trasee
                var elite = context.Traseu.Add(new Traseu { Denumire = "Elite" }).Entity;
                var hobby = context.Traseu.Add(new Traseu { Denumire = "Hobby" }).Entity;

                // categorii
                var mSub35 = context.Categorie.Add(new Categorie { Nume = "Masculin <35" }).Entity;
                var mPeste35 = context.Categorie.Add(new Categorie { Nume = "Masculin 35+" }).Entity;
                var fSub35 = context.Categorie.Add(new Categorie { Nume = "Feminin <35" }).Entity;
                var fPeste35 = context.Categorie.Add(new Categorie { Nume = "Feminin 35+" }).Entity;
                var mOpen = context.Categorie.Add(new Categorie { Nume = "Open Masculin" }).Entity;
                var fOpen = context.Categorie.Add(new Categorie { Nume = "Open Feminin" }).Entity;

                // sportivi
                context.Sportiv.AddRange(
                    new Sportiv()
                    {
                        Nume = "Rîciu",
                        Prenume = "Ștefan",
                        Localitate = "Iași",
                        Club = "HPM Running Team",
                        Email = "riciustef@gmail.com",
                        Telefon = "555123456",
                        DataDeNastere = DateTime.Parse("1990-09-23"),
                        Confirmat = true,
                        DataInregistrare = DateTime.Parse("2016-01-01"),
                        Observatii = "MPC 2015, 2012, Bate Toaca 2015, 2014, 2013, VMT 2015, RRR 2015 etc",
                        CategorieID = mSub35.CategorieID,
                        TraseuID = elite.TraseuID
                    },
                    new Sportiv()
                    {
                        Nume = "Ionescu",
                        Prenume = "Daniel",
                        Localitate = "București",
                        Club = "Bucharest Runners",
                        Email = "ionescudaniel@example.com",
                        Telefon = "555123456",
                        DataDeNastere = DateTime.Parse("1987-04-22"),
                        Confirmat = true,
                        DataInregistrare = DateTime.Parse("2016-01-01"),
                        Observatii = "MPC 2015, Bate Toaca 2015, 2014, 2013, VMT 2015, RRR 2015 etc",
                        CategorieID = mSub35.CategorieID,
                        TraseuID = elite.TraseuID
                    },
                    new Sportiv()
                    {
                        Nume = "Vasilescu",
                        Prenume = "Andreea",
                        Localitate = "Constanța",
                        Club = "Beach Runners",
                        Email = "andreeavasilescu@example.com",
                        Telefon = "555123456",
                        DataDeNastere = DateTime.Parse("1986-01-06"),
                        Confirmat = true,
                        DataInregistrare = DateTime.Parse("2016-01-01"),
                        Observatii = "MPC 2014, Bate Toaca 2015, 2014, 2013, VMT 2015, RRR 2015 etc",
                        CategorieID = fSub35.CategorieID,
                        TraseuID = elite.TraseuID
                    },
                    new Sportiv()
                    {
                        Nume = "Gheorghe",
                        Prenume = "Ion",
                        Localitate = "Cluj-Napoca",
                        Club = "Cluj Runners",
                        Email = "iongheorghe@example.com",
                        Telefon = "555123456",
                        DataDeNastere = DateTime.Parse("1992-01-01"),
                        Confirmat = true,
                        DataInregistrare = DateTime.Parse("2016-01-01"),
                        Observatii = "MPC 2015, Bate Toaca 2015, 2014, 2013, VMT 2015, RRR 2015 etc",
                        CategorieID = mOpen.CategorieID,
                        TraseuID = hobby.TraseuID
                    },
                    new Sportiv()
                    {
                        Nume = "Popescu",
                        Prenume = "Pavel",
                        Localitate = "Timișoara",
                        Club = "Frații P",
                        Email = "pavelpopescu@example.com",
                        Telefon = "555123789",
                        DataDeNastere = DateTime.Parse("1978-01-01"),
                        Confirmat = true,
                        DataInregistrare = DateTime.Parse("2016-01-01"),
                        Observatii = "MPC 2013, Bate Toaca 2013 etc",
                        CategorieID = mOpen.CategorieID,
                        TraseuID = hobby.TraseuID
                    },
                    new Sportiv()
                    {
                        Nume = "Popescu",
                        Prenume = "Petru",
                        Localitate = "Brașov",
                        Club = "Frații P",
                        Email = "petrupopescu@example.com",
                        Telefon = "555123986",
                        DataDeNastere = DateTime.Parse("1975-01-01"),
                        Confirmat = true,
                        DataInregistrare = DateTime.Parse("2016-01-01"),
                        Observatii = "Bate Toaca 2015, 2014, VMT 2015, RRR 2015 etc",
                        CategorieID = mPeste35.CategorieID,
                        TraseuID = elite.TraseuID
                    },
                    new Sportiv()
                    {
                        Nume = "Gheorghe",
                        Prenume = "Ana",
                        Localitate = "Galați",
                        Club = null,
                        Email = "anagheorghe@example.com",
                        Telefon = "555123457",
                        DataDeNastere = DateTime.Parse("1985-01-01"),
                        Confirmat = true,
                        DataInregistrare = DateTime.Parse("2016-01-01"),
                        Observatii = "Semimaraton Iași 2015 etc",
                        CategorieID = fOpen.CategorieID,
                        TraseuID = hobby.TraseuID
                    },
                    new Sportiv()
                    {
                        Nume = "Vasilache",
                        Prenume = "Maria",
                        Localitate = "Suceava",
                        Club = null,
                        Email = "mariavasilache@example.com",
                        Telefon = "555123452",
                        DataDeNastere = DateTime.Parse("1979-11-01"),
                        Confirmat = true,
                        DataInregistrare = DateTime.Parse("2016-01-01"),
                        Observatii = null,
                        CategorieID = fOpen.CategorieID,
                        TraseuID = hobby.TraseuID
                    }
                    );

                // sponsor types
                var organizator = context.SponsorType.Add(new SponsorType { Nume = "Organizator" }).Entity;
                var voluntar = context.SponsorType.Add(new SponsorType { Nume = "Voluntar" }).Entity;
                var media = context.SponsorType.Add(new SponsorType { Nume = "Media" }).Entity;
                var partener = context.SponsorType.Add(new SponsorType { Nume = "Partener" }).Entity;
                var companie = context.SponsorType.Add(new SponsorType { Nume = "Companie" }).Entity;

                // sponsori
                context.Sponsor.AddRange(
                    new Sponsor {
                    Nume = "Sponsorul Iași",
                    Logo = "LogoSponsorulIasi.png",
                    URL = "http://www.example.ro/",
                    SponsorTypeID = companie.SponsorTypeID,
                    DataInregistrare = DateTime.Parse("2016-01-01")
                    },
                    new Sponsor
                    {
                        Nume = "Voluntari Iași",
                        Logo = "LogoVoluntari.png",
                        URL = "http://www.example.ro",
                        SponsorTypeID = voluntar.SponsorTypeID,
                        DataInregistrare = DateTime.Parse("2016-01-01")
                    },
                    new Sponsor
                    {
                        Nume = "Echipa Organizatoare",
                        Logo = "LogoEchipaOrganizatoare.png",
                        URL = "http://www.example.ro",
                        SponsorTypeID = organizator.SponsorTypeID,
                        DataInregistrare = DateTime.Parse("2016-01-01")
                    },
                    new Sponsor
                    {
                        Nume = "Media Iași",
                        Logo = "LogoMediaIasi.png",
                        URL = "http://www.example.ro",
                        SponsorTypeID = media.SponsorTypeID,
                        DataInregistrare = DateTime.Parse("2016-01-01")
                    },
                    new Sponsor
                    {
                        Nume = "Concurs partener",
                        Logo = "LogoConcursPartener.png",
                        URL = "http://www.example.ro",
                        SponsorTypeID = partener.SponsorTypeID,
                        DataInregistrare = DateTime.Parse("2016-01-01")
                    }
                    );

                // pagini
                context.Pagina.AddRange(
                    new Pagina
                    {
                        Titlu = "Regulament",
                        Descriere = "Regulamentul concursului pentru ediția din anul 2016",
                        Continut = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Imagine = null,
                        Video = null,
                        Activa = true,
                        DataInregistrare = DateTime.Parse("2016-01-01")
                    },
                    new Pagina
                    {
                        Titlu = "Despre",
                        Descriere = "Despre concursul ediția din anul 2016",
                        Continut = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Imagine = null,
                        Video = null,
                        Activa = true,
                        DataInregistrare = DateTime.Parse("2016-01-01")
                    },
                    new Pagina
                    {
                        Titlu = "Info Utile",
                        Descriere = "Informații utile participanților pentru ediția din anul 2016",
                        Continut = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Imagine = null,
                        Video = null,
                        Activa = true,
                        DataInregistrare = DateTime.Parse("2016-01-01")
                    },
                    new Pagina
                    {
                        Titlu = "Contact",
                        Descriere = "Pentru mai multe informații",
                        Continut = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Imagine = null,
                        Video = null,
                        Activa = true,
                        DataInregistrare = DateTime.Parse("2016-01-01")
                    },
                    new Pagina
                    {
                        Titlu = "Traseu",
                        Descriere = "Despre trasee",
                        Continut = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        Imagine = null,
                        Video = null,
                        Activa = true,
                        DataInregistrare = DateTime.Parse("2016-01-01")
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
