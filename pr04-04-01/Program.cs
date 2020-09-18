using System;
using System.Globalization;
using System.Collections;
using System.Collections.Specialized;


namespace pr04_04_01
{
  class Program
  {
    static void Main(string[] args)
    {
      ListDictionary list = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));
  
      list["Estados Unidos"] = "United States of America";
      list["Canada"] = "Canada";
      list["Espana"] = "Spain";
     
      Console.WriteLine(list["espana"]);
      Console.WriteLine(list["CANADA"]);
      Console.Read();

    }
  }
}
