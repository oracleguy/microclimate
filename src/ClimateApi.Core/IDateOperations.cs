namespace ClimateApi.Core;

public interface IDateOperations
{
    IEnumerable<DateOnly> GetPreviousFiveYears(DateOnly start);

    DateOnly Today();

    DateOnly Yesterday();
}