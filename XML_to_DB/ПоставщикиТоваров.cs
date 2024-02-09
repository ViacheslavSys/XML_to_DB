using System;
using System.Collections.Generic;

namespace XML_to_DB;

public partial class ПоставщикиТоваров
{
    public int IdПоставщика { get; set; }

    public string НаименованиеПоставщика { get; set; } = null!;

    public string? АдресПоставщика { get; set; }

    public string? ТелефонПоставщика { get; set; }

    public string? EmailПоставщика { get; set; }

    public virtual ICollection<Товары> Товарыs { get; set; } = new List<Товары>();
}
