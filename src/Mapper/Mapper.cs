using Mapper.Absracts;

namespace Mapper
{
    internal class Mapper : IMapper
    {
        private readonly IMapStore _mapStore;

        public Mapper(IMapStore mapStore)
        {
            _mapStore = mapStore;
        }

        public TResult Map<TIn, TResult>(TIn source)
        {
            if (source == null) return default(TResult);

            var mapFunc = _mapStore.Get<TIn, TResult, Func<TIn, TResult>>();

            if (mapFunc == null) return default(TResult);

            return mapFunc(source);
        }
     }
}
