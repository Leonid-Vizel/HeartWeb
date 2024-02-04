using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum Apgar
{
    [Weight(-2)]
    [Display(Name = "3-5")]
    ThreeToFive,
    [Weight(0)]
    [Display(Name = "5-7")]
    FiveToSeven,
    [Weight(1)]
    [Display(Name = "7-9")]
    SevenToNine,
}
