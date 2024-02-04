using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum AuskultativePicture
{
    [Weight(0)]
    [Display(Name = "Систолический 1/6 шум на основании")]
    SystolicMurmurAtTheBase,
    [Weight(2)]
    [Display(Name = "Систолический 2-3/6 вдоль левого края грудины")]
    SystolicAlongTheLeftSternalBorder,
    [Weight(4)]
    [Display(Name = "Систолический 2/6 с максимумом на спине")]
    SystolicWithAMaximumAtTheBack,
    [Weight(-1)]
    [Display(Name = "Отсутствие шума в сердце, шлухие сердечные тоны")]
    AbsenceOfHeartMurmur
}
