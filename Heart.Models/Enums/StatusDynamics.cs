using Heart.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Enums;

public enum StatusDynamics
{
    [Weight(2)]
    [Display(Name = "Положительная без медицинской поддержки")]
    PositiveWithoutMedicalAssistance,
    [Weight(-2)]
    [Display(Name = "Тяжёлое состояние с момента рождения")]
    ComplexConditionSinceBirth,
    [Weight(4)]
    [Display(Name = "Ухудшение к 3-4 неделе")]
    ThirdToFourthWeekDeterioration,
    [Weight(5)]
    [Display(Name = "Резкое ухудшение через несколько часов после рождения")]
    SuddenDeteriorationAfterServeralHours,
}
