using Audaces.Controllers.Models;
using Infra.Interfaces;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class CombinacoesRepository : ICombinacoesRepository
{
    private readonly DataBaseContext _context;


    public CombinacoesRepository (DataBaseContext context)
    {
        this._context = context;
    }


    private  CombinacoesEntradaModel IncluirCombinacoes(VMInput combinacoes, string message)
    {            
        return new CombinacoesEntradaModel { Id = Guid.NewGuid(),  
                                             Mensagem =  message,
                                             DataHora = DateTime.Now,
                                             SequenciaEntrada = String.Join(", ", combinacoes.Sequence.Select(i => i.ToString()).ToList()),
                                             NumeroAlvo = combinacoes.Target};
    }

    private CombinacoesSaidaModel IncluirCombinacoesItem(Guid idGuid, VMOutput combinacoesItem)
    {
         return new CombinacoesSaidaModel{ Id = idGuid.ToString(), SequenciaSaida = combinacoesItem.Sequence.ToString() };  
    }

    public Guid Add(VMInput input, VMOutput output)
    {
        
        var mapperCombinacoesEntrada = IncluirCombinacoes(input, output.Message);
        var mapperCombinacoesSaida = IncluirCombinacoesItem(mapperCombinacoesEntrada.Id, output);
    
        this._context.CombinacoesEntrada.Add(mapperCombinacoesEntrada);
        this._context.CombinacoesSaida.Add(mapperCombinacoesSaida);
  
        this._context.SaveChanges();

        return mapperCombinacoesEntrada.Id;
    }


    public List<VMOutput> ListAll()
    {           
        var retorno = new List<VMOutput>();        
        var combinacoesEntrada = this._context.CombinacoesEntrada.ToList();


        foreach (var item in combinacoesEntrada)
        {
            var combinacoesSaida = this._context.CombinacoesSaida.Where(w => w.Id == item.Id.ToString())
                                                                 .Select( s => s.SequenciaSaida).ToList();

            var obj = new  VMOutput { Id = item.Id, 
                                      DataHora = item.DataHora ,
                                      SequenceInput = item.SequenciaEntrada,
                                      Sequence = String.Join(", ",combinacoesSaida) ,
                                      Message = item.Mensagem ,
                                      NumeroAlvo = item.NumeroAlvo } ;
            retorno.Add(obj);            
        }
        return retorno;
    }



}