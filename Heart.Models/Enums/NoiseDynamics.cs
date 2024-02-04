using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum NoiseDynamics
{
    [Weight(0)]
    [Display(Name = "Шума нет")]
    NoMurmur,
    [Weight(0)]
    [Display(Name = "Появляется через несколько часов или дней после рождения")]
    AppearsSeveralHoursOrDaysAfterBirth,
    [Weight(4)]
    [Display(Name = "Выслушивается в родильном зале")]
    AuscultatedInTheDeliveryRoom,
    [Weight(3)]
    [Display(Name = "Нарастает с ухудшением состояния")]
    IncreasesWithWorseningCondition,
    [Weight(6)]
    [Display(Name = "Исчезает с ухудшением состояния")]
    DisappearsWithWorseningCondition
}
