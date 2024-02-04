using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum ArterialPressure
{
    [Weight(0)]
    [Display(Name = "Равное")]
    Equal,
    [Weight(5)]
    [Display(Name = "Постоянный градиент более 30 мм.рт.ст.")]
    ContinuousGradient,
    [Weight(5)]
    [Display(Name = "Системная гипотония")]
    SystemicHypotension
}
