using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.LiskovSubstitution.Smell2
{

  /// <summary>
  /// http://softwareengineering.stackexchange.com/questions/7055/what-is-the-most-frequently-used-design-pattern
  /// </summary>
  public interface IBaseClass
  {
    void Method1();
    void Method2();
  }
  
  /// <summary>
  /// Use Interface segreggation to remove NotImplementedExceptions
  /// </summary>
  public interface IBaseClass1 : IBaseClass
  {
    void Method3();
  }


  public class Class1 : IBaseClass1
  {
    public  void Method1()
    {
      //...code here
    }

    public  void Method2()
    {
      //...code here
    }

    public  void Method3()
    {
      //...code here
    }
  }

  public class Class2 : IBaseClass
  {
    public  void Method1()
    {
      //...code here
    }

    public  void Method2()
    {
      //...code here
    }

  }

}
