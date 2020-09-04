using System;

namespace pr02_02_1
{
  class Program
  {
    SByte a = 0; 
    Byte b = 0; 
    Int16 с = 0; 
    Int32 d = 0; 
    Int64 e = 0; 
    string s = "";
    Exception ex = new Exception();
    object[] types = { a, b, c, d, e, s, ex };

    static void Main(string[] args)
    {
      foreach (object о in types)
      {
        string type;
        if (o.GetType().IsValueType) type = "Value type";
        else
        type = "Reference Type";
        Console.WriteLine("{0}: {1}", o.GetType(), type);
      }
      Console.WriteLine("Hello World!");
    }
  }
}
