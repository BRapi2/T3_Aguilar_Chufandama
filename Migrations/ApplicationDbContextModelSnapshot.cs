using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using T3_Aguilar_Chufandama.Data;

#nullable disable

namespace T3_Aguilar_Chufandama.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("T3_Aguilar_Chufandama.Models.Libro", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("AnioPublicacion")
                    .HasColumnType("int");

                b.Property<string>("Autor")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Categoria")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Editorial")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Material")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Paginas")
                    .HasColumnType("int");

                b.Property<int>("Copias")
                    .HasColumnType("int");

                b.Property<string>("Tema")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Titulo")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Libros");
            });
        }
    }
}
