namespace ProjetScrutin;

public class Scrutin
{
    private bool _isDone;
    private Dictionary<string, int> _votes = new();

    public void init(Dictionary<string, int>? votes)
    {
        if (votes != null) _votes = votes;
        open();
    }

    public void addVote(string vote)
    {
        if (_isDone) throw new Exception("Scrutin is done");
        _votes[vote]++;
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
        return _votes.OrderByDescending(x => x.Value).First().Key;
    }
}