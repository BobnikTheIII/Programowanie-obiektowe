using System.Diagnostics;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Labolatorium_1;

class Program
{
    static void Main()
    {
        //Zadanie 1
        //Potok pracy w Git(zapisywanie zmian)
        //  Potok składa się z trzech głównych kroków roboczych:
        //  git add<nazwa_pliku>(lub git add.dla wszystkich) – dodanie zmodyfikowanych plików do poczekalni(staging area).Deklarujesz w ten sposób, co ma wejść w skład nowej wersji.
        //  git commit -m "opis zmian" – trwałe zapisanie zmian w lokalnym repozytorium na twoim komputerze wraz z komentarzem tłumaczącym, co zostało zrobione.
        //  git push – wysłanie lokalnych zapisów(commitów) na serwer zdalny(np.GitHub / GitLab), aby inni mieli do nich dostęp.

        //Zadanie 2
        //Praca w zespole, struktura gałęzi i konflikty
        // Struktura: Zazwyczaj istnieje gałąź główna(np.main lub master) zawierająca stabilny, działający kod.Każdy programista tworzy własną gałąź roboczą(tzw.feature branch, np.feature/ logowanie) odgałęzioną od main, aby pracować nad swoim zadaniem bez psucia kodu innym.
        //  Łączenie(Merge): Gdy praca na gałęzi roboczej jest skończona, łączy się ją z gałęzią main za pomocą polecenia git merge lub(częściej w firmach) poprzez Pull Request, co pozwala innym na sprawdzenie kodu przed jego scaleniem.
        //  Konflikty: Powstają, gdy dwie osoby zmienią dokładnie tę samą linijkę kodu i Git nie wie, którą wersję zachować.
        //  Rozwiązywanie konfliktów: Należy otworzyć konfliktowe pliki(edytor podświetli sporne miejsca), ręcznie usunąć znaczniki dodane przez Gita, zostawić właściwy kod, a następnie zapisać plik, wykonać git add i na końcu git commit, aby zatwierdzić ostateczną wersję.

        //Zadanie 3
        //Różnice między C# a JavaScript / Python
        //  Kompilacja vs Interpretacja: C# to język kompilowany (kod przed uruchomieniem musi zostać przetłumaczony przez kompilator na język pośredni). JavaScript i Python to języki interpretowane (wykonywane linijka po linijce w locie, bez wcześniejszej kompilacji).
        //  Typowanie statyczne vs dynamiczne: C# jest językiem silnie i statycznie typowanym – musisz z góry określić, czy zmienna to liczba (int) czy tekst (string), a błędy typów wyłapywane są przed uruchomieniem. JS i Python dobierają typy dynamicznie w trakcie działania programu.
        //  Paradygmat: C# jest bardzo rygorystyczny i od podstaw w pełni obiektowy (wszystko musi być wewnątrz klas). JS i Python pozwalają na luźniejsze pisanie kodu (np. swobodne skrypty bez tworzenia klas).

        //Zadanie 4
        //Różnica między Rozwiązaniem(Solution) a Projektem w Visual Studio
        //  Projekt(.csproj): Zawiera kod źródłowy, zasoby i ustawienia potrzebne do zbudowania pojedynczego pliku wynikowego – np.jednej aplikacji wykonywalnej(.exe) lub jednej biblioteki(.dll).
        //  Rozwiązanie(.sln): To kontener, który grupuje jeden lub więcej projektów powiązanych ze sobą logicznie.Pozwala na otwarcie i zarządzanie całym systemem naraz(np.jednym rozwiązaniem może być aplikacja webowa + osobny projekt z testami + osobny projekt z bazą danych).

        //Zadania w kodzie:
        Zadanie5();
        Zadanie6();
        Zadanie7();
        Zadanie8();

        //Zadanie 9
        //Debugger w MS Visual Studio to narzędzie służące do wykrywania i naprawiania błędów w programie.Pozwala sprawdzić, jak program działa krok po kroku, oraz znaleźć przyczynę nieprawidłowego działania.
        //Podstawowe funkcje Debuggera:
        //  - Breakpoint – zatrzymuje program w wybranym miejscu.
        //  - Step Over – wykonuje kolejną instrukcję bez wchodzenia do funkcji.   
        //  - Step Into – pozwala wejść do funkcji i sprawdzić jej działanie.
        //  - Step Out – kończy wykonywanie aktualnej funkcji i wraca do miejsca, z którego ją wywołano.
        //  - Podgląd zmiennych – umożliwia sprawdzanie aktualnych wartości zmiennych.
        //  - Call Stack – pokazuje, jakie funkcje zostały wywołane i w jakiej kolejności.
        //  - Continue – wznawia działanie programu po jego zatrzymaniu.

    }

    //Zadanie 5
    static string helloWsiz()
    {
        return "Hello WSIiZ";
    }

    static void Zadanie5()
    {
        Console.WriteLine(helloWsiz());
    }

    //Zadanie 6

    static void Zadanie6()
    {
        int a = WczytajInt("Podaj liczbę całkowitą a: ");
        int b = WczytajInt("Podaj liczbę całkowitą b: ");
        WypiszPrzedzial(a, b);
    }

    static void WypiszPrzedzial(int a, int b)
    {
        if (a > b)
        {
            (a, b) = (b, a);
        }

        for (long i = a; i <= b; i++)
        {
            Console.Write(i);
            Console.Write(i < b ? " " : Environment.NewLine);
        }
    }

    static int WczytajInt(string komunikat)
    {
        while (true)
        {
            Console.Write(komunikat);
            string? wejscie = Console.ReadLine();
            if (wejscie == null)
            {
                throw new EndOfStreamException("Brak danych wejściowych.");
            }
            if (int.TryParse(wejscie, out int wynik))
            {
                return wynik;
            }
            Console.WriteLine("To nie jest poprawna liczba całkowita, spróbuj ponownie.");
        }
    }

    //Zadanie 7
    static double PrzyblizeniePi(int n)
    {
        double suma = 0.0;
        for (int k = 0; k < n; k++)
        {
            double wyraz = 1.0 / (2 * k + 1);
            suma += (k % 2 == 0) ? wyraz : -wyraz;
        }
        return 4 * suma;
    }

    static void Zadanie7()
    {
        int n;
        do
        {
            n = WczytajInt("Podaj liczbę wyrazów n (n >= 1): ");
        } while (n < 1);

        double y = PrzyblizeniePi(n);
        Console.WriteLine($"Przybliżenie dla n = {n}: {y}");
        Console.WriteLine($"Math.PI:                {Math.PI}");
        Console.WriteLine($"Błąd:                   {Math.Abs(Math.PI - y)}");

        Console.WriteLine();
        Console.WriteLine("Test zbieżności:");
        foreach (int liczba in new[] { 1, 2, 10, 100, 1000, 1_000_000 })
        {
            double wynik = PrzyblizeniePi(liczba);
            Console.WriteLine($"  n = {liczba,9}: y = {wynik:F10}, błąd = {Math.Abs(Math.PI - wynik):E2}");
        }
    }

    //Zadanie 8
    static string NaSzesnastkowy(long liczba)
    {
        const string cyfry = "0123456789ABCDEF";
        if (liczba == 0)
        {
            return "0";
        }
        bool ujemna = liczba < 0;
        ulong wartosc = ujemna ? (ulong)(-(liczba + 1)) + 1 : (ulong)liczba;

        string wynik = "";
        while (wartosc > 0)
        {
            int reszta = (int)(wartosc % 16);
            wynik = cyfry[reszta] + wynik;
            wartosc /= 16;
        }

        return ujemna ? "-" + wynik : wynik;
    }
    static void WypiszSzesnastkowo(long liczba)
    {
        Console.WriteLine($"{liczba} (dec) = {NaSzesnastkowy(liczba)} (hex)");
    }
    static void Zadanie8()
    {
        long liczba;
        while (true)
        {
            Console.Write("Podaj liczbę dziesiętną (całkowitą): ");
            string? wejscie = Console.ReadLine();
            if (wejscie == null)
            {
                return;
            }
            if (long.TryParse(wejscie, out liczba))
            {
                break;
            }
            Console.WriteLine("To nie jest poprawna liczba całkowita, spróbuj ponownie.");
        }
        WypiszSzesnastkowo(liczba);
    }
}
