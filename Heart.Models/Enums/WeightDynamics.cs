using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum WeightDynamics
{
    [Weight(0)]
    [Display(Name = "Нормальная потеря")]
    NormaLoss,
    [Weight(1)]
    [Display(Name = "Нет динамики")]
    NoDynamics,
    [Weight(2)]
    [Display(Name = "Патологическая прибавка")]
    PathologicalGain,
}
