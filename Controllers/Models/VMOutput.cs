namespace Audaces.Controllers.Models
{
    public class VMOutput
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public string SequenceInput { get; set; }
        public int NumeroAlvo { get; set; }
        public string Sequence { get; set; }
        public string Message { get; set; }
    }
}