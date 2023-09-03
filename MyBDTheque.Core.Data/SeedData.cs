using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.Core.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DefaultContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DefaultContext>>()))
            {
                //return;
                //if (context.Serie.Any())
                //{
                //    return;
                //    foreach (var serie in context.Serie)
                //    {
                //        context.Serie.Remove(serie);
                //    }
                //}

                foreach (var bd in context.BandeDessinees)
                {
                    context.BandeDessinees.Remove(bd);
                }
                foreach (var a in context.Auteurs)
                {
                    context.Auteurs.Remove(a);
                }
                foreach (var s in context.Series)
                {
                    context.Series.Remove(s);
                }
                foreach (var abd in context.BandeDessineeAuteurs)
                {
                    context.BandeDessineeAuteurs.Remove(abd);
                }

                context.SaveChanges();

                var series = new Serie[]
                {
                    new Serie
                    {
                        Titre = "Lanfeust de Troy",
                        Resume = "La série Lanfeust de Troy"
                    },
                    new Serie
                    {
                        Titre = "Lanfeust de Troy fake",
                        Resume = "La fausse série Lanfeust de Troy"
                    },
                    new Serie
                    {
                        Titre = "Trolls de Troy",
                        Resume = "l'histoire des trolls de Phalompe."
                    },
                    new Serie
                    {
                        Titre = "De cape et de crocs",
                        Resume = "La série De cape et de crocs, une des meilleures série de tout les temps."
                    }
                };

                foreach (Serie s in series)
                {
                    context.Series.Add(s);
                }
                context.SaveChanges();

                var auteurs = new Auteur[]
                {
                    new Auteur
                    {
                        Nom = "Arleston",
                        Prenom = "Christophe",
                        DateDeNaissance = new DateTime(1963,8,14),
                        Biographie = "Le célèbre scénariste de Lanfeust de Troy."
                    },
                    new Auteur
                    {
                        Nom = "Tarquin",
                        Prenom = "Didier",
                        DateDeNaissance = new DateTime(1967,1,20),
                        Biographie = "Le dessinateur de Lanfeust de troy."
                    },
                    new Auteur
                    {
                        Nom = "Mourier",
                        Prenom = "Jean-Louis",
                        DateDeNaissance = new DateTime(1962,11,6),
                        Biographie = "Le dessinateur de Trolls de Troy."
                    },
                    new Auteur
                    {
                        Nom = "Ayroles",
                        Prenom = "Alain",
                        DateDeNaissance = new DateTime(1968,1,26),
                        Biographie = "Le scénariste de De cape et de Crocs."
                    },
                    new Auteur
                    {
                        Nom = "Masbou",
                        Prenom = "Jean-Luc",
                        DateDeNaissance = new DateTime(1963,3,14),
                        Biographie = "Le dessinateur de De cape et de Crocs."
                    }
                };

                foreach (Auteur a in auteurs)
                {
                    context.Auteurs.Add(a);
                }
                context.SaveChanges();

                var bandesdessinees = new BandeDessinee[]
                {
                    new BandeDessinee()
                    {
                        Titre = "L'ivoire du Magohamoth",
                        DateParution = new DateTime(1994,10,1),
                        Resume = "Le tome 1 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Thanos l'incongru",
                        DateParution = new DateTime(1995,8,1),
                        Resume = "Le tome 2 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Castel Or-Azur",
                        DateParution = new DateTime(1996,5,1),
                        Resume = "Le tome 3 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Le paladin d'Eckmül",
                        DateParution = new DateTime(1996,11,1),
                        Resume = "Le tome 4 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Le frisson de l'Haruspice",
                        DateParution = new DateTime(1997,10,3),
                        Resume = "Le tome 5 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Cixi impératrice",
                        DateParution = new DateTime(1998,10,1),
                        Resume = "Le tome 6 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Les pétaures se cachent pour mourir",
                        DateParution = new DateTime(1999,10,1),
                        Resume = "Le tome 7 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "La bête fabuleuse",
                        DateParution = new DateTime(2000,12,1),
                        Resume = "Le tome 8 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "La Forêt Noiseuse",
                        DateParution = new DateTime(2021,11,1),
                        Resume = "Le tome 9 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },
                    new BandeDessinee()
                    {
                        Titre = "Histoires trolles",
                        DateParution = new DateTime(1997,6,1),
                        Resume = "Le tome 1 de Trolls de Troy",
                        SerieId = series.Single(s => s.Titre == "Trolls de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Le scalp du vénérable",
                        DateParution = new DateTime(1998,6,1),
                        Resume = "Le tome 2 de Trolls de Troy",
                        SerieId = series.Single(s => s.Titre == "Trolls de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Comme un vol de pétaures",
                        DateParution = new DateTime(1999,4,1),
                        Resume = "Le tome 3 de Trolls de Troy",
                        SerieId = series.Single(s => s.Titre == "Trolls de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Le feu occulte",
                        DateParution = new DateTime(2000,6,1),
                        Resume = "Le tome 4 de Trolls de Troy",
                        SerieId = series.Single(s => s.Titre == "Trolls de Troy").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Le secret du janissaire",
                        DateParution = new DateTime(1995,11,1),
                        Resume = "Le tome 1 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Pavillon noir !",
                        DateParution = new DateTime(1997,5,1),
                        Resume = "Le tome 2 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "L'archipel du danger",
                        DateParution = new DateTime(1998,9,1),
                        Resume = "Le tome 3 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Le mystère de l'île étrange",
                        DateParution = new DateTime(2000,5,1),
                        Resume = "Le tome 4 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Jean Sans Lune",
                        DateParution = new DateTime(2002,9,1),
                        Resume = "Le tome 5 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Luna Incognita",
                        DateParution = new DateTime(2004,04,1),
                        Resume = "Le tome 6 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Chasseurs de chimères",
                        DateParution = new DateTime(2006,1,1),
                        Resume = "Le tome 7 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Le maître d'armes",
                        DateParution = new DateTime(2007,11,1),
                        Resume = "Le tome 8 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "Revers de fortune",
                        DateParution = new DateTime(2009,11,1),
                        Resume = "Le tome 9 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    },
                    new BandeDessinee
                    {
                        Titre = "De la Lune à la Terre",
                        DateParution = new DateTime(2012,4,1),
                        Resume = "Le tome 10 de la série",
                        SerieId = series.Single(s => s.Titre == "De cape et de crocs").SerieId
                    }

                };

                foreach (BandeDessinee bd in bandesdessinees)
                {
                    context.BandeDessinees.Add(bd);
                }

                context.SaveChanges();

                var auteurBandeDessinees = new BandeDessineeAuteur[]
                {
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "L'ivoire du Magohamoth").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Arleston" && a.Prenom == "Christophe").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Thanos l'incongru").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Arleston" && a.Prenom == "Christophe").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Castel Or-Azur").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Arleston" && a.Prenom == "Christophe").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Histoires trolles").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Arleston" && a.Prenom == "Christophe").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Le scalp du vénérable").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Arleston" && a.Prenom == "Christophe").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Comme un vol de pétaures").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Arleston" && a.Prenom == "Christophe").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "L'ivoire du Magohamoth").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Tarquin" && a.Prenom == "Didier").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Thanos l'incongru").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Tarquin" && a.Prenom == "Didier").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Castel Or-Azur").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Tarquin" && a.Prenom == "Didier").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Histoires trolles").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Mourier" && a.Prenom == "Jean-Louis").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Le scalp du vénérable").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Mourier" && a.Prenom == "Jean-Louis").AuteurId
                    },
                    new BandeDessineeAuteur
                    {
                        BandeDessineeId = bandesdessinees.Single(bd => bd.Titre == "Comme un vol de pétaures").BandeDessineeId,
                        AuteurId = auteurs.Single(a => a.Nom == "Mourier" && a.Prenom == "Jean-Louis").AuteurId
                    },
                };

                foreach (BandeDessineeAuteur abd in auteurBandeDessinees)
                {
                    context.BandeDessineeAuteurs.Add(abd);
                }
                context.SaveChanges();
            }
        }
    }
}
