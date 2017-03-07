using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiPatterns.IterateWithLogic.Alternative
{
  /// <summary>
  /// Petras solution - fix up the code, don't create hard to read Linq extensions
  /// </summary>
  class SolutionPetras
  {

    public void Main()
    {
    }

    /// <summary>
    /// Cleaned up method
    /// </summary>
    /// <param name="sqMeters"></param>
    /// <param name="painters"></param>
    /// <returns></returns>
    private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
    {
      if (painters == null || painters.Count() == 0)
        return null;

      IPainter cheapest = painters.First();

      foreach (IPainter painter in painters.Where(p => p.IsAvailable))
      {
          if (painter.EstimateCompensation(sqMeters) < cheapest.EstimateCompensation(sqMeters))
            cheapest = painter;        
      }

      return cheapest;
    }


    public interface IPainter
    {
      bool IsAvailable { get; }
      TimeSpan EstimateTimeToPaint(double sqMeters);
      double EstimateCompensation(double sqMeters);
    }

  }




}
