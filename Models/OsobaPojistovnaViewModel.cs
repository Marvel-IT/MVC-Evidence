using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcEvidence.Models;

public class OsobaPojistovnaViewModel
{
    public List<Osoba>? Osoby {get; set; }
    public SelectList? Pojistovny {get; set;}
    public string? OsobaPojistovna {get; set; }
    public string? SearchString {get; set;}
}