using ClosedXML.Excel;
using HeartWeb.Attributes;
using HeartWeb.Models;
using System.Reflection;

namespace HeartWeb.Instruments
{
    public static class Exporter
    {
        private static string[] GetResultsHeaderRow()
        {
            return new string[] { "Идентификатор", "Почта заполнявшего", "Время сохранения", "Время рождения", "Дни от рождения до проведения анализов", "Регион", "Населённый пункт", "Контактный телефон родителя", "Пол ребёнка", "Недоношенность", "Аспирация околоплодных вод (особенно мекониальная)", "Апгар", "Динамика состояния", "Частота дыхания в покое", "Частота сердечных сокращений в покое", "Окраска кожи", "Переферический пульс", "Аускультативная картина", "Динамика шума", "Динамика веса в первые дни жизни", "Диурез", "Аускультативная картина со стороны лёгких", "Динамика на кардиотониках", "Проба с дыханием 100% кислородом", "Артериальное давление руки/ноги", "ЭКГ", "Рентгенография органов грудной клетки", "Лёгочные поля", "Сатурация O2", "КЩС (pO2)", "КЩС" };
        }

        public static byte[] ExportResults(List<FormModel> models)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Результаты");
                string[] header = GetResultsHeaderRow();
                IXLTable table = worksheet.Range(1, 1, models.Count + 1, header.Length).CreateTable("Результаты");
                table.Cell(1, 1).InsertData(header, true);
                for (int i = 0; i < models.Count; i++)
                {
                    FormModel model = models[i];
                    List<object?> row = new List<object?>(25);
                    row.Add(model.Id);
                    row.Add(model.Login);
                    row.Add(model.SaveTime);
                    row.Add(model.BirthTime);
                    row.Add(model.DaysPassed);
                    row.Add(model.Region);
                    row.Add(model.Town);
                    row.Add(model.Phone);
                    switch (model.ChildSex)
                    {
                        case Sex.Boy:
                            row.Add("Мальчик");
                            break;
                        case Sex.Girl:
                            row.Add("Девочка");
                            break;
                        default:
                            row.Add("?");
                            break;
                    }
                    if (model.Prematurity)
                    {
                        row.Add("Да");
                    }
                    else
                    {
                        row.Add("Нет");
                    }
                    if (model.Aspiration)
                    {
                        row.Add("Да");
                    }
                    else
                    {
                        row.Add("Нет");
                    }
                    foreach (PropertyInfo info in model.GetSelectProperties())
                    {
                        byte value = (byte)info.GetValue(model);
                        row.Add((info.GetCustomAttribute(typeof(OptionsAttribute)) as OptionsAttribute).Options[value]);
                    }
                    table.Cell(i + 2, 1).InsertData(row, true);
                }
                worksheet.Columns().AdjustToContents();
                using (MemoryStream memStream = new MemoryStream())
                {
                    workbook.SaveAs(memStream);
                    return memStream.ToArray();
                }
            }
        }
    }
}
