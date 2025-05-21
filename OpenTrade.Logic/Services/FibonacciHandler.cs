namespace OpenTrade.Logic.Services
{
    public class FibonacciHandler : IFibonacciHandler
    {
        public (int, int) GetPreviousFibonacci(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Число должно быть положительным.");
            }

            int a = 0;
            int b = 1;

            if (n == 1)
            {
                return (0, 1);
            }

            int prevA = 0;
            int prevB = 1;

            while (true)
            {
                int next = prevA + prevB;
                if (next == n)
                {
                    return (prevA, prevB);
                }
                else if (next > n)
                {
                    throw new ArgumentException($"Число {n} не входит в последовательность Фибоначчи.");
                }
                prevA = prevB;
                prevB = next;
            }
        }
    }
}
