using AutoMapper;

namespace Tragate.UI.BuildingBlocks.AutoMapper {
    public class AutoMapperConfig {
        public static MapperConfiguration RegisterMappings () {
            return new MapperConfiguration (cfg => {
                cfg.AddProfile (new DtoToModelMappingProfile ());
            });
        }
    }
}