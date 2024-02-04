using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum CardioDynamics
{
    [Weight(0)]
    [Display(Name = "Не применялась")]
    NotUsed,
    [Weight(2)]
    [Display(Name = "Положительная")]
    Positive,
    [Weight(3)]
    [Display(Name = "Нет динамики")]
    NoDynamics,
}
