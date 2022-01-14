namespace Mapper.Absracts
{
    public interface IMapStore
    {
        TMapFunc Get<TIn, TResult, TMapFunc>() where TMapFunc : class;

        void AddMap<TIn, TResult>(Func<TIn, TResult> func);
    }
}
