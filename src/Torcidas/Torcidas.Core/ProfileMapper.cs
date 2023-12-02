using AutoMapper;

using Torcidas.Core.DTOs;
using Torcidas.Domain.Entities;

namespace Torcidas.Core
{
    public class ProfileMapper: Profile
    {

        public ProfileMapper()
        {
            CreateMap<User, UserDTO>();

        }
    }
}
