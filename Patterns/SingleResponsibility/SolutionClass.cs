using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// See http://softwareengineering.stackexchange.com/questions/17100/clarify-the-single-responsibility-principle
/// </summary>
namespace AntiPatterns.SingleResponsibility.Solution1
{
  public class Rectangle
  {
    public double Length { get; }//immutable
    public double Width { get; }

    public Rectangle(double length, double width)
    {
      Length = length;
      Width = width;
    }

    public double Area()
    {
      return Length * Width;
    }
  }



  public class HTMLPrinter 
  {
    public void Print(Rectangle rectangle)
    {
      throw new NotImplementedException();
    }
  }


  public class PDFPrinter 
  {
    public void Print(Rectangle rectangle)
    {
      throw new NotImplementedException();
    }
  }


  public class WordPrinter 
  {
    public Margins Margins {get;}

    public void Print(Rectangle rectangle)
    {
      throw new NotImplementedException();
    }
  }


  public class Margins
  {
  }



}
