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
                "dbo.Aluno",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Matricula = c.Int(nullable: false),
                        Ano = c.DateTime(nullable: false),
                        Turno = c.Int(nullable: false),
                        NomePai = c.String(),
                        NomeMae = c.String(),
                        TelPai = c.Int(nullable: false),
                        TelMae = c.Int(nullable: false),
                        Turma_TurmaId = c.Int(),
                        Usuario_UsuarioId = c.Int(),
                        Frequencia_FrequenciaId = c.Int(),
                    })
                .PrimaryKey(t => t.AlunoId)
                .ForeignKey("dbo.Turma", t => t.Turma_TurmaId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioId)
                .ForeignKey("dbo.Frequencia", t => t.Frequencia_FrequenciaId)
                .Index(t => t.Turma_TurmaId)
                .Index(t => t.Usuario_UsuarioId)
                .Index(t => t.Frequencia_FrequenciaId);
            
            CreateTable(
                "dbo.Boletim",
                c => new
                    {
                        BoletimId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Fechado = c.Boolean(nullable: false),
                        Aluno_AlunoId = c.Int(),
                    })
                .PrimaryKey(t => t.BoletimId)
                .ForeignKey("dbo.Aluno", t => t.Aluno_AlunoId)
                .Index(t => t.Aluno_AlunoId);
            
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
                "dbo.Turma",
                c => new
                    {
                        TurmaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Excluida = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TurmaId);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false, identity: true),
                        CategoriaDeEnsino = c.Int(nullable: false),
                        Cordenador_CordenadorId = c.Int(),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfessorId)
                .ForeignKey("dbo.Cordenador", t => t.Cordenador_CordenadorId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioId)
                .Index(t => t.Cordenador_CordenadorId)
                .Index(t => t.Usuario_UsuarioId);
            
            CreateTable(
                "dbo.Cordenador",
                c => new
                    {
                        CordenadorId = c.Int(nullable: false, identity: true),
                        CategorioDeEnsino = c.Int(nullable: false),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.CordenadorId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioId)
                .Index(t => t.Usuario_UsuarioId);
            
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
                        Endereco_LogradouroId = c.Int(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Logradouro", t => t.Endereco_LogradouroId)
                .Index(t => t.Endereco_LogradouroId);
            
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
                        Professor_ProfessorId = c.Int(nullable: false),
                        Disciplina_DisciplinaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Professor_ProfessorId, t.Disciplina_DisciplinaId })
                .ForeignKey("dbo.Professor", t => t.Professor_ProfessorId, cascadeDelete: true)
                .ForeignKey("dbo.Disciplina", t => t.Disciplina_DisciplinaId, cascadeDelete: true)
                .Index(t => t.Professor_ProfessorId)
                .Index(t => t.Disciplina_DisciplinaId);
            
            CreateTable(
                "dbo.ProfessorTurma",
                c => new
                    {
                        Professor_ProfessorId = c.Int(nullable: false),
                        Turma_TurmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Professor_ProfessorId, t.Turma_TurmaId })
                .ForeignKey("dbo.Professor", t => t.Professor_ProfessorId, cascadeDelete: true)
                .ForeignKey("dbo.Turma", t => t.Turma_TurmaId, cascadeDelete: true)
                .Index(t => t.Professor_ProfessorId)
                .Index(t => t.Turma_TurmaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Financeiro", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Agenda", "Turma_TurmaId", "dbo.Turma");
            DropForeignKey("dbo.Agenda", "Disciplina_DisciplinaId", "dbo.Disciplina");
            DropForeignKey("dbo.Frequencia", "Disciplína_DisciplinaId", "dbo.Disciplina");
            DropForeignKey("dbo.Aluno", "Frequencia_FrequenciaId", "dbo.Frequencia");
            DropForeignKey("dbo.Aluno", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Professor", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.ProfessorTurma", "Turma_TurmaId", "dbo.Turma");
            DropForeignKey("dbo.ProfessorTurma", "Professor_ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.ProfessorDisciplina", "Disciplina_DisciplinaId", "dbo.Disciplina");
            DropForeignKey("dbo.ProfessorDisciplina", "Professor_ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Cordenador", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Endereco_LogradouroId", "dbo.Logradouro");
            DropForeignKey("dbo.Professor", "Cordenador_CordenadorId", "dbo.Cordenador");
            DropForeignKey("dbo.Frequencia", "Turma_TurmaId", "dbo.Turma");
            DropForeignKey("dbo.Aluno", "Turma_TurmaId", "dbo.Turma");
            DropForeignKey("dbo.Boletim", "Aluno_AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.Nota", "Disciplina_DisciplinaId", "dbo.Disciplina");
            DropForeignKey("dbo.Nota", "Boletim_BoletimId", "dbo.Boletim");
            DropIndex("dbo.ProfessorTurma", new[] { "Turma_TurmaId" });
            DropIndex("dbo.ProfessorTurma", new[] { "Professor_ProfessorId" });
            DropIndex("dbo.ProfessorDisciplina", new[] { "Disciplina_DisciplinaId" });
            DropIndex("dbo.ProfessorDisciplina", new[] { "Professor_ProfessorId" });
            DropIndex("dbo.Financeiro", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Usuario", new[] { "Endereco_LogradouroId" });
            DropIndex("dbo.Cordenador", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Professor", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Professor", new[] { "Cordenador_CordenadorId" });
            DropIndex("dbo.Nota", new[] { "Disciplina_DisciplinaId" });
            DropIndex("dbo.Nota", new[] { "Boletim_BoletimId" });
            DropIndex("dbo.Boletim", new[] { "Aluno_AlunoId" });
            DropIndex("dbo.Aluno", new[] { "Frequencia_FrequenciaId" });
            DropIndex("dbo.Aluno", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Aluno", new[] { "Turma_TurmaId" });
            DropIndex("dbo.Frequencia", new[] { "Disciplína_DisciplinaId" });
            DropIndex("dbo.Frequencia", new[] { "Turma_TurmaId" });
            DropIndex("dbo.Agenda", new[] { "Turma_TurmaId" });
            DropIndex("dbo.Agenda", new[] { "Disciplina_DisciplinaId" });
            DropTable("dbo.ProfessorTurma");
            DropTable("dbo.ProfessorDisciplina");
            DropTable("dbo.Financeiro");
            DropTable("dbo.Logradouro");
            DropTable("dbo.Usuario");
            DropTable("dbo.Cordenador");
            DropTable("dbo.Professor");
            DropTable("dbo.Turma");
            DropTable("dbo.Nota");
            DropTable("dbo.Boletim");
            DropTable("dbo.Aluno");
            DropTable("dbo.Frequencia");
            DropTable("dbo.Disciplina");
            DropTable("dbo.Agenda");
        }
    }
}
