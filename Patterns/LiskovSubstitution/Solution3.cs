using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.LiskovSubstitution.Solution3
{

  public interface IFlyable
  {
     void Fly();
  }

  public class AirPlane : IFlyable
  {
    public void Fly()
    {
    }
  }

}
