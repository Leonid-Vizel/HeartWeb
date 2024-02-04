using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Heart.Models.Data.DataRows;

public sealed class DataRow : DataRowBase
{
    [Key]
    public int Id { get; set; }
    [DisplayName("Время сохранения: ")]
    public DateTime SaveTime { get; set; }

    public DataRow()
    {
        
    }
}
