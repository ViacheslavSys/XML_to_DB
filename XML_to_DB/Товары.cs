using System;
using System.Collections.Generic;

namespace XML_to_DB;

public partial class Товары
{
    public int IdТовара { get; set; }

    public string НазваниеТовара { get; set; } = null!;

    public decimal ЦенаТовара { get; set; }

    public string? ОписаниеТовара { get; set; }

    public string? АртикулТовара { get; set; }

    public int? IdКатегорииТовара { get; set; }

    public int? IdПоставщика { get; set; }

    public string? РазмерыТовара { get; set; }

    public decimal? ВесТовара { get; set; }

    public virtual КатегорииТоваров? IdКатегорииТовараNavigation { get; set; }

    public virtual ПоставщикиТоваров? IdПоставщикаNavigation { get; set; }
}
