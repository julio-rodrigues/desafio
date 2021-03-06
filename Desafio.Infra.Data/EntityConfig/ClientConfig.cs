﻿using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.EntityConfig {
    public class ClientConfig : EntityTypeConfiguration<Client>{
        public ClientConfig() {
            HasKey(c => c.ClientId)
                .Property(u => u.ClientId)
                .HasColumnName("ClientId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(p => p.Product);

            ToTable("client");
        }
    }
}
