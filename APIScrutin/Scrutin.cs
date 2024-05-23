namespace ProjetScrutin;

public class Scrutin
{
    private bool _isDone;

    public Dictionary<string, int> Votes { get; private set; } = new();

    public void init(Dictionary<string, int>? votes)
    {
        if (votes != null) Votes = votes;
        open();
    }

    public void addVote(string vote)
    {
        if (_isDone) throw new Exception("Scrutin is done");
        Votes[vote]++;
    }

    public void open()
    {
        _isDone = false;
    }

    public void end()
    {
        _isDone = true;
    }

    public string getWinner()
    {
        if (!_isDone) throw new InvalidOperationException("Scrutin is not done");
        return Votes.OrderByDescending(x => x.Value).First().Key;
    }
}