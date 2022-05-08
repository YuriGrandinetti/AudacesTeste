using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Infra.Models;


public class CombinacoesEntradaModel
{        
    [Key]
    public Guid  Id { get; set; }

    public DateTime DataHora {get; set;}

    public int NumeroAlvo {get; set;}

    public string SequenciaEntrada {get; set;}    

    public string Mensagem  {get; set;}    

}