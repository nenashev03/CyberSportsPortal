using CyberSportsPortal.Data.Model.Views;
using System;
using System.Collections.Generic;

namespace CyberSportsPortal.Core.OlympiadServices;

public class PlayerTasksService
{
    public List<PlayerView> FilterPlayers(List<PlayerView> players, string filter)
    {
        // задание 5
        // n s +
        // kir+
        // igor+\
        var filteredPlayers = new List<PlayerView>();
        if (players.Count>0 && !string.IsNullOrEmpty(filter))
        {
            string filterLower = filter.ToLower();

            foreach (var player in players)
            {
                if (player.NickName != null && player.NickName.ToLower().Contains(filter))
                {
                    filteredPlayers.Add(player);
                    continue;
                }
                if (player.NickName != null && player.CombinedName.ToLower().Contains(filter))
                {
                    filteredPlayers.Add(player);
                }
            }          
        }
        return filteredPlayers;
    }
    
}