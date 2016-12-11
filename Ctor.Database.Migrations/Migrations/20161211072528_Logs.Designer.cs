using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Ctor.Database;

namespace Ctor.Database.Migrations.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20161211072528_Logs")]
    partial class Logs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Ctor.Database.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Conference");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Sender");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });
        }
    }
}
