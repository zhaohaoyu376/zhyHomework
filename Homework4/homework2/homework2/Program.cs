using System;

namespace homework2
{
    class Program
    {


    static void Main(string[] args)
        {
            //Console.WriteLine("111111111111");
            Clock clock = new Clock();

            Time T1 = new Time()
            {
                S = 0,
                M = 0,
                H = 0
            };

            Time T2 = new Time()
            {
                S = 10,
                M = 5,
                H = 0
            };

            clock.SetTime(T1);
            clock.SetAlarm(T2);
            clock.Tick += (T1 => {
                Time T01 = clock.GetTime();
                if (++T01.S == 60)
                {
                    T01.S = 0;
                    T01.M += 1;
                    if (T01.M == 60)
                    {
                        T01.M = 0;
                        T01.H += 1;
                        if (T01.H == 24)
                        {
                            T01.H = 0;
                        }
                    }
                }
                clock.SetTime(T01);

                Console.WriteLine($"现在：{T01.H}:{T01.M}:{T01.S}");
            });

            clock.Alarm += (T2 => {
                Time T01 = clock.GetTime();
                Time T02 = clock.GetAlarm();
                if (T01.S == T02.S && T01.M == T02.M && T01.H == T02.H)
                {
                    Console.WriteLine("闹钟响了");
                }
            });

            clock.StartRunning();
        }
    }


    public class Time
    {
        public int S { get; set; }
        public int M { get; set; }
        public int H { get; set; }
    }

    public delegate void AlarmClock(Time t);
    public class Clock
    {
        private Time newTime = new Time()
        {
            S = 0,
            M = 0,
            H = 0
        };
        private Time alarm;

        public event AlarmClock Tick;
        public event AlarmClock Alarm;

        public void SetTime(Time t)
        {
            if (IfTimeRight(t))
            {
                newTime = t;
            }
            else
            {
                Console.WriteLine("输入时间错误！");
            }
        }
        public Time GetTime()
        {
            return newTime;
        }
        public void SetAlarm(Time t)
        {
            if (IfTimeRight(t))
            {
                alarm = t;
            }
            else
            {
                Console.WriteLine("输入时间错误！");
            }
        }
        public Time GetAlarm()
        {
            return alarm;
        }
        public void StartRunning()
        {

            do
            {
                Tick(newTime);
                Alarm(alarm);
            } while (true);
        }
        public bool IfTimeRight(Time T)
        {
            if (T.S < 0 || T.S > 60)
            {
                return false;
            }
            else
            {
                if (T.M < 0 || T.M > 60)
                {
                    return false;
                }
                else
                {
                    if (T.H < 0 || T.H > 24)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
    }
}
