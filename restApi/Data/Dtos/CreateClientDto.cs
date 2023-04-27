using System.ComponentModel.DataAnnotations;

namespace restApi.Data.Dtos; 
public class CreateClientDto {
    [Required(ErrorMessage = "This field is required.")]
    public int Id { get; set; }
    [Required(ErrorMessage = "This field is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "This field is required.")]
    public string Adress { get; set; }
}
