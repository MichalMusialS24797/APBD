// See https://aka.ms/new-console-template for more information

using System.Net.Sockets;

namespace APPBD2;

class Program
{
    static void Main(string[] args)
    {
        //Stworzenie kontenera danego typu
        LiquidContainer c1 = new LiquidContainer(1000.0, 100, 2000, 300);
        CoolingContainer c2 = new CoolingContainer("Bananas", 14.0, 1000.0, 200, 3000 , 400);
        GasContainer c3 = new GasContainer(1000.0, 300, 2300 , 200);
        LiquidContainer c4 = new LiquidContainer(1000.0, 400, 4200 , 300);
        
        // Zaladowanie ladunku do danego kontenera
        c1.setLoad(600, LoadType.Food);
        c2.setLoad(200, "Bananas");
        c3.setLoad(100);
        c4.setLoad(700, LoadType.Fuel);
        
        // Stworzenie statkow
        Ship ship = new Ship("Titanic", 3.1, 10, 4.5);
        Ship ship2 = new Ship("MarineCosTamXD", 3.1, 10, 4.5);
        
        // Zaladowanie kontenera na statek
        ship.AddContainer(c1);
        
        // Zaladowanie listy kontenerow
        List<Container> containers = new List<Container>{c2,c3}; // validate dla nie dodawania tych samych kontenerow
        ship.AddContainer(containers);
        
        // Usuniecie kontenera
        ship.DropContainer("KON-L-1");
        // bledny serial number
        ship.DropContainer("KON-L-2");
        
        //Rozladowanie kontenera toDO
        Console.WriteLine("c3 container before");
        c3.showInfo();
        ship.unloadContainer(c3);
        Console.WriteLine("c3 container after");
        c3.showInfo();
        
        // Zastapienie kontenera na statku o danyum numerze innym kontenerem
        ship.ReplaceContainer("KON-G-3", c4);
        
        // Mozliwosc przeniesienia kontenera miedzy dwoma statkami
        ship.MoveContainer(c2, ship2);
        
        // //Wypisanie informacji o danym kontenerze
        c1.showInfo();
        c2.showInfo();
        c3.showInfo();
        c4.showInfo();

        // // Wypisanie infromacji o danym statku i jego ladunku
        ship.showInfo();
        ship2.showInfo();
        
        ship.showFullInfo();
        ship2.showFullInfo();
    }
}


