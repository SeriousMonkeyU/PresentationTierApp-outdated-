using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Client
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    public string username { get; set; }
    public string password { get; set; }
}