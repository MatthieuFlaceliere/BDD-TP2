namespace ProjetScrutin;

public class Scrutin
{
    private bool _isDone;
    private List<string> _secondRoundCandidates = new();

    private Dictionary<string, int> _votes = new();

    public bool isSecondRound { get; set; }

    public void Init(Dictionary<string, int>? votes)
    {
        if (votes != null) _votes = votes;
        Open();
    }

    public void AddVote(string? vote)
    {
        if (_isDone) throw new Exception("Scrutin is done");
        if (vote == null) vote = "Vote blanc";
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

        var potentialWinner = _votes.OrderByDescending(x => x.Value).First().Key;
        if (_votes[potentialWinner] > _votes.Values.Sum() / 2 && !isSecondRound) return potentialWinner;

        if (isSecondRound)
        {
            if (_votes[_secondRoundCandidates[0]] == _votes[_secondRoundCandidates[1]])
                throw new InvalidOperationException("Draw");
            return potentialWinner;
        }

        isSecondRound = true;
        CalculateSecondRound();
        _votes.Clear();
        throw new InvalidOperationException("Second round is needed");
    }

    public List<string> GetSecondRoundCandidates()
    {
        if (!isSecondRound) throw new InvalidOperationException("Second round is not needed");
        return _secondRoundCandidates;
    }

    public void CalculateSecondRound()
    {
        var candidates = _votes.OrderByDescending(x => x.Value).Take(2).Select(x => x.Key).ToList();
        _secondRoundCandidates = candidates;
    }
}

public class VoteWithPercentage
{
    public int Vote { get; set; }
    public float Percentage { get; set; }
}