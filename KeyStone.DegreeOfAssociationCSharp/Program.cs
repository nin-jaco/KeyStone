using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KeyStone.DegreeOfAssociationCSharp.DataModel;

namespace KeyStone.DegreeOfAssociationCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var entity = new EntityModel())
            {
                var results = entity.Associations.GroupBy(x => x.GrandParent).OrderByDescending(p => p.Count()).Take(10).ToList()
                    .Select(g =>
                    {
                        var childItems = entity.Associations.Where(z => z.IdGrandParent == g.Key.IdGrandParent)
                            .GroupBy(z => z.Party)?.OrderByDescending(z => z.Count()).Take(5);

                        return new DegreeOfAssociation
                        {
                            Parent = g.Key.GrandParentGuid, ParentCount = g.Count(), Children = childItems.Select(x => new Child
                                {ChildId = x.Key.PartyName, ChildCount = x.Count()}).ToList()
                        };
                    });

                Console.WriteLine($@"The top watched shows with their top 5 associations are as follows:");
                int number = 1;
                foreach (var item in results)
                {
                    Console.WriteLine($@"{number}. {item.Parent} count: {item.ParentCount}");
                    Console.WriteLine($@"Top 5 associated items are:");
                    int secondNumber = 1;
                    foreach (var child in item.Children)
                    {
                        Console.WriteLine($@"     {secondNumber}. {child.ChildId}  {child.ChildCount}");
                        secondNumber++;
                    }

                    number++;
                }
                
            }
            Console.ReadKey();
            GetTopTenAndTopFiveForTheTen();
        }

        //-->[That is unless you want the top 5 shows for the entire top 10. Can be more efficiently written.]
        public static void GetTopTenAndTopFiveForTheTen()
        {
            using (var entity = new EntityModel())
            {
                var results = entity.Associations.GroupBy(x => x.GrandParent).OrderByDescending(p => p.Count()).Take(10).ToList()
                    .Select(g => new DegreeOfAssociation
                    {
                        Parent = g.Key.GrandParentGuid,
                        ParentCount = g.Count()
                    });

                var ids = results.Select(p => p.Parent);
                var childItems = entity.Associations.Where(z => ids.Contains(z.GrandParent.GrandParentGuid))
                    .GroupBy(z => z.Party)?.OrderByDescending(z => z.Count()).Take(5).Select(x => new Child
                        { ChildId = x.Key.PartyName, ChildCount = x.Count() }).ToList();

                Console.WriteLine($@"The top 10 watched shows are as follows:");
                int number = 1;
                foreach (var item in results)
                {
                    Console.WriteLine($@"{number}. {item.Parent} count: {item.ParentCount}");
                    number++;
                }
                Console.WriteLine($@"The top 5 watched shows based on the 10 are as follows:");
                int secondNumber = 1;
                foreach (var item in childItems)
                {
                    Console.WriteLine($@"{secondNumber}. {item.ChildId} count: {item.ChildCount}");
                    secondNumber++;
                }

            }
            Console.ReadKey();
        }
    }
}
