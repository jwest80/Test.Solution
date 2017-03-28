using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Model.Entities;

namespace Test.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose Command:");
                Console.WriteLine("1) Create");
                Console.WriteLine("2) Read");
                Console.WriteLine("3) Update");
                Console.WriteLine("4) Delete");
                Console.WriteLine("5) Exit");

                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Create();
                        break;
                    case "2":
                        Read();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        exit = true;
                        break;
                }
            } while (!exit);

        }

        static private void Create()
        {

            using (var db = new BloggingContext())
            {
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }

        static private void Read()
        {
            using (var db = new BloggingContext())
            {
                // Display all Blogs from the database 
                var query = from b in db.Blogs
                            orderby b.Id
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Id + ") " + item.Name);
                }
            }
        }

        static private void Update()
        {
            Console.Clear();
            Console.WriteLine("Which blog do you wish to update? ");
            Read();
            var choice = Console.ReadLine();

            using (var db = new BloggingContext())
            {
                var blogList = db.Blogs.ToList<Blog>();
                Blog blogToUpdate = blogList.Where(b => b.Id == Convert.ToInt32(choice)).FirstOrDefault<Blog>();

                Console.Clear();
                Console.Write("Enter new name for '" + blogToUpdate.Name + "': ");
                var newName = Console.ReadLine();

                blogToUpdate.Name = newName;
                db.SaveChanges();
            }

        }

        static private void Delete()
        {
            Console.Clear();
            Console.WriteLine("Which blog do you wish to delete? ");
            Read();
            var choice = Console.ReadLine();

            using (var db = new BloggingContext())
            {
                var blogList = db.Blogs.ToList<Blog>();
                db.Blogs.Remove(blogList.Find(b => b.Id == Convert.ToInt32(choice)));

                db.SaveChanges();
                Read();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
