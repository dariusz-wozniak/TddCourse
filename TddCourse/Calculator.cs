using System;
using System.Threading.Tasks;

namespace TddCourse
{
    // PLEASE NOTE That code is only for TDD demonstration uses.
    // This is not a great example of how calculator design and code should looks like in the real/production life.
    public interface ICalculator
    {
        float Divide(int dividend, int divisor);
        float Divide(double dividend, double divisor);
        Task<float> DivideAsync(double dividend, double divisor);
        
        event EventHandler CalculatedEvent;
    }

    public class Calculator : ICalculator
    {
        public float Divide(int dividend, int divisor)
        {
            if (divisor == 0) throw new DivideByZeroException();

            float result = (float) dividend/divisor;
            OnCalculated();
            return result;
        }

        public float Divide(double dividend, double divisor)
        {
            if (divisor == 0) throw new DivideByZeroException();

            float result = (float)dividend / (float)divisor;
            OnCalculated();
            return result;
        }

        public async Task<float> DivideAsync(double dividend, double divisor)
        {
            await Task.Delay(millisecondsDelay: 1000)
                      .ConfigureAwait(continueOnCapturedContext: false);

            return (float)dividend/(float)divisor;
        }

        public event EventHandler CalculatedEvent;

        protected virtual void OnCalculated()
        {
            var handler = CalculatedEvent;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}