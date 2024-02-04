using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Heart.Models.Enums;

namespace Heart.Models.Data.DataRows;

public abstract class DataRowBase
{
    [DisplayName("Пол ребёнка")]
    [Range(0, 1, ErrorMessage = "Выберите пол ребёнка!")]
    [Required(ErrorMessage = "Выберите пол ребёнка!")]
    public Sex Sex { get; set; }
    [DisplayName("Время рождения ребёнка")]
    [Required(ErrorMessage = "Укажите время рождения ребёнка!")]
    public DateTime BirthTime { get; set; }
    [DisplayName("На какой день от рождения проводились анализы?")]
    [Required(ErrorMessage = "Укажите на какой день от рождения проводились анализы!")]
    [Range(0, 28, ErrorMessage = "Форма действительна только если анализы проведены не более чем через 28 дней после рождения!")]
    public int DaysPassed { get; set; }
    [Required(ErrorMessage = "Укажите номер телефона!")]
    [MinLength(1, ErrorMessage = "Минимальный размер телефонного номера: 1 символ!")]
    [MaxLength(16, ErrorMessage = "Максимальный размер телефонного номера: 16 символов!")]
    [DisplayName("Контактный номер телефона родителей")]
    [Phone(ErrorMessage = "Неверный формат номера телефона!")]
    public string Phone { get; set; } = null!;
    [Required(ErrorMessage = "Укажите регион!")]
    [MinLength(1, ErrorMessage = "Минимальный размер региона: 1 символ!")]
    [MaxLength(100, ErrorMessage = "Максимальный размер региона: 100 символов!")]
    [DisplayName("Регион")]
    public string Region { get; set; } = null!;
    [Required(ErrorMessage = "Укажите населённый пункт!")]
    [MinLength(1, ErrorMessage = "Минимальный размер населённого пункта: 1 символ!")]
    [MaxLength(100, ErrorMessage = "Максимальный размер региона: 100 символов!")]
    [DisplayName("Населённый пункт")]
    public string Town { get; set; } = null!;
    [DisplayName("Недоношенность")]
    public bool Prematurity { get; set; }
    [DisplayName("Аспирация околоплодных вод (особенно мекониальная)")]
    public bool Aspiration { get; set; }
    [DisplayName("Апгар:")]
    [Required(ErrorMessage = "Укажите значение по шкале апгар!")]
    public Apgar Apgar { get; set; }
    [DisplayName("Динамика состояния:")]
    [Required(ErrorMessage = "Укажите динамику состояния!")]
    public StatusDynamics StatusDynamics { get; set; }
    [DisplayName("Частота дыхания в покое:")]
    [Required(ErrorMessage = "Укажите частоту дыхания в покое!")]
    public BreathFrequency BreathFrequency { get; set; }
    [DisplayName("Частота сердечных сокращений в покое:")]
    [Required(ErrorMessage = "Укажите частоту сердечных сокращений в покое!")]
    public HeartBeatFrequency HeartBeatFrequency { get; set; }
    [DisplayName("Окраска кожи:")]
    [Required(ErrorMessage = "Укажите окраску кожи!")]
    public SkinColor SkinColor { get; set; }
    [DisplayName("Переферический пульс:")]
    [Required(ErrorMessage = "Укажите переферический пульс!")]
    public PerepherialPulse PerepherialPulse { get; set; }
    [DisplayName("Аускультативная картина:")]
    [Required(ErrorMessage = "Укажите аускультативную картину!")]
    public AuskultativePicture AuskultativePicture { get; set; }
    [DisplayName("Динамика шума:")]
    [Required(ErrorMessage = "Укажите динамику шума")]
    public NoiseDynamics NoiseDynamics { get; set; }
    [DisplayName("Динамика веса в первые дни жизни:")]
    [Required(ErrorMessage = "Укажите динамику веса в первые дни жизни!")]
    public WeightDynamics WeightDynamics { get; set; }
    [DisplayName("Диурез:")]
    [Required(ErrorMessage = "Укажите диурез!")]
    public Diurez Diurez { get; set; }
    [DisplayName("Аускультативная картина со стороны лёгких:")]
    [Required(ErrorMessage = "Укажите аускультативную картину со стороны лёгких!")]
    public AuskultativeLungPicture AuskultativeLungPicture { get; set; }
    [DisplayName("Динамика на кардиотониках:")]
    [Required(ErrorMessage = "Укажите динамику на кардиотониках!")]
    public CardioDynamics CardioDynamics { get; set; }
    [DisplayName("Проба с дыханием 100% кислородом:")]
    [Required(ErrorMessage = "Укажите пробу с дыханием 100% кислородом!")]
    public OxygenBreathTest OxygenBreathTest { get; set; }
    [DisplayName("Артериальное давление руки/ноги:")]
    [Required(ErrorMessage = "Укажите артериальное давление руки/ноги!")]
    public ArterialPressure ArterialPressure { get; set; }
    [DisplayName("ЭКГ:")]
    [Required(ErrorMessage = "Укажите ЭКГ!")]
    public ECG ECG { get; set; }
    [DisplayName("Рентгенография органов грудной клетки:")]
    [Required(ErrorMessage = "Укажите рентгенографию органов грудной клетки!")]
    public Rentgenography Rentgenography { get; set; }
    [DisplayName("Лёгочные поля:")]
    [Required(ErrorMessage = "Укажите лёгочные поля!")]
    public LungFields LungFields { get; set; }
    [DisplayName("Сатурация O2:")]
    [Required(ErrorMessage = "Укажите сатурацию!")]
    public Saturation Saturation { get; set; }
    [DisplayName("КЩС (pO2):")]
    [Required(ErrorMessage = "Укажите КЩС (pO2)!")]
    public PO2 PO2 { get; set; }
    [DisplayName("КЩС:")]
    [Required(ErrorMessage = "Укажите КЩС!")]
    public AcidAlkalineState AcidAlkalineState { get; set; }

    public DataRowBase() : base() { }
    public DataRowBase(DataRowBase model) : this()
    {
        BirthTime = model.BirthTime;
        Sex = model.Sex;
        DaysPassed = model.DaysPassed;
        Phone = model.Phone;
        Region = model.Region;
        Town = model.Town;
        Prematurity = model.Prematurity;
        Aspiration = model.Aspiration;
        Apgar = model.Apgar;
        StatusDynamics = model.StatusDynamics;
        BreathFrequency = model.BreathFrequency;
        HeartBeatFrequency = model.HeartBeatFrequency;
        SkinColor = model.SkinColor;
        PerepherialPulse = model.PerepherialPulse;
        AuskultativePicture = model.AuskultativePicture;
        NoiseDynamics = model.NoiseDynamics;
        WeightDynamics = model.WeightDynamics;
        Diurez = model.Diurez;
        AuskultativeLungPicture = model.AuskultativeLungPicture;
        CardioDynamics = model.CardioDynamics;
        OxygenBreathTest = model.OxygenBreathTest;
        ArterialPressure = model.ArterialPressure;
        ECG = model.ECG;
        Rentgenography = model.Rentgenography;
        LungFields = model.LungFields;
        Saturation = model.Saturation;
        PO2 = model.PO2;
        AcidAlkalineState = model.AcidAlkalineState;
    }

    public void Update(DataRowBase model)
    {
        if (BirthTime != model.BirthTime)
        {
            BirthTime = model.BirthTime;
        }
        if (Sex != model.Sex)
        {
            Sex = model.Sex;
        }
        if (DaysPassed != model.DaysPassed)
        {
            DaysPassed = model.DaysPassed;
        }
        if (Phone != model.Phone)
        {
            Phone = model.Phone;
        }
        if (Region != model.Region)
        {
            Region = model.Region;
        }
        if (Town != model.Town)
        {
            Town = model.Town;
        }
        if (Prematurity != model.Prematurity)
        {
            Prematurity = model.Prematurity;
        }
        if (Aspiration != model.Aspiration)
        {
            Aspiration = model.Aspiration;
        }
        if (Apgar != model.Apgar)
        {
            Apgar = model.Apgar;
        }
        if (StatusDynamics != model.StatusDynamics)
        {
            StatusDynamics = model.StatusDynamics;
        }
        if (BreathFrequency != model.BreathFrequency)
        {
            BreathFrequency = model.BreathFrequency;
        }
        if (HeartBeatFrequency != model.HeartBeatFrequency)
        {
            HeartBeatFrequency = model.HeartBeatFrequency;
        }
        if (SkinColor != model.SkinColor)
        {
            SkinColor = model.SkinColor;
        }
        if (PerepherialPulse != model.PerepherialPulse)
        {
            PerepherialPulse = model.PerepherialPulse;
        }
        if (AuskultativePicture != model.AuskultativePicture)
        {
            AuskultativePicture = model.AuskultativePicture;
        }
        if (NoiseDynamics != model.NoiseDynamics)
        {
            NoiseDynamics = model.NoiseDynamics;
        }
        if (WeightDynamics != model.WeightDynamics)
        {
            WeightDynamics = model.WeightDynamics;
        }
        if (Diurez != model.Diurez)
        {
            Diurez = model.Diurez;
        }
        if (AuskultativeLungPicture != model.AuskultativeLungPicture)
        {
            AuskultativeLungPicture = model.AuskultativeLungPicture;
        }
        if (CardioDynamics != model.CardioDynamics)
        {
            CardioDynamics = model.CardioDynamics;
        }
        if (OxygenBreathTest != model.OxygenBreathTest)
        {
            OxygenBreathTest = model.OxygenBreathTest;
        }
        if (ArterialPressure != model.ArterialPressure)
        {
            ArterialPressure = model.ArterialPressure;
        }
        if (ECG != model.ECG)
        {
            ECG = model.ECG;
        }
        if (Rentgenography != model.Rentgenography)
        {
            Rentgenography = model.Rentgenography;
        }
        if (LungFields != model.LungFields)
        {
            LungFields = model.LungFields;
        }
        if (Saturation != model.Saturation)
        {
            Saturation = model.Saturation;
        }
        if (PO2 != model.PO2)
        {
            PO2 = model.PO2;
        }
        if (AcidAlkalineState != model.AcidAlkalineState)
        {
            AcidAlkalineState = model.AcidAlkalineState;
        }
    }
}
