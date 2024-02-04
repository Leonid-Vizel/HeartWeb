using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum SkinColor
{
    [Weight(2)]
    [Display(Name = "Физиологическая")]
    Physiological,
    [Weight(0)]
    [Display(Name = "Акроцианоз")]
    Acrocyanosis,
    [Weight(3)]
    [Display(Name = "Мраморность")]
    Marbling,
    [Weight(5)]
    [Display(Name = "Тотальный цианоз")]
    TotalCyanosis,
    [Weight(5)]
    [Display(Name = "Дифференцированный цианоз")]
    DifferentiatedCyanosis,
}
