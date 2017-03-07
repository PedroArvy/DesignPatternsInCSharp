using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns
{
  public class Program
  {
    public static void Main(string[] args)
    {
      AntiPatterns.Factory2.Solution solution = new AntiPatterns.Factory2.Solution();

      string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
      solution.main(weekDays);


    }
  }
}
