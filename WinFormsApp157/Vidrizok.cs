using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp157
{
    internal class Vidrizok
    {
        Point p1;
        Point p2;
        public Vidrizok(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public double Lenght
        {
            get {return Math.Sqrt(Math.Pow(p1.X-p2.X,2)+Math.Pow(p1.Y-p2.Y,2));}
        }
        (long a, long b, long c) Pryama
        {
            get { return (p2.Y - p1.Y, p1.X - p2.X, (long)p1.Y * p2.X - (long)p1.X * p2.Y); }
        }
        public bool GetPorizni(Point p1, Point p2)
        {
            long res1 = Pryama.a*p1.X+Pryama.b*p1.Y+Pryama.c;
            long res2 = Pryama.a*p2.X+Pryama.b*p2.Y+Pryama.c;
            if (res1 * res2 < 0)
                return true;
            return false;
        }
        public static bool IsPeretun(Vidrizok v1, Vidrizok v2)
        {
            if(v1.GetPorizni(v2.p1, v2.p2)&&v2.GetPorizni(v1.p1,v1.p2))
                return true;
            return false;
        }
    }
}
