using Audaces.Controllers.Models;

namespace Audaces.Controllers.Interfaces
{
    public interface ICombinacoes
    {
        public string Mensagem { get; set; }        
        
         public VMOutput IniciaCombinacao(VMInput vminput);
         public bool ValidaCombinacao(VMInput vminput);
    }
}