using BenchmarkDotNet.Attributes;

namespace BenchmarkDemo
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkDictionaryLookup
    {
        readonly DictionaryLookup _dctLookup;

        public BenchmarkDictionaryLookup()
        {
            _dctLookup = new();
        }

        [Benchmark(Baseline = true)]
        public void GetValueByKey()
        {
            _dctLookup.GetValueByKey("test_99");
        }

        [Benchmark]
        public void GetValueByKeyWithLinq()
        {
            _dctLookup.GetValueByKeyWithLinq("test_99");
        }

        [Benchmark]
        public void GetValueByKeyWithTryGet()
        {
            _dctLookup.GetValueByKeyWithTryGet("test_99");
        }

        [Benchmark]
        public void GetValueByKeyManual()
        {
            _dctLookup.GetValueByKeyManual("test_99");
        }
    }
}
