using System;
using System.Collections.Generic;

namespace XML_to_DB;

public partial class КорзинаПользователя
{
    public int IdЗаказа { get; set; }

    public int IdПользователя { get; set; }

    public DateOnly? ДатаЗаказа { get; set; }

    public TimeOnly? ВремяЗаказа { get; set; }

    public string? СтатусЗаказа { get; set; }

    public decimal? СтоимостьЗаказа { get; set; }

    public string? АдресДоставки { get; set; }

    public string? СпособПолучения { get; set; }

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;
}
