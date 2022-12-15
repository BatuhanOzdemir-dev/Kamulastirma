using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kamulastirma.Models
{
    public partial class KamulastirmaContext : DbContext
    {
        public KamulastirmaContext()
        {
        }

        public KamulastirmaContext(DbContextOptions<KamulastirmaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kisiler> Kisilers { get; set; } = null!;
        public virtual DbSet<MahkemeDavaKonulari> MahkemeDavaKonularis { get; set; } = null!;
        public virtual DbSet<MahkemeOdemeler> MahkemeOdemelers { get; set; } = null!;
        public virtual DbSet<Mahkemeler> Mahkemelers { get; set; } = null!;
        public virtual DbSet<MulkiyetAnaliz> MulkiyetAnalizs { get; set; } = null!;
        public virtual DbSet<MulkiyetBilgileri> MulkiyetBilgileris { get; set; } = null!;
        public virtual DbSet<MulkiyetKonutIsyeri> MulkiyetKonutIsyeris { get; set; } = null!;
        public virtual DbSet<MulkiyetKonutTeslimi> MulkiyetKonutTeslimis { get; set; } = null!;
        public virtual DbSet<MulkiyetTasinmazlari> MulkiyetTasinmazlaris { get; set; } = null!;
        public virtual DbSet<SozlesmeDuzeltmeleri> SozlesmeDuzeltmeleris { get; set; } = null!;
        public virtual DbSet<SozlesmeIptalleri> SozlesmeIptalleris { get; set; } = null!;
        public virtual DbSet<SozlesmeOnaylari> SozlesmeOnaylaris { get; set; } = null!;
        public virtual DbSet<SozlesmeTurleri> SozlesmeTurleris { get; set; } = null!;
        public virtual DbSet<Sozlesmeler> Sozlesmelers { get; set; } = null!;
        public virtual DbSet<UzlasmaKomGorevler> UzlasmaKomGorevlers { get; set; } = null!;
        public virtual DbSet<UzlasmaKomUyeler> UzlasmaKomUyelers { get; set; } = null!;
        public virtual DbSet<UzlasmaKomisyonlar> UzlasmaKomisyonlars { get; set; } = null!;
        public virtual DbSet<VerasetlerOrtakliklar> VerasetlerOrtakliklars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Kamulastirma;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisiler>(entity =>
            {
                entity.HasKey(e => e.KisiId);

                entity.ToTable("Kisiler");

                entity.Property(e => e.KisiId).HasColumnName("KisiID");

                entity.Property(e => e.DogumTarihi).HasColumnType("date");

                entity.Property(e => e.KisiAd).HasMaxLength(50);

                entity.Property(e => e.KisiSoyad).HasMaxLength(50);

                entity.Property(e => e.TckimlikNo).HasColumnName("TCKimlikNo");

                entity.Property(e => e.Telefon).HasMaxLength(50);

                entity.Property(e => e.VefatTarih).HasColumnType("date");
            });

            modelBuilder.Entity<MahkemeDavaKonulari>(entity =>
            {
                entity.HasKey(e => e.DavaKonusuId)
                    .HasName("PK_DavaKonulari");

                entity.ToTable("MahkemeDavaKonulari");

                entity.Property(e => e.DavaKonusuId).HasColumnName("DavaKonusuID");

                entity.Property(e => e.DavaKonusu).HasMaxLength(50);
            });

            modelBuilder.Entity<MahkemeOdemeler>(entity =>
            {
                entity.HasKey(e => e.MahkemeOdemeId);

                entity.ToTable("MahkemeOdemeler");

                entity.Property(e => e.MahkemeOdemeId).HasColumnName("MahkemeOdemeID");

                entity.Property(e => e.OdenenIcraMd).HasMaxLength(50);
            });

            modelBuilder.Entity<Mahkemeler>(entity =>
            {
                entity.HasKey(e => e.MahkemeId);

                entity.ToTable("Mahkemeler");

                entity.Property(e => e.MahkemeId).HasColumnName("MahkemeID");

                entity.Property(e => e.DavaKonusuId).HasColumnName("DavaKonusuID");

                entity.Property(e => e.KisiId).HasColumnName("KisiID");

                entity.Property(e => e.MahkemeOdemeId).HasColumnName("MahkemeOdemeID");

                entity.HasOne(d => d.DavaKonusu)
                    .WithMany(p => p.Mahkemelers)
                    .HasForeignKey(d => d.DavaKonusuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mahkemeler_DavaKonulari");

                entity.HasOne(d => d.Kisi)
                    .WithMany(p => p.Mahkemelers)
                    .HasForeignKey(d => d.KisiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mahkemeler_Kisiler");

                entity.HasOne(d => d.MahkemeOdeme)
                    .WithMany(p => p.Mahkemelers)
                    .HasForeignKey(d => d.MahkemeOdemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mahkemeler_MahkemeOdemeler");
            });

            modelBuilder.Entity<MulkiyetAnaliz>(entity =>
            {
                entity.HasKey(e => e.AnalizId);

                entity.ToTable("MulkiyetAnaliz");

                entity.Property(e => e.GecekonduAdresi).HasMaxLength(50);

                entity.Property(e => e.TakdirBedeli)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TeslimTarihi).HasColumnType("date");

                entity.Property(e => e.YikimTarihi).HasColumnType("date");

                entity.HasOne(d => d.Mulkiyet)
                    .WithMany(p => p.MulkiyetAnalizs)
                    .HasForeignKey(d => d.MulkiyetId)
                    .HasConstraintName("FK_MulkiyetAnaliz_MulkiyetBilgileri");
            });

            modelBuilder.Entity<MulkiyetBilgileri>(entity =>
            {
                entity.HasKey(e => e.MulkiyetId)
                    .HasName("PK_Mulkiyet");

                entity.ToTable("MulkiyetBilgileri");

                entity.Property(e => e.MulkiyetId).HasColumnName("MulkiyetID");

                entity.Property(e => e.BorcPesinTaksit).HasMaxLength(1);

                entity.Property(e => e.BorcluAlacakli).HasMaxLength(50);

                entity.Property(e => e.BorcluSicil).HasMaxLength(50);
            });

            modelBuilder.Entity<MulkiyetKonutIsyeri>(entity =>
            {
                entity.HasKey(e => e.KonutIsyeriId)
                    .HasName("PK_KonutIsyeri_1");

                entity.ToTable("MulkiyetKonutIsyeri");

                entity.Property(e => e.KonutIsyeriId).HasColumnName("KonutIsyeriID");

                entity.Property(e => e.MulkiyetId).HasColumnName("MulkiyetID");

                entity.HasOne(d => d.Mulkiyet)
                    .WithMany(p => p.MulkiyetKonutIsyeris)
                    .HasForeignKey(d => d.MulkiyetId)
                    .HasConstraintName("FK_MulkiyetHisse_MulkiyetBilgileri");
            });

            modelBuilder.Entity<MulkiyetKonutTeslimi>(entity =>
            {
                entity.HasKey(e => e.KonutTeslimiId)
                    .HasName("PK_SozlesmeKonutTeslimi");

                entity.ToTable("MulkiyetKonutTeslimi");

                entity.Property(e => e.KonutTeslimiId).HasColumnName("KonutTeslimiID");

                entity.Property(e => e.AdaParsel).HasMaxLength(50);

                entity.Property(e => e.KiraBaslama).HasColumnType("date");

                entity.Property(e => e.KiraBitirilme).HasColumnType("date");

                entity.Property(e => e.KonutTeslimTarihi).HasColumnType("date");

                entity.Property(e => e.TapuTescilTarihi).HasColumnType("date");

                entity.Property(e => e.TapuYevmiyeTarihi).HasColumnType("date");

                entity.HasOne(d => d.Mulkiyet)
                    .WithMany(p => p.MulkiyetKonutTeslimis)
                    .HasForeignKey(d => d.MulkiyetId)
                    .HasConstraintName("FK_MulkiyetKonutTeslimi_MulkiyetBilgileri");
            });

            modelBuilder.Entity<MulkiyetTasinmazlari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MulkiyetTasinmazlari");

                entity.Property(e => e.Ada)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Etap)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Hisse)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MulkiyetTasinmazId).ValueGeneratedOnAdd();

                entity.Property(e => e.Parsel)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Mulkiyet)
                    .WithMany()
                    .HasForeignKey(d => d.MulkiyetId)
                    .HasConstraintName("FK_MulkiyetTasinmazlari_MulkiyetBilgileri");
            });

            modelBuilder.Entity<SozlesmeDuzeltmeleri>(entity =>
            {
                entity.HasKey(e => e.SozlesmeDuzeltmeId);

                entity.ToTable("SozlesmeDuzeltmeleri");

                entity.Property(e => e.SozlesmeDuzeltmeId).HasColumnName("SozlesmeDuzeltmeID");

                entity.Property(e => e.DuzeltilenSozlesmeTarihi).HasColumnType("date");

                entity.Property(e => e.SozlesmeId).HasColumnName("SozlesmeID");

                entity.Property(e => e.UzlasmaKomTarih).HasColumnType("date");

                entity.HasOne(d => d.Sozlesme)
                    .WithMany(p => p.SozlesmeDuzeltmeleris)
                    .HasForeignKey(d => d.SozlesmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SozlesmeDuzeltmeleri_Sozlesmeler");
            });

            modelBuilder.Entity<SozlesmeIptalleri>(entity =>
            {
                entity.HasKey(e => e.SozlesmeIptalId);

                entity.ToTable("SozlesmeIptalleri");

                entity.Property(e => e.SozlesmeIptalId).HasColumnName("SozlesmeIptalID");

                entity.Property(e => e.SozlesmeId).HasColumnName("SozlesmeID");

                entity.Property(e => e.UzlasmaKomTarih).HasColumnType("date");

                entity.HasOne(d => d.Sozlesme)
                    .WithMany(p => p.SozlesmeIptalleris)
                    .HasForeignKey(d => d.SozlesmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SozlesmeIptalleri_Sozlesmeler");
            });

            modelBuilder.Entity<SozlesmeOnaylari>(entity =>
            {
                entity.HasKey(e => e.SozlesmeOnayiId);

                entity.ToTable("SozlesmeOnaylari");

                entity.Property(e => e.SozlesmeOnayiId).HasColumnName("SozlesmeOnayiID");

                entity.Property(e => e.SozlesmeId).HasColumnName("SozlesmeID");

                entity.Property(e => e.SozlesmeTarihi).HasColumnType("date");

                entity.Property(e => e.TapuFeragTarihi).HasColumnType("date");

                entity.Property(e => e.UzlasmaKomTarih).HasColumnType("date");

                entity.HasOne(d => d.Sozlesme)
                    .WithMany(p => p.SozlesmeOnaylaris)
                    .HasForeignKey(d => d.SozlesmeId)
                    .HasConstraintName("FK_SozlesmeOnaylari_Sozlesmeler");
            });

            modelBuilder.Entity<SozlesmeTurleri>(entity =>
            {
                entity.HasKey(e => e.SozlesmeTuruId);

                entity.ToTable("SozlesmeTurleri");

                entity.Property(e => e.SozlesmeTuruId).HasColumnName("SozlesmeTuruID");

                entity.Property(e => e.SozlesmeTuru).HasMaxLength(50);
            });

            modelBuilder.Entity<Sozlesmeler>(entity =>
            {
                entity.HasKey(e => e.SozlesmeId);

                entity.ToTable("Sozlesmeler");

                entity.Property(e => e.SozlesmeId).HasColumnName("SozlesmeID");

                entity.Property(e => e.KisiId).HasColumnName("KisiID");

                entity.Property(e => e.KonutTeslimiId).HasColumnName("KonutTeslimiID");

                entity.Property(e => e.MulkiyetId).HasColumnName("MulkiyetID");

                entity.Property(e => e.ProjeId).HasColumnName("ProjeID");

                entity.Property(e => e.SozlesmeTuruId).HasColumnName("SozlesmeTuruID");

                entity.HasOne(d => d.Kisi)
                    .WithMany(p => p.Sozlesmelers)
                    .HasForeignKey(d => d.KisiId)
                    .HasConstraintName("FK_Sozlesmeler_Kisiler");

                entity.HasOne(d => d.Mulkiyet)
                    .WithMany(p => p.Sozlesmelers)
                    .HasForeignKey(d => d.MulkiyetId)
                    .HasConstraintName("FK_Sozlesmeler_MulkiyetBilgileri");

                entity.HasOne(d => d.SozlesmeTuru)
                    .WithMany(p => p.Sozlesmelers)
                    .HasForeignKey(d => d.SozlesmeTuruId)
                    .HasConstraintName("FK_Sozlesmeler_SozlesmeTurleri");
            });

            modelBuilder.Entity<UzlasmaKomGorevler>(entity =>
            {
                entity.HasKey(e => e.UzlasmaKomGorevId)
                    .HasName("PK_KomisyonGorevleri");

                entity.ToTable("UzlasmaKomGorevler");

                entity.Property(e => e.UzlasmaKomGorevId).HasColumnName("UzlasmaKomGorevID");

                entity.Property(e => e.KomisyonGorevi).HasMaxLength(50);
            });

            modelBuilder.Entity<UzlasmaKomUyeler>(entity =>
            {
                entity.HasKey(e => e.UzlasmaKomUyeId)
                    .HasName("PK_UzlasmaKomOnaylar");

                entity.ToTable("UzlasmaKomUyeler");

                entity.Property(e => e.UzlasmaKomUyeId).HasColumnName("UzlasmaKomUyeID");

                entity.Property(e => e.Ad).HasMaxLength(50);

                entity.Property(e => e.Soyad).HasMaxLength(50);

                entity.Property(e => e.Unvan).HasMaxLength(50);

                entity.HasOne(d => d.UzlasmaKomGorev)
                    .WithMany(p => p.UzlasmaKomUyelers)
                    .HasForeignKey(d => d.UzlasmaKomGorevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UzlasmaKomUyeler_UzlasmaKomGorevler");
            });

            modelBuilder.Entity<UzlasmaKomisyonlar>(entity =>
            {
                entity.HasKey(e => e.UzlasmaKomisyonId);

                entity.ToTable("UzlasmaKomisyonlar");

                entity.Property(e => e.KomisyonDurumu)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.UzlasmaKomUye)
                    .WithMany(p => p.UzlasmaKomisyonlars)
                    .HasForeignKey(d => d.UzlasmaKomUyeId)
                    .HasConstraintName("FK_UzlasmaKomisyonlar_UzlasmaKomUyeler");
            });

            modelBuilder.Entity<VerasetlerOrtakliklar>(entity =>
            {
                entity.HasKey(e => e.VerasetOrtaklikId)
                    .HasName("PK_VerasetOrtaklik");

                entity.ToTable("VerasetlerOrtakliklar");

                entity.Property(e => e.VerasetOrtaklikId).HasColumnName("VerasetOrtaklikID");

                entity.Property(e => e.KisiId).HasColumnName("KisiID");

                entity.Property(e => e.VarisOrtakId).HasColumnName("VarisOrtakID");

                entity.Property(e => e.VerasetOrtaklik)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kisi)
                    .WithMany(p => p.VerasetlerOrtakliklarKisis)
                    .HasForeignKey(d => d.KisiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VerasetlerOrtakliklar_Kisiler");

                entity.HasOne(d => d.VarisOrtak)
                    .WithMany(p => p.VerasetlerOrtakliklarVarisOrtaks)
                    .HasForeignKey(d => d.VarisOrtakId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VerasetlerOrtakliklar_Kisiler_Varis");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
