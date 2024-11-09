using AutoMapper;
using MyAnthemsAPI.Management.PlaylistManagement.Dtos;
using MyAnthemsAPI.Models.PlaylistManagement;

namespace MyAnthemsAPI.Management.PlaylistManagement.Mapper
{
    public class PlaylistMappingProfile : Profile
    {
        public PlaylistMappingProfile()
        {
            CreateMap<Playlist, PlaylistDto>();
        }
    }
}