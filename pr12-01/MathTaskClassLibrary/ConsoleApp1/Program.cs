using System;
using MathTaskClassLibrary;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      Geometry gc = new Geometry();
      int a = 4;
      int b = 7;
      //RectangleArea(a, b);
      Console.WriteLine(gc.RectangleArea(a, b));
    }
  }
}
