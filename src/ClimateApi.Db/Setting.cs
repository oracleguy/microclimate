using Microsoft.EntityFrameworkCore;

namespace ClimateApi.Db;

[Index(nameof(Name), IsUnique = true)]
public class Setting
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Value { get; set; }
}