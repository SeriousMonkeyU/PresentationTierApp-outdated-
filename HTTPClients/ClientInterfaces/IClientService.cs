using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.ClientInterfaces;

public interface IClientService
{
    Task<Client> Create(ClientCreationDTO dto);
}