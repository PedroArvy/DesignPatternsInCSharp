using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//smell - only required because we needed to Design members
//whenever you have code that works and is complete and you want to extend it 
//but need to add a dependency, you are breaking the Single Responsiblity Principle 
//not an inheritance issue directly, but often arsies in inhertiance heirarchies
//using Spanman.DesignLibrary;

/// <summary>
/// Inheritance that breaks Single Responsibility Pattern
/// </summary>
namespace Patterns.LiskovSubstitution.Smell4
{
  public abstract class Member
  {
    public int Length { get; set; }

    public abstract int DeadLoad();

    /// <summary>
    /// smell - method does nothing, correct but becomes very hard to read and debug
    /// </summary>
    /// <returns></returns>,
    public virtual bool DesignCrane()
    {
      return true;
    }


    protected virtual bool DesignDeadLoad()
    {
      bool ok = true;

      if (DeadLoad() > 100)
        ok = false;

      return ok;
    }


    public virtual bool Design()
    {
      bool ok = true;

      DesignDeadLoad();
      DesignCrane();

      return ok;
    }
  }


  public class FloorMember : Member
  {
    public int FloorWidth { get; set; }
    public int FloorWeight { get; set; }
    public int WallAboveHeight { get; set; }
    public int WallAboveWeight { get; set; }
    public int RoofWeight { get; set; }
    public int RoofWidthSupported { get; set; }

    public override int DeadLoad()
    {
      return FloorWidth * FloorWeight + WallAboveHeight * WallAboveWeight + RoofWeight * RoofWidthSupported;
    }
  }


  /// <summary>
  /// 2 levels of inheritance, although not technically a problem, 
  /// makes code very hard to read
  /// </summary>
  public class FloorBeam : FloorMember {}

  public class FloorJoist : FloorMember {}


  public class Rafter : Member
  {
    public int CraneLoad { get; set; }
    public int Spacing { get; set; }
    public int RoofWeight { get; set; }

    public override int DeadLoad()
    {
      return Spacing * RoofWeight;
    }

    /// <summary>
    /// smell
    /// </summary>
    /// <returns></returns>
    public override bool DesignCrane()
    {
      bool ok = true;

      if (CraneLoad > 100)
        ok = false;

      return ok;
    }


  }


  public class Lintel : Member
  {
    public int WallAboveHeight { get; set; }
    public int WallAboveWeight { get; set; }
    public int RoofWeight { get; set; }
    public int RoofWidthSupported { get; set; }

    public override int DeadLoad()
    {
      return WallAboveWeight * WallAboveHeight + RoofWeight * RoofWidthSupported;
    }
  }


  public class Main
  {
    public void DoSomething()
    {
      Member member = new FloorBeam();
      int load = member.DeadLoad();

      member = new FloorJoist();
      load = member.DeadLoad();

      member = new Lintel();
      load = member.DeadLoad();

      member = new Rafter();
      load = member.DeadLoad();
    }
  }


}
