using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum Saturation
{
    [Weight(0)]
    [Display(Name = "95-100%")]
    Values95To100,
    [Weight(2)]
    [Display(Name = "90-95%")]
    Values90To95,
    [Weight(1)]
    [Display(Name = "80-90%")]
    Values80To90,
    [Weight(4)]
    [Display(Name = "Менее 80%")]
    LessThan80,
}
