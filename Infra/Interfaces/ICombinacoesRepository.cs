using Audaces.Controllers.Models;
using Infra.Models;

namespace Infra.Interfaces;

public interface ICombinacoesRepository
{
  public Guid Add(VMInput input, VMOutput output);
  public List<VMOutput> ListAll();    
}


