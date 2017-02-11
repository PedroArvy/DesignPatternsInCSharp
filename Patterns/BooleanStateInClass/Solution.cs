using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiPatterns.BooleanDecisionsInClass
{

  public class Account
  {
    private decimal _Balance;
    public IState State  { get; set; }


    public Account()
    {
      State = new UnApproved();
    }


    public void Approve()
    {
      State = new Active();
    }


    public void Close()
    {
      State = new Closed();
    }


    public void Deposit(decimal amount)
    {
      State.Deposit(() => { this._Balance += amount; });
    }


    public void Freeze()
    {
      State = new Frozen();
    }


    public void Withdrawl(decimal amount)
    {
      State.Withdraw(() => { this._Balance -= amount; });
    }

  }


  public interface IState
  {
    IState Deposit(Action addToBalance);
    IState Withdraw(Action removeFromBalance);
  }


  public class Active : IState
  {
    public IState Deposit(Action addToBalance)
    {
      addToBalance();
      return this;
    }

    public IState Withdraw(Action removeFromBalance)
    {
      removeFromBalance();
      return this;
    }
  }


  public class UnApproved : IState
  {
    public IState Deposit(Action addToBalance) 
    {
      addToBalance();
      return new Active();
    }

    public IState Withdraw(Action removeFromBalance)
    {
      return this;
    }
  }


  public class Closed : IState
  {
    public IState Deposit(Action addToBalanace) => this;

    public IState Withdraw(Action removeFromBalance) => this;
  }


  public class Frozen : IState
  {
    public IState Deposit(Action addToBalance)
    {
      addToBalance();
      return new Active();
    }

    public IState Withdraw(Action removeFromBalance) => this;
  }


}
