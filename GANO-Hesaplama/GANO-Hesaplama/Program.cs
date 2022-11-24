using System;

namespace GANO_Hesaplama
{
    public class Öğrenci
    {
        private string _Adı;
        public string Adı
        {
            get { return _Adı; }
            set { _Adı = value; }
        }

        private string _SoyAdı;
        public string SoyAdı
        {
            get { return _SoyAdı; }
            set { _SoyAdı = value; }
        }

        private int _Numara;
        public int Numara
        {
            get
            {
                return _Numara;
            }
            set
            {
                if (0 < value && value < 100000)
                {
                    _Numara = value;
                }
                else
                {
                    _Numara = 100000;

                }

            }
        }
        private double GANO { get; set; }

        public void GANOHesaplama()
        {
            Öğrenci[] öğrenci = new Öğrenci[99999];
            int i = 0;
            int k = 0;


            while (true)
            {
                double KrediToplamı = 0;
                double DersPuanı = 0;
                öğrenci[i] = new Öğrenci();
                Console.Write("Öğrencinin adını giriniz: ");
                öğrenci[i].Adı = Convert.ToString(Console.ReadLine());
                Console.Write("Öğrencinin soy adını giriniz: ");
                öğrenci[i].SoyAdı = Convert.ToString(Console.ReadLine());

            NumaraGiriş:
                Console.Write("Öğrenci numarasını giriniz: ");
                öğrenci[i].Numara = Convert.ToInt32(Console.ReadLine());

                if (öğrenci[i].Numara == 100000)
                {
                    Console.WriteLine("NOT: Numara 1 den küçük olamaz. Bu yüzden 100000 olarak atandı.");
                    Console.Write("Öğrenci No: ");
                    Console.WriteLine(öğrenci[i].Numara);
                    Console.WriteLine("Öğrenci numarasını değiştirmek istermisiniz? y/n");
                    if (Console.ReadLine() == "y") goto NumaraGiriş;
                }
                Ders[] ders = new Ders[99999];
                int derssayacı = 1;
                while (true)
                {
                    double HarfNotuKarşılığı = 0;
                    ders[k] = new Ders();
                    Console.Write($"\n{derssayacı}. Ders adını giriniz: ");
                    ders[k].DersAdı = Convert.ToString(Console.ReadLine());
                DersKrediGiriş:
                    Console.Write($"{derssayacı}. Ders Kredisi girniz:");
                    ders[k].DersKredisi = Convert.ToInt32(Console.ReadLine());

                    if (ders[k].DersKredisi == 10)
                    {
                        Console.WriteLine("NOT: Ders Kredisi 2 den küçük ve 6 dan büyük olamaz.");
                        goto DersKrediGiriş;
                    }

                DersNotuGiriş:
                    Console.Write($"{derssayacı}. Ders Notunu girniz:");
                    ders[k].DersNotu = Convert.ToInt32(Console.ReadLine());

                    if (ders[k].DersNotu == 110)
                    {
                        Console.WriteLine("NOT: Ders Notu 0 dan küçük ve 100 den büyük olamaz.");
                        Console.Write("Lütfen tekrar ");
                        goto DersNotuGiriş;
                    }
                    if (ders[k].DersNotu < 50)
                    {
                        HarfNotuKarşılığı = 0;
                    }
                    else if (ders[k].DersNotu >= 50 && ders[k].DersNotu < 60)
                    {
                        HarfNotuKarşılığı = 2;
                    }
                    else if (ders[k].DersNotu >= 60 && ders[k].DersNotu < 70)
                    {
                        HarfNotuKarşılığı = 2.5;
                    }
                    else if (ders[k].DersNotu >= 70 && ders[k].DersNotu < 80)
                    {
                        HarfNotuKarşılığı = 3;
                    }
                    else if (ders[k].DersNotu >= 80 && ders[k].DersNotu < 90)
                    {
                        HarfNotuKarşılığı = 3.5;
                    }
                    else if (ders[k].DersNotu >= 90 && ders[k].DersNotu <= 100)
                    {
                        HarfNotuKarşılığı = 4;
                    }

                    DersPuanı += HarfNotuKarşılığı * ders[k].DersKredisi;
                    KrediToplamı += ders[k].DersKredisi;
                    Console.WriteLine("\nDers eklemeyi sonladırmak için \"DersBitir\" yazın.");
                    string dersbitir = Convert.ToString(Console.ReadLine());
                    if (dersbitir == "DersBitir") break;
                    derssayacı++;
                    k++;

                }
                double GANO = DersPuanı / KrediToplamı;
                öğrenci[i].GANO = GANO;
                Console.WriteLine($"\n{öğrenci[i].Adı} {öğrenci[i].SoyAdı} GANO'su: {öğrenci[i].GANO}");
                Console.WriteLine("\nÖğrenci eklemeyi sonladırmak için \"ÖğrenciBitir\" yazın.");
                string öğrencibitir = Convert.ToString(Console.ReadLine());
                if (öğrencibitir == "ÖğrenciBitir") break;
                i++;
            }
        ÖğrenciGörüntüle:
            Console.Write("Bilgilerini görüntülemek istediğiniz öğrencinin numarasını giriniz: ");
            int ÖğrenciNO = Convert.ToInt32(Console.ReadLine());
            int z = 0;
            while (true)
            {
                if (ÖğrenciNO == öğrenci[z].Numara)
                {
                    Console.WriteLine($"{öğrenci[z].Adı} {öğrenci[z].SoyAdı}\n GANO'su: {öğrenci[z].GANO}");
                    break;
                }
            }
            Console.WriteLine("Başka öğrencinin bilgilerini görmek istiyor musunuz?... (y/n)");
            if (Console.ReadLine() == "y") goto ÖğrenciGörüntüle;
        }
    }

    public class Ders
    {
        private string _DersAdı;
        public string DersAdı
        {
            get { return _DersAdı; }
            set { _DersAdı = value; }
        }

        private int _DersNotu;
        public int DersNotu
        {
            get
            {
                return _DersNotu;
            }
            set
            {
                if (0 <= value && value <= 100)
                {
                    _DersNotu = value;
                }
                else
                {
                    _DersNotu = 110;

                }
            }
        }

        private int _DersKredisi;
        public int DersKredisi
        {
            get
            {
                return _DersKredisi;
            }
            set
            {
                if (2 <= value && value <= 6)
                {
                    _DersKredisi = value;
                }
                else
                {
                    _DersKredisi = 10;

                }
            }
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Öğrenci öğrenciler = new Öğrenci();
            öğrenciler.GANOHesaplama();
            Console.ReadLine();
        }
    }

}
