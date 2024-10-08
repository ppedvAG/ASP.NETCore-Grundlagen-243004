﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStoreApp.Data;

#nullable disable

namespace MovieStore.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20241009090137_InitMovies")]
    partial class InitMovies
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieStoreApp.Models.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<double>("IMDBRating")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                            Genre = 5,
                            IMDBRating = 8.5,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg",
                            Price = 13.99m,
                            Title = "The Shawshank Redemption"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                            Genre = 5,
                            IMDBRating = 7.5999999999999996,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg",
                            Price = 19.99m,
                            Title = "The Godfather"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids.",
                            Genre = 1,
                            IMDBRating = 9.0,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Jurassic_Park_Poster.jpg",
                            Price = 12.99m,
                            Title = "Jurassic Park"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
