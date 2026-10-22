using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Attributes
{
    [Category("Physical System", "short therm memory used by processor to do tasks")]
    public class RAM
    {
    }

    [Category("Physical System")]
    public class Processor
    {
    }

    [Category("Physical System")]
    public class Disk
    {
    }

    [Category("Logical System", "translates source code into machine code")]
    public class Compiler
    {
    }

    [Category("Logical System")]
    public class Interpreter
    {
    }

    [Category("Logical System")]
    public class CompilerJIT
    {
    }

    [Category("Material")]
    public class SourceCode
    {
    }

    [Category("Material", "performed by processor")]
    public class MachineCode
    {
    }

    [Category("Material")]
    public class AssemblyFile
    {
    }

    [Category("Function")]
    public class Function
    {
    }

    [Category("Specification")]
    public class ProgrammingLanguage 
    {
    }




}
