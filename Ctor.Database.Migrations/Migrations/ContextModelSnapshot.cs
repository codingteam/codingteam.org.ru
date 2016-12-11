using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Ctor.Database;

namespace Ctor.Database.Migrations.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
