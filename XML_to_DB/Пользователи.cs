using System;
using System.Collections.Generic;

namespace XML_to_DB;

public partial class Пользователи
{
    public int IdПользователя { get; set; }

    public string ИмяПользователя { get; set; } = null!;

    public string? Пол { get; set; }

    public DateOnly? ДатаРождения { get; set; }

    public DateOnly? ДатаРегистрации { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public string? EmailПользователя { get; set; }

    public string? ТелефонПользователя { get; set; }

    public virtual ICollection<КорзинаПользователя> КорзинаПользователяs { get; set; } = new List<КорзинаПользователя>();
}
