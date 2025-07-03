using CyberSportsPortal.Data.Entities;
using CyberSportsPortal.Data.Model.Enums;
using CyberSportsPortal.Data.Model.Views;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.OlympiadServices;

public class TournamentTasksService
{
    // 1 задание
    public string GetTournamentStatus(Tournament tournament)
    {
        string res = "В процессе";
        if (tournament.StartDate < DateTime.UtcNow) res = "Не начался";
        else if (tournament.EndDate > DateTime.UtcNow) res = "Окончен";
        return res;
    }
    // 3 задание
    public int GetPlayersFromCountryCount(List<Player> players, Country country)
    {
        int count = 0;
        if (players.Count > 0)
        {
            foreach (var player in players)
            {
                if (
                    player.Country == country)
                {
                    count++;
                }
            }
        }
        else return -1;
         return count;
    }
   // 4 задание
    public string GetTeamParticipantsNameString(List<Team> teams)
    {
        string result = string.Empty;
        for (int i = 0; i < teams.Count; i++)
        {
            result += teams[i].Name + ", ";
        }
        result=result.Substring(0, result.Length - 2);
        return result;
    }
    // 6 задание
    //очень странное задание( сначала интовские переводятся в строки, а затем снова из строк в интовские значение)
    public int ComparePrizes(string prizeA, string prizeB)
    {
        int a = int.Parse(prizeA);
        int b = int.Parse(prizeB);
        if (a>b)
            return 1;
        else if (a==b)
            return 0;
        else
            return -1;
    }

    public Dictionary<int, decimal> GetTournamentVictoryProbabilities(List<TeamWithVictoryProbabilities> teams, Dictionary<int, int> standings)
    {
        return new Dictionary<int, decimal>();
    }
}