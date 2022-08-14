using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeartWeb.Models;

public class FormModel
{
    [Key]
    public int Id { get; set; }
    [ValidateNever]
    public string Login { get; set; }
    [DisplayName("Недоношенность")]
    public bool Prematurity { get; set; }
    [DisplayName("Аспирация околоплодных вод (особенно мекониальная)")]
    public bool Aspiration { get; set; }
    [DisplayName("Апгар:")]
    [Required(ErrorMessage = "Укажите значение по шкале апгар!")]
    public byte Apgar { get; set; }
    [DisplayName("Динамика состояния:")]
    [Required(ErrorMessage = "Укажите динамику состояния!")]
    public byte StatusDynamics { get; set; }
    [DisplayName("Частота дыхания в покое:")]
    [Required(ErrorMessage = "Укажите частоту дыхания в покое!")]
    public byte BreathFrequency { get; set; }
    [DisplayName("Частота сердечных сокращений в покое:")]
    [Required(ErrorMessage = "Укажите частоту сердечных сокращений в покое!")]
    public byte HeartBeatFrequency { get; set; }
    [DisplayName("Окраска кожи:")]
    [Required(ErrorMessage = "Укажите окраску кожи!")]
    public byte SkinColor { get; set; }
    [DisplayName("Переферический пульс:")]
    [Required(ErrorMessage = "Укажите переферический пульс!")]
    public byte PerepherialPulse { get; set; }
    [DisplayName("Аускультативная картина:")]
    [Required(ErrorMessage = "Укажите аускультативную картину!")]
    public byte AuskultativePicture { get; set; }
    [DisplayName("Динамика шума:")]
    [Required(ErrorMessage = "Укажите динамику шума")]
    public byte NoiseDynamics { get; set; }
    [DisplayName("Динамика веса в первые дни жизни:")]
    [Required(ErrorMessage = "Укажите динамику веса в первые дни жизни!")]
    public byte WeightDynamics { get; set; }
    [DisplayName("Диурез:")]
    [Required(ErrorMessage = "Укажите диурез!")]
    public byte Diurez { get; set; }
    [DisplayName("Аускультативная картина со стороны лёгких:")]
    [Required(ErrorMessage = "Укажите аускультативную картину со стороны лёгких!")]
    public byte AuskultativeLungPicture { get; set; }
    [DisplayName("Динамика на кардиотониках:")]
    [Required(ErrorMessage = "Укажите динамику на кардиотониках!")]
    public byte CardioDynamics { get; set; }
    [DisplayName("Проба с дыханием 100% кислородом:")]
    [Required(ErrorMessage = "Укажите пробу с дыханием 100% кислородом!")]
    public byte OxygenBreathTest { get; set; }
    [DisplayName("Артериальное давление руки/ноги:")]
    [Required(ErrorMessage = "Укажите артериальное давление руки/ноги!")]
    public byte ArterialPressure { get; set; }
    [DisplayName("ЭКГ:")]
    [Required(ErrorMessage = "Укажите ЭКГ!")]
    public byte ECG { get; set; }
    [DisplayName("Рентгенография органов грудной клетки:")]
    [Required(ErrorMessage = "Укажите рентгенографию органов грудной клетки!")]
    public byte Rentgenography { get; set; }
    [DisplayName("Лёгочные поля:")]
    [Required(ErrorMessage = "Укажите лёгочные поля!")]
    public byte LungFields { get; set; }
    [DisplayName("Сатурация O2:")]
    [Required(ErrorMessage = "Укажите сатурацию!")]
    public byte Saturation { get; set; }
    [DisplayName("КЩС (pO2):")]
    [Required(ErrorMessage = "Укажите КЩС (pO2)!")]
    public byte PO2 { get; set; }
    [DisplayName("КЩС:")]
    [Required(ErrorMessage = "Укажите КЩС!")]
    public byte AcidAlkalineState { get; set; }

    public byte Calculate()
    {
        byte total = 0;
        if (Prematurity)
        {
            total -= 2;
        }
        if (Aspiration)
        {
            total -= 2;
        }
        switch (Apgar)
        {
            case 0:
                total -= 2;
                break;
            case 2:
                total += 1;
                break;
        }
        switch (StatusDynamics)
        {
            case 0:
                total += 2;
                break;
            case 1:
                total -= 2;
                break;
            case 2:
                total += 4;
                break;
            case 3:
                total += 5;
                break;
        }
        switch (BreathFrequency)
        {
            case 0:
                total += 3;
                break;
            case 2:
                total += 2;
                break;
            case 3:
                total += 4;
                break;
        }
        switch (HeartBeatFrequency)
        {
            case 0:
                total += 3;
                break;
            case 2:
                total += 2;
                break;
            case 3:
            case 4:
                total += 4;
                break;
        }
        switch (SkinColor)
        {
            case 0:
                total += 2;
                break;
            case 2:
                total += 4;
                break;
            case 3:
            case 4:
                total += 5;
                break;
        }
        switch (PerepherialPulse)
        {
            case 1:
            case 2:
                total += 5;
                break;
        }
        switch (AuskultativePicture)
        {
            case 1:
                total += 2;
                break;
            case 2:
                total += 4;
                break;
            case 3:
                total -= 1;
                break;
        }
        switch (NoiseDynamics)
        {
            case 1:
                total += 4;
                break;
            case 2:
                total += 3;
                break;
            case 3:
                total += 6;
                break;
        }
        switch (WeightDynamics)
        {
            case 1:
                total += 1;
                break;
            case 2:
                total += 2;
                break;
        }
        switch (Diurez)
        {
            case 1:
                total += 2;
                break;
            case 2:
                total += 3;
                break;
        }
        switch (AuskultativeLungPicture)
        {
            case 1:
                total -= 2;
                break;
            case 2:
                total += 1;
                break;
        }
        switch (CardioDynamics)
        {
            case 1:
                total += 2;
                break;
            case 2:
                total += 3;
                break;
        }
        switch (OxygenBreathTest)
        {
            case 0:
                total -= 2;
                break;
            case 1:
                total += 6;
                break;
        }
        switch (ArterialPressure)
        {
            case 1:
            case 2:
                total += 5;
                break;
        }
        switch (ECG)
        {
            case 1:
                total += 4;
                break;
            case 2:
                total += 2;
                break;
            case 3:
                total += 5;
                break;
        }
        switch (Rentgenography)
        {
            case 0:
                total -= 1;
                break;
            case 1:
                total += 3;
                break;
            case 2:
                total += 4;
                break;
        }
        switch (LungFields)
        {
            case 0:
                total += 3;
                break;
            case 1:
                total -= 2;
                break;
            case 2:
                total += 2;
                break;
            case 3:
                total += 5;
                break;
            case 4:
                total += 4;
                break;
            case 5:
                total -= 5;
                break;
        }
        switch (Saturation)
        {
            case 1:
                total += 2;
                break;
            case 2:
                total += 1;
                break;
            case 3:
                total += 4;
                break;
        }
        switch (PO2)
        {
            case 0:
                total -= 2;
                break;
            case 2:
                total += 3;
                break;
        }
        switch (AcidAlkalineState)
        {
            case 0:
                total += 1;
                break;
            case 1:
                total -= 2;
                break;
            case 2:
                total += 2;
                break;
            case 3:
                total += 3;
                break;
        }
        return total;
    }

    //public override string ToString()
    //    => $"{Convert.ToInt16(Prematurity)}-{Convert.ToInt16(Aspiration)}-{Apgar}-{StatusDynamics}-{BreathFrequency}-{HeartBeatFrequency}-{SkinColor}-{PerepherialPulse}-{AuskultativePicture}-{NoiseDynamics}-{WeightDynamics}-{Diurez}-{AuskultativeLungPicture}-{CardioDynamics}-{OxygenBreathTest}-{ArterialPressure}-{ECG}-{Rentgenography}-{LungFields}-{Saturation}-{PO2}-{AcidAlkalineState}";

    //public static FormModel? FromString(string initial)
    //{
    //    byte[] values = initial.Split('-').Select(x => byte.Parse(x)).ToArray();
    //    FormModel model = new FormModel();
    //    PropertyInfo[] props = model.GetType().GetProperties().Skip(2).ToArray();
    //    if (values.Length != props.Length+2)
    //    {
    //        return null;
    //    }
    //    model.Prematurity = values[0] == 1;
    //    model.Aspiration = values[1] == 1;
    //    for (int i = 0; i < props.Length; i++)
    //    {
    //        props[i].SetValue(model, values[i]);
    //    }
    //    return model;
    //}
}
