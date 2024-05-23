Feature: Scrutin

    @mytag
    Scenario: Obtenir le vainqueur du vote
        Given 2 votes pour A et 3 votes pour B
        When le scrutin est terminé
        Then le vainqueur devrait être B