using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace QueueApp
{
    class ServiceSystem
    {
        double time_c; //время проведения

        public double Time_c
        {
            get { return time_c; }
            set { if (value>0) time_c = value; }
        }
        double time_now; //текущее время в системе

        public double Time_now
        {
            get { return time_now; }
            set { time_now = value; }
        }

        public ServiceSystem()
        {
        }

        public void MainMeth(int t_c,int n,int t_oi,int tm)
        {

            this.Time_c = t_c;
            List<Cas> mass;
            mass = StartSys(n, t_oi);

            while (time_now < time_c)
            {
                //Console.WriteLine("Общее время {0}", time_now);
                Div_queue(mass, tm);
                WorkCas(mass);
                Time_now++;
                Console.WriteLine();
            }

            int sum_mr = 0;
            int sum_mtr = 0;
            for (int i = 0; i < mass.Count; i++)
            {
                sum_mr += mass[i].Mr;
                sum_mtr += mass[i].Mtr;
            }

            Console.WriteLine("Всего обслужено:{0} Общая очередь:{1}",sum_mr,sum_mtr);
        }

        List<Cas> StartSys(int n, int t_oi)      //создание касс
        {
            List<Cas> mass = new List<Cas>() ;
            for (int i = 0; i < n; i++)
            {
                mass.Add(new Cas(i,t_oi));
            }
            return mass;
        }

        void Div_queue(List<Cas> mass,int tm)    //распределение очереди
        {
            int tm_now = tm; 
            Random rnd = new Random();
        
            int add_count = 1;   //по сколько раздавать

            while (tm_now > 0)
            {
              int k = rnd.Next(0, mass.Count); //определяет номер кассы в очередь которой будет добавление

              if (tm_now < add_count) add_count = tm_now;

              mass[k].Inc_mtr(add_count);
              tm_now = tm_now - add_count;
            }
        }

        void WorkCas(List<Cas> mass)
        {
            Thread[] mass_th = new Thread[mass.Count];

            for (int i = 0; i < mass.Count; i++)
            {
                mass_th[i] = new Thread(mass[i].Work);
            }

            for (int i = 0; i < mass.Count; i++)
            {
                mass_th[i].Start();
            }

            for (int i = 0; i < mass.Count; i++)
            {
                mass_th[i].Join();
            }
        }

        bool CheckInputVal(int t_c, int n, int t_oi, int tm)
        {
            CheckParam(t_c, "Время наблюдения");
            CheckParam(n, "Количество касс");
            CheckParam(t_oi, "Время обслуживания");
            CheckParam(tm, "Количество машин в ед. времени");
            return true;
        }

        bool CheckParam(int param,string s)
        {
            if (param <= 0) { Console.WriteLine(s + " должно быть положительным"); return false; };
            return true;
        }
    }
}
