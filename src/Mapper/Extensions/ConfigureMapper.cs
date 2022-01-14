using Mapper.Absracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mapper.Extensions
{
    public static class ConfigureMapper
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<Mapper>();
            services.AddSingleton<IMapStore, MapStore>();

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => GetLoadableTypes(assembly))
                .Where(type => typeof(IMapperConfig).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .ToList();

            types.ForEach(type => services.AddSingleton(typeof(IMapperConfig), type));

            services.AddSingleton<IMapper, Mapper>(service =>
            {
                var store = service.GetRequiredService<IMapStore>();
                var mapper = service.GetRequiredService<Mapper>();

                foreach (var config in service.GetRequiredService<IEnumerable<IMapperConfig>>())
                    config.AddMaps(store, mapper);

                return mapper;
            });
        }

        private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(x => x != null);
            }
        }
    }
}
