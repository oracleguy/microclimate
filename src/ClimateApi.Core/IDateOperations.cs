namespace ClimateApi.Core;

public interface IDateOperations
{
    IEnumerable<DateOnly> GetPreviousFiveYears(DateOnly start);
}