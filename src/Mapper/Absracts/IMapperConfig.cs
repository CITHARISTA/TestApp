namespace Mapper.Absracts
{
    public interface IMapperConfig
    {
        void AddMaps(IMapStore store, IMapper mapper);
    }
}
