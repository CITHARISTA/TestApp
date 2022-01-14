using Mapper.Absracts;

namespace Mapper
{
    internal class MapStore : IMapStore
    {
        private readonly object Locker = new object();
        private Dictionary<Type, Dictionary<Type, Delegate>> Maps = new Dictionary<Type, Dictionary<Type,Delegate>>();
        public void AddMap<TIn, TResult>(Func<TIn, TResult> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));

            lock (Locker)
            {
                if (!Maps.ContainsKey(typeof(TIn)))
                    Maps.Add(typeof(TIn), new Dictionary<Type, Delegate>());

                var typeMaps = Maps[typeof(TIn)];
                if (typeMaps.ContainsKey(typeof(TResult)))
                    throw new InvalidOperationException($"Конвертер {typeof(TIn)} => {typeof(TResult)} уже существует.");

                typeMaps.Add(typeof(TResult), func);
            }
        }

        public TMapFunc Get<TIn, TResult, TMapFunc>() where TMapFunc : class
        {
            if (!Maps.TryGetValue(typeof(TIn), out var from))
                throw new NotImplementedException($"Конвертер {typeof(TIn)} => {typeof(TResult)} уже существует.");

            if (!from.TryGetValue(typeof(TResult), out var result))
                throw new NotImplementedException($"Конвертер {typeof(TIn)} => {typeof(TResult)} уже существует.");
            
            return (result as TMapFunc) ?? throw new Exception();
        }
    }
}
