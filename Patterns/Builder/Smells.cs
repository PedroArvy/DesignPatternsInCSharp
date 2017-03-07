using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//smell - extending a previously completed class by adding a new dependency breaks the Single Responsiblity Principle
//using MyLibrary.NewCode;

namespace Patterns.Builder
{
  public enum BreadType { WHITE, WHOLEMEAL, RYE };
  public enum CheeseType { SWISS, CHEDDAR, BLUE };
  public enum MeatType { BEEF, CHICKEN }

  public class Sandwich
  {
    public BreadType BreadType { get; set; }
    public bool IsToasted { get; set; }
    public CheeseType CheeseType { get; set; }
    public MeatType MeatType { get; set; }
    public bool HasMustard { get; set; }
    public bool HasMayo { get; set; }
    public List<string> Vegetables { get; set; }

    /// <summary>
    /// smell - which constructor should be used?
    /// </summary>
    public Sandwich()
    {
    }


    public Sandwich(BreadType breadType, bool isToasted, CheeseType cheeseType, MeatType meatType, bool hasMustard, bool hasMayo, List<string> vegetables)
    {
      BreadType = breadType;
      IsToasted = isToasted;
      CheeseType = cheeseType;
      MeatType = meatType;
      HasMustard = hasMustard;
      HasMayo = hasMayo;
      Vegetables = vegetables;
    }

    //smell - possibility of more than one constructor to deal with different possibilities 
    //But hard to know which constructor
    public Sandwich(BreadType breadType, bool isToasted, CheeseType cheeseType)
    {
      BreadType = breadType;
      IsToasted = isToasted;
      CheeseType = cheeseType;
    }


  }


  public class Main
  {
    public void DoSomething()
    {
      //Used when you are creating fixed objects by altering Properties in a single class

      //smell
      //Large number of parameters in constructor 
      Sandwich sandwich = new Sandwich(BreadType.RYE, true, CheeseType.SWISS, MeatType.BEEF, true, false, new List<string> { "Tomato", "Radish" });

      //smell - or it is unclear which Properties to set
      Sandwich sandwich1 = new Sandwich()
      {
        //smell - can't control the order of setting properties in case logic (e.g. validation) 
        //has to be performed
        //Or in case some Properties shouldn'rt be set until other Properties are set
        BreadType = BreadType.RYE,
        CheeseType = CheeseType.CHEDDAR,
        HasMayo = true,
        IsToasted = true
      };

      //smell - there are fixed object created from a single class
    }
  }


}
