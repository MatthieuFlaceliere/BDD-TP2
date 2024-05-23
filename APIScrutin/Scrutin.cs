namespace ProjetScrutin;

public class Scrutin
{
    private bool _isDone;

    public Dictionary<string, int> Votes { get; private set; } = new();

    public void Init(Dictionary<string, int>? votes)
    {
        if (votes != null) Votes = votes;
        Open();
    }

    public void AddVote(string vote)
    {
        if (_isDone) throw new Exception("Scrutin is done");
        Votes[vote]++;
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
        return Votes.OrderByDescending(x => x.Value).First().Key;
    }
}