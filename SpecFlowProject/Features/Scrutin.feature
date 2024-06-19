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
    Scenario: Afficher le nombre de votes et le pourcentage de chaque candidat à la clôture du scrutin
        Given Votes:
          | Candidat | Votes |
          | A        | 25    |
          | B        | 75    |
        When afficher les votes à la clôture du scrutin
        Then les votes devraient être:
          | Candidat | Votes | Pourcentage |
          | A        | 25    | 25          |
          | B        | 75    | 75          |

    @scrutin
    Scenario: Si aucun candidat n'a pas plus de 50%, alors on garde les 2 candidats
    correspondants aux meilleurs pourcentages et il y aura un deuxième tour
    de scrutin
        Given Votes:
          | Candidat | Votes |
          | A        | 50    |
          | B        | 50    |
          | C        | 10    |
        When le scrutin est terminé
        Then les candidats qualifiés pour le deuxième tour devraient être:
          | Candidat |
          | A        |
          | B        |

    @scrutin
    Scenario: Lors du deuxième tour, le candidat avec le plus de voix est déclaré vainqueur
        Given Votes second tour:
          | Candidat | Votes |
          | A        | 50    |
          | B        | 30    |
        When le scrutin est terminé
        Then le vainqueur du deuxième tour devrait être A

    @scrutin
    Scenario: Si il y a égalité au deuxième tour on ne peut pas déterminer le vainqueur
        Given Votes second tour:
          | Candidat | Votes |
          | A        | 50    |
          | B        | 50    |
        When le scrutin est terminé
        Then le vainqueur du deuxième tour ne peut pas être déterminé