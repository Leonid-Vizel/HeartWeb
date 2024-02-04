using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum PerepherialPulse
{
    [Weight(0)]
    [Display(Name = "Удовлетворительного наполнения на всех конечностях")]
    SatisfactoryFillingInAllExtremities,
    [Weight(5)]
    [Display(Name = "Не определяется на бедренной артерии")]
    NotDetectedInTheFemoralArtery,
    [Weight(5)]
    [Display(Name = "Симметрично снижен")]
    SymmetricallyReduced
}
