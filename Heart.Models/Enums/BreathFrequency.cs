using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum BreathFrequency
{
    [Weight(3)]
    [Display(Name = "40 и менее в мин. (брадипноэ с элементами апноэ)")]
    LessThanForty,
    [Weight(0)]
    [Display(Name = "40-60 в мин.")]
    FortyToSixty,
    [Weight(2)]
    [Display(Name = "60-80 в мин.")]
    SixtyToEighty,
    [Weight(4)]
    [Display(Name = "80-100 в мин.")]
    EightyToHindred,
}
