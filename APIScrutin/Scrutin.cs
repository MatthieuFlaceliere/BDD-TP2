namespace ProjetScrutin;

public class Scrutin
{
    private bool _isDone;

    private Dictionary<string, int> _votes = new();

    public void Init(Dictionary<string, int>? votes)
    {
        if (votes != null) _votes = votes;
        Open();
    }

    public void AddVote(string vote)
    {
        if (_isDone) throw new Exception("Scrutin is done");
        _votes[vote]++;
    }

    public Dictionary<string, VoteWithPercentage> GetVotesWithPercentages()
    {
        var total = _votes.Values.Sum();
        var result = new Dictionary<string, VoteWithPercentage>();
        foreach (var vote in _votes)
            result.Add(vote.Key, new VoteWithPercentage
            {
                Vote = vote.Value,
                Percentage = (float)vote.Value / total * 100
            });
        return result;
    }

    public void Open()
    {
        _isDone = false;
    }

    public void End()
    {
        _isDone = true;
    }

    public string GetWinner()
    {
        if (!_isDone) throw new InvalidOperationException("Scrutin is not done");
        return _votes.OrderByDescending(x => x.Value).First().Key;
    }
}

public class VoteWithPercentage
{
    public int Vote { get; set; }
    public float Percentage { get; set; }
}