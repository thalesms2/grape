using AutoMapper;
using restApi.Data.Dtos;
using restApi.Models;

namespace restApi.Profiles; 
public class ClientProfile : Profile {
    public ClientProfile() {
        CreateMap<CreateClientDto, Client>();
        CreateMap<Client, ReadClientDto>();
        CreateMap<UpdateClientDto, Client>();
    }
}
