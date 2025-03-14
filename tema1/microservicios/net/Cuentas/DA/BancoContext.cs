﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroServiciosBccr.Modelos;

namespace MicroServiciosBccr.DA.AccesoDatos
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.FechaVencimiento).IsRequired();
                entity.Property(e => e.Estado).IsRequired();
                entity.Property(e => e.Emisor).IsRequired();
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.NumeroDeCuenta).IsRequired();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.HasMany(e => e.Tarjetas).WithOne(c => c.Cliente).HasForeignKey(c => c.IdCliente);
                entity.HasMany(e => e.Cuentas).WithOne(c => c.Cliente).HasForeignKey(c => c.IdCliente);
            });

            modelBuilder.Entity<Cliente>().HasData(
                  new Cliente { Id = 1, Nombre = "John Doe"},
                  new Cliente { Id = 2, Nombre = "Jane Smith"},
                  new Cliente { Id = 3, Nombre = "William Johnson"}
              );

            // Configuración de Cuenta
            modelBuilder.Entity<Cuenta>().HasData(
                new Cuenta { Id = 1, IdCliente = 1, NumeroDeCuenta = "1234567890", Estado ="1", Moneda ="CRC", Tipo = "1" },
                new Cuenta { Id = 2, IdCliente = 1, NumeroDeCuenta = "0987654321", Estado ="1", Moneda ="CRC", Tipo = "1" },
                new Cuenta { Id = 3, IdCliente = 2, NumeroDeCuenta = "1122334455", Estado ="1", Moneda ="CRC", Tipo = "1" },
                new Cuenta { Id = 4, IdCliente = 3, NumeroDeCuenta = "5544332211", Estado ="1", Moneda ="CRC", Tipo = "1" },
                new Cuenta { Id = 5, IdCliente = 3, NumeroDeCuenta = "6677889900", Estado ="1", Moneda ="CRC", Tipo = "1" }
            );

            // Configuración de Tarjeta
            modelBuilder.Entity<Tarjeta>().HasData(
                new Tarjeta { Id = 1, Numero = "4111111111111111", FechaVencimiento = new DateTime(2025, 12, 31), IdCliente = 1, Emisor = "VISA", Estado = "ACTIVA" },
                new Tarjeta { Id = 2, Numero = "4222222222222222", FechaVencimiento = new DateTime(2024, 11, 30), IdCliente = 1, Emisor = "VISA", Estado = "ACTIVA" },
                new Tarjeta { Id = 3, Numero = "4333333333333333", FechaVencimiento = new DateTime(2023, 10, 31), IdCliente = 2, Emisor = "VISA", Estado = "ACTIVA" },
                new Tarjeta { Id = 4, Numero = "4444444444444444", FechaVencimiento = new DateTime(2025, 01, 15), IdCliente = 2, Emisor = "VISA", Estado = "ACTIVA" },
                new Tarjeta { Id = 5, Numero = "4555555555555555", FechaVencimiento = new DateTime(2026, 07, 29), IdCliente = 3, Emisor = "VISA", Estado = "ACTIVA" }
            );
        }
    }
}
