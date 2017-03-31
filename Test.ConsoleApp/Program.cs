using System;
using Test.Model.Entities;
using Test.Services;

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
            Console.Write("Enter a name for a new Blog: ");
            var name = Console.ReadLine();
            var blog = new Blog { Name = name };

            var service = new BlogService();
            service.Create(blog);
        }

        static private void Read()
        {
            var service = new BlogService();
            var items = service.Read();

            Console.WriteLine("All blogs in the database:");
            foreach (var item in items)
            {
                Console.WriteLine(item.Id + ") " + item.Name);
            }
        }

        static private void Update()
        {
            Console.Clear();
            Console.WriteLine("Which blog do you wish to update? ");
            Read();
            var choice = Convert.ToInt32(Console.ReadLine());

            var service = new BlogService();

            Blog update = service.ReadById(choice);
            Console.Clear();
            Console.Write("Enter new name for '" + update.Name + "': ");
            update.Name = Console.ReadLine();
            service.Update(update);


        }

        static private void Delete()
        {
            Console.Clear();
            Console.WriteLine("Which blog do you wish to delete? ");
            Read();
            var choice = Convert.ToInt32(Console.ReadLine());

            var service = new BlogService();
            service.Delete(choice);

            Read();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
