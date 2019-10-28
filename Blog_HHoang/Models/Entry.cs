namespace Blog_HHoang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Entrys")]
    public partial class Entry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entry()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }

        [Key]
        public int id_Entry { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dates { get; set; }

        [StringLength(1000)]
        public string content { get; set; }
        [StringLength(200)]
        public string content1 { get; set; }

        public int? id_User { get; set; }

        [StringLength(50)]
        public string UrlImg { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }
    }
}
