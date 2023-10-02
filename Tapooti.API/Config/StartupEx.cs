using AutoMapper;

namespace Tapooti.API.Config
{
    public static class StartupEx
    {
        //AutoMapperConfig
        public static void AutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(GetAutoMapperProfilesFromAllAssemblies()
                .ToArray());
        }

        public static IEnumerable<Type> GetAutoMapperProfilesFromAllAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var aType in assembly.GetTypes())
                {
                    if (aType.IsClass && !aType.IsAbstract && aType.IsSubclassOf(typeof(Profile)))
                        yield return aType;
                }
            }
        }
    }
}