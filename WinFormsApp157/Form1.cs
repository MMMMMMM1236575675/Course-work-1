namespace WinFormsApp157
{
    public partial class Form1 : Form
    {
        List<Choturukutnuk>listChoturukutnuk;
        Choturukutnuk minCh;
        Choturukutnuk maxCh;
        public Form1()
        {
            InitializeComponent();
            listChoturukutnuk = new List<Choturukutnuk>();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Choturukutnuk ch in listChoturukutnuk)
            {
                Pen pen = new Pen(Color.Green);
                if (ch.oznakaPeretun)
                    pen = new Pen(Color.Blue, 3);
                e.Graphics.DrawPolygon(pen,new Point[] {ch.A,ch.B,ch.C,ch.D});
            }
            e.Graphics.DrawPolygon(new Pen(Color.Red,3), new Point[] { minCh.A, minCh.B, minCh.C, minCh.D });
            e.Graphics.DrawPolygon(new Pen(Color.Red,3), new Point[] { maxCh.A, maxCh.B, maxCh.C, maxCh.D });

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(@"C:\1\choturukutnuk.txt");
            string str = "";
            while (true)
            {
                str = streamReader.ReadLine();
                if (str == null)
                    break;
                string[] arrSt = str.Split(',',' ', ';' );
                listChoturukutnuk.Add(new Choturukutnuk(
                    new Point(int.Parse(arrSt[4]),int.Parse(arrSt[8])),
                    new Point(int.Parse(arrSt[12]),int.Parse(arrSt[16])),
                    new Point(int.Parse(arrSt[20]), int.Parse(arrSt[24])),
                    new Point(int.Parse(arrSt[28]), int.Parse(arrSt[32]))
                    ));
            }
            for (int i = 0; i < listChoturukutnuk.Count; i++)
                for (int j = i + 1; j < listChoturukutnuk.Count; j++)
                    Choturukutnuk.ChuPeretun(listChoturukutnuk[i], listChoturukutnuk[j]);
            minCh = listChoturukutnuk.Where((ch1) => ch1.oznakaPeretun).Min();
            maxCh = listChoturukutnuk.Where((ch2)=>ch2.oznakaPeretun).Max();

        }
    }
}