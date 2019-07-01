﻿// <auto-generated />
using System;
using FantasyServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fantasy_server.Migrations
{
    [DbContext(typeof(FantasyContext))]
    [Migration("20190505033244_Etapaid")]
    partial class Etapaid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Fantasy_server.Models.Etapa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nome");

                    b.HasKey("id");

                    b.ToTable("etapa","develop");
                });

            modelBuilder.Entity("Fantasy_server.Models.EtapaParticipante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Editalid");

                    b.Property<int?>("Etapaid");

                    b.Property<int?>("Participanteid");

                    b.Property<int>("ano");

                    b.Property<int>("fk_etapa");

                    b.Property<int>("fk_participante");

                    b.Property<double>("nota");

                    b.HasKey("id");

                    b.HasIndex("Etapaid");

                    b.HasIndex("Participanteid");

                    b.ToTable("etapaparticipante","develop");
                });

            modelBuilder.Entity("Fantasy_server.Models.Participante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("nome");

                    b.HasKey("id");

                    b.ToTable("participante","develop");
                });

            modelBuilder.Entity("Fantasy_server.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("fkparticipante");

                    b.Property<string>("nome");

                    b.Property<string>("senha");

                    b.HasKey("id");

                    b.ToTable("acessuser","develop");
                });

            modelBuilder.Entity("Fantasy_server.Models.EtapaParticipante", b =>
                {
                    b.HasOne("Fantasy_server.Models.Etapa", "Etapa")
                        .WithMany()
                        .HasForeignKey("Etapaid");

                    b.HasOne("Fantasy_server.Models.Participante", "Participante")
                        .WithMany()
                        .HasForeignKey("Participanteid");
                });
#pragma warning restore 612, 618
        }
    }
}
