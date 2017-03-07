using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AntiPatterns.Factory1
{

  public class Smell1
  {

    public void main(string[] args)
    {
      string carName = args[0];
      IAuto car = GetCar(carName);
      car.TurnOn();
      car.TurnOff();
    }

    private IAuto GetCar(string carName)
    {
      //smell - to add a new car we need to modify existing code
      //violates the open-closed principle
      //becomes unreadable when there are a huge number of case statements
      switch (carName)
      {
        case "bmw":
          return new BMW335Xi();
        case "mini":
          return new MiniCooper();
        default:
          return new NullCar();
      }
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

