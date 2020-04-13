using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStone.DegreeOfAssociationCSharp.DataModel
{
    public class Association
    {
        public int IdParty { get; set; }
        public Party Party { get; set; }

        public int IdGrandParent { get; set; }
        public GrandParent GrandParent { get; set; }
    }
}
