﻿// <auto-generated />
using Livraria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Livraria.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241127203819_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Livraria.Models.Assunto", b =>
                {
                    b.Property<int>("CodAs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodAs"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodAs");

                    b.ToTable("Assunto");
                });

            modelBuilder.Entity("Livraria.Models.Autor", b =>
                {
                    b.Property<int>("CodAu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodAu"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodAu");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("Livraria.Models.Livro", b =>
                {
                    b.Property<int>("Codl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codl"));

                    b.Property<string>("AnoPublicacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AssuntoCodAs")
                        .HasColumnType("int");

                    b.Property<int?>("AutorCodAu")
                        .HasColumnType("int");

                    b.Property<int>("Edicao")
                        .HasColumnType("int");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Codl");

                    b.HasIndex("AssuntoCodAs");

                    b.HasIndex("AutorCodAu");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("Livraria.Models.LivroAssunto", b =>
                {
                    b.Property<int>("Livro_Codl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Livro_Codl"));

                    b.Property<int>("AssuntoCodAs")
                        .HasColumnType("int");

                    b.Property<int>("Assunto_CodAs")
                        .HasColumnType("int");

                    b.Property<int>("LivroCodl")
                        .HasColumnType("int");

                    b.HasKey("Livro_Codl");

                    b.HasIndex("AssuntoCodAs");

                    b.HasIndex("LivroCodl");

                    b.ToTable("Livro_Assunto");
                });

            modelBuilder.Entity("Livraria.Models.LivroAutor", b =>
                {
                    b.Property<int>("Livro_Codl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Livro_Codl"));

                    b.Property<int>("AutorCodAu")
                        .HasColumnType("int");

                    b.Property<int>("Autor_CodAu")
                        .HasColumnType("int");

                    b.Property<int>("LivroCodl")
                        .HasColumnType("int");

                    b.HasKey("Livro_Codl");

                    b.HasIndex("AutorCodAu");

                    b.HasIndex("LivroCodl");

                    b.ToTable("Livro_Autor");
                });

            modelBuilder.Entity("Livraria.Models.RelatorioLivro", b =>
                {
                    b.Property<string>("AnoPublicacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Livro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("VWRELATORIOLIVROS", (string)null);
                });

            modelBuilder.Entity("Livraria.Models.Livro", b =>
                {
                    b.HasOne("Livraria.Models.Assunto", null)
                        .WithMany("Livros")
                        .HasForeignKey("AssuntoCodAs");

                    b.HasOne("Livraria.Models.Autor", null)
                        .WithMany("Livros")
                        .HasForeignKey("AutorCodAu");
                });

            modelBuilder.Entity("Livraria.Models.LivroAssunto", b =>
                {
                    b.HasOne("Livraria.Models.Assunto", "Assunto")
                        .WithMany("Livro_Assunto")
                        .HasForeignKey("AssuntoCodAs")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livraria.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroCodl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assunto");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Livraria.Models.LivroAutor", b =>
                {
                    b.HasOne("Livraria.Models.Autor", "Autor")
                        .WithMany("Livro_Autor")
                        .HasForeignKey("AutorCodAu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livraria.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroCodl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Livraria.Models.Assunto", b =>
                {
                    b.Navigation("Livro_Assunto");

                    b.Navigation("Livros");
                });

            modelBuilder.Entity("Livraria.Models.Autor", b =>
                {
                    b.Navigation("Livro_Autor");

                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
