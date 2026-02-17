using System;
using System.Collections.Generic;
using System.Linq;

// Team class
public class Team : IComparable<Team>
{
    public string Name { get; set; }
    public int Points { get; set; }

    // Compare by points (descending), then by name
    public int CompareTo(Team other)
    {
        int pointCompare = other.Points.CompareTo(this.Points); // descending
        if (pointCompare == 0)
            return this.Name.CompareTo(other.Name);

        return pointCompare;
    }
}

// Match class
public class Match
{
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public int Team1PointsBefore { get; set; }
    public int Team2PointsBefore { get; set; }

    public Match(Team t1, Team t2)
    {
        Team1 = t1;
        Team2 = t2;
    }

    // Clone for undo
    public Match Clone()
    {
        return new Match(Team1, Team2)
        {
            Team1PointsBefore = Team1.Points,
            Team2PointsBefore = Team2.Points
        };
    }
}

// Tournament class
public class Tournament
{
    private SortedList<int, Team> _rankings = new SortedList<int, Team>();
    private LinkedList<Match> _schedule = new LinkedList<Match>();
    private Stack<Match> _undoStack = new Stack<Match>();
    private List<Team> _teams = new List<Team>();

    // Add match to schedule
    public void ScheduleMatch(Match match)
    {
        _schedule.AddLast(match);

        if (!_teams.Contains(match.Team1)) _teams.Add(match.Team1);
        if (!_teams.Contains(match.Team2)) _teams.Add(match.Team2);
    }

    // Record result
    public void RecordMatchResult(Match match, int team1Score, int team2Score)
    {
        _undoStack.Push(match.Clone());

        if (team1Score > team2Score)
            match.Team1.Points += 3;
        else if (team2Score > team1Score)
            match.Team2.Points += 3;
        else
        {
            match.Team1.Points += 1;
            match.Team2.Points += 1;
        }

        UpdateRankings();
    }

    // Undo last match
    public void UndoLastMatch()
    {
        if (_undoStack.Count == 0) return;

        var last = _undoStack.Pop();
        last.Team1.Points = last.Team1PointsBefore;
        last.Team2.Points = last.Team2PointsBefore;

        UpdateRankings();
    }

    // Update sorted rankings
    private void UpdateRankings()
    {
        _rankings.Clear();

        var sorted = _teams.OrderBy(t => t).ToList();

        int rank = 1;
        foreach (var team in sorted)
        {
            _rankings.Add(rank++, team);
        }
    }

    // Binary search ranking lookup
    public int GetTeamRanking(Team team)
    {
        int left = 0;
        int right = _rankings.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            var current = _rankings.Values[mid];

            if (current == team)
                return _rankings.Keys[mid];

            if (current.CompareTo(team) < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    public List<Team> GetRankings()
    {
        return _rankings.Values.ToList();
    }
}

// Test
class Program
{
    public static void Main()
    {
        Tournament tournament = new Tournament();

        Team teamA = new Team { Name = "Team Alpha", Points = 0 };
        Team teamB = new Team { Name = "Team Beta", Points = 0 };

        Match match = new Match(teamA, teamB);

        tournament.ScheduleMatch(match);
        tournament.RecordMatchResult(match, 3, 1); // Team Alpha wins

        var rankings = tournament.GetRankings();
        Console.WriteLine(rankings[0].Name); // Team Alpha

        tournament.UndoLastMatch();
        Console.WriteLine(teamA.Points); // 0
    }
}
