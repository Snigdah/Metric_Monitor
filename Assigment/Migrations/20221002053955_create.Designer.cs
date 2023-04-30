﻿// <auto-generated />
using Assigment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Assigment.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221002053955_create")]
    partial class create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Assigment.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MetricId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MetricId");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("Assigment.Models.Metric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("MatricName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Metrics");
                });

            modelBuilder.Entity("Assigment.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MetricId")
                        .HasColumnType("integer");

                    b.Property<int>("Time")
                        .HasColumnType("integer");

                    b.Property<int>("Val")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MetricId");

                    b.ToTable("Value");
                });

            modelBuilder.Entity("Assigment.Models.Label", b =>
                {
                    b.HasOne("Assigment.Models.Metric", "Metric")
                        .WithMany("Labels")
                        .HasForeignKey("MetricId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Metric");
                });

            modelBuilder.Entity("Assigment.Models.Value", b =>
                {
                    b.HasOne("Assigment.Models.Metric", "Metric")
                        .WithMany("Values")
                        .HasForeignKey("MetricId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Metric");
                });

            modelBuilder.Entity("Assigment.Models.Metric", b =>
                {
                    b.Navigation("Labels");

                    b.Navigation("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
