﻿// <auto-generated />
using Fantasy_server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fantasy_server.Migrations
{
    [DbContext(typeof(FantasyContext))]
    [Migration("20190516020325_Etapa_devedor_add")]
    partial class Etapa_devedor_add
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
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

                    b.Property<int>("ano");

                    b.Property<int>("fk_etapa");

                    b.Property<int>("fk_participante");

                    b.Property<double>("nota");

                    b.HasKey("id");

                    b.HasIndex("fk_etapa");

                    b.HasIndex("fk_participante");

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
                        .HasForeignKey("fk_etapa")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy_server.Models.Participante", "Participante")
                        .WithMany()
                        .HasForeignKey("fk_participante")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
