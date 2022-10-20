
// Evaluating array reference performance: row-major vs. column-major order
// https://onestepcode.com/array-reference-performance-row-major-vs-column-major-order/

[MemoryDiagnoser]
public class FillArrayByRowOrColumnBenchmark
{
    [Params(5000)]
    public int N;

    [Params(5000)]
    public int M;

    private byte[,] _buffer;

    [GlobalSetup]
    public void Setup()
    {
        _buffer = new byte[N, M];
    }

    [Benchmark]
    public byte[,] Row()
    {
        for (int i = 0; i < N; i++)
        for (int j = 0; j < M; j++)
        {
            _buffer[i, j] = 1;
        }
        return _buffer;
    }

    [Benchmark]
    public byte[,] Column()
    {
        for (int j = 0; j < M; j++)
        for (int i = 0; i < N; i++)
        {
            _buffer[i, j] = 1;
        }
        return _buffer;
    }
}