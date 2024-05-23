using FluentAssertions;
using ProjetScrutin;

namespace SpecFlowProject.Steps;

[Binding]
public sealed class ScrutinStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    private readonly Scrutin _scrutin = new();

    private Dictionary<string, int> _votes;

    public ScrutinStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"(.*) votes pour A et (.*) votes pour B")]
    public void GivenVotesPourAEtVotesPourB(int p0, int p1)
    {
        _scrutin.init(new Dictionary<string, int>
        {
            { "A", p0 },
            { "B", p1 }
        });
    }

    [When(@"le scrutin est terminé")]
    public void WhenLeScrutinEstTermine()
    {
        _scrutin.end();
    }

    [Then(@"le vainqueur devrait être B")]
    public void ThenLeVainqueurDevraitEtreB()
    {
        _scrutin.getWinner().Should().Be("B");
    }

    [When(@"le scrutin est en cours")]
    public void WhenLeScrutinEstEnCours()
    {
        _scrutin.open();
    }

    [Then(@"le vainqueur ne peut pas être déterminé")]
    public void ThenLeVainqueurNePeutPasEtreDetermine()
    {
        Action act = () => _scrutin.getWinner();
        act.Should().Throw<InvalidOperationException>();
    }

    [When(@"afficher les votes")]
    public void WhenAfficherLesVotes()
    {
        _votes = _scrutin.Votes;
    }

    [Then(@"le résultat devrait être")]
    public void ThenLeResultatDevraitEtre(Table table)
    {
        var expected = table.Rows.ToDictionary(x => x[0], x => int.Parse(x[1]));
        _votes.Should().BeEquivalentTo(expected);
    }
}