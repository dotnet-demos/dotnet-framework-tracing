# DotNet Framework Tracing
Basic tracing in .Net Framework

> Please note this is not recommended for production logging. For production use other products such as Azure Application Insights 

# Purpose
- Quick debugging of .Net Framework applications (legacy) in higher environments by turning the logging on in the configuration file.

# FAQ

## Isn't .Net Framework dead?
Unfortunately developers like me needs to maintain legacy code bases. Enjoy ILogger if you are in .Net Core / .Net 5/6 world.

## Why not recommending TraceSource based tracing?
- This is for simple tracing purpose with Trace class. Though [TraceSource](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.tracesource?view=net-5.0) is powerful, that require more code. 

## Is TraceSource best way to instrument in production?
Personally I don't recommend TraceSource as I have experienced performance issues with it. I recommend Windows OS level [ETW](https://docs.microsoft.com/en-us/dotnet/framework/performance/etw-events) or dedicated instrumentnation technologies such as Azure Application Insights.

## If this is not recommended for production why wasting time?
If we are in debugging higher level environments and we don't have access to production instrumentation, but have permission to update the application configuration, this is useful.
Don't ask why. Welcome to legacy Enterprise world.

## Why I need to use the <filter>? What about switches
switches require application to check switch before logging. That cannot be simply done when using static methods of Trace class. Use TraceSource to get that feature.

## Shall I use XmlWriterTraceListener always?
- There is a caution given in documentation about it as its not thread-safe. It leads to resource contention due to locks Eventually performance degradation. [Read the Docs](https://docs.microsoft.com/en-us/dotnet/framework/wcf/diagnostics/tracing/configuring-tracing#configuring-trace-listeners-to-consume-traces)
- It is mainly [intended to use with TraceSource](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.xmlwritertracelistener?view=net-5.0#remarks) tracing. Not good with static methods of `Trace` class  

## Will this correlate traces across different processes in a microservice system?
[ReadTheDocs](https://docs.microsoft.com/en-us/dotnet/framework/wcf/diagnostics/tracing/configuring-tracing#configuring-activity-tracing-and-propagation-for-correlation). It doesn't seems good at correlation.'

## How to view the xml file produced?
Use [Service Trace Viewer Tool](https://docs.microsoft.com/en-us/dotnet/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe?redirectedfrom=MSDN)

## Can I push the traces to EventLog and see in EventViewer?
- Yes. Though it is not in this sample, it is [very much possible](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.eventlogtracelistener?view=windowsdesktop-5.0).
- It does not output optional trace data.
- It may require permission to write to EventLog.

# More ReadTheDocs

- [Tracing and Instrumenting Applications](https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/tracing-and-instrumenting-applications)
- [TraceFilter](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.tracefilter?view=net-5.0)
- [How to: Use TraceSource and Filters with Trace Listeners](https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/how-to-use-tracesource-and-filters-with-trace-listeners)