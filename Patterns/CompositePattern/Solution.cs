using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.CompositeSolution
{
  /// <summary>
  /// Use the Composite when:
  /// - You have a tree
  /// - You have groups or collections and by adding an interface you can treat the collection as one thing
  /// - You have items you need to distribute
  /// </summary>
  public class Solution
  {
    static void MainSolution(string[] args)
    {
      int goldForKill = 1023;
      Console.WriteLine("You have killed the Giant IE6 Monster and gained {0} gold!", goldForKill);

      var joe = new Person { Name = "Joe" };
      var jake = new Person { Name = "Jake" };
      var emily = new Person { Name = "Emily" };
      var sophia = new Person { Name = "Sophia" };
      var brian = new Person { Name = "Brian" };
      var oldBob = new Person { Name = "Old Bob" };
      var newBob = new Person { Name = "New Bob" };
      var bobs = new Group { Members = { oldBob, newBob } };//easily create nested data (a tree) without changing logic
      var developers = new Group { Name = "Developers", Members = { joe, jake, emily, bobs } };

      var parties = new Group { Members = { developers, sophia, brian } };

      //the implementation of the Gold property allows a group or individual to be modelled identically
      parties.Gold += goldForKill;
      parties.Stats();

      Console.ReadKey();
    }
  }

  /// <summary>
  /// Treating a collection as an individual is a key part of the Composite pattern 
  /// that enables nested data without changes in logic
  /// This enables trees to be modelled easily
  /// </summary>
  public class Group : Party
  {
    public string Name { get; set; }
    public List<Party> Members { get; set; }

    public Group()
    {
      Members = new List<Party>();
    }

    public int Gold
    {
      get
      {
        int totalGold = 0;
        foreach (var member in Members)
        {
          totalGold += member.Gold;
        }

        return totalGold;
      }
      set
      {
        var eachSplit = value / Members.Count;
        var leftOver = value % Members.Count;
        foreach (var member in Members)
        {
          member.Gold += eachSplit + leftOver;
          leftOver = 0;
        }
      }
    }

    public void Stats()
    {
      foreach (var member in Members)
      {
        member.Stats();
      }
    }
  }

  public class Person : Party
  {
    public string Name { get; set; }
    public int Gold { get; set; }

    public void Stats()
    {
      Console.WriteLine("{0} has {1} gold coins.", Name, Gold);
    }
  }

  public interface Party
  {
    int Gold { get; set; }
    void Stats();
  }
}
