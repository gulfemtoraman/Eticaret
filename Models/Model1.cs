using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Eticaret.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=veritabani")
        {
        }

        public virtual DbSet<aspnet_Applications> aspnet_Applications { get; set; }
        public virtual DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public virtual DbSet<aspnet_Paths> aspnet_Paths { get; set; }
        public virtual DbSet<aspnet_PersonalizationAllUsers> aspnet_PersonalizationAllUsers { get; set; }
        public virtual DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
        public virtual DbSet<aspnet_Profile> aspnet_Profile { get; set; }
        public virtual DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public virtual DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }
        public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }
        public virtual DbSet<aspnet_WebEvent_Events> aspnet_WebEvent_Events { get; set; }
        public virtual DbSet<Kargo> Kargoes { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Marka> Markas { get; set; }
        public virtual DbSet<Musteri> Musteris { get; set; }
        public virtual DbSet<MusteriAdre> MusteriAdres { get; set; }
        public virtual DbSet<OzellikDeger> OzellikDegers { get; set; }
        public virtual DbSet<OzellikTip> OzellikTips { get; set; }
        public virtual DbSet<Resim> Resims { get; set; }
        public virtual DbSet<Sati> Satis { get; set; }
        public virtual DbSet<SatisDetay> SatisDetays { get; set; }
        public virtual DbSet<SiparisDurum> SiparisDurums { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Urun> Uruns { get; set; }
        public virtual DbSet<UrunOzellik> UrunOzelliks { get; set; }
        public virtual DbSet<vw_aspnet_Applications> vw_aspnet_Applications { get; set; }
        public virtual DbSet<vw_aspnet_MembershipUsers> vw_aspnet_MembershipUsers { get; set; }
        public virtual DbSet<vw_aspnet_Profiles> vw_aspnet_Profiles { get; set; }
        public virtual DbSet<vw_aspnet_Roles> vw_aspnet_Roles { get; set; }
        public virtual DbSet<vw_aspnet_Users> vw_aspnet_Users { get; set; }
        public virtual DbSet<vw_aspnet_UsersInRoles> vw_aspnet_UsersInRoles { get; set; }
        public virtual DbSet<vw_aspnet_WebPartState_Paths> vw_aspnet_WebPartState_Paths { get; set; }
        public virtual DbSet<vw_aspnet_WebPartState_Shared> vw_aspnet_WebPartState_Shared { get; set; }
        public virtual DbSet<vw_aspnet_WebPartState_User> vw_aspnet_WebPartState_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Membership)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Paths)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Roles)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Users)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Paths>()
                .HasOptional(e => e.aspnet_PersonalizationAllUsers)
                .WithRequired(e => e.aspnet_Paths);

            modelBuilder.Entity<aspnet_Roles>()
                .HasMany(e => e.aspnet_Users)
                .WithMany(e => e.aspnet_Roles)
                .Map(m => m.ToTable("aspnet_UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.aspnet_Membership)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.aspnet_Profile)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_Users>()
                .HasOptional(e => e.Musteri)
                .WithRequired(e => e.aspnet_Users);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventSequence)
                .HasPrecision(19, 0);

            modelBuilder.Entity<aspnet_WebEvent_Events>()
                .Property(e => e.EventOccurrence)
                .HasPrecision(19, 0);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.OzellikTips)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Uruns)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marka>()
                .HasMany(e => e.Uruns)
                .WithRequired(e => e.Marka)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.Telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.MusteriAdres)
                .WithRequired(e => e.Musteri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OzellikDeger>()
                .HasMany(e => e.UrunOzelliks)
                .WithRequired(e => e.OzellikDeger)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OzellikTip>()
                .HasMany(e => e.OzellikDegers)
                .WithRequired(e => e.OzellikTip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OzellikTip>()
                .HasMany(e => e.UrunOzelliks)
                .WithRequired(e => e.OzellikTip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sati>()
                .Property(e => e.ToplamTutar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sati>()
                .HasMany(e => e.SatisDetays)
                .WithRequired(e => e.Sati)
                .HasForeignKey(e => e.SatisID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SatisDetay>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.SatisDetays)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.UrunOzelliks)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);
        }
    }
}
