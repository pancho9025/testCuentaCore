using Core.Transaccion.Domain.Entities.Cuenta;
using Core.Transaccion.Domain.Entities.Cliente;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Core.Transaccion.Infrastructure.Context
{
    public class CoreCuentaContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        public CoreCuentaContext(DbContextOptions<CoreCuentaContext> options)
            : base(options)
        {
           
        }

        /// <summary>
        /// Configuración del modelo de datos
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
           
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.PersonaId)
                    .HasName("PK_PERSONA");

                entity.ToTable("Persona", "cu");

                entity.Property(e => e.Nombre)
                               .HasMaxLength(220)
                                .IsUnicode(false);

                entity.Property(e => e.Genero)
                               .HasMaxLength(1)
                                .IsUnicode(false);

                entity.Property(e => e.Edad)
                                .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                                .HasMaxLength(13)
                                .IsUnicode(false);

                entity.Property(e => e.Direccion)
                           .HasMaxLength(220)
                           .IsUnicode(false);

                entity.Property(e => e.Telefono)
                           .HasMaxLength(20)
                           .IsUnicode(false);
                
            });
            modelBuilder.Entity<Cliente>(entity =>
            {               
                entity.ToTable("Cliente", "cu");
                entity.HasBaseType<Persona>();

                entity.Property(e => e.ClienteId)  
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonaId);

                entity.Property(e => e.Clave)
                                .HasMaxLength(128)
                                .IsUnicode(false);


                entity.Property(e => e.Estado);

                
                entity.HasBaseType<Persona>(); 

                entity.Property(e => e.Clave)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Estado);

                entity.HasOne<Persona>()
                      .WithOne()
                      .HasForeignKey<Cliente>(c => c.PersonaId); 
            });
            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.CuentaId)
                    .HasName("PK_CUENTA");

                entity.ToTable("Cuenta", "cu");

                entity.Property(e => e.NumeroCuenta);

                entity.Property(e => e.TipoCuenta)
                                .HasMaxLength(9)
                                .IsUnicode(false);

                entity.Property(e => e.SaldoInicial);
                entity.Property(e => e.Estado);
            });
            modelBuilder.Entity<ClienteCuenta>(entity =>
            {
                entity.HasKey(e => e.ClienteCuentaId)
                    .HasName("PK_CLIENTECUENTA");

                entity.ToTable("ClienteCuenta", "cu");

                entity.Property(e => e.ClienteCuentaId);

                entity.Property(e => e.CuentaId);

                entity.Property(e => e.ClienteId);
            });
            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.MovimientoId)
                    .HasName("PK_MOVIMIENTO");

                entity.ToTable("Movimiento", "cu");

                entity.Property(e => e.ClienteId);

                entity.Property(e => e.CuentaId);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.TipoMovimiento)
                                .HasMaxLength(9)
                                .IsUnicode(false);

                entity.Property(e => e.Valor);

                entity.Property(e => e.Saldo);

            });
            modelBuilder.Entity<CuentaMovimiento>().HasNoKey();
        }
    }

}