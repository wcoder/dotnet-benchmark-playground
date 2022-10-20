public class PerformanceConfig : ManualConfig
{
    public PerformanceConfig()
    {
        var defaultConfig = DefaultConfig.Instance;
        AddExporter(defaultConfig.GetExporters().ToArray());
        AddLogger(defaultConfig.GetLoggers().ToArray());
        AddColumnProvider(defaultConfig.GetColumnProviders().ToArray());

        AddDiagnoser(MemoryDiagnoser.Default);
    }
}