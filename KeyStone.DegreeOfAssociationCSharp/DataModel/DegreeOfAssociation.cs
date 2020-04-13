using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStone.DegreeOfAssociationCSharp.DataModel
{
    public class DegreeOfAssociation
    {
        public Guid Parent { get; set; }
        public int ParentCount { get; set; }
        //public IQueryable<IGrouping<Party, Association>> ChildList { get; set; }
        public List<Child> Children {get; set; } = new List<Child>();
    }

    public class Child
    {
        public int ChildId { get; set; }
        public int ChildCount { get; set; }
    }
}
