namespace ConsoleApp2
{
    public interface ITest
    {
        double Felszin();
        double Terfogat();
    }
    public interface IKezel
    {

        /// <summary>
        /// A megadott mennyiséget betölti a testbe.
        /// </summary>
        /// <param name="mennyit">A töltés mennyisége.</param>
        void Tolt(double mennyit);
        /// <summary>
        /// Kiüríti a testet, így a töltöttsége 0% lesz!
        /// </summary>

        void Kiurit();
        //Megadja, hogy a test térfogata mekkora %-ban van kitöltve.
        double JelenlegiToltottsegSzazalekban { get; }
    }
    public class Gomb : ITest,IKezel
    {
        double sugar;
        double toltet;
        public double JelenlegiToltottsegSzazalekban => toltet/Terfogat()*100;

        public Gomb(double sugar)
        {
            this.sugar = sugar;
        }

        public double Felszin()
        {
            return 4*Math.PI*Math.Pow(sugar,2);
        }
        public double Terfogat()
        {
            return 4*sugar*Math.PI/3*Math.Pow(sugar,3);
        }

        public void Tolt(double mennyit)
        {
            if (toltet+mennyit > Terfogat())
            {
                throw new OverflowException();
            }
            else
            {
                toltet += mennyit;
            }
        }

        public void Kiurit()
        {
            toltet = 0;
        }

        public override string? ToString()
        {
            return $"Sugár:{sugar}, Töltet:{toltet}";
        }
        
    }
    public class Teglatest : ITest, IKezel
    {
        double aEl, bEl, cEl;
        double toltet;
        public double JelenlegiToltottsegSzazalekban => toltet / Terfogat() * 100;

        public Teglatest(double aEl, double bEl, double cEl)
        {
            this.aEl = aEl;
            this.bEl = bEl;
            this.cEl = cEl;
        }

        public double Felszin()
        {
            return 2*(aEl*bEl+aEl*cEl+bEl*cEl);
        }
        public double Terfogat()
        {
            return aEl*bEl*cEl;
        }
        public void Tolt(double mennyit)
        {
            if (toltet + mennyit > Terfogat())
            {
                throw new OverflowException();
            }
            else
            {
                toltet += mennyit;
            }
        }

        public void Kiurit()
        {
            toltet = 0;
        }
        public override string? ToString()
        {
            return $"aÉl:{aEl}; bÉl:{bEl}; cÉl:{cEl}; Töltet:{toltet}";
        }
    }
    public class Henger : ITest,IKezel
    {
        double magassag;
        double sugar;
        double toltet;
        public double JelenlegiToltottsegSzazalekban => toltet / Terfogat() * 100;

        public Henger(double magassag, double sugar)
        {
            this.magassag = magassag;
            this.sugar = sugar;
        }

        public double Felszin()
        {
            return 2*Math.Pow(sugar,2)*Math.PI+2*sugar*Math.PI*magassag;
        }
        public double Terfogat()
        {
            return Math.Pow(sugar, 2) * Math.PI * magassag;
        }
        public void Tolt(double mennyit)
        {
            if (toltet + mennyit > Terfogat())
            {
                throw new OverflowException();
            }
            else
            {
                toltet += mennyit;
            }
        }

        public void Kiurit()
        {
            toltet = 0;
        }

        public override string? ToString()
        {
            return $"Sugár:{sugar}; Magasság:{magassag}; Töltet:{toltet}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

}