using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.EntityConfig {
    public class ProductConfig : EntityTypeConfiguration<Product>{
        public ProductConfig() {
            HasKey(p => p.ProductId)
                .Property(u => u.ProductId)
                .HasColumnName("ProductId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            ToTable("product");
        }
    }
}
