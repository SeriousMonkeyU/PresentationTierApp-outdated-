namespace Application.Client.DAOInterfaces;

public interface IClientDAO
{
    Task<Shared.Models.Client> CreateAsync(Shared.Models.Client client);
}