using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddCourse
{
    internal interface ICalculator
    {
        float Divide(int dividend, int divisor);
        event EventHandler CalculatedEvent;
    }

    internal class Calculator : ICalculator
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