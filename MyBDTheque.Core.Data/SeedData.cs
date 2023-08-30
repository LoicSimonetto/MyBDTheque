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

                if (context.BandeDessinees.Any())
                {
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
                        DateParution = DateTime.Parse("1994-10-1"),
                        Resume = "Le tome 1 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },

                    new BandeDessinee
                    {
                        Titre = "Thanos l'incongru",
                        DateParution = DateTime.Parse("1995-8-1"),
                        Resume = "Le tome 2 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },

                    new BandeDessinee
                    {
                        Titre = "Castel Or-Azur",
                        DateParution = DateTime.Parse("1996-5-3"),
                        Resume = "Le tome 3 de Lanfeust de Troy",
                        SerieId = series.Single(s => s.Titre == "Lanfeust de Troy").SerieId
                    },

                    new BandeDessinee()
                    {
                        Titre = "Histoires trolles",
                        DateParution = DateTime.Parse("2007-10-7"),
                        Resume = "Le tome 1 de Trolls de Troy",
                        SerieId = series.Single(s => s.Titre == "Trolls de Troy").SerieId
                    },

                    new BandeDessinee
                    {
                        Titre = "Le scalp du vénérable",
                        DateParution = DateTime.Parse("2000-1-1"),
                        Resume = "Le tome 2 de Trolls de Troy",
                        SerieId = series.Single(s => s.Titre == "Trolls de Troy").SerieId
                    },

                    new BandeDessinee
                    {
                        Titre = "Comme un vol de pétaures",
                        DateParution = DateTime.Parse("2000-1-1"),
                        Resume = "Le tome 3 de Trolls de Troy",
                        SerieId = series.Single(s => s.Titre == "Trolls de Troy").SerieId
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
