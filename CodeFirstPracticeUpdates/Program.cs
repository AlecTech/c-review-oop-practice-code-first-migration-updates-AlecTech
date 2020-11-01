using CodeFirstPracticeUpdates.Models;
using System;
using System.Linq;

namespace CodeFirstPracticeUpdates
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ShelfContext())
            {
                Console.Write("Please enter Name of the shelf:");
                var name = Console.ReadLine();
                Console.Write("Please enter Material Code (1-3):");

                var materialName = Console.ReadLine();

                if (db.Shelfs.Where(x => x.Name.ToUpper() == name.Trim().ToUpper()).Count() != 0)
                {
                    throw new Exception("This item already present.");
                }

                var shelf = new Shelf { Name = name.Trim(), ShelfMaterialID = Int32.Parse(materialName.Trim()) };
                db.Shelfs.Add(shelf);
                db.SaveChanges();
            }
        }
    }
}
