namespace TddCourse
{
    public class GenericCalculator<T>
    {
        public T Add(T a, T b)
        {
            return (dynamic) a + (dynamic) b;
        }
    }
}