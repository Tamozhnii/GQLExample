﻿// <auto-generated />
using GQLExample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GQLExample.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210830205036_AddBrightnessSaturationAndColorToDb")]
    partial class AddBrightnessSaturationAndColorToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("ColorShade", b =>
                {
                    b.Property<int>("ColorsId")
                        .HasColumnType("int");

                    b.Property<int>("ShadesId")
                        .HasColumnType("int");

                    b.HasKey("ColorsId", "ShadesId");

                    b.HasIndex("ShadesId");

                    b.ToTable("ColorShade");
                });

            modelBuilder.Entity("GQLExample.Models.Brightness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LocalValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Brightnesses");
                });

            modelBuilder.Entity("GQLExample.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Association")
                        .HasColumnType("text");

                    b.Property<int>("BrightnessId")
                        .HasColumnType("int");

                    b.Property<string>("HEX")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SaturationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrightnessId");

                    b.HasIndex("SaturationId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("GQLExample.Models.Saturation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LocalValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Saturations");
                });

            modelBuilder.Entity("GQLExample.Models.Shade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HEX")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LocalName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shades");
                });

            modelBuilder.Entity("ColorShade", b =>
                {
                    b.HasOne("GQLExample.Models.Color", null)
                        .WithMany()
                        .HasForeignKey("ColorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GQLExample.Models.Shade", null)
                        .WithMany()
                        .HasForeignKey("ShadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GQLExample.Models.Color", b =>
                {
                    b.HasOne("GQLExample.Models.Brightness", "Brightness")
                        .WithMany("Colors")
                        .HasForeignKey("BrightnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GQLExample.Models.Saturation", "Saturation")
                        .WithMany("Colors")
                        .HasForeignKey("SaturationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brightness");

                    b.Navigation("Saturation");
                });

            modelBuilder.Entity("GQLExample.Models.Brightness", b =>
                {
                    b.Navigation("Colors");
                });

            modelBuilder.Entity("GQLExample.Models.Saturation", b =>
                {
                    b.Navigation("Colors");
                });
#pragma warning restore 612, 618
        }
    }
}