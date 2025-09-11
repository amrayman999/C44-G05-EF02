using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DeptId);
            builder.Property(x => x.DeptId).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasMaxLength(20);
            //builder.Property(x => x.DeptId)
            //.ValueGeneratedNever();

            //builder
            //    .Property(x=> x.DeptId)
            //    .HasDefaultValueSql("NewGuid()");

            builder
                .Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnName("DepartmentName")
                .IsRequired(false)
                .HasDefaultValue("HR");

            builder.Property(x => x.DateofCreation)
                .HasAnnotation("DataType", "Date")
                //.HasDefaultValue(DateOnly.FromDateTime(DateTime.Now))
                .HasDefaultValueSql("getdate()");

            builder.Ignore(x => x.Serial);


        }
    }
}
