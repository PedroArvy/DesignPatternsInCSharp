using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiPatterns.InterfaceSegregation.Solution1
{

  /// <summary>
  /// Both emails and text messages will need these properties and methods
  /// </summary>
  public interface IMessage
  {
    IList<String> ToAddresses { get; set; }
    string MessageBody { get; set; }
    bool Send();
  }


  /// <summary>
  /// For emails, use inheritance to create an interface that extends IMessage, 
  /// perhaps from multiple other interfaces
  /// </summary>
  public interface ISmtpMessage : IMessage
  {
    string Subject { get; set; }
  }



  public class EmailMessage : ISmtpMessage
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

    public bool Send()
    {
      //Do the real work here
      return true;
    }
  }

}
