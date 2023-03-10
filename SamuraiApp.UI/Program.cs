using System;
using System.Linq;
using ClassLibrary1;
using SumuraiApp.Data;

namespace SumuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            // _context.Database.EnsureCreated();
            AddSamurai("Julie","Sampson");
            GetSamurais();
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private static void AddSamurai(params string[] names)
        {
            foreach (var name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
            }
            _context.SaveChanges();
        }

        private static void GetSamurais()
        {
            var samurais = _context.Samurais.ToList();
            // Console.WriteLine($"{text}: Samurai Count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}