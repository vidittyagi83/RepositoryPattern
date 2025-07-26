using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeesSalary> EmployeesSalaries { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=.;Database=test;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Candidate>(entity =>
        {
            _ = entity.HasKey(e => e.CandidateId).HasName("PK__Candidat__DF539B9CB4AF4209");

            _ = entity.ToTable("Candidate");

            _ = entity.Property(e => e.CandidateId).ValueGeneratedOnAdd();
            _ = entity.Property(e => e.FullName).HasMaxLength(50);

            _ = entity.HasOne(d => d.Company).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Candidate__Compa__5EBF139D");
        });

        _ = modelBuilder.Entity<Category>(entity =>
        {
            _ = entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0744FB1378");

            _ = entity.Property(e => e.Name).HasMaxLength(255);
        });

        _ = modelBuilder.Entity<Company>(entity =>
        {
            _ = entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC0C778B5E");

            _ = entity.ToTable("Company");

            _ = entity.Property(e => e.CompanyId).ValueGeneratedOnAdd();
            _ = entity.Property(e => e.CompanyName).HasMaxLength(50);
        });

        _ = modelBuilder.Entity<Employee>(entity =>
        {
            _ = entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF110703149");

            _ = entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            _ = entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            _ = entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            _ = entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
        });

        _ = modelBuilder.Entity<EmployeesSalary>(entity =>
        {
            _ = entity
                .HasNoKey()
                .ToTable("EmployeesSalary");
        });

        _ = modelBuilder.Entity<Product>(entity =>
        {
            _ = entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07396BA499");

            _ = entity.Property(e => e.Name).HasMaxLength(255);
            _ = entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        _ = modelBuilder.Entity<ProductCategory>(entity =>
        {
            _ = entity.HasKey(e => e.Id).HasName("PK__ProductC__3214EC071BA469C5");

            _ = entity.Property(e => e.Name).HasMaxLength(255);
            _ = entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            _ = entity.HasOne(d => d.Category).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Categories");
        });

        _ = modelBuilder.Entity<TblEmployee>(entity =>
        {
            _ = entity.HasKey(e => e.Id).HasName("PK__tblEmplo__3214EC07104713FF");

            _ = entity.ToTable("tblEmployee");

            _ = entity.HasIndex(e => e.DepartmentId, "NCL_ID");

            _ = entity.Property(e => e.Id).ValueGeneratedNever();
            _ = entity.Property(e => e.Gender).HasMaxLength(10);
            _ = entity.Property(e => e.Name).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
