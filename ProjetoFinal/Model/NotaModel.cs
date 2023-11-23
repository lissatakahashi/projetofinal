namespace ProjetoFinal.Model {
    public class NotaModel {
        public int? NotaID { get; set; }
        public decimal? Prova1 { get; set; }
        public decimal? Prova2 { get; set; }
        public decimal? Trabalho { get; set; }
        public decimal? Atividade { get; set; }
        public List<AlunoModel>? Alunos { get; set; }
    }
}