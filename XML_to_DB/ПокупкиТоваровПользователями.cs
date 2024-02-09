using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XML_to_DB;

public partial class ПокупкиТоваровПользователями
{
    [Key]
    public int IdЗаказа { get; set; }

    public int IdТовара { get; set; }

    public int КоличествоТовара { get; set; }

    public virtual КорзинаПользователя IdЗаказаNavigation { get; set; } = null!;

    public virtual Товары IdТовараNavigation { get; set; } = null!;
}
