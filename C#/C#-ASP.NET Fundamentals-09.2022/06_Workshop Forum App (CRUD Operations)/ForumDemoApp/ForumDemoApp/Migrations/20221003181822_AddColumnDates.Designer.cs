﻿// <auto-generated />
using ForumDemoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumDemoApp.Migrations
{
    [DbContext(typeof(ForumDemoAppDbContext))]
    [Migration("20221003181822_AddColumnDates")]
    partial class AddColumnDates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ForumDemoApp.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Post id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasComment("Post content");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Post create on");

                    b.Property<string>("DeletedDate")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Post deleted on");

                    b.Property<string>("EditedDate")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Post last edited on");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Post is deleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Post title");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasComment("Post");
                });
#pragma warning restore 612, 618
        }
    }
}
