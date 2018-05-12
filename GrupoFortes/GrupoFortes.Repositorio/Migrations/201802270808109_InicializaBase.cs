namespace SIPE.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicializaBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        AgendaId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Conteudo = c.String(),
                        Excluida = c.Boolean(nullable: false),
                        Disciplina_DisciplinaId = c.Int(),
                        Turma_TurmaId = c.Int(),
                    })
                .PrimaryKey(t => t.AgendaId)
                .ForeignKey("dbo.Disciplina", t => t.Disciplina_DisciplinaId)
                .ForeignKey("dbo.Turma", t => t.Turma_TurmaId)
                .Index(t => t.Disciplina_DisciplinaId)
                .Index(t => t.Turma_TurmaId);
            
            CreateTable(
                "dbo.Disciplina",
                c => new
                    {
                        DisciplinaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Excluida = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DisciplinaId);
            
            CreateTable(
                "dbo.Frequencia",
                c => new
                    {
                        FrequenciaId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Turma_TurmaId = c.Int(),
                        Disciplína_DisciplinaId = c.Int(),
                    })
                .PrimaryKey(t => t.FrequenciaId)
                .ForeignKey("dbo.Turma", t => t.Turma_TurmaId)
                .ForeignKey("dbo.Disciplina", t => t.Disciplína_DisciplinaId)
                .Index(t => t.Turma_TurmaId)
                .Index(t => t.Disciplína_DisciplinaId);
            
            CreateTable(
                "dbo.Usuario",
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
                        AlunoId = c.Int(),
                        Matricula = c.Int(),
                        Ano = c.DateTime(),
                        Turno = c.Int(),
                        NomePai = c.String(),
                        NomeMae = c.String(),
                        TelPai = c.Int(),
                        TelMae = c.Int(),
                        ProfessorId = c.Int(),
                        CategoriaDeEnsino = c.Int(),
                        CordenadorId = c.Int(),
                        CategorioDeEnsino = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Turma_TurmaId = c.Int(),
                        Cordenador_UsuarioId = c.Int(),
                        Frequencia_FrequenciaId = c.Int(),
                        Endereco_LogradouroId = c.Int(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Turma", t => t.Turma_TurmaId)
                .ForeignKey("dbo.Usuario", t => t.Cordenador_UsuarioId)
                .ForeignKey("dbo.Frequencia", t => t.Frequencia_FrequenciaId)
                .ForeignKey("dbo.Logradouro", t => t.Endereco_LogradouroId)
                .Index(t => t.Turma_TurmaId)
                .Index(t => t.Cordenador_UsuarioId)
                .Index(t => t.Frequencia_FrequenciaId)
                .Index(t => t.Endereco_LogradouroId);
            
            CreateTable(
                "dbo.Boletim",
                c => new
                    {
                        BoletimId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Fechado = c.Boolean(nullable: false),
                        Aluno_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.BoletimId)
                .ForeignKey("dbo.Usuario", t => t.Aluno_UsuarioId)
                .Index(t => t.Aluno_UsuarioId);
            
            CreateTable(
                "dbo.Nota",
                c => new
                    {
                        NotaId = c.Int(nullable: false, identity: true),
                        NotaDiciplina = c.Double(nullable: false),
                        Boletim_BoletimId = c.Int(),
                        Disciplina_DisciplinaId = c.Int(),
                    })
                .PrimaryKey(t => t.NotaId)
                .ForeignKey("dbo.Boletim", t => t.Boletim_BoletimId)
                .ForeignKey("dbo.Disciplina", t => t.Disciplina_DisciplinaId)
                .Index(t => t.Boletim_BoletimId)
                .Index(t => t.Disciplina_DisciplinaId);
            
            CreateTable(
                "dbo.Logradouro",
                c => new
                    {
                        LogradouroId = c.Int(nullable: false, identity: true),
                        Cep = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Rua = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.LogradouroId);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        TurmaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Excluida = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TurmaId);
            
            CreateTable(
                "dbo.Financeiro",
                c => new
                    {
                        FinanceiroId = c.Int(nullable: false, identity: true),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.FinanceiroId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioId)
                .Index(t => t.Usuario_UsuarioId);
            
            CreateTable(
                "dbo.ProfessorDisciplina",
                c => new
                    {
                        Professor_UsuarioId = c.Int(nullable: false),
                        Disciplina_DisciplinaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Professor_UsuarioId, t.Disciplina_DisciplinaId })
                .ForeignKey("dbo.Usuario", t => t.Professor_UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Disciplina", t => t.Disciplina_DisciplinaId, cascadeDelete: true)
                .Index(t => t.Professor_UsuarioId)
                .Index(t => t.Disciplina_DisciplinaId);
            
            CreateTable(
                "dbo.ProfessorTurma",
                c => new
                    {
                        Professor_UsuarioId = c.Int(nullable: false),
                        Turma_TurmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Professor_UsuarioId, t.Turma_TurmaId })
                .ForeignKey("dbo.Usuario", t => t.Professor_UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Turma", t => t.Turma_TurmaId, cascadeDelete: true)
                .Index(t => t.Professor_UsuarioId)
                .Index(t => t.Turma_TurmaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Financeiro", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Endereco_LogradouroId", "dbo.Logradouro");
            DropForeignKey("dbo.Agenda", "Turma_TurmaId", "dbo.Turma");
            DropForeignKey("dbo.Agenda", "Disciplina_DisciplinaId", "dbo.Disciplina");
            DropForeignKey("dbo.Frequencia", "Disciplína_DisciplinaId", "dbo.Disciplina");
            DropForeignKey("dbo.Usuario", "Frequencia_FrequenciaId", "dbo.Frequencia");
            DropForeignKey("dbo.ProfessorTurma", "Turma_TurmaId", "dbo.Turma");
            DropForeignKey("dbo.ProfessorTurma", "Professor_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.ProfessorDisciplina", "Disciplina_DisciplinaId", "dbo.Disciplina");
            DropForeignKey("dbo.ProfessorDisciplina", "Professor_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Cordenador_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Frequencia", "Turma_TurmaId", "dbo.Turma");
            DropForeignKey("dbo.Usuario", "Turma_TurmaId", "dbo.Turma");
            DropForeignKey("dbo.Boletim", "Aluno_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Nota", "Disciplina_DisciplinaId", "dbo.Disciplina");
            DropForeignKey("dbo.Nota", "Boletim_BoletimId", "dbo.Boletim");
            DropIndex("dbo.ProfessorTurma", new[] { "Turma_TurmaId" });
            DropIndex("dbo.ProfessorTurma", new[] { "Professor_UsuarioId" });
            DropIndex("dbo.ProfessorDisciplina", new[] { "Disciplina_DisciplinaId" });
            DropIndex("dbo.ProfessorDisciplina", new[] { "Professor_UsuarioId" });
            DropIndex("dbo.Financeiro", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Nota", new[] { "Disciplina_DisciplinaId" });
            DropIndex("dbo.Nota", new[] { "Boletim_BoletimId" });
            DropIndex("dbo.Boletim", new[] { "Aluno_UsuarioId" });
            DropIndex("dbo.Usuario", new[] { "Endereco_LogradouroId" });
            DropIndex("dbo.Usuario", new[] { "Frequencia_FrequenciaId" });
            DropIndex("dbo.Usuario", new[] { "Cordenador_UsuarioId" });
            DropIndex("dbo.Usuario", new[] { "Turma_TurmaId" });
            DropIndex("dbo.Frequencia", new[] { "Disciplína_DisciplinaId" });
            DropIndex("dbo.Frequencia", new[] { "Turma_TurmaId" });
            DropIndex("dbo.Agenda", new[] { "Turma_TurmaId" });
            DropIndex("dbo.Agenda", new[] { "Disciplina_DisciplinaId" });
            DropTable("dbo.ProfessorTurma");
            DropTable("dbo.ProfessorDisciplina");
            DropTable("dbo.Financeiro");
            DropTable("dbo.Turma");
            DropTable("dbo.Logradouro");
            DropTable("dbo.Nota");
            DropTable("dbo.Boletim");
            DropTable("dbo.Usuario");
            DropTable("dbo.Frequencia");
            DropTable("dbo.Disciplina");
            DropTable("dbo.Agenda");
        }
    }
}
