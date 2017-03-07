using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.LiskovSubstitution.Solution2
{
  
  public abstract class Shape
  {
    public abstract double Area();
  }


  public class Square : Shape
  {
    //private member Property and name makes sense
    private int Length { get; set; }

    public override double Area()
    {
      return Length * Length;
    }
  }


  public class Rectangle : Shape
  {
    private int Width { get; set; }
    private int Height { get; set; }

    public override double Area()
    {
      return Width * Height;
    }
  }



}
