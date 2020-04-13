using Microsoft.EntityFrameworkCore;

namespace KeyStone.DegreeOfAssociationCSharp.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Party
    {
        [Key]
        public int IdParty { get; set; }

        public int PartyName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Association> Associations { get; set; }
    }
}
