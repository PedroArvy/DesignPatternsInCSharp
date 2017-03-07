using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace AntiPatterns.Factory2
{

  public class Solution
  {

    public void main(string[] args)
    {
      string carName = args[0];

      SimpleFactory factory = new SimpleFactory();
      IAuto car = factory.CreateInstance("BMW335Xi");

      car.TurnOn();
      car.TurnOff();
    }


    /// <summary>
    /// Could also be an instance of IAutoFactory if there is more than one factory
    /// In that case, you may wish to inject the factory type via configuration
    /// </summary>
    public class SimpleFactory
    {
      private Dictionary<string, Type> _Autos;

      public Dictionary<string, Type> Autos
      {
        get
        {
          if (_Autos == null)
            _Autos = LoadTypesICanReturn();

          return _Autos;
        }
      }


      /// <summary>
      /// Generic method - will work on new Auto's
      /// </summary>
      /// <param name="name"></param>
      /// <returns></returns>
      public IAuto CreateInstance(string name)
      {
        Type t = GetTypeToCreate(name);

        if (t == null)
          return new NullCar();

        return Activator.CreateInstance(t) as IAuto;
      }


      /// <summary>
      /// Generic method - will work on new Auto's
      /// </summary>
      /// <param name="name"></param>
      /// <returns></returns>
      private Type GetTypeToCreate(string name)
      {
        Type t = null;

        foreach (var auto in Autos)
        {
          if (auto.Key.Contains(name.ToLower()))
          {
            t = Autos[auto.Key];
            break;
          }
        }

        return t;
      }


      /// <summary>
      /// Use reflection to get all IAutos
      /// </summary>
      /// <returns></returns>
      private Dictionary<string, Type> LoadTypesICanReturn()
      {
        string typeName;
        Dictionary<string, Type> autos = new Dictionary<string, Type>();

        Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

        foreach (Type type in typesInThisAssembly)
        {
          typeName = typeof(IAuto).Name.ToString();

          if (type.GetInterface(typeName) != null
            && !autos.Keys.Any(k => k.ToLower() == type.Name.ToLower()))
          {
            autos.Add(type.Name.ToLower(), type);
          }
        }

        return autos;
      }

      public void Test()
      {
        Dictionary<string, Type> autos = Autos;
      }

    }

    public interface IAuto
    {
      void TurnOn();
      void TurnOff();
    }

    public class BMW335Xi : IAuto
    {
      public void TurnOn()
      {
      }

      public void TurnOff()
      {
      }
    }

    public class MiniCooper : IAuto
    {
      public void TurnOn()
      {
      }

      public void TurnOff()
      {
      }
    }

    public class NullCar : IAuto
    {
      public void TurnOn()
      {
      }

      public void TurnOff()
      {
      }
    }

  }
}