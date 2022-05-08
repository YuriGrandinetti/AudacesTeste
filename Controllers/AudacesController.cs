using Audaces.Controllers.Interfaces;
using Audaces.Controllers.Models;
using Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Audaces.Controllers;

[ApiController]
[Route("[controller]")]
public class AudacesController : ControllerBase
{
    private readonly ICombinacoes _combinacoes;
    private readonly ICombinacoesRepository _combinacoesRepository;

    public AudacesController(ICombinacoes combinacoes, ICombinacoesRepository combinacoesRepository)
    {
        _combinacoes = combinacoes;
        _combinacoesRepository = combinacoesRepository;
    }

    [HttpPost("RetornaCombinacao")]
    public VMOutput RetornaCombinacao([FromBody] VMInput payload)
    {        
        if (!this._combinacoes.ValidaCombinacao(payload) )
            return new VMOutput { Message = this._combinacoes.Mensagem};
 
        var objetoRetorno = this._combinacoes.IniciaCombinacao(payload);

        var retornoAdd = _combinacoesRepository.Add(payload, objetoRetorno);
        objetoRetorno.Id  = retornoAdd;
        objetoRetorno.DataHora = DateTime.Now;
        
        return objetoRetorno;
    }

    [HttpGet("PesquisaCombinacao")]
    public ActionResult PesquisaCombinacao()
    {        
       return Ok(_combinacoesRepository.ListAll());
    }

    
}
