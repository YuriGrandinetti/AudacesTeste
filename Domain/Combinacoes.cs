using Audaces.Controllers.Interfaces;
using Audaces.Controllers.Models;
using System.Linq;

namespace Audaces.Domain
{
    public class Combinacoes : ICombinacoes
    {
        public List<int> _sequence { get; set; }
        public int _target  { get; set; }

        public List<int> Retorno { get; set; }
        public string Mensagem { get; set; }        
        
        public bool ValidaCombinacao(VMInput vminput)
        {   
            var _retorno = true;
            if (vminput.Sequence.Any(s=> s==0))
            {
                _retorno= false;
                this.Mensagem = "A sequencia não pode ter 0";
            }         
            return _retorno; 
        }

        public VMOutput IniciaCombinacao(VMInput vminput)
        {    
            this._sequence = vminput.Sequence.OrderByDescending(s=> s).ToList();
            this._target = vminput.Target;

            var _sequenceRetorno = new List<int>();            
            var _mensagemRetorno = string.Empty;
            var _ponteiroSoma = 0;
        
            //Descobrindo quantas vezes vou precisar do valor maior
            int _dividePeloValorMaior =  (this._target / this._sequence[0]) ;

            //O VALOR ALVO é menor que o maior valor na sequencia, então inverto a ordem pra pegar o menor.
            if ( _dividePeloValorMaior > 0 )
            {
                //Já popular o retorno        
                for (var i = 1; i <= _dividePeloValorMaior; i++)
                {
                  _sequenceRetorno.Add(this._sequence[0]);
                  _ponteiroSoma += this._sequence[0];
                }
            }

            //Vou somando até o final até chegar no valor alvo
            for (var i = 1; ((i < this._sequence.Count()-1) && (_ponteiroSoma < this._target)) ; i++)
            {
                _ponteiroSoma += this._sequence[i];
                _sequenceRetorno.Add(this._sequence[i]);
            }
            
            if (  _ponteiroSoma > this._target )
            {
                _sequenceRetorno = new List<int>();
                this.Mensagem = "Não foi possível atingir o número alvo";
            }
            else
            {
                this.Mensagem = "Número alvo atingido com sucesso";
            }

            return new VMOutput{ NumeroAlvo = this._target, 
                                 SequenceInput = String.Join(", ", this._sequence.Select(i => i.ToString()).ToList()),
                                 Sequence = String.Join(", ", _sequenceRetorno.Select(i => i.ToString()).ToList()), 
                                 Message  = this.Mensagem};
        }
        
    }
}