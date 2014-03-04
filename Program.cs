using System;

namespace lab1
{

	public class Samochod
	{
		private string marka;
		private string model;
		private int iloscDrzwi;
		private int pojemnoscSilnika;
		private double srednieSpalanie;
		private static int liczbaSamochodow = 0;

		public string Marka
		{
			get {return marka; }
			set { marka = value; }
		}

		public string Model
		{
			get {return model; }
			set { model = value; }
		}

		public int IloscDrzwi
		{
			get {return iloscDrzwi; }
			set { iloscDrzwi = value; }
		}

		public int PojemnoscSilnika
		{
			get {return pojemnoscSilnika; }
			set { pojemnoscSilnika = value; }
		}

		public double SrednieSpalanie
		{
			get {return srednieSpalanie; }
			set { srednieSpalanie = value; }
		}

		public Samochod()
		{
			marka = "nieznana";
			model = "nieznany";
			iloscDrzwi = 0;
			pojemnoscSilnika = 0;
			srednieSpalanie = 0;
			liczbaSamochodow++;
		}

		public Samochod(string _marka, string _model, int _ilosc, int _pojemnosc, double srspal)
		{
			marka = _marka;
			model = _model;
			iloscDrzwi = _ilosc;
			pojemnoscSilnika = _pojemnosc;
			srednieSpalanie = srspal;
			liczbaSamochodow++;
		}

		private double ObliczSpalanie(double dlugoscTrasy)
		{
			return (srednieSpalanie*dlugoscTrasy)/100.0;
		}

		public double ObliczKosztPrzejazdu(double dlugosc, double cena)
		{
			return ObliczSpalanie(dlugosc)*cena;
		}

		public void WypiszInfo()
		{
			Console.WriteLine("Marka: " + marka);
			Console.WriteLine("Model: " + model);
			Console.WriteLine("Ilosc drzwi: " + iloscDrzwi);
			Console.WriteLine("Pojemnosc: " + pojemnoscSilnika);
			Console.WriteLine("Srednie spalanie: " + srednieSpalanie);
		}

		public static void WypiszIloscSamochodow()
		{
			Console.WriteLine("Ilosc samochodow: " + liczbaSamochodow);
		}

	}

	public class Garaz
	{
		private string adres;
		private int pojemnosc;
		private int liczbaSamochodow = 0;
		private Samochod[] samochody;

		public string Adres
		{
			get { return adres; }
			set { adres = value; }
		}

		public int Pojemnosc
		{
			get { return pojemnosc; }
			set {
				pojemnosc = value;
				samochody = new Samochod[pojemnosc];
			}
		}

		public Garaz()
		{
			adres = "nieznany";
			pojemnosc = 0;
			samochody = null;
		}

		public Garaz(string _adres, int _pojemnosc)
		{
			adres = _adres;
			pojemnosc = _pojemnosc;
			samochody = new Samochod[pojemnosc];
		}

		public void WprowadzSamochod(Samochod s)
		{
			if (liczbaSamochodow == pojemnosc)
				Console.WriteLine ("Garaz jest pelny!");
			else {
				samochody [liczbaSamochodow] = s;
				liczbaSamochodow++;
			}
		}

		public Samochod WyprowadzSamochod()
		{
			if (liczbaSamochodow == 0) {
				Console.WriteLine ("Garaz jest pusty!");
				return null;
			}
				else {
				liczbaSamochodow--;
				Samochod temp = samochody [liczbaSamochodow];
				samochody [liczbaSamochodow] = null;
				return temp;
			}
		}

		public void WypiszInfo()
		{
			Console.WriteLine ("Adres: " + adres);
			Console.WriteLine ("Liczba samochodow: " + liczbaSamochodow);
			Console.WriteLine ("Samochody: ");
			Console.WriteLine ();
			for (int i = 0; i < liczbaSamochodow; i++) {
				samochody [i].WypiszInfo ();
				Console.WriteLine ();
			}
		}

	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0); 
			Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6); 

			Garaz g1 = new Garaz(); 
			g1.Adres = "ul. Garażowa 1"; 
			g1.Pojemnosc = 1; 

			Garaz g2 = new Garaz("ul. Garażowa 2", 2); 

			g1.WprowadzSamochod(s1); 
			g1.WypiszInfo(); 
			g1.WprowadzSamochod(s2); 

			g2.WprowadzSamochod(s2); 
			g2.WprowadzSamochod(s1); 
			g2.WypiszInfo(); 

			g2.WyprowadzSamochod(); 
			g2.WypiszInfo(); 

			g2.WyprowadzSamochod(); 
			g2.WyprowadzSamochod(); 

			Console.ReadKey(); 
			/*
			Samochod s1 = new Samochod(); 

			s1.WypiszInfo(); 

			s1.Marka = "Fiat"; 
			s1.Model = "126p"; 
			s1.IloscDrzwi = 2; 
			s1.PojemnoscSilnika = 650; 
			s1.SrednieSpalanie = 6.0; 

			s1.WypiszInfo(); 

			Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6); 

			s2.WypiszInfo(); 

			double kosztPrzejazdu = s2.ObliczKosztPrzejazdu(30.5, 4.85); 
			Console.WriteLine("Koszt przejazdu: " + kosztPrzejazdu); 

			Samochod.WypiszIloscSamochodow(); 

			Console.ReadKey(); 
			*/
		}
	}
}
