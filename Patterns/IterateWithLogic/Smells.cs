using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiPatterns.IterateWithLogic
{
  /// <summary>
  /// https://app.pluralsight.com/library/courses/c-sharp-code-more-object-oriented/table-of-contents
  /// Keeping the Focus on Domain Logic with Sequences
  /// </summary>
  class Smells
  {

    public void Main()
    {
    }

    /// <summary>
    /// Smell - Hard to read
    /// Smell - Hard to prove if correct
    /// Smell - If there is a bug, can you tell if it is here or somewhere else
    /// </summary>
    /// <param name="sqMeters"></param>
    /// <param name="painters"></param>
    /// <returns></returns>
    private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
    {
      double bestPrice = 1000000;
      IPainter cheapest = null;

      foreach(IPainter painter in painters)
      {
        if(painter.IsAvailable)
        {
          double price = painter.EstimateCompensation(sqMeters);

          if (cheapest == null || price < bestPrice)
          {
            cheapest = painter;
            price = bestPrice;
          }
        }
      }

      return cheapest;
    }

  }


  public interface IPainter
  {
    bool IsAvailable { get; }
    TimeSpan EstimateTimeToPaint(double sqMeters);
    double EstimateCompensation(double sqMeters);
  }

}
