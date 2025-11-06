using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingwithSQLLiteinAsp.NETCoreWebAPI.Models;

[Table("UFCEVENTS")]
public partial class Ufcevent
{
    [Key]
    [Column("EVENT")]
    public string Event { get; set; } = null!;

    [Column("URL")]
    public string? Url { get; set; }

    [Column("DATE")]
    public string? Date { get; set; }

    [Column("LOCATION")]
    public string? Location { get; set; }
}
