using System;

namespace TestSystem.Model
{
    public class Ct
    {
        public Ct() { }
        public Ct(int id,string tg, string a, string b, string c, string d, string da)
        {
            ID = id;
            TG = tg;
            A = a;
            B = b;
            C = c;
            D = d;
            DA = da;
        }
        public int ID { get; set; }
        public string TG { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string DA { get; set; }
    }

    public class WTest
    {
        public string UName { get; set; }
        public DateTime TDate { get; set; }
        public int INTV { get; set; }
        public double Score { get; set; }
    }
}
