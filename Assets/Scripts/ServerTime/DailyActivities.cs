using System;
using System.Globalization;
using UnityEngine;
using Zenject;
using YG;

public class DailyActivities : MonoBehaviour
{
    private const string Format = "yyyy-MM-dd";
    private QuestData[] _questDates;
    private LocationLevel _locationLevel;
    
    [Inject]
    public void Contruct(QuestData[] questDates, LocationLevel locationLevel)
    {
        _questDates = questDates;
        _locationLevel = locationLevel;
    }
    
    private void OnEnable()
    {
         YG2.onGetSDKData += OnData;
    }
    
    private void OnDisable()
    {
        YG2.onGetSDKData -= OnData;
    }

    private void OnData()
    {
        DateTime currentDate = DateTimeOffset.FromUnixTimeMilliseconds(YG2.ServerTime()).UtcDateTime;

        bool parseSuccess = DateTime.TryParseExact(
            YG2.saves.LastDateTime, 
            Format,  
            CultureInfo.InvariantCulture, 
            DateTimeStyles.AssumeUniversal, 
            out var lastRewardDate
        );

        if (parseSuccess == false)
            lastRewardDate = DateTime.MinValue;

        if (lastRewardDate.Date < currentDate.Date)
        {
            foreach (var questData in _questDates)
                questData.Reset();
            
            _locationLevel.Reset();
            YG2.saves.LastDateTime = currentDate.Date.ToString(Format, CultureInfo.InvariantCulture);
        }
    }
}