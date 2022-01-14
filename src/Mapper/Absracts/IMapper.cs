namespace Mapper.Absracts
{
    public interface IMapper
    {
        TResult Map<TIn, TResult>(TIn source);
    }
}
