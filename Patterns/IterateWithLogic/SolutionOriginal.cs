using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiPatterns.IterateWithLogic.Original
{
  /// <summary>
  /// 
  /// </summary>
  class SolutionPluralsight
  {

    private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
    {
      return painters.Where(p => p.IsAvailable).WithMinimum(p => p.EstimateCompensation(sqMeters));
    }

  }


  public static class EnumerableExtensions
  {
    /// <summary>
    /// Extermely hard to read but this is a utility function that remains far out of sight
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="sequence"></param>
    /// <param name="criterion"></param>
    /// <returns></returns>
    public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
      where T : class
      where TKey : IComparable<TKey> =>
      sequence
      .Select(obj => Tuple.Create(obj, criterion(obj)))
      .Aggregate((Tuple<T, TKey>)null,
        (best, current) => best == null
        || current.Item2.CompareTo(best.Item2) < 0 ? current : best)
      .Item1;
  }



  public interface IPainter
  {
    bool IsAvailable { get; }
    TimeSpan EstimateTimeToPaint(double sqMeters);
    double EstimateCompensation(double sqMeters);
  }


}
