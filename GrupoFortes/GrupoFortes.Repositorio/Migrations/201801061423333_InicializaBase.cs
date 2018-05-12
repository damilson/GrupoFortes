namespace SIPE.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicializaBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ALUNO",
                c => new
                    {
                        AlunoId = c.Int(nullable: false),
                        Matricula = c.Int(nullable: false),
                        Ano = c.DateTime(nullable: false),
                        Turno = c.Int(nullable: false),
                        NomePai = c.String(),
                        NomeMae = c.String(),
                        TelPai = c.Int(nullable: false),
                        TelMae = c.Int(nullable: false),
                        Turma_TurmaId = c.Int(),
                        Boletim_BoletimId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoId)
                .ForeignKey("dbo.TURMA", t => t.Turma_TurmaId)
                .ForeignKey("dbo.BOLETIM", t => t.Boletim_BoletimId)
                .ForeignKey("dbo.TURMA", t => t.AlunoId)
                .ForeignKey("dbo.USUARIO", t => t.AlunoId, cascadeDelete: true)
                .Index(t => t.AlunoId)
                .Index(t => t.Turma_TurmaId)
                .Index(t => t.Boletim_BoletimId);
            
            CreateTable(
                "dbo.BOLETIM",
                c => new
                    {
                        BoletimId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Fechado = c.Boolean(nullable: false),
                        Notas_NotaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BoletimId)
                .ForeignKey("dbo.NOTA", t => t.Notas_NotaId, cascadeDelete: true)
                .Index(t => t.Notas_NotaId);
            
            CreateTable(
                "dbo.NOTA",
                c => new
                    {
                        NotaId = c.Int(nullable: false),
                        NotaDiciplina = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.NotaId)
                .ForeignKey("dbo.BOLETIM", t => t.NotaId, cascadeDelete: true)
                .ForeignKey("dbo.DISCIPLINA", t => t.NotaId)
                .Index(t => t.NotaId);
            
            CreateTable(
                "dbo.DISCIPLINA",
                c => new
                    {
                        DisciplinaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.DisciplinaId);
            
            CreateTable(
                "dbo.FREQUENCIA",
                c => new
                    {
                        FrequenciaId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Alunos_AlunoId = c.Int(nullable: false),
                        Disciplína_DisciplinaId = c.Int(nullable: false),
                        Turma_TurmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FrequenciaId)
                .ForeignKey("dbo.ALUNO", t => t.Alunos_AlunoId, cascadeDelete: true)
                .ForeignKey("dbo.DISCIPLINA", t => t.Disciplína_DisciplinaId, cascadeDelete: true)
                .ForeignKey("dbo.TURMA", t => t.Turma_TurmaId, cascadeDelete: true)
                .Index(t => t.Alunos_AlunoId)
                .Index(t => t.Disciplína_DisciplinaId)
                .Index(t => t.Turma_TurmaId);
            
            CreateTable(
                "dbo.TURMA",
                c => new
                    {
                        TurmaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.TurmaId);
            
            CreateTable(
                "dbo.PROFESSOR",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false),
                        CategoriaDeEnsino = c.Int(nullable: false),
                        Cordenador_CordenadorId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfessorId)
                .ForeignKey("dbo.CORDENADOR", t => t.Cordenador_CordenadorId)
                .ForeignKey("dbo.CORDENADOR", t => t.ProfessorId)
                .ForeignKey("dbo.USUARIO", t => t.ProfessorId, cascadeDelete: true)
                .Index(t => t.ProfessorId)
                .Index(t => t.Cordenador_CordenadorId);
            
            CreateTable(
                "dbo.CORDENADOR",
                c => new
                    {
                        CordenadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CordenadorId)
                .ForeignKey("dbo.USUARIO", t => t.CordenadorId, cascadeDelete: true)
                .Index(t => t.CordenadorId);
            
            CreateTable(
                "dbo.USUARIO",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Sexo = c.Int(nullable: false),
                        CPF = c.String(),
                        DatadeNascimento = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Email = c.String(),
                        UserId = c.String(),
                        Perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.LOGRADOURO",
                c => new
                    {
                        LogradouroId = c.Int(nullable: false),
                        Cep = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Rua = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.LogradouroId)
                .ForeignKey("dbo.USUARIO", t => t.LogradouroId)
                .Index(t => t.LogradouroId);
            
            CreateTable(
                "dbo.FINANCEIRO",
                c => new
                    {
                        FinanceiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinanceiroId)
                .ForeignKey("dbo.USUARIO", t => t.FinanceiroId, cascadeDelete: true)
                .Index(t => t.FinanceiroId);
            
            CreateTable(
                "dbo.AGENDA",
                c => new
                    {
                        AgendaId = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AgendaId)
                .ForeignKey("dbo.TURMA", t => t.AgendaId)
                .Index(t => t.AgendaId);
            
            CreateTable(
                "dbo.ProfessorTurma",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false),
                        TurmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfessorId, t.TurmaId })
                .ForeignKey("dbo.PROFESSOR", t => t.ProfessorId, cascadeDelete: true)
                .ForeignKey("dbo.TURMA", t => t.TurmaId, cascadeDelete: true)
                .Index(t => t.ProfessorId)
                .Index(t => t.TurmaId);
            
            CreateTable(
                "dbo.ProfessorDiscplina",
                c => new
                    {
                        DisciplinaId = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DisciplinaId, t.ProfessorId })
                .ForeignKey("dbo.DISCIPLINA", t => t.DisciplinaId, cascadeDelete: true)
                .ForeignKey("dbo.PROFESSOR", t => t.ProfessorId, cascadeDelete: true)
                .Index(t => t.DisciplinaId)
                .Index(t => t.ProfessorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AGENDA", "AgendaId", "dbo.TURMA");
            DropForeignKey("dbo.FINANCEIRO", "FinanceiroId", "dbo.USUARIO");
            DropForeignKey("dbo.ALUNO", "AlunoId", "dbo.USUARIO");
            DropForeignKey("dbo.ALUNO", "AlunoId", "dbo.TURMA");
            DropForeignKey("dbo.ALUNO", "Boletim_BoletimId", "dbo.BOLETIM");
            DropForeignKey("dbo.BOLETIM", "Notas_NotaId", "dbo.NOTA");
            DropForeignKey("dbo.NOTA", "NotaId", "dbo.DISCIPLINA");
            DropForeignKey("dbo.ProfessorDiscplina", "ProfessorId", "dbo.PROFESSOR");
            DropForeignKey("dbo.ProfessorDiscplina", "DisciplinaId", "dbo.DISCIPLINA");
            DropForeignKey("dbo.FREQUENCIA", "Turma_TurmaId", "dbo.TURMA");
            DropForeignKey("dbo.PROFESSOR", "ProfessorId", "dbo.USUARIO");
            DropForeignKey("dbo.ProfessorTurma", "TurmaId", "dbo.TURMA");
            DropForeignKey("dbo.ProfessorTurma", "ProfessorId", "dbo.PROFESSOR");
            DropForeignKey("dbo.PROFESSOR", "ProfessorId", "dbo.CORDENADOR");
            DropForeignKey("dbo.CORDENADOR", "CordenadorId", "dbo.USUARIO");
            DropForeignKey("dbo.LOGRADOURO", "LogradouroId", "dbo.USUARIO");
            DropForeignKey("dbo.PROFESSOR", "Cordenador_CordenadorId", "dbo.CORDENADOR");
            DropForeignKey("dbo.ALUNO", "Turma_TurmaId", "dbo.TURMA");
            DropForeignKey("dbo.FREQUENCIA", "Disciplína_DisciplinaId", "dbo.DISCIPLINA");
            DropForeignKey("dbo.FREQUENCIA", "Alunos_AlunoId", "dbo.ALUNO");
            DropForeignKey("dbo.NOTA", "NotaId", "dbo.BOLETIM");
            DropIndex("dbo.ProfessorDiscplina", new[] { "ProfessorId" });
            DropIndex("dbo.ProfessorDiscplina", new[] { "DisciplinaId" });
            DropIndex("dbo.ProfessorTurma", new[] { "TurmaId" });
            DropIndex("dbo.ProfessorTurma", new[] { "ProfessorId" });
            DropIndex("dbo.AGENDA", new[] { "AgendaId" });
            DropIndex("dbo.FINANCEIRO", new[] { "FinanceiroId" });
            DropIndex("dbo.LOGRADOURO", new[] { "LogradouroId" });
            DropIndex("dbo.CORDENADOR", new[] { "CordenadorId" });
            DropIndex("dbo.PROFESSOR", new[] { "Cordenador_CordenadorId" });
            DropIndex("dbo.PROFESSOR", new[] { "ProfessorId" });
            DropIndex("dbo.FREQUENCIA", new[] { "Turma_TurmaId" });
            DropIndex("dbo.FREQUENCIA", new[] { "Disciplína_DisciplinaId" });
            DropIndex("dbo.FREQUENCIA", new[] { "Alunos_AlunoId" });
            DropIndex("dbo.NOTA", new[] { "NotaId" });
            DropIndex("dbo.BOLETIM", new[] { "Notas_NotaId" });
            DropIndex("dbo.ALUNO", new[] { "Boletim_BoletimId" });
            DropIndex("dbo.ALUNO", new[] { "Turma_TurmaId" });
            DropIndex("dbo.ALUNO", new[] { "AlunoId" });
            DropTable("dbo.ProfessorDiscplina");
            DropTable("dbo.ProfessorTurma");
            DropTable("dbo.AGENDA");
            DropTable("dbo.FINANCEIRO");
            DropTable("dbo.LOGRADOURO");
            DropTable("dbo.USUARIO");
            DropTable("dbo.CORDENADOR");
            DropTable("dbo.PROFESSOR");
            DropTable("dbo.TURMA");
            DropTable("dbo.FREQUENCIA");
            DropTable("dbo.DISCIPLINA");
            DropTable("dbo.NOTA");
            DropTable("dbo.BOLETIM");
            DropTable("dbo.ALUNO");
        }
    }
}
