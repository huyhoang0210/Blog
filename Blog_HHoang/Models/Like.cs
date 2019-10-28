namespace Blog_HHoang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Like
    {
        [Key]
        public int id_Like { get; set; }

        public int? id_User { get; set; }

        public int? id_Entry { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual User User { get; set; }
    }
}
