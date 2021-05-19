﻿// <auto-generated />
using Clinica.AtencionPaciente.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinica.AtencionPaciente.Infrastructure.Migrations
{
    [DbContext(typeof(AtencionContext))]
    [Migration("20210518143921_ClinicaMigration1")]
    partial class ClinicaMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clinica.AtencionPaciente.Domain.Entities.ConsultaClinica", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CantidadPacientes")
                        .HasColumnType("int");

                    b.Property<string>("EspecialistaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("TipoConsulta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EspecialistaId")
                        .IsUnique()
                        .HasFilter("[EspecialistaId] IS NOT NULL");

                    b.ToTable("ConsultasClinicas");
                });

            modelBuilder.Entity("Clinica.AtencionPaciente.Domain.Entities.Especialista", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Especialistas");
                });

            modelBuilder.Entity("Clinica.AtencionPaciente.Domain.Entities.Hospital", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConsultasClinicasId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PacientesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Sala")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultasClinicasId");

                    b.HasIndex("PacientesId");

                    b.ToTable("Hospitales");
                });

            modelBuilder.Entity("Clinica.AtencionPaciente.Domain.Entities.Paciente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroHistoriasClinico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prioridad")
                        .HasColumnType("float");

                    b.Property<double>("Riesgo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Paciente");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Paciente");
                });

            modelBuilder.Entity("Clinica.AtencionPaciente.Domain.Entities.Anciano", b =>
                {
                    b.HasBaseType("Clinica.AtencionPaciente.Domain.Entities.Paciente");

                    b.Property<bool>("TieneDieta")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Anciano");
                });

            modelBuilder.Entity("Clinica.AtencionPaciente.Domain.Entities.Joven", b =>
                {
                    b.HasBaseType("Clinica.AtencionPaciente.Domain.Entities.Paciente");

                    b.Property<int>("AnnosFumando")
                        .HasColumnType("int");

                    b.Property<bool>("EsFumador")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Joven");
                });

            modelBuilder.Entity("Clinica.AtencionPaciente.Domain.Entities.Ninno", b =>
                {
                    b.HasBaseType("Clinica.AtencionPaciente.Domain.Entities.Paciente");

                    b.Property<int>("RelacionPesoEstatura")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Ninno");
                });

            modelBuilder.Entity("Clinica.AtencionPaciente.Domain.Entities.ConsultaClinica", b =>
                {
                    b.HasOne("Clinica.AtencionPaciente.Domain.Entities.Especialista", "Especialista")
                        .WithOne("ConsultaClinica")
                        .HasForeignKey("Clinica.AtencionPaciente.Domain.Entities.ConsultaClinica", "EspecialistaId");
                });

            modelBuilder.Entity("Clinica.AtencionPaciente.Domain.Entities.Hospital", b =>
                {
                    b.HasOne("Clinica.AtencionPaciente.Domain.Entities.ConsultaClinica", "ConsultasClinicas")
                        .WithMany("hospital")
                        .HasForeignKey("ConsultasClinicasId");

                    b.HasOne("Clinica.AtencionPaciente.Domain.Entities.Paciente", "Pacientes")
                        .WithMany("Hospital")
                        .HasForeignKey("PacientesId");
                });
#pragma warning restore 612, 618
        }
    }
}
