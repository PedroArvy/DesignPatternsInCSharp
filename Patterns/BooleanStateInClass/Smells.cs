using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiPatterns.BooleanDecisionsInClass
{

  public class BankAccount
  {
    private decimal _Amount;

    /// <summary>
    /// Smell - object can hvae a state
    /// Account can be closed
    /// </summary>
    public bool Closed { get; set; }

    /// <summary>
    /// Smell - object can hvae a state
    /// Frozen due to security concers
    /// </summary>
    public bool Frozen { get; set; }

    /// <summary>
    /// Smell - object can hvae a state
    /// New accounts new to be approved
    /// </summary>
    public bool UnApproved { get; set; }


    /// <summary>
    /// Smeell - Boolean state can create a lots of unit test per method to test all possible combinations
    /// Logic becomes obscure with multiple if statements (in real situations, more than here)
    /// </summary>
    /// <param name="amount"></param>
    public void Deposit(decimal amount)
    {
      if (!Frozen && !Closed) //smell - decision based on object state
        _Amount += amount;
    }


    public void Withdrawl(decimal amount)
    {
      if (!UnApproved && !Closed && !Frozen) //smell - decision based on object state
        _Amount += amount;
    }

  }



}
