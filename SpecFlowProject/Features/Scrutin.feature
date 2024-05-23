Feature: Scrutin

    @scrutin
    Scenario: Obtenir le vainqueur du vote
        Given Votes:
          | Candidat | Votes |
          | A        | 1     |
          | B        | 3     |
        When le scrutin est terminé
        Then le vainqueur devrait être B

    @scrutin
    Scenario: Pour obtenir un vainqueur, le scrutin doit être clôturé
        Given Votes:
          | Candidat | Votes |
          | A        | 2     |
          | B        | 3     |
        When le scrutin est en cours
        Then le vainqueur ne peut pas être déterminé

    @scrutin
    Scenario: Si un candidat obtient > 50% des voix, il est déclaré vainqueur du scrutin
        Given Votes:
          | Candidat | Votes |
          | A        | 1     |
          | B        | 3     |
        When le scrutin est terminé
        Then le vainqueur devrait être B

    @scrutin
    Scenario: Afficher le nombre de votes pour chaque candidat
        Given Votes:
          | Candidat | Votes |
          | A        | 1     |
          | B        | 3     |
        When afficher les votes
        Then les votes devraient être:
          | Candidat | Votes |
          | A        | 1     |
          | B        | 3     |