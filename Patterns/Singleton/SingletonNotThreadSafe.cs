using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.Singleton
{
  /// <summary>
  /// Should 
  /// </summary>
  public class SingletonNotThreadSafe
  {

    private static SingletonNotThreadSafe _Instance;


    public static SingletonNotThreadSafe Instance
    {
      get
      {
        if (_Instance == null)
          _Instance = new SingletonNotThreadSafe();

        return _Instance;
      }
    }

    /// <summary>
    /// ensure only Signleton can create an instance
    /// </summary>
    private SingletonNotThreadSafe()
    {
    }


    public void DoStuff()
    {
    }

  }
}
