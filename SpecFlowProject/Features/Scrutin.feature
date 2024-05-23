Feature: Scrutin

    @scrutin
    Scenario: Obtenir le vainqueur du vote
        Given 1 votes pour A et 3 votes pour B
        When le scrutin est terminé
        Then le vainqueur devrait être B

    @scrutin
    Scenario: Pour obtenir un vainqueur, le scrutin doit être clôturé
        Given 2 votes pour A et 3 votes pour B
        When le scrutin est en cours
        Then le vainqueur ne peut pas être déterminé
        
    @scrutin
    Scenario: Si un candidat obtient > 50% des voix, il est déclaré vainqueur du scrutin
        Given 1 votes pour A et 3 votes pour B
        When le scrutin est terminé
        Then le vainqueur devrait être B