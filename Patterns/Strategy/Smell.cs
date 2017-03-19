using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns.Strategy.Smell
{

  public class ShippingCostCalculatorService
  {
    public double CalculateShippingCost(Order order)
    {
      //smell - switch statement
      //in order to add a new shipping method, the switch statement would have to be modified
      switch (order.ShippingMethod)
      {
        case Order.ShippingOptions.FedEx:
          return CalculateForFedEx(order);

        case Order.ShippingOptions.UPS:
          return CalculateForUPS(order);

        case Order.ShippingOptions.USPS:
          return CalculateForUSPS(order);

        default:
          throw new UnknownOrderShippingMethodException();

      }

    }

    double CalculateForUSPS(Order order)
    {
      return 3.00d;
    }

    double CalculateForUPS(Order order)
    {
      return 4.25d;
    }

    double CalculateForFedEx(Order order)
    {
      return 5.00d;
    }
  }


  public class Address
  {
    public string ContactName { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }

    public string PostalCode { get; set; }
  }


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


  public class UnknownOrderShippingMethodException : Exception
  {
  }


}
