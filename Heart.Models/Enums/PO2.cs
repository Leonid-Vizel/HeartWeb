using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum PO2
{
    [Weight(-2)]
    [Display(Name = "Норма")]
    Normal,
    [Weight(0)]
    [Display(Name = "Умеренно снижено")]
    ModeratelyReduced,
    [Weight(3)]
    [Display(Name = "Менее 30 мм.рт.ст.")]
    LessThan30
}
