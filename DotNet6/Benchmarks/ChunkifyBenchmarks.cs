using Softeq.XToolkit.Common.Extensions;

[MemoryDiagnoser]
public class ChunkifyBenchmarks
{
    [Params(1, 3, 10)]
    public int ChunkSize;

    [Params(8, 100)]
    public int DataLength;

    public IEnumerable<int> _generator;

    [GlobalSetup]
    public void Setup()
    {
        _generator = Enumerable.Range(1, DataLength);
    }

    [Benchmark]
    public List<int[]> Run_Chunkify()
    {
        var result = _generator.Chunkify(ChunkSize).ToList();
        return result;
    }

    [Benchmark]
    public List<int[]> Run_Chunk()
    {
        var result = _generator.Chunk(ChunkSize).ToList();
        return result;
    }
}