using Shared.DTOs;

namespace Application.Client.LogicInterfaces;

public interface IClientLogic
{
    public Task<Shared.Models.Client> CreateAsync(ClientCreationDTO clientToCreate);
}