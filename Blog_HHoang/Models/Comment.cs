namespace Blog_HHoang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int id_Comment { get; set; }

        public int? id_User { get; set; }

        public int? id_Entry { get; set; }

        [StringLength(500)]
        public string content { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual User User { get; set; }
    }
}
