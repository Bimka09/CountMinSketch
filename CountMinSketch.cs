using System.Text;

namespace ProbabilisticAlgorithm
{
    internal class CountMinSketch
    {
        private int d;
        private int w;
        private int[,] table;
        private int[] hashes;

        public CountMinSketch(int d, int w)
        {
            this.d = d;
            this.w = w;
            table = new int[d, w];
            hashes = new int[d];
            Random random = new Random();
            for (int i = 0; i < d; i++)
            {
                hashes[i] = random.Next();
            }
        }

        public void Add(string value, int count)
        {
            for (int i = 0; i < d; i++)
            {
                uint index = Convert.ToUInt32(Hash(value, hashes[i]) % w);
                table[i, index] += count;
            }
        }

        public int Count(string value)
        {
            int minCount = int.MaxValue;
            for (int i = 0; i < d; i++)
            {
                uint index = Convert.ToUInt32(Hash(value, hashes[i]) % w);
                minCount = Math.Min(minCount, table[i, index]);
            }
            return minCount;
        }

        private uint Hash(string value, int hash)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            uint result = (uint)hash;
            for (int i = 0; i < bytes.Length; i++)
            {
                result = (result * 31 + bytes[i]) % int.MaxValue;
            }
            return result;
        }
    }
}
