using System;

namespace TddCourse
{
    public interface ICalculator
    {
        float Divide(int dividend, int divisor);
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

        public event EventHandler CalculatedEvent;

        protected virtual void OnCalculated()
        {
            var handler = CalculatedEvent;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}