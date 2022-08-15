using HeartWeb.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HeartWeb.Models;

public class FormModel
{
    [Key]
    public int Id { get; set; }
    [ValidateNever]
    public string Login { get; set; } = null!;
    [DisplayName("Недоношенность")]
    public bool Prematurity { get; set; }
    [DisplayName("Аспирация околоплодных вод (особенно мекониальная)")]
    public bool Aspiration { get; set; }
    [DisplayName("Апгар:")]
    [Options("3-5", "5-7", "7-9")]
    [Weights(-2,0,1)]
    [Required(ErrorMessage = "Укажите значение по шкале апгар!")]
    public byte Apgar { get; set; }
    [DisplayName("Динамика состояния:")]
    [Options("Положительная без медицинской поддержки", "Тяжёлое состояние с момента рождения", "Ухудшение к 3-4 неделе", "Резкое ухудшениечерез несколько часов после рождения")]
    [Weights(2,-2,4,5)]
    [Required(ErrorMessage = "Укажите динамику состояния!")]
    public byte StatusDynamics { get; set; }
    [DisplayName("Частота дыхания в покое:")]
    [Options("40 и менее в мин. (брадипноэ с элементами апноэ)", "40-60 в мин.", "60-80 в мин.", "80-100 в мин.")]
    [Weights(3,0,2,4)]
    [Required(ErrorMessage = "Укажите частоту дыхания в покое!")]
    public byte BreathFrequency { get; set; }
    [DisplayName("Частота сердечных сокращений в покое:")]
    [Options("Менее 110 в мин.", "110-140 в мин.", "140-150 в мин.", "160-180 в мин.", "Более 180 в мин.")]
    [Weights(3,0,2,4,4)]
    [Required(ErrorMessage = "Укажите частоту сердечных сокращений в покое!")]
    public byte HeartBeatFrequency { get; set; }
    [DisplayName("Окраска кожи:")]
    [Options("Физиологическая","Акроцианоз", "Мраморность", "Тотальный цианоз", "Дифференцированный цианоз")]
    [Weights(2,0,3,5,5)]
    [Required(ErrorMessage = "Укажите окраску кожи!")]
    public byte SkinColor { get; set; }
    [DisplayName("Переферический пульс:")]
    [Options("Удоавлетворительного наполнения на всех конечностях", "Не определяется на бедренной артерии", "Симметрично снижен")]
    [Weights(0,5,5)]
    [Required(ErrorMessage = "Укажите переферический пульс!")]
    public byte PerepherialPulse { get; set; }
    [DisplayName("Аускультативная картина:")]
    [Options("Систолический 1/6 шум на основании", "Систолический 2-3/6 вдоль левого края грудины", "Систолический 2/6 с максимумом на спине", "Отсутствие шума в сердце, шлухие сердечные тоны")]
    [Weights(0,2,4,-1)]
    [Required(ErrorMessage = "Укажите аускультативную картину!")]
    public byte AuskultativePicture { get; set; }
    [DisplayName("Динамика шума:")]
    [Options("Появляется через несколько часов или дней после рождения", "Выслушивается в родильном зале", "Нарастает с ухудшением состояния", "Исчезает с ухудшением состояния")]
    [Weights(0,4,3,6)]
    [Required(ErrorMessage = "Укажите динамику шума")]
    public byte NoiseDynamics { get; set; }
    [DisplayName("Динамика веса в первые дни жизни:")]
    [Options("Нормальная потеря", "Нет динамики", "Патологическая прибавка")]
    [Weights(0,1,2)]
    [Required(ErrorMessage = "Укажите динамику веса в первые дни жизни!")]
    public byte WeightDynamics { get; set; }
    [DisplayName("Диурез:")]
    [Options("Нормальный", "Стимулируется мочегонными", "Олигурия, переходящая в анурию")]
    [Weights(0,2,3)]
    [Required(ErrorMessage = "Укажите диурез!")]
    public byte Diurez { get; set; }
    [DisplayName("Аускультативная картина со стороны лёгких:")]
    [Options("Дыхание проводится по всем полям, хрипов нет", "Очаговые нарушения", "Постоянная крепитация по всем полям")]
    [Weights(0,-2,1)]
    [Required(ErrorMessage = "Укажите аускультативную картину со стороны лёгких!")]
    public byte AuskultativeLungPicture { get; set; }
    [DisplayName("Динамика на кардиотониках:")]
    [Options("Не применялась", "Положительная", "Нет динамики")]
    [Required(ErrorMessage = "Укажите динамику на кардиотониках!")]
    [Weights(0,2,3)]
    public byte CardioDynamics { get; set; }
    [DisplayName("Проба с дыханием 100% кислородом:")]
    [Options("Положительная", "Отрицательная")]
    [Weights(-2,6)]
    [Required(ErrorMessage = "Укажите пробу с дыханием 100% кислородом!")]
    public byte OxygenBreathTest { get; set; }
    [DisplayName("Артериальное давление руки/ноги:")]
    [Options("Равное", "Постоянный градиент более 30 мм.рт.ст.", "Системная гипотония")]
    [Weights(0,5,5)]
    [Required(ErrorMessage = "Укажите артериальное давление руки/ноги!")]
    public byte ArterialPressure { get; set; }
    [DisplayName("ЭКГ:")]
    [Options("Без особенностей", "Гипертрофия правых отделов", "Комбинированная гипертрофия или гипертрофия левого желудочка", "Патологическое отклонение ЭОС влево")]
    [Weights(0,4,2,5)]
    [Required(ErrorMessage = "Укажите ЭКГ!")]
    public byte ECG { get; set; }
    [DisplayName("Рентгенография органов грудной клетки:")]
    [Options("Нормальные размеры сердца", "Умеренное увеличение", "Кардиомегалия")]
    [Weights(-1,3,4)]
    [Required(ErrorMessage = "Укажите рентгенографию органов грудной клетки!")]
    public byte Rentgenography { get; set; }
    [DisplayName("Лёгочные поля:")]
    [Options("Без патологии", "Очаговая инфильтрация", "Усиление лёгочного рисунка", "Диффузное снижение пневматизации", "Обеднение лёгочного рисунка", "Другие изменения")]
    [Weights(3,-2,2,5,4,-5)]
    [Required(ErrorMessage = "Укажите лёгочные поля!")]
    public byte LungFields { get; set; }
    [DisplayName("Сатурация O2:")]
    [Options("95-100%", "90-95%", "80-90%", "Менее 80%")]
    [Weights(0,2,1,4)]
    [Required(ErrorMessage = "Укажите сатурацию!")]
    public byte Saturation { get; set; }
    [DisplayName("КЩС (pO2):")]
    [Options("Норма", "Умеренно снижено", "Менее 30 мм.рт.ст.")]
    [Weights(-2,0,3)]
    [Required(ErrorMessage = "Укажите КЩС (pO2)!")]
    public byte PO2 { get; set; }
    [DisplayName("КЩС:")]
    [Options("pH норма, pCO2 норма", "pH снижено, pCO2 повышено", "pH снижено, pCO2 норма", "pH снижено, pCO2 снижено")]
    [Weights(1,-2,2,3)]
    [Required(ErrorMessage = "Укажите КЩС!")]
    public byte AcidAlkalineState { get; set; }

    public int Calculate()
    {
        int total = 0;
        foreach(PropertyInfo info in GetType().GetProperties().Skip(4))
        {
            WeightsAttribute attribute = info.GetCustomAttribute(typeof(WeightsAttribute)) as WeightsAttribute;
            total += attribute.Weights[(byte)info.GetValue(this)];
        }
        return total;
    }
}
