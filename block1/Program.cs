using System;
using System.Threading;

class Program
{
  static void Main(string[] args)
  {
    Timer timer1 = new(CustomMethod1, 1000);
    Timer timer2 = new(CustomMethod2, 500);
    Console.ReadLine();
    timer1.Stop();

    Console.ReadLine();
    timer2.Stop();
  }
  public static void CustomMethod1()
  {
    Console.WriteLine("Hello, world!");
  }
  public static void CustomMethod2()
  {
    Console.WriteLine("Hello, kitty!");

  }


}

public class Timer
{
  private int _time;
  public delegate void Method();
  private bool isActive;
  private Thread timerThread;

  public Timer(Method method, int time)
  {
    _time = time;
    isActive = true;
    timerThread = new Thread(() => Start(method));
    timerThread.IsBackground = true;
    timerThread.Start();
  }

  private void Start(Method method)
  {
    while (isActive)
    {
      method();
      Thread.Sleep(_time);
    }
  }

  public void Stop()
  {
    isActive = false;
    if (timerThread.IsAlive)
    {
      timerThread.Join();
    }
  }
}
