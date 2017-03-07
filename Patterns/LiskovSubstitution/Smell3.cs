using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.LiskovSubstitution.Smell3
{
  /// <summary>
  /// smell - Verbs as class names indicate interfaces, not inheritance
  /// </summary>
  public abstract class Flyable
  {
    public abstract void Fly();
  }


  /// <summary>
  /// smell - Deriving from a class named from a verb indicates an interface should have been used
  /// </summary>
  public class AirPlane : Flyable
  {
    public override void Fly()
    {
    }
  }




}
