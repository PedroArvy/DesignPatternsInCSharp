using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.Singleton
{
  public class SampleUsage
  {
    public void SomeMethod()
    {
      // Call Singleton's DoStuff() method 
      SingletonNotThreadSafe.Instance.DoStuff();

      // Assign to another variable 
      var myObject = SingletonNotThreadSafe.Instance;
      myObject.DoStuff();

      // Pass as parameter 
      SomeOtherMethod(SingletonNotThreadSafe.Instance); 
    }


    private void SomeOtherMethod(SingletonNotThreadSafe singleton)
    {
      singleton.DoStuff();
    }
  }