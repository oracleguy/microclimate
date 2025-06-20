using ClimateApi.Model;

namespace ClimateApi;

public interface IDataOverview
{
    Snapshot GetToday();

    Snapshot GetYesterday();

    int GetDaysStored();

    List<Snapshot> OnThisDay();
}