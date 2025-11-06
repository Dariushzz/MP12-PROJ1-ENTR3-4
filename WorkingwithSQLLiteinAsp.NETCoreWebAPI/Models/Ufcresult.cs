using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingwithSQLLiteinAsp.NETCoreWebAPI.Models;

[Table("UFCRESULTS")]
public partial class Ufcresult
{
    [Column("EVENT")]
    public string? Event { get; set; }

    [Key]
    [Column("FIGHTERS")]
    public string Fighters { get; set; } = null!;

    [Column("URL")]
    public string? Url { get; set; }
}
