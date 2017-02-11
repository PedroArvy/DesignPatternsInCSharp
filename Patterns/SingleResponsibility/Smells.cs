using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A class should have only one reason to change
/// A class should model  one abstraction that it models
/// </summary>
namespace AntiPatterns.SingleResponsibility
{

  public class Rectangle
  {

    private readonly double _Length;
    private readonly double _Width;

    public Rectangle(double length, double width)
    {
      _Length = length;
      _Width = width;
    }

    public double Area()
    {
      return _Length * _Width;
    }


    public void PrintHTML()
    {
      HTMLPrinter printer = new HTMLPrinter(); //smell - Rectangle has a dependnecy on HTMLPrinter
      //etc
    }


    public void PrintPDF()
    {
      PDFPrinter printer = new PDFPrinter();//smell - Rectangle has a dependnecy on PDFPrinter
      //etc
    }

  }


  public class HTMLPrinter
  {
  }


  public class PDFPrinter
  {
  }

}
