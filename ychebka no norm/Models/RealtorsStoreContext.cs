using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ychebka_no_norm.Models;

public partial class RealtorsStoreContext : DbContext
{
    public RealtorsStoreContext()
    {
    }

    public RealtorsStoreContext(DbContextOptions<RealtorsStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<ApartmentsNeed> ApartmentsNeeds { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Deal> Deals { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Estate> Estates { get; set; }

    public virtual DbSet<EstateApartment> EstateApartments { get; set; }

    public virtual DbSet<EstateHouse> EstateHouses { get; set; }

    public virtual DbSet<EstateLand> EstateLands { get; set; }

    public virtual DbSet<HouseNeed> HouseNeeds { get; set; }

    public virtual DbSet<LandsNeed> LandsNeeds { get; set; }

    public virtual DbSet<Need> Needs { get; set; }

    public virtual DbSet<Realtor> Realtors { get; set; }

    public virtual DbSet<Suggestion> Suggestions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=RealtorsStore;Trusted_Connection=true;", x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3213E83F8AAEE6F9");

            entity.ToTable("Address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.House)
                .HasMaxLength(50)
                .HasColumnName("house");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .HasColumnName("number");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");
        });

        modelBuilder.Entity<ApartmentsNeed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Apartmen__3213E83F3781F8E4");

            entity.ToTable("ApartmentsNeed");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MaxFloor).HasColumnName("max_floor");
            entity.Property(e => e.MaxRoomsCount).HasColumnName("max_rooms_count");
            entity.Property(e => e.MaxSquare).HasColumnName("max_square");
            entity.Property(e => e.MinFloor).HasColumnName("min_floor");
            entity.Property(e => e.MinRoomsCount).HasColumnName("min_rooms_count");
            entity.Property(e => e.MinSquare).HasColumnName("min_square");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3213E83F4B944A2B");

            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => new { e.Suggestion, e.Need }).HasName("DealPK");

            entity.ToTable("Deal");

            entity.Property(e => e.Suggestion).HasColumnName("suggestion");
            entity.Property(e => e.Need).HasColumnName("need");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.NeedNavigation).WithMany(p => p.Deals)
                .HasForeignKey(d => d.Need)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DealNeedFK");

            entity.HasOne(d => d.SuggestionNavigation).WithMany(p => p.Deals)
                .HasForeignKey(d => d.Suggestion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DealSuggestionFK");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__District__72E12F1A5DA79D57");

            entity.ToTable("District");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
      
        });

        modelBuilder.Entity<Estate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estate__3213E83FF8A38D7C");

            entity.ToTable("Estate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasColumnName("district");
            entity.Property(e => e.EstateType)
                .HasMaxLength(20)
                .HasColumnName("estate_type");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Estates)
                .HasForeignKey(d => d.Address)
                .HasConstraintName("EstateAddressFK");

            entity.HasOne(d => d.DistrictNavigation).WithMany(p => p.Estates)
                .HasForeignKey(d => d.District)
                .HasConstraintName("EstateDistrictFK");
        });

        modelBuilder.Entity<EstateApartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstateAp__3213E83F1BDB7D62");

            entity.ToTable("EstateApartment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.RoomsCount).HasColumnName("rooms_count");
            entity.Property(e => e.Square).HasColumnName("square");
        });

        modelBuilder.Entity<EstateHouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstateHo__3213E83FDCC567C1");

            entity.ToTable("EstateHouse");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FloorsCount).HasColumnName("floors_count");
            entity.Property(e => e.RoomsCount).HasColumnName("rooms_count");
            entity.Property(e => e.Square).HasColumnName("square");
        });

        modelBuilder.Entity<EstateLand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstateLa__3213E83F0B127B4F");

            entity.ToTable("EstateLand");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Square).HasColumnName("square");
        });

        modelBuilder.Entity<HouseNeed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HouseNee__3213E83F3CF83048");

            entity.ToTable("HouseNeed");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MaxFloorsCount).HasColumnName("max_floors_count");
            entity.Property(e => e.MaxRoomsCount).HasColumnName("max_rooms_count");
            entity.Property(e => e.MaxSquare).HasColumnName("max_square");
            entity.Property(e => e.MinFloorsCount).HasColumnName("min_floors_count");
            entity.Property(e => e.MinRoomsCount).HasColumnName("min_rooms_count");
            entity.Property(e => e.MinSquare).HasColumnName("min_square");
        });

        modelBuilder.Entity<LandsNeed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LandsNee__3213E83FE4A8CF5E");

            entity.ToTable("LandsNeed");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MaxSquare).HasColumnName("max_square");
            entity.Property(e => e.MinSquare).HasColumnName("min_square");
        });

        modelBuilder.Entity<Need>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Need__3213E83FF674E226");

            entity.ToTable("Need");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Client).HasColumnName("client");
            entity.Property(e => e.EstateType)
                .HasMaxLength(20)
                .HasColumnName("estate_type");
            entity.Property(e => e.MaxPrice)
                .HasColumnType("money")
                .HasColumnName("max_price");
            entity.Property(e => e.MinPrice)
                .HasColumnType("money")
                .HasColumnName("min_price");
            entity.Property(e => e.Realtor).HasColumnName("realtor");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Needs)
                .HasForeignKey(d => d.Address)
                .HasConstraintName("NeedAddressFK");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Needs)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("NeedClientFK");

            entity.HasOne(d => d.RealtorNavigation).WithMany(p => p.Needs)
                .HasForeignKey(d => d.Realtor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("NeedRealtorFK");
        });

        modelBuilder.Entity<Realtor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Realtor__3213E83F17FDBDAB");

            entity.ToTable("Realtor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comission).HasColumnName("comission");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
        });

        modelBuilder.Entity<Suggestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Suggesti__3213E83F1DA1E861");

            entity.ToTable("Suggestion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Client).HasColumnName("client");
            entity.Property(e => e.Estate).HasColumnName("estate");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Realtor).HasColumnName("realtor");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Suggestions)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SuggestionClientFK");

            entity.HasOne(d => d.EstateNavigation).WithMany(p => p.Suggestions)
                .HasForeignKey(d => d.Estate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SuggestionEstateFK");

            entity.HasOne(d => d.RealtorNavigation).WithMany(p => p.Suggestions)
                .HasForeignKey(d => d.Realtor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SuggestionRealtorFK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
