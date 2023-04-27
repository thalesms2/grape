using System.ComponentModel.DataAnnotations;

namespace restApi.Data.Dtos;
public class ReadClientDto {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}
