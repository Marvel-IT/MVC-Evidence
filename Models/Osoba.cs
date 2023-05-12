using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEvidence.Models;

public class Osoba 
{
    public int Id {get; set; }
    [Display(Name = "Jméno"), Required]
    [StringLength(50, MinimumLength = 1)]    
    public string? Jmeno {get; set; }
    [Display(Name = "Přijmení"), Required]
    [StringLength(50, MinimumLength = 1)]    
    public string? Prijmeni {get; set; }
    [Display(Name = "Věk")]
    public int Vek {get; set; }
    [DataType(DataType.PhoneNumber), MinLength(9)]
    [DisplayFormat(DataFormatString = "{0:###-###-###}")]    
    public int Telefon {get; set; }
    [Display(Name = "Pojišťovna"), Required]
    public string? Pojistovna {get; set; }
}