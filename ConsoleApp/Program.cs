using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteSimpleTraces();
            
        }
        private static void WriteSimpleTraces()
        {
            // Below simple trace will not be written using delimited string by DelimitedListTraceListener. https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.delimitedlisttracelistener?view=net-5.0#remarks
            Trace.WriteLine("This is a simple trace.writeline");
            Trace.WriteLine("This is a simple trace.writeline with MyCategory", "MyCategory");

            // These are written properly in delimited writer as well as in xml.
            // There is no way to TraceVerbose when using Trace class. User TraceSource class for Verbose.
            Trace.TraceError("This is a trace.traceerror");
            Trace.TraceInformation("This is a trace.traceinformaton");
            Trace.TraceWarning("This is a trace.tracewarning");
            Trace.TraceError("This is the second trace.traceerror");

            // This is not producing the StackTrace in the output.
            Trace.Fail("This is simple failure");
        }
    }
}