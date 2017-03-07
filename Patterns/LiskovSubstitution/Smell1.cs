using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.LiskovSubstitution.Smell1
{

  /// <summary>
  /// http://softwareengineering.stackexchange.com/questions/7055/what-is-the-most-frequently-used-design-pattern
  /// </summary>
  public abstract class BaseClass
  {
    public abstract void Method1();
    public abstract void Method2();
    public abstract void Method3();
  }

  public class Class1 : BaseClass
  {
    public override void Method1()
    {
      //...code here
    }

    public override void Method2()
    {
      //...code here
    }

    public override void Method3()
    {
      //...code here
    }
  }

  public class Class2 : BaseClass
  {
    public override void Method1()
    {
      //...code here
    }

    public override void Method2()
    {
      //...code here
    }

    public override void Method3()
    {
      //smell - Class2 cannot be substituted for Class1 because an exception will be thrown
      throw new NotImplementedException();
    }
  }


}
