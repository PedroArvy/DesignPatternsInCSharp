using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.Strategy.Solution
{


  public class Order
  {
    public enum ShippingOptions
    {
      UPS = 100,
      FedEx = 200,
      USPS = 300,
    };

    public ShippingOptions ShippingMethod { get; set; }

    public Address Destination { get; set; }
    public Address Origin { get; set; }
  }

  public class ShippingCostCalculatorService
  {
    readonly IShippingCostStrategy shippingCostStrategy;

    public ShippingCostCalculatorService(IShippingCostStrategy shippingCostStrategy)
    {
      this.shippingCostStrategy = shippingCostStrategy;
    }

    public double CalculateShippingCost(Order order)
    {
      return shippingCostStrategy.Calculate(order);
    }
  }

  /// <summary>
  /// This is the key to the strategy pattern
  /// New interfaces can be created which don't affect code in existing interface implementations
  /// </summary>
  public interface IShippingCostStrategy
  {
    double Calculate(Order order);
  }


  /// <summary>
  /// Class has single responsibility
  /// </summary>
  public class FedExShippingCostStrategy : IShippingCostStrategy
  {
    public double Calculate(Order order)
    {
      return 5.00d;
    }
  }


  /// <summary>
  /// Class has single responsibility
  /// </summary>
  public class UPSShippingCostStrategy : IShippingCostStrategy
  {
    public double Calculate(Order order)
    {
      return 4.25d;
    }
  }


  /// <summary>
  /// Class has single responsibility
  /// </summary>
  public class USPSShippingCostStrategy : IShippingCostStrategy
  {
    public double Calculate(Order order)
    {
      return 3.00d;
    }
  }

}
