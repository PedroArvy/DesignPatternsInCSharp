using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.LiskovSubstitution.Smell2
{
  
  public abstract class Shape
  {
    /// <summary>
    /// smell - Properties that may not apply to all child classes are in base class
    /// </summary>
    protected int Width { get; set; }
    protected int Height { get; set; }

    public abstract double Area();
  }


  public class Square : Shape
  {
    public override double Area()
    {
      //smell - Squares have one length, not two. Although correct, this is a misuse of inheritance
      return Width * Height;
    }
  }


  public class Rectangle : Shape
  {
    public override double Area()
    {
      return Width * Height;
    }
  }



}
