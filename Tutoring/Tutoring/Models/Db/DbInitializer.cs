using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Db;
using Tutoring.Models.Db.Models;

namespace Tutoring.Models.Db
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(TutoringContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User
                {
                    Firstname = "Jan",
                    Lastname = "Kowalski",
                    Email = "jan123@gmail.com",
                    Password = "jan123",
                    Birthdate = DateTime.Parse("1973-05-13"),
                    CreatedTutorials = new Tutorial[]
                    {
                        new Tutorial
                        {
                            Title = "Test title 1",
                            Description = "Super test description 1",
                                    Content = new ContentItem[]
                                    {
                                        new ContentItem
                                        {
                                            Content = "Test content",
                                        },
                                        new ContentItem
                                        {
                                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                        },
                                        new ContentItem
                                        {
                                            Content = "dori.jpg",
                                            ContentType = ContentType.Image
                                        }
                                    },

                        }
                    }

                }, new User
                {
                    Firstname = "Andrzej",
                    Lastname = "Nowak",
                    Email = "andrzej@gmail.com",
                    Password = "andrzej123",
                    Birthdate = DateTime.Parse("1964-12-24"),
                    CreatedTutorials = new Tutorial[]
                    {
                        new Tutorial
                        {
                            Title = "Test title 2",
                            Description = "Super test description 2",
                            Content = new ContentItem[]
                            {
                                new ContentItem
                                {
                                    Content = "Test content"
                                },
                                new ContentItem
                                {
                                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                },
                                new ContentItem
                                {
                                    Content = "Test content"
                                },
                                new ContentItem
                                {
                                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                }
                            }

                        }, new Tutorial
                        {
                            Title = "Test title 3",
                            Description = "Super test description 3",
                            Content = new ContentItem[]
                            {
                                new ContentItem
                                {
                                    Content = "Test content"
                                },
                                new ContentItem
                                {
                                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                },

                                new ContentItem
                                {
                                    Content = "Test content"
                                },
                                new ContentItem
                                {
                                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                }
                            },

                        }
                    }

                },
                new User
                {
                    Firstname = "Kamil",
                    Lastname = "Krańczuk",
                    Email = "kamil@outlook.com",
                    Nickname = "Fifok",
                    Password = "kamil123",
                    Birthdate = DateTime.Parse("1994-08-31"),
                    CreatedTutorings = new TutoringModel[]
                    {
                        new TutoringModel
                        {
                            Title = "Programowanko z ASP.NET Core",
                            Description = "Nauka programowania w ASP.NET Core dla opornych. Super zabawa",
                        }
                    }
                },
                new User
                {
                    Firstname = "Anna",
                    Lastname = "Maria",
                    Email = "anna@wp.com",
                    Password = "anna123",
                    Birthdate = DateTime.Parse("2005-03-14"),
                     CreatedTutorings = new TutoringModel[]
                    {
                        new TutoringModel
                        {
                            Title = "Malowanie",
                            Description = "Donec eleifend maximus eros in malesuada. Quisque sagittis ultricies turpis a porttitor. Maecenas ultricies, urna eget ultrices imperdiet, ligula ante cursus lorem, sed laoreet libero nisl at odio. Fusce et metus ac dolor posuere semper. Integer vel augue eget velit mollis fringilla ut at lectus. Proin cursus tellus at elit hendrerit, non posuere dui commodo. Quisque non convallis tellus. Nullam lorem purus, porta non tempor non, ullamcorper eget felis. Aenean dignissim egestas dui, in laoreet erat fermentum eu. Cras iaculis suscipit velit at convallis.",
                        }
                    }
                },
            };

            var students = users.Take(2);
            var tut = users[2].CreatedTutorings.ElementAt(0);
            tut.Students = students.Select(x => new StudentTutoring
            {
                Tutoring = tut,
                Student = x
            }).ToArray();
           

            await context.Users.AddRangeAsync(users);

            await context.SaveChangesAsync();
        }
    }
}
