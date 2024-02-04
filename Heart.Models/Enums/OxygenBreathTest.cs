using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum OxygenBreathTest
{
    [Weight(-2)]
    [Display(Name = "Положительная")]
    Positive,
    [Weight(6)]
    [Display(Name = "Отрицательная")]
    Negative
}
