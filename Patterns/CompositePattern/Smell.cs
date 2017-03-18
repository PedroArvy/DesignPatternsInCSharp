using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.CompositeSmell
{
  /// <summary>
  /// Use the Composite when:
  /// - You have a tree
  /// - You have groups or collections and by adding an interface you can treat the collection as one thing
  /// - You have items you need to distribute
  /// </summary>
  public class Smell
  {

    static void CompositeMain(string[] args)
    {
      int goldForKill = 1023;
      Console.WriteLine("You have killed the Giant IE6 Monster and gained {0} gold!", goldForKill);

      var joe = new Person { Name = "Joe" };
      var jake = new Person { Name = "Jake" };
      var emily = new Person { Name = "Emily" };
      var sophia = new Person { Name = "Sophia" };
      var brian = new Person { Name = "Brian" };
      var developers = new Group { Name = "Developers", Members = { joe, jake, emily } };

      //smell - need two different collection types to sove the problem
      var individuals = new List<Person> { sophia, brian };
      var groups = new List<Group> { developers };

      //smell - big ball of mud to follow
      //hard to see intent
      var totalToSplitBy = individuals.Count + groups.Count;

      var amountForEach = goldForKill / totalToSplitBy;
      var leftOver = goldForKill % totalToSplitBy;

      foreach (var individual in individuals)
      {
        individual.Gold += amountForEach + leftOver;
        leftOver = 0;
        individual.Stats();
      }

      foreach (var group in groups)
      {
        var amountForEachGroupMember = amountForEach / group.Members.Count;
        var leftOverForGroup = amountForEachGroupMember % group.Members.Count;
        foreach (var member in group.Members)
        {
          member.Gold += amountForEachGroupMember + leftOverForGroup;
          leftOverForGroup = 0;
          member.Stats();
        }
      }

      Console.ReadKey();
    }

  }


  public class Group
  {
    public string Name { get; set; }
    public List<Person> Members { get; set; }

    public Group()
    {
      Members = new List<Person>();
    }
  }


  public class Person
  {
    public string Name { get; set; }
    public int Gold { get; set; }

    public void Stats()
    {
      Console.WriteLine("{0} has {1} gold coins.", Name, Gold);
    }
  }

}
