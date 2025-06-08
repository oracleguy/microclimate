using System.Text;

namespace ClimateApi.Db;

public sealed class InfluxConfig
{
    public required string BucketName { get; set; }

    public required string Url { get; set; }

    public required string Token { get; set; }

    public override string ToString()
    {
        var text = new StringBuilder();
        text.AppendLine($"Url: {Url}");
        text.AppendLine($"Token: {Token}");
        text.AppendLine($"Bucket Name: {BucketName}");
        return text.ToString();
    }
}