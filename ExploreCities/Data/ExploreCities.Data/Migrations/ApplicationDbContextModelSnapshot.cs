﻿// <auto-generated />
using System;
using ExploreCities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExploreCities.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExploreCities.Data.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Discussions.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddedByUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiscussionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegionViewId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("RegionViewId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Discussions.Discussion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RegionViewId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("RegionViewId");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.CityHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddedByUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MaterialLinks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("CityId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("CityHistories");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.Picture", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityHistoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ObjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegionViewId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CityHistoryId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ObjectId");

                    b.HasIndex("RegionViewId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.Region", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.RegionObject", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ObjectType")
                        .HasColumnType("int");

                    b.Property<string>("Opinion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("RegionViewId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("RegionViewId");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.RegionView", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddedByUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AirPollution")
                        .HasColumnType("int");

                    b.Property<int>("ArrivalYear")
                        .HasColumnType("int");

                    b.Property<int>("BikeArea")
                        .HasColumnType("int");

                    b.Property<double>("BusStationDistance")
                        .HasColumnType("float");

                    b.Property<int>("ChildrenPlaygrounds")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartureYear")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("MetroStationDistance")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Noise")
                        .HasColumnType("int");

                    b.Property<int>("ParkingSpaces")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicTransport")
                        .HasColumnType("int");

                    b.Property<string>("RegionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RegionLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetLighting")
                        .HasColumnType("int");

                    b.Property<int>("StreetPollution")
                        .HasColumnType("int");

                    b.Property<int>("StreetQuality")
                        .HasColumnType("int");

                    b.Property<double>("TrainStationDistance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("RegionId");

                    b.ToTable("RegionViews");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.UserCity", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "CityId");

                    b.HasIndex("CityId");

                    b.ToTable("UserCities");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.UserDiscussion", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiscussionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "DiscussionId");

                    b.HasIndex("DiscussionId");

                    b.ToTable("UserDiscussions");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.UserRegion", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RegionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RegionId");

                    b.HasIndex("RegionId");

                    b.ToTable("UserRegions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.ApplicationUser", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.Location.City", null)
                        .WithMany("Users")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Discussions.Comment", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExploreCities.Data.Models.Discussions.Discussion", null)
                        .WithMany("Comments")
                        .HasForeignKey("DiscussionId");

                    b.HasOne("ExploreCities.Data.Models.Location.RegionView", "Region")
                        .WithMany()
                        .HasForeignKey("RegionViewId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AddedByUser");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Discussions.Discussion", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.Location.RegionView", null)
                        .WithMany("Discussions")
                        .HasForeignKey("RegionViewId");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.CityHistory", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExploreCities.Data.Models.Location.City", "City")
                        .WithMany("Histories")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AddedByUser");

                    b.Navigation("City");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.Picture", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.Location.CityHistory", null)
                        .WithMany("Picture")
                        .HasForeignKey("CityHistoryId");

                    b.HasOne("ExploreCities.Data.Models.Location.RegionObject", "Object")
                        .WithMany("Pictures")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExploreCities.Data.Models.Location.RegionView", null)
                        .WithMany("Pictures")
                        .HasForeignKey("RegionViewId");

                    b.Navigation("Object");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.Region", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.Location.City", "City")
                        .WithMany("Regions")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.RegionObject", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.Location.RegionView", "Region")
                        .WithMany("Objects")
                        .HasForeignKey("RegionViewId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.RegionView", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExploreCities.Data.Models.Location.Region", "Region")
                        .WithMany("RegionViews")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AddedByUser");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.UserCity", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.Location.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", "USer")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("USer");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.UserDiscussion", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.Discussions.Discussion", "Discussion")
                        .WithMany()
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", "USer")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discussion");

                    b.Navigation("USer");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.UserRegion", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.Location.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", "USer")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("USer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ExploreCities.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ExploreCities.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Discussions.Discussion", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.City", b =>
                {
                    b.Navigation("Histories");

                    b.Navigation("Regions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.CityHistory", b =>
                {
                    b.Navigation("Picture");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.Region", b =>
                {
                    b.Navigation("RegionViews");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.RegionObject", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("ExploreCities.Data.Models.Location.RegionView", b =>
                {
                    b.Navigation("Discussions");

                    b.Navigation("Objects");

                    b.Navigation("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
