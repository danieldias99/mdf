﻿// <auto-generated />
using MDF.Models.ClassesDeDominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MDF.Migrations
{
    [DbContext(typeof(MDFContext))]
    partial class MDFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MDF.Associations.LinhaProducaoMaquinas", b =>
                {
                    b.Property<long>("id_maquina");

                    b.Property<long>("id_linhaProducao");

                    b.HasKey("id_maquina", "id_linhaProducao");

                    b.HasIndex("id_linhaProducao");

                    b.ToTable("LinhaProducaoMaquinas");
                });

            modelBuilder.Entity("MDF.Associations.TipoMaquinaOperacao", b =>
                {
                    b.Property<long>("id_operacao");

                    b.Property<long>("id_tipoMaquina");

                    b.HasKey("id_operacao", "id_tipoMaquina");

                    b.HasIndex("id_tipoMaquina");

                    b.ToTable("TipoMaquinaOperacao");
                });

            modelBuilder.Entity("MDF.Models.LinhaProducao", b =>
                {
                    b.Property<long>("id");

                    b.HasKey("id");

                    b.ToTable("LinhasProducao");
                });

            modelBuilder.Entity("MDF.Models.Maquina", b =>
                {
                    b.Property<long>("Id");

                    b.Property<long>("id_tipoMaquina");

                    b.HasKey("Id");

                    b.HasIndex("id_tipoMaquina");

                    b.ToTable("Maquinas");
                });

            modelBuilder.Entity("MDF.Models.Operacao", b =>
                {
                    b.Property<long>("id");

                    b.HasKey("id");

                    b.ToTable("Operacoes");
                });

            modelBuilder.Entity("MDF.Models.TipoMaquina", b =>
                {
                    b.Property<long>("id_tipoMaquina");

                    b.HasKey("id_tipoMaquina");

                    b.ToTable("TiposMaquina");
                });

            modelBuilder.Entity("MDF.Associations.LinhaProducaoMaquinas", b =>
                {
                    b.HasOne("MDF.Models.LinhaProducao", "linhaProducao")
                        .WithMany("maquinas")
                        .HasForeignKey("id_linhaProducao")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MDF.Models.Maquina", "maquina")
                        .WithMany("linhasProducao")
                        .HasForeignKey("id_maquina")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MDF.Associations.TipoMaquinaOperacao", b =>
                {
                    b.HasOne("MDF.Models.Operacao", "operacao")
                        .WithMany("tiposMaquinas")
                        .HasForeignKey("id_operacao")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MDF.Models.TipoMaquina", "tipoMaquina")
                        .WithMany("operacoesMaquina")
                        .HasForeignKey("id_tipoMaquina")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MDF.Models.Maquina", b =>
                {
                    b.HasOne("MDF.Models.TipoMaquina", "tipoMaquina")
                        .WithMany("maquinas")
                        .HasForeignKey("id_tipoMaquina")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("MDF.Models.ValueObjects.NomeMaquina", "nomeMaquina", b1 =>
                        {
                            b1.Property<long>("MaquinaId");

                            b1.Property<string>("nomeMaquina");

                            b1.HasKey("MaquinaId");

                            b1.ToTable("Maquinas");

                            b1.HasOne("MDF.Models.Maquina")
                                .WithOne("nomeMaquina")
                                .HasForeignKey("MDF.Models.ValueObjects.NomeMaquina", "MaquinaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MDF.Models.ValueObjects.PosicaoNaLinhaProducao", "posicaoLinhaProducao", b1 =>
                        {
                            b1.Property<long>("MaquinaId");

                            b1.Property<int>("posicaoNaLinhaProducao");

                            b1.HasKey("MaquinaId");

                            b1.ToTable("Maquinas");

                            b1.HasOne("MDF.Models.Maquina")
                                .WithOne("posicaoLinhaProducao")
                                .HasForeignKey("MDF.Models.ValueObjects.PosicaoNaLinhaProducao", "MaquinaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MDF.Models.Operacao", b =>
                {
                    b.OwnsOne("MDF.Models.ValueObjects.DuracaoOperacao", "duracaoOperacao", b1 =>
                        {
                            b1.Property<long>("Operacaoid");

                            b1.Property<string>("hora");

                            b1.Property<string>("min");

                            b1.Property<string>("seg");

                            b1.HasKey("Operacaoid");

                            b1.ToTable("Operacoes");

                            b1.HasOne("MDF.Models.Operacao")
                                .WithOne("duracaoOperacao")
                                .HasForeignKey("MDF.Models.ValueObjects.DuracaoOperacao", "Operacaoid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MDF.Models.ValueObjects.Descricao", "descricaoOperacao", b1 =>
                        {
                            b1.Property<long>("Operacaoid");

                            b1.Property<string>("Id");

                            b1.HasKey("Operacaoid");

                            b1.ToTable("Operacoes");

                            b1.HasOne("MDF.Models.Operacao")
                                .WithOne("descricaoOperacao")
                                .HasForeignKey("MDF.Models.ValueObjects.Descricao", "Operacaoid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MDF.Models.TipoMaquina", b =>
                {
                    b.OwnsOne("MDF.Models.ValueObjects.Descricao", "descricaoTipoMaquina", b1 =>
                        {
                            b1.Property<long>("TipoMaquinaid_tipoMaquina");

                            b1.Property<string>("Id");

                            b1.HasKey("TipoMaquinaid_tipoMaquina");

                            b1.ToTable("TiposMaquina");

                            b1.HasOne("MDF.Models.TipoMaquina")
                                .WithOne("descricaoTipoMaquina")
                                .HasForeignKey("MDF.Models.ValueObjects.Descricao", "TipoMaquinaid_tipoMaquina")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
