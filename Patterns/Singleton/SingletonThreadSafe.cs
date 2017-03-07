using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.Singleton
{
  //The c# compiler will guarantee the a type initialiser is instantiated lazily only if it is not marked with 
  //a special flag called before field init
  //To ensure it is *not marked* with this flag create a static constructor
  //Although not used for anything it is important because of the C# compiler functionality.
  public class LazySingletonThreadSafe
  {
    private LazySingletonThreadSafe()
    {}

    public static LazySingletonThreadSafe Instance
    {
      get{ return Nested.instance; }
    }

    private class Nested
    {
      static Nested() { }
      internal static readonly LazySingletonThreadSafe instance = new LazySingletonThreadSafe();
    }
  }
}
