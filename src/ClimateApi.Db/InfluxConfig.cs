using System.Text;

namespace ClimateApi.Db;

public sealed class InfluxConfig
{
    public required string Bucket { get; set; }

    public required string Url { get; set; }

    public required string Token { get; set; }

    public override string ToString()
    {
        var text = new StringBuilder();
        text.AppendLine($"Url: {Url}");
        text.AppendLine($"Token: {Token}");
        text.AppendLine($"Bucket Name: {Bucket}");
        return text.ToString();
    }
}