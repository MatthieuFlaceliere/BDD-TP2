using FluentAssertions;
using ProjetScrutin;

namespace SpecFlowProject.Steps;

[Binding]
public sealed class ScrutinStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    private readonly Scrutin _scrutin = new();

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
}