using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// See http://softwareengineering.stackexchange.com/questions/17100/clarify-the-single-responsibility-principle
/// </summary>
namespace AntiPatterns.SingleResponsibility.Solution2
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


  /// <summary>
  /// Use interface to decouple printing
  /// </summary>
  public interface IRectanglePrinter
  {
    void Print(Rectangle rectangle);
  }


  public class HTMLPrinter : IRectanglePrinter
  {
    public void Print(Rectangle rectangle)
    {
      throw new NotImplementedException();
    }
  }


  public class PDFPrinter : IRectanglePrinter
  {
    public void Print(Rectangle rectangle)
    {
      throw new NotImplementedException();
    }
  }


  public class WordPrinter : IRectanglePrinter
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
