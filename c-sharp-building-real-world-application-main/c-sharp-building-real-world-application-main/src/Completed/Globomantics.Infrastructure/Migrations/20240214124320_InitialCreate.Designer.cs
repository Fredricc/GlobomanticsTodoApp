﻿// <auto-generated />
using System;
using Globomantics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Globomantics.Infrastructure.Migrations
{
    [DbContext(typeof(GlobomanticsDbContext))]
    [Migration("20240214124320_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BugId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BugId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ParentId");

                    b.ToTable("Todo");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Todo");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.TodoTask", b =>
                {
                    b.HasBaseType("Globomantics.Infrastructure.Data.Models.Todo");

                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("TodoTask");
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.Bug", b =>
                {
                    b.HasBaseType("Globomantics.Infrastructure.Data.Models.TodoTask");

                    b.Property<int>("AffectedUsers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AffectedVersion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AssigedToId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Severity")
                        .HasColumnType("INTEGER");

                    b.HasIndex("AssigedToId");

                    b.ToTable("Todo", t =>
                        {
                            t.Property("AssigedToId")
                                .HasColumnName("Bug_AssigedToId");

                            t.Property("Description")
                                .HasColumnName("Bug_Description");
                        });

                    b.HasDiscriminator().HasValue("Bug");
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.Feature", b =>
                {
                    b.HasBaseType("Globomantics.Infrastructure.Data.Models.TodoTask");

                    b.Property<Guid>("AssigedToId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Component")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.HasIndex("AssigedToId");

                    b.HasDiscriminator().HasValue("Feature");
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.Image", b =>
                {
                    b.HasOne("Globomantics.Infrastructure.Data.Models.Bug", null)
                        .WithMany("Images")
                        .HasForeignKey("BugId");
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.Todo", b =>
                {
                    b.HasOne("Globomantics.Infrastructure.Data.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Globomantics.Infrastructure.Data.Models.Todo", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("CreatedBy");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.Bug", b =>
                {
                    b.HasOne("Globomantics.Infrastructure.Data.Models.User", "AssigedTo")
                        .WithMany()
                        .HasForeignKey("AssigedToId");

                    b.Navigation("AssigedTo");
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.Feature", b =>
                {
                    b.HasOne("Globomantics.Infrastructure.Data.Models.User", "AssigedTo")
                        .WithMany()
                        .HasForeignKey("AssigedToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssigedTo");
                });

            modelBuilder.Entity("Globomantics.Infrastructure.Data.Models.Bug", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
