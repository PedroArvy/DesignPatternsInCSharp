using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiPatterns.OpenClosed
{

  public class Circle
  {
    public double Radius { get; set; }
  }


  public class Rectangle
  {
    public double Width { get; set; }
    public double Height { get; set; }
  }


  public class AreaCalculator
  {
    public double Area(object[] shapes)
    {
      double area = 0;
      foreach (var shape in shapes)
      {
        //smell - decisions based on object type
        if (shape is Rectangle)
        {
          Rectangle rectangle = (Rectangle)shape;
          area += rectangle.Width * rectangle.Height;
        }
        //smell - decisions based on object type
        else
        {
          Circle circle = (Circle)shape;
          area += circle.Radius * circle.Radius * Math.PI;
        }
      }

      return area;
    }

  }


}
