﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TangoRoom.Server.Models.Data;

#nullable disable

namespace TangoRoom.Server.Models.Data.Migrations
{
    [DbContext(typeof(ContextTangoRoom))]
    [Migration("20241221231427_CreationBase")]
    partial class CreationBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarathonUtilisateur", b =>
                {
                    b.Property<int>("IdMarathon")
                        .HasColumnType("int");

                    b.Property<int>("IdUtilisateur")
                        .HasColumnType("int");

                    b.HasKey("IdMarathon", "IdUtilisateur");

                    b.HasIndex("IdUtilisateur");

                    b.ToTable("PlanningAnnuel", (string)null);
                });

            modelBuilder.Entity("TangoRoom.Server.Models.Inscription", b =>
                {
                    b.Property<int>("IdLeader")
                        .HasColumnType("int");

                    b.Property<int>("IdFollower")
                        .HasColumnType("int");

                    b.Property<int>("IdMarathon")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMatchUp")
                        .HasColumnType("datetime2");

                    b.HasKey("IdLeader", "IdFollower", "IdMarathon");

                    b.HasIndex("IdFollower");

                    b.HasIndex("IdMarathon");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("TangoRoom.Server.Models.Marathon", b =>
                {
                    b.Property<int>("IdMarathon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMarathon"));

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinInscription")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StatutMarathon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("IdMarathon");

                    b.ToTable("Marathons", t =>
                        {
                            t.HasCheckConstraint("CK_MarathonEndRegister", "( DateFinInscription<=DATEADD(m,-15,DateDebut))");

                            t.HasCheckConstraint("CK_MarathonStatus", "StatutMarathon IN ('disponible', 'clos')");

                            t.HasCheckConstraint("CK_MarathonValidity", "(DateDebut <= GETDATE())");
                        });
                });

            modelBuilder.Entity("TangoRoom.Server.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRole"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdRole");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TangoRoom.Server.Models.Utilisateur", b =>
                {
                    b.Property<int>("IdUtilisateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUtilisateur"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("StatutPersonnel")
                        .HasColumnType("int");

                    b.Property<bool>("ValideInscription")
                        .HasColumnType("bit");

                    b.HasKey("IdUtilisateur");

                    b.HasIndex("IdRole");

                    b.ToTable("Utilisateurs");

                    b.HasDiscriminator().HasValue("Utilisateur");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TangoRoom.Server.Models.Follower", b =>
                {
                    b.HasBaseType("TangoRoom.Server.Models.Utilisateur");

                    b.Property<string>("TextInvitation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Follower");
                });

            modelBuilder.Entity("TangoRoom.Server.Models.Leader", b =>
                {
                    b.HasBaseType("TangoRoom.Server.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("Leader");
                });

            modelBuilder.Entity("MarathonUtilisateur", b =>
                {
                    b.HasOne("TangoRoom.Server.Models.Marathon", null)
                        .WithMany()
                        .HasForeignKey("IdMarathon")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TangoRoom.Server.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("IdUtilisateur")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TangoRoom.Server.Models.Inscription", b =>
                {
                    b.HasOne("TangoRoom.Server.Models.Follower", null)
                        .WithMany()
                        .HasForeignKey("IdFollower")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TangoRoom.Server.Models.Leader", null)
                        .WithMany()
                        .HasForeignKey("IdLeader")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TangoRoom.Server.Models.Marathon", null)
                        .WithMany()
                        .HasForeignKey("IdMarathon")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TangoRoom.Server.Models.Utilisateur", b =>
                {
                    b.HasOne("TangoRoom.Server.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
