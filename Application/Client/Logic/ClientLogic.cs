using Application.Client.DAOInterfaces;
using Application.Client.LogicInterfaces;
using Shared.DTOs;

namespace Application.Client.Logic;

public class ClientLogic : IClientLogic
{
    private readonly IClientDAO clientDao;

    public ClientLogic(IClientDAO clientDao)
    {
        this.clientDao = clientDao;
    }

    public async Task<Shared.Models.Client> CreateAsync(ClientCreationDTO dto)
    {
        Shared.Models.Client? existing = null; // CHECK IF THE USER ALREADY EXISTS
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        Shared.Models.Client toCreate = new Shared.Models.Client
        {
            username = dto.username,
            password = dto.password
        };

        Shared.Models.Client created = await clientDao.CreateAsync(toCreate);

        return created; 
    }
    
    private static void ValidateData(ClientCreationDTO userToCreate)
    {
        string userName = userToCreate.username;
        string password = userToCreate.password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        if (password.Length < 3)
            throw new Exception("Password must be at least 3 characters!");
        if (password.Length > 20)
            throw new Exception("Password must be less than 21 characters!");
    }
    
}