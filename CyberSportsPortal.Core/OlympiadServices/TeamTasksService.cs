using CyberSportsPortal.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.OlympiadServices;

public class TeamTasksService
{
    //задание 2
    public int GetTeamIncomeForYear(Team team, int year)
    {
        int profit=0;
        if (team.TeamTournamentResults != null)
        {
            foreach (var i in team.TeamTournamentResults)
            {
                if (i.Place != null)
                {
                    int curplace = i.Place.Value;
                    Tournament curtour = i.Tournament;
                    if (curtour.StartDate.Year == year && curtour.EndDate.Year == year)
                    {
                        foreach (var i2 in curtour.TournamentPrizes)
                        {
                            if (i2.Place == curplace)
                            {
                                profit += i2.Prize;
                            }
                        }
                    }
                }

            }
        }
        return profit;
    }
    // 7 задание, логику прописал, по идее должно работать, но на деле неа)))
    public List<Rating> GetNewRatings(List<MatchHistory> matches, List<Rating> oldRatings)
    {
        var NewRating = oldRatings.Select(r => new Rating
        {
            Id = r.Id,
            Score = r.Score,
            AtMoment = r.AtMoment,
            TeamId = r.TeamId,
            Team = r.Team
        }).ToList();
        var sortingmatches = matches.OrderBy(d => d.Date);
        foreach (var match in sortingmatches)
        {
            var wR = NewRating.Find(r => r.TeamId == match.WinnerId);
            var lR = NewRating.Find(r => r.TeamId == match.LoserId);
            int points;
            if (wR.Score > lR.Score)
            {
                points = (int)Math.Round(lR.Score * 0.01);
            }
            else if (wR.Score < lR.Score)
            {
                points = (int)Math.Round(lR.Score * 0.1);
            }
            else
            {
                points = (int)Math.Round(lR.Score * 0.1);
            }

            wR.Score += points;
            lR.Score -= points;
        }

        return NewRating;
    }
}