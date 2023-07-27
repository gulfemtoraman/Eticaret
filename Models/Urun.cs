namespace Eticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            Resims = new HashSet<Resim>();
            SatisDetays = new HashSet<SatisDetay>();
            UrunOzelliks = new HashSet<UrunOzellik>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        [Column(TypeName = "money")]
        public decimal Fiyat { get; set; }

        public Nullable<System.DateTime> Tarih { get; set; }

        public Nullable<int> KategoriID { get; set; }

        public Nullable<int> MarkaID { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Marka Marka { get; set; }

        public virtual ICollection<Resim> Resims { get; set; }

        public virtual ICollection<SatisDetay> SatisDetays { get; set; }

        public virtual ICollection<UrunOzellik> UrunOzelliks { get; set; }
    }
}
