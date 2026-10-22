using System.Security.Cryptography;
using templates;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;   

// 1. DANE: lista czterech trybów awarii
var failures = new List<FailureMode>
{
    new FailureMode { Component = "UPS_onco_ward", Mode = "electrical shock", Probability = 0.3 },
    new FailureMode { Component = "<script>alert('hack')</script>", Mode = "wyciek uszczelnienia", Probability = 0.4 },
    new FailureMode { Component = "engine", Mode = "cylinder corroded", Probability = 0.2 },
    new FailureMode { Component = "valve", Mode = "fail to close on demand", Probability = 0.1 }
};

// 2. ZADANIE A: interpolacja, szablon wpisany w kod
foreach (var f in failures)
{
    Console.WriteLine($"There is {f.Probability:P0} probability that {f.Component} fails by {f.Mode}");
}

Console.WriteLine();   // pusta linia dla oddzielenia

// 3. ZADANIE B: szablon z pliku
string template = File.ReadAllText("row.txt");      // wczytaj tekst szablonu z pliku

foreach (var f in failures)                          // dla każdego trybu awarii...
{
    var data = new Dictionary<string, string>        // ...UTWÓRZ SŁOWNIK
    {
        ["Component"] = f.Component,
        ["Mode"] = f.Mode,
        ["Probability"] = f.Probability.ToString("P0")
    };

    string result = TemplateEngine.Render(template, data);   // wypełnij szablon
    Console.WriteLine(result);                                // wypisz wynik
}


foreach (var p in typeof(FailureMode).GetProperties())
{
    Console.WriteLine(p.Name);
}


// 4. ZADANIE C: raport HTML

string template_html = File.ReadAllText("report.html");
string template_html_row = File.ReadAllText("row.html");

string rows = "";                                    // pusta zmienna na caly tekst ktory jest sklejany w petli z poszegolnych slownikow

foreach (var f in failures)                          // dla każdego trybu awarii...
{

    // 1. Decyzja: czy ten tryb awarii jest wysokiego ryzyka?
    string riskClass;
    if (f.Probability > 0.3)
    {
        riskClass = "high";     // naklejka dla przeglądarki
    }
    else
    {
        riskClass = "";         // brak naklejki
    }

    // 2. Słownik jednej awarii: dane + decyzja
    var rowData = new Dictionary<string, string>
    {
        ["Component"] = WebUtility.HtmlEncode(f.Component),
        ["Mode"] = WebUtility.HtmlEncode(f.Mode),
        ["Probability"] = WebUtility.HtmlEncode(f.Probability.ToString("P0")),
        ["RiskClass"] = riskClass
    };

    // 3. Wypełnij szablon wiersza i doklej do reszty
    string row = TemplateEngine.Render(template_html_row, rowData); // jeden wiersz w html <tr> jest wypełniony danymi z jednego słownika
    rows += row + "\n";                                               // doklej do reszty i zostaw pustą linię dla czytelności
                                         
}

// po pętli: raport raz, ze wszystkimi wierszami
var reportData = new Dictionary<string, string> // tworzy jeden nowy slownik gdzie "Rows" to key a rows to value, czyli wszystkie wiersze w html staja sie jednym value
{
    ["Rows"] = rows
};

string report = TemplateEngine.Render(template_html, reportData); // renderuje dokument template_html z jednym slownikiem reportData, ktory ma w sobie wszystkie wiersze

File.WriteAllText("raport.html", report);            // C.3: zapis do pliku
Console.WriteLine("Zapisano raport.html");


foreach (var f in failures)
{




}