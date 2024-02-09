using System;
using System.Collections.Generic;

namespace XML_to_DB;

public partial class КатегорииТоваров
{
    public int IdКатегорииТовара { get; set; }

    public string НазваниеКатегорииТовара { get; set; } = null!;

    public string? ОписаниеКатегорииТовара { get; set; }

    public virtual ICollection<Товары> Товарыs { get; set; } = new List<Товары>();
}
