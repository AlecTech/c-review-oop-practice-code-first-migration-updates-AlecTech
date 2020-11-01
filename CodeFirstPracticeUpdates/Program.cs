using CodeFirstPracticeUpdates.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstPracticeUpdates
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ShelfContext())
            {
                //ex: enter Box
                Console.Write("Please enter Name of the item on the shelf:");
                var name = Console.ReadLine();
                //if Box alreay exists then throw an exception if not the continue
                if (db.Shelfs.Where(x => x.Name.ToUpper() == name.Trim().ToUpper()).Count() != 0)
                {
                    throw new Exception("This item already present.");
                }
                //print out all options of the material type
                using (ShelfContext context1 = new ShelfContext())
                {
                    var materials = context1.Shelf_Material.Select(x => x.MaterialName).ToList();
                    // if "type of materials" object has 5 types it will loop 5 times.
                    foreach (var material in materials)
                    {   //print out row from shelf query Name and then look into Shelf_Material object and grab all categories that correlate with MaterialId 
                        Console.WriteLine($"-{material}");
                    }
                }
                //ex: enter plastic
                Console.Write("Please choose type of material from given selection:");
                var materialName = Console.ReadLine();             
                //grab ID of material type ex: pastic has id of 5 => output obj {ID = 5, Name = Box, }
                Shelf_Material materialsLIST = db.Shelf_Material.Where(x => x.MaterialName.ToLower() == materialName.ToLower()).Single();
                //reassign value from the object to a single int ID value
                int newIndex = materialsLIST.ID;
                //Not push new Product name and chosen material type into new object shelf 
                var shelf = new Shelf { Name = name.Trim(), ShelfMaterialID = newIndex };
                //Add this shelf object to Shelfs Model/class
                db.Shelfs.Add(shelf);         
                db.SaveChanges();
            }

            string input;
            do
            {

                Console.Write("Please enter product name to check if it exists or quit to exit:");
                input = Console.ReadLine().Trim().ToLower();

                using (ShelfContext context = new ShelfContext())
                {
                    try
                    {
                        //get everything from context.Shelfs first, then chose only that row which is equals to the input from the user
                        Shelf materialsLIST = context.Shelfs.Where(x => x.Name.ToLower() == input.ToLower()).Single();
                        //JOIN Shelf table with Shelf_Material table based on ShelfMaterialID and ID columns
                        List<Shelf_Material> material = context.Shelf_Material.Where(x => x.ID == materialsLIST.ShelfMaterialID).ToList();

                        // if "product" object has 3 #s assosiated with input name it will loop 3 times.
                        foreach (Shelf_Material materials in material)
                        {   //print out row from shelf query Name and then look into Shelf_Material object and grab all categories that correlate with MaterialId 
                            Console.WriteLine($"-{materialsLIST.Name} {materials.MaterialName}");
                        }

                    }

                    catch
                    {
                        Console.WriteLine("ERROR: PRODUCT not found.");
                    }

                }//if true keep looping
            } while (input != "quit");
        }
    }
}
