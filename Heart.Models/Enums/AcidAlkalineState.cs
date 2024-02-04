using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum AcidAlkalineState
{
    [Weight(1)]
    [Display(Name = "pH норма, pCO2 норма")]
    PhNormalCo2Normal,
    [Weight(-2)]
    [Display(Name = "pH снижено, pCO2 повышено")]
    PhReducedCo2Increased,
    [Weight(2)]
    [Display(Name = "pH снижено, pCO2 норма")]
    PhReducedCo2Normal,
    [Weight(3)]
    [Display(Name = "pH снижено, pCO2 снижено")]
    PhReducedCo2Reduced,
}
