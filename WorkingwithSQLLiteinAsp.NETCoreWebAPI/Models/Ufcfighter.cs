using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingwithSQLLiteinAsp.NETCoreWebAPI.Models;

[Table("UFCFIGHTERS")]
public partial class Ufcfighter
{
    [Column("DOB")]
    public string? Dob { get; set; }

    [Key]
    [Column("FIGHTER")]
    public string Fighter { get; set; } = null!;

    [Column("HEIGHT")]
    public string? Height { get; set; }

    [Column("REACH")]
    public string? Reach { get; set; }

    [Column("STANCE")]
    public string? Stance { get; set; }

    [Column("URL")]
    public string? Url { get; set; }

    [Column("WEIGHT")]
    public string? Weight { get; set; }
}
