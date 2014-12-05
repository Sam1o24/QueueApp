using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace QueueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //int time_c = args[0];     //время проведения
                //int n = args[1];          //количество касс
                //int t_oi = args[2];       //время обслуживания одной машины
                //int tm = args[3];         //поток машин в ед. времени
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка в типе входных параметров");
            }

            //int time_c =Convert.ToInt32(Console.ReadLine());
            int time_c = 4;     //время проведения
            int n = 3;          //количество касс
            int t_oi = 1;       //время обслуживания одной машины
            int tm = 7;         //поток машин в ед. времени

            ServiceSystem sys = new ServiceSystem();
            sys.MainMeth(time_c, n, t_oi, tm);
        }
    }
}
