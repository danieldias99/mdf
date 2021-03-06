using Microsoft.EntityFrameworkCore;
using MDF.Models.ValueObjects;
using MDF.Models;
using MDF.Associations;

namespace MDF.Models.ClassesDeDominio
{
    public class MDFContext : DbContext
    {
        public MDFContext(DbContextOptions<MDFContext> options) : base(options) { }

        public DbSet<Operacao> Operacoes { get; set; }

        public DbSet<TipoMaquina> TiposMaquina { get; set; }
        public DbSet<TipoMaquinaOperacao> TipoMaquinaOperacao { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<LinhaProducao> LinhasProducao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Operacao
            modelBuilder.Entity<Operacao>().HasKey(j => j.id);
            modelBuilder.Entity<Operacao>().Property(j => j.id).ValueGeneratedNever();

            modelBuilder.Entity<Operacao>().OwnsOne(j => j.descricaoOperacao);
            modelBuilder.Entity<Operacao>().OwnsOne(j => j.duracaoOperacao);

            modelBuilder.Entity<Operacao>().OwnsOne(j => j.ferramentaOperacao);


            //Tipo Maquina
            modelBuilder.Entity<TipoMaquina>().HasKey(a => a.id_tipoMaquina);
            modelBuilder.Entity<TipoMaquina>().Property(a => a.id_tipoMaquina).ValueGeneratedNever();

            modelBuilder.Entity<TipoMaquina>().OwnsOne(a => a.descricaoTipoMaquina);

            //Tipo Maquina Operacao
            modelBuilder.Entity<TipoMaquinaOperacao>()
                .HasKey(tmo => new { tmo.id_operacao, tmo.id_tipoMaquina });
            modelBuilder.Entity<TipoMaquinaOperacao>()
                .HasOne(tmo => tmo.operacao)
                .WithMany(b => b.tiposMaquinas)
                .HasForeignKey(tmo => tmo.id_operacao);
            modelBuilder.Entity<TipoMaquinaOperacao>()
                .HasOne(tmo => tmo.tipoMaquina)
                .WithMany(c => c.operacoesMaquina)
                .HasForeignKey(tmo => tmo.id_tipoMaquina);

            //Maquina
            modelBuilder.Entity<Maquina>().HasKey(b => b.Id);
            modelBuilder.Entity<Maquina>().Property(b => b.Id).ValueGeneratedNever();

            modelBuilder.Entity<Maquina>().OwnsOne(b => b.nomeMaquina);
            modelBuilder.Entity<Maquina>().OwnsOne(b => b.modeloMaquina);
            modelBuilder.Entity<Maquina>().OwnsOne(b => b.marcaMaquina);
            modelBuilder.Entity<Maquina>().Property(b => b.estado);

            modelBuilder.Entity<Maquina>()
            .HasOne<TipoMaquina>(s => s.tipoMaquina)
            .WithMany(g => g.maquinas)
            .HasForeignKey(s => s.id_tipoMaquina);
            modelBuilder.Entity<Maquina>()
            .HasOne<LinhaProducao>(s => s.linhaProducao)
            .WithMany(g => g.maquinas)
            .HasForeignKey(s => s.id_linhaProducao);
            modelBuilder.Entity<Maquina>().OwnsOne(b => b.posicaoLinhaProducao);
            modelBuilder.Entity<Maquina>().OwnsOne(b => b.posicaoRelativa);

            //Linhas de Producao
            modelBuilder.Entity<LinhaProducao>().HasKey(d => d.id);
            modelBuilder.Entity<LinhaProducao>().Property(d => d.id).ValueGeneratedNever();

            modelBuilder.Entity<LinhaProducao>().OwnsOne(b => b.descricao);
            modelBuilder.Entity<LinhaProducao>().OwnsOne(b => b.posicaoAbsolutaLinhaProducao);
            modelBuilder.Entity<LinhaProducao>().OwnsOne(b => b.orientacaoLinhaProducao);
            modelBuilder.Entity<LinhaProducao>().OwnsOne(b => b.dimensaoLinhaProducao);
        }

    }
}