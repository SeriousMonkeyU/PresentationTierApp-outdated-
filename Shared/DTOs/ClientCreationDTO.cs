namespace Shared.DTOs;

public class ClientCreationDTO
{
    public int id { get; }
    public string username { get; }
    public string password { get; }

    public ClientCreationDTO(int id, string username, string password)
    {
        this.id = id;
        this.username = username;
        this.password = password;
    }
}