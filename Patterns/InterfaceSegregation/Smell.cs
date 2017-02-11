using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://www.intertech.com/Blog/the-interface-segregation-principle-with-c-examples/
/// </summary>
namespace AntiPatterns.InterfaceSegregation.Smell1
{

  public interface IMessage
  {
    IList<String> ToAddresses { get; set; }
    string MessageBody { get; set; }
    string Subject { get; set; }
    bool Send();
  }


  public class EmailMessage : IMessage
  {
    public IList<String> ToAddresses { get; set; }
    public string MessageBody { get; set; }
    public string Subject { get; set; }

    public bool Send()
    {
      //Do the real work here
      return true;
    }
  }


  public class TextMessage : IMessage
  {
    public IList<String> ToAddresses { get; set; }
    public string MessageBody { get; set; }


    /// <summary>
    /// Text messages don't need a subject
    /// Smell - the interface has too many members as implementers throw NotImplementedExceptions
    /// </summary>
    public string Subject {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }


    public bool Send()
    {
      //Do the real work here
      return true;
    }
  }


}
