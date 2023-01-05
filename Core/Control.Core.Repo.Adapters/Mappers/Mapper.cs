namespace Control.Infrastructure.Domain.Models.Mappers
{
    internal static partial class Mapper
    {
        private static List<S> Apply<T, S>(IQueryable<T> dt, Func<T?, S?> fn)
        {
            List<S> result = new();
            foreach(T? row in dt)
            {
                S? model = fn(row);
                if (model != null)
                    result.Add(model!);
            }

            return result;
        }

        private static List<S> Apply<T, S>(ICollection<T> dt, Func<T?, S?> fn)
        {
            List<S> result = new();
            foreach(T? row in dt)
            {
                S? model = fn(row);
                if (model != null)
                    result.Add(model!);
            }

            return result;
        }
    }
}
