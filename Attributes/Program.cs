
using Attributes;
using System.Reflection;

Player ewa = new Player("Ewa", "Magician");

int nowyPoziom = ewa.PromoteSafe(5);   
Console.WriteLine(nowyPoziom);



void WriteDown(Type type)
{
    var attribute = type.GetCustomAttribute<CategoryAttribute>();
    Console.WriteLine($"{type.Name} : {attribute?.Name ?? "no category"} – {attribute?.Description}");
}

WriteDown(typeof(RAM));
WriteDown(typeof(Processor));
WriteDown(typeof(Disk));

WriteDown(typeof(Compiler));
WriteDown(typeof(Interpreter));
WriteDown(typeof(CompilerJIT));


WriteDown(typeof(SourceCode));
WriteDown(typeof(MachineCode));
WriteDown(typeof(AssemblyFile));

WriteDown(typeof(Function));
WriteDown(typeof(ProgrammingLanguage));




