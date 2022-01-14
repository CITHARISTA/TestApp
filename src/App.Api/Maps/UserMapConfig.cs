using App.Api.Models;
using App.Core.Models;
using Mapper.Absracts;

namespace App.Api.Maps
{
    public class UserMapConfig: IMapperConfig
    {
        public void AddMaps(IMapStore store, IMapper mapper)
        {
            store.AddMap<UserVm, User>(source =>
            {
                return new User
                {
                    Name = source.Name,
                    MiddleName = source.MiddleName,
                    LastName = source.LastName,
                    Email = source.Email,
                    PhoneNumber = source.PhoneNumber
                };
            });
        }
    }
}
