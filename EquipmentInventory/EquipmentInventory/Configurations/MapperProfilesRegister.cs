using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Features.Scanning;
using AutoMapper;

namespace EquipmentInventory.Configurations
{
    public static class MapperProfilesRegister
    {
        internal static ContainerBuilder AddMapperProfiles(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Program)))
                .Where(r => r.BaseType == typeof(Profile) && !r.IsAbstract && r.IsPublic)
                .As<Profile>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                
                
                foreach (var profile in ctx.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);
            }));

            return builder;
        }
    }
}