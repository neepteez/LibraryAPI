using LibraryAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace LibraryAPI.Infrastructure.Migrations;

[DbContext(typeof(AppDbContext))]
partial class AppDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

        modelBuilder.Entity("LibraryAPI.Domain.Entities.Author", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
            b.Property<string>("Bio").HasColumnType("TEXT");
            b.Property<string>("Name").IsRequired().HasMaxLength(200).HasColumnType("TEXT");
            b.HasKey("Id");
            b.ToTable("Authors");
        });

        modelBuilder.Entity("LibraryAPI.Domain.Entities.Book", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
            b.Property<int>("AuthorId").HasColumnType("INTEGER");
            b.Property<string>("Description").HasColumnType("TEXT");
            b.Property<string>("Title").IsRequired().HasMaxLength(300).HasColumnType("TEXT");
            b.Property<int>("Year").HasColumnType("INTEGER");
            b.HasKey("Id");
            b.HasIndex("AuthorId");
            b.ToTable("Books");
        });

        modelBuilder.Entity("LibraryAPI.Domain.Entities.Book", b =>
        {
            b.HasOne("LibraryAPI.Domain.Entities.Author", "Author")
                .WithMany("Books")
                .HasForeignKey("AuthorId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            b.Navigation("Author");
        });

        modelBuilder.Entity("LibraryAPI.Domain.Entities.Author", b =>
        {
            b.Navigation("Books");
        });
#pragma warning restore 612, 618
    }
}
