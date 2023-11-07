using System.ComponentModel.DataAnnotations;

namespace MvcPlayers.Models;

public class Players
{
    [Key]

    public int Nummer { get; set; }
    public string? Namn { get; set; }
    [DataType(DataType.Date)]
    public DateTime FödelseDatum { get; set; }
    public decimal Mål { get; set; }
    public decimal Assist { get; set; }
    public bool Skadad { get; set; }

}
