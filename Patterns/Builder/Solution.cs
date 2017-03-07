using Patterns.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.BuilderSolution
{
  //object to be built
  public class Sandwich
  {
    public BreadType BreadType { get; set; }
    public bool IsToasted { get; set; }
    public CheeseType CheeseType { get; set; }
    public MeatType MeatType { get; set; }
    public bool HasMustard { get; set; }
    public bool HasMayo { get; set; }
    public List<string> Vegetables { get; set; }

    public Sandwich()
    {
    }
  }


  public abstract class SandwichBuilder
  {
    protected Sandwich sandwich;

    public Sandwich GetSandwich()
    {
      return sandwich;
    }

    public void CreateNewSandwich()
    {
      sandwich = new Sandwich();
    }

    /// <summary>
    /// Instead of setting all Properties at once, set one or a group of Properties in a method
    /// where logic can be added
    /// </summary>
    public abstract void ApplyCondiments();

    public abstract void ApplyMeatAndCheese();

    public abstract void ApplyVegetables();

    public abstract void PrepareBread();
  }


  //Build a specific type of Sandwich
  //No logic - this becomes a very clear data class
  public class ClubSandwichBuilder : SandwichBuilder
  { 

    public override void ApplyCondiments()
    {
      //ability to add logic during composition
      if (sandwich.BreadType == BreadType.WHITE)
      {
        sandwich.HasMayo = true;
        sandwich.IsToasted = true;
      }
      else
        sandwich.IsToasted = true;
    }


    public override void PrepareBread()
    {
      sandwich.BreadType = BreadType.WHOLEMEAL;
    }


    public override void ApplyMeatAndCheese()
    {
      sandwich.MeatType = MeatType.CHICKEN;
      sandwich.CheeseType = CheeseType.SWISS;
    }


    public override void ApplyVegetables()
    {
      sandwich.Vegetables = new List<string> { "Radish", "Lettuce" };
    }
  }


  //Build a specific type of Sandwich
  //No logic - this becomes a very clear data class
  public class WeekendSandwichBuilder : SandwichBuilder
  {
    Sandwich sandwich;

    public override void ApplyMeatAndCheese()
    {
      sandwich.MeatType = MeatType.BEEF;
      sandwich.CheeseType = CheeseType.CHEDDAR;
    }


    public override void ApplyVegetables()
    {
      sandwich.Vegetables = new List<string> { "Tomato", "Onion" };
    }


    public override void ApplyCondiments()
    {
      //ability to add logic during composition
      if(sandwich.BreadType == BreadType.WHITE)
      {
        sandwich.HasMayo = true;
        sandwich.IsToasted = true;
      }
      else
        sandwich.IsToasted = true;
    }


    public override void PrepareBread()
    {
      sandwich.BreadType = BreadType.RYE;
    }
  }


  /// <summary>
  /// Specifies the steps to build a Sandwich
  /// </summary>
  public class SandwichMaker
  {
    private readonly SandwichBuilder Builder_;

    public SandwichMaker(SandwichBuilder builder)
    {
      Builder_ = builder;
    }

    /// <summary>
    /// Logic to create a sandwich is in one place
    /// </summary>
    public void BuildSandwich()
    {
      //steps
      Builder_.CreateNewSandwich();
      Builder_.PrepareBread();
      Builder_.ApplyMeatAndCheese();
      Builder_.ApplyVegetables();
      Builder_.ApplyCondiments();
    }

    public Sandwich GetSandwich()
    {
      return Builder_.GetSandwich();
    }

  }



  public class Main
  {
    public void DoSomething()
    {
      var sandwichMaker = new SandwichMaker(new WeekendSandwichBuilder());
      Sandwich sandwich = sandwichMaker.GetSandwich();

      var clubSandwichMaker = new SandwichMaker(new ClubSandwichBuilder());
      Sandwich sandwich1 = sandwichMaker.GetSandwich();
    }
  }


}
