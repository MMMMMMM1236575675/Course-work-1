using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp157
{
    internal class Choturukutnuk : IEnumerable, IComparable<Choturukutnuk>
    {
        public bool oznakaPeretun { get; private set; } = false;
        public Point A { get; }
        public Point B { get; }
        public Point C { get; }
        public Point D { get; }
        public Choturukutnuk(Point A, Point B, Point C, Point D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }
        public Vidrizok AB
        {
            get { return new Vidrizok(A, B); }
        }
        public Vidrizok BC
        {
            get { return new Vidrizok(B, C); }
        }
        public Vidrizok CD
        {
            get {  return new Vidrizok(C,D); }
        }
        public Vidrizok DA
        {
            get { return new Vidrizok(D,A); }
        }
        public double Perimetr
        {
            get { return AB.Lenght + BC.Lenght + CD.Lenght + DA.Lenght; }
        }
        public static void ChuPeretun(Choturukutnuk ch1, Choturukutnuk ch2)
        {
            foreach(Vidrizok v1 in ch1)
                foreach(Vidrizok v2 in ch2)
                    if (Vidrizok.IsPeretun(v1, v2))
                    {
                        ch1.oznakaPeretun = true;
                        ch2.oznakaPeretun = true;
                        return;
                    }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return AB;
            yield return BC;
            yield return CD;
            yield return DA;
        }
        int IComparable<Choturukutnuk>.CompareTo(Choturukutnuk ch)
        {
            return Perimetr.CompareTo(ch.Perimetr);
        }
    }
}
