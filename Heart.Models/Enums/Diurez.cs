using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum Diurez
{
    [Weight(0)]
    [Display(Name = "Нормальный")]
    Normal,
    [Weight(2)]
    [Display(Name = "Стимулируется мочегонными")]
    StimulatedByDiuretics,
    [Weight(3)]
    [Display(Name = "Олигурия, переходящая в анурию")]
    OliguriaProgressingToAnuria,
}
