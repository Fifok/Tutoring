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
                            Pages = new Page[]
                            {
                                new Page
                                {
                                    Title = "First page",
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
                                            Content = "dori.jpg",
                                            ContentType = ContentType.Image
                                        }
                                    }
                                },
                                new Page
                                {
                                    Title = "Second page",
                                    Content = new ContentItem[]
                                    {
                                        new ContentItem
                                        {
                                            Content = "Test content"
                                        },
                                        new ContentItem
                                        {
                                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                        }
                                    }
                                }
                            }
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
                            Pages = new Page[]
                            {
                                new Page
                                {
                                    Title = "First page",
                                    Content = new ContentItem[]
                                    {
                                        new ContentItem
                                        {
                                            Content = "Test content"
                                        },
                                        new ContentItem
                                        {
                                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                        }
                                    }
                                },
                                new Page
                                {
                                    Title = "Second page",
                                    Content = new ContentItem[]
                                    {

                                        new ContentItem
                                        {
                                            Content = "Test content"
                                        },
                                        new ContentItem
                                        {
                                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                        }
                                    }
                                }
                            }
                        }, new Tutorial
                        {
                            Title = "Test title 3",
                            Description = "Super test description 3",
                            Pages = new Page[]
                            {
                                new Page
                                {
                                    Title = "First page",
                                    Content = new ContentItem[]
                                    {
                                        new ContentItem
                                        {
                                            Content = "Test content"
                                        },
                                        new ContentItem
                                        {
                                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                        }
                                    }
                                },
                                new Page
                                {
                                    Title = "Second page",
                                    Content = new ContentItem[]
                                    {
                                        new ContentItem
                                        {
                                            Content = "Test content"
                                        },
                                        new ContentItem
                                        {
                                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu metus accumsan, fermentum dui interdum, faucibus ipsum. Aliquam eu libero eget elit feugiat dapibus. Etiam viverra venenatis diam, ut elementum elit. Phasellus laoreet est eget libero sollicitudin porta. Morbi a sem ultrices, sagittis tortor et, efficitur nulla. Curabitur placerat scelerisque sapien, scelerisque malesuada nisl viverra eu. Donec scelerisque scelerisque lobortis. Nulla ut magna maximus, bibendum erat in, blandit neque. Duis tincidunt maximus purus. Sed feugiat ligula nec velit sollicitudin tristique."
                                        }
                                    }
                                }
                            }
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
                }, 
                new User
                {
                    Firstname = "Anna",
                    Lastname = "Maria",
                    Email = "anna@wp.com",
                    Password = "anna123",
                    Birthdate = DateTime.Parse("2005-03-14"),
                },
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
