using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum LungFields
{
    [Weight(3)]
    [Display(Name = "Без патологии")]
    NoPathology,
    [Weight(-2)]
    [Display(Name = "Очаговая инфильтрация")]
    FocalInfiltration,
    [Weight(2)]
    [Display(Name = "Усиление лёгочного рисунка")]
    IncreasedPulmonaryPattern,
    [Weight(5)]
    [Display(Name = "Диффузное снижение пневматизации")]
    DiffuseDecreaseInPneumatization,
    [Weight(4)]
    [Display(Name = "Обеднение лёгочного рисунка")]
    DepletionOfPulmonaryPattern,
    [Weight(-5)]
    [Display(Name = "Другие изменения")]
    OtherChanges
}
