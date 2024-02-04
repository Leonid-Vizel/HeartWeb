using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum ECG
{
    [Weight(0)]
    [Display(Name = "Без особенностей")]
    NoFeatures,
    [Weight(4)]
    [Display(Name = "Гипертрофия правых отделов")]
    RightHypertrophy,
    [Weight(2)]
    [Display(Name = "Комбинированная гипертрофия или гипертрофия левого желудочка")]
    CmbinedLeftHypertrophy,
    [Weight(5)]
    [Display(Name = "Патологическое отклонение ЭОС влево")]
    PathologicalLeftDeviation
}
