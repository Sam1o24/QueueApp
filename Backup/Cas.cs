using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueApp
{
    class Cas
    {
        int num;        //номер кассы

        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        int t_oi;    //время обслуживания одной машины

        public int T_oi
        {
            get { return t_oi; }
            set { t_oi = value; }
        }
        int mr;         //количество обсуженных машин

        public int Mr
        {
            get { return mr; }
            set { mr = value; }
        }
        int mtr;        //очередь

        public int Mtr
        {
            get { return mtr; }
            set { mtr = value; }
        }
        int t_now;      //время обслуживания текущей машины

        public int T_now
        {
            get { return t_now; }
            set { t_now = value; }
        }

        public Cas()
        { 
        }

        public Cas(int num,int t)
        {
            this.Num = num;
            this.T_oi = t;
            this.Mr = 0;
            this.Mtr = 0;
        }

        public void Inc_mtr(int inc)
        {
            if (inc >0) this.Mtr += inc;
        }

        public void Work()
        {
            if (this.mtr <= 0) 
            {
                Console.WriteLine("№ {0} обслужено:{1} в очереди:{2}", this.Num, this.Mr, this.Mtr);
                return;
            }

            T_now++;
            if (T_now >= T_oi)
            {
                this.Mr++;
                this.Mtr--;
                T_now = 0;
            }
            Console.WriteLine("№ {0} обслужено:{1} в очереди:{2}", this.Num, this.Mr, this.Mtr);
            //Console.WriteLine("№ {0} обслужено:{1} в очереди:{2} обслуживание текущей:{3}", this.Num,this.Mr,this.Mtr,this.T_now);
        }
    }
}
