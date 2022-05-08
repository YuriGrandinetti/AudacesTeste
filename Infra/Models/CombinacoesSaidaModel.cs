using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Infra.Models;


public class CombinacoesSaidaModel 
{   
    public string Id { get; set; }
    public string SequenciaSaida {get; set;}
}