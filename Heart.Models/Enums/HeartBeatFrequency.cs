using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum HeartBeatFrequency
{
    [Weight(3)]
    [Display(Name = "Менее 110 в мин.")]
    LessThan110,
    [Weight(0)]
    [Display(Name = "110-140 в мин.")]
    MoreThan110,
    [Weight(2)]
    [Display(Name = "140-150 в мин.")]
    MoreThan140,
    [Weight(4)]
    [Display(Name = "160-180 в мин.")]
    MoreThan160,
    [Weight(4)]
    [Display(Name = "Более 180 в мин.")]
    MoreThan180,
}
