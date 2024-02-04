using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum AuskultativeLungPicture
{
    [Weight(0)]
    [Display(Name = "Дыхание проводится по всем полям, хрипов нет")]
    NoWheezing,
    [Weight(-2)]
    [Display(Name = "Очаговые нарушения")]
    FocalDisturbances,
    [Weight(1)]
    [Display(Name = "Постоянная крепитация по всем полям")]
    ConstantCrepitus
}
