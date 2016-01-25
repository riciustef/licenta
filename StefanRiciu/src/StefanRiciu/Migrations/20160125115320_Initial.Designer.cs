using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using StefanRiciu.Models;

namespace StefanRiciu.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160125115320_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("StefanRiciu.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("StefanRiciu.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.HasKey("CategorieID");
                });

            modelBuilder.Entity("StefanRiciu.Models.Pagina", b =>
                {
                    b.Property<int>("PaginaID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Activa");

                    b.Property<string>("Continut")
                        .IsRequired();

                    b.Property<DateTime>("DataInregistrare");

                    b.Property<string>("Descriere")
                        .IsRequired();

                    b.Property<string>("Imagine");

                    b.Property<string>("Titlu")
                        .IsRequired();

                    b.Property<string>("Video");

                    b.HasKey("PaginaID");
                });

            modelBuilder.Entity("StefanRiciu.Models.Sponsor", b =>
                {
                    b.Property<int>("SponsorID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataInregistrare");

                    b.Property<string>("Logo")
                        .IsRequired();

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<int>("SponsorTypeID");

                    b.Property<string>("URL")
                        .IsRequired();

                    b.HasKey("SponsorID");
                });

            modelBuilder.Entity("StefanRiciu.Models.SponsorType", b =>
                {
                    b.Property<int>("SponsorTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.HasKey("SponsorTypeID");
                });

            modelBuilder.Entity("StefanRiciu.Models.Sportiv", b =>
                {
                    b.Property<int>("SportivID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategorieID");

                    b.Property<string>("Club");

                    b.Property<bool>("Confirmat");

                    b.Property<DateTime>("DataDeNastere");

                    b.Property<DateTime>("DataInregistrare");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Localitate");

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<string>("Observatii");

                    b.Property<string>("Prenume")
                        .IsRequired();

                    b.Property<string>("Telefon")
                        .IsRequired();

                    b.Property<int>("TraseuID");

                    b.HasKey("SportivID");
                });

            modelBuilder.Entity("StefanRiciu.Models.Traseu", b =>
                {
                    b.Property<int>("TraseuID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Denumire")
                        .IsRequired();

                    b.HasKey("TraseuID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StefanRiciu.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StefanRiciu.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("StefanRiciu.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("StefanRiciu.Models.Sponsor", b =>
                {
                    b.HasOne("StefanRiciu.Models.SponsorType")
                        .WithMany()
                        .HasForeignKey("SponsorTypeID");
                });

            modelBuilder.Entity("StefanRiciu.Models.Sportiv", b =>
                {
                    b.HasOne("StefanRiciu.Models.Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieID");

                    b.HasOne("StefanRiciu.Models.Traseu")
                        .WithMany()
                        .HasForeignKey("TraseuID");
                });
        }
    }
}
