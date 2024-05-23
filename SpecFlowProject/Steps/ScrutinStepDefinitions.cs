using FluentAssertions;
using ProjetScrutin;

namespace SpecFlowProject.Steps;

[Binding]
public sealed class ScrutinStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    private readonly Scrutin _scrutin = new();

    private Dictionary<string, VoteWithPercentage> _votes;

    public ScrutinStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"Votes:")]
    public void GivenVotes(Table table)
    {
        var votes = table.Rows.ToDictionary(x => x[0], x => int.Parse(x[1]));
        _scrutin.Init(votes);
    }

    [When(@"le scrutin est terminé")]
    public void WhenLeScrutinEstTermine()
    {
        _scrutin.End();
    }

    [Then(@"le vainqueur devrait être B")]
    public void ThenLeVainqueurDevraitEtreB()
    {
        _scrutin.GetWinner().Should().Be("B");
    }

    [When(@"le scrutin est en cours")]
    public void WhenLeScrutinEstEnCours()
    {
        _scrutin.Open();
    }

    [Then(@"le vainqueur ne peut pas être déterminé")]
    public void ThenLeVainqueurNePeutPasEtreDetermine()
    {
        Action act = () => _scrutin.GetWinner();
        act.Should().Throw<InvalidOperationException>();
    }


    [When(@"afficher les votes à la clôture du scrutin")]
    public void WhenAfficherLesVotesALaClotureDuScrutin()
    {
        _scrutin.End();
        _votes = _scrutin.GetVotesWithPercentages();
    }

    [Then(@"les votes devraient être:")]
    public void ThenLesVotesDevraientEtre(Table table)
    {
        var votes = table.Rows.ToDictionary(x => x[0], x => new VoteWithPercentage
        {
            Vote = int.Parse(x[1]),
            Percentage = float.Parse(x[2])
        });

        _votes.Should().BeEquivalentTo(votes);
    }
}