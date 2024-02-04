using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum Rentgenography
{
    [Weight(-1)]
    [Display(Name = "Нормальные размеры сердца")]
    NormalSize,
    [Weight(3)]
    [Display(Name = "Умеренное увеличение")]
    ModerateEnlargement,
    [Weight(4)]
    [Display(Name = "Кардиомегалия")]
    Cardiomegaly,
}
