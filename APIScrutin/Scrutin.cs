namespace ProjetScrutin;

public class Scrutin
{
    private bool _isDone;
    private Dictionary<string, int> _votes = new();

    public void init(Dictionary<string, int>? votes)
    {
        if (votes != null) _votes = votes;
        _isDone = false;
    }

    public void addVote(string vote)
    {
        if (_isDone) throw new Exception("Scrutin is done");
        _votes[vote]++;
    }

    public void end()
    {
        _isDone = true;
    }

    public string getWinner()
    {
        return _votes.OrderByDescending(x => x.Value).First().Key;
    }
}