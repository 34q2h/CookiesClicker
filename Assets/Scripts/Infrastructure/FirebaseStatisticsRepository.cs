using CookiesClicker.DTO;
using Cysharp.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace CookiesClicker.Infrastructure
{
    public class FirebaseStatisticsRepository : IStatisticsRepository
    {
        async UniTask<LeadrsDTO> IStatisticsRepository.PullLeaders()
        {
            try
            {
                var snapshot = await FirebaseDatabase
                    .DefaultInstance
                    .GetReference(Constants.DB_LEADERS)
                    .OrderByValue()
                    .GetValueAsync();

                var dbResult = JsonConvert
                    .DeserializeObject<Dictionary<string, int>>(snapshot.GetRawJsonValue());

                return new LeadrsDTO(dbResult);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                return null;
            }
        }
    }
}