# tests-validation

## I.

Différents éléments du logiciel empêchent celui-ci d'être validé dans l'état actuel.  

On retrouve parmis ces éléments :
- des bugs, notemment d'affichage, de condition de victoire, d'usage.
- pas de sauvegarde
- pas d'IA
- code non stable
- code pas testé et difficilement testable

Le fait que l'on ne trouve presque aucune classes dans ce code (ce n'est clairement pas de la poo), restricte énormément notre capacité à tester le code.  
En effet, on aime en général tester les fonctionnalités d'une classe, en l'initialisant, l'appelant avec certaines données et vérifier le contenu du retour de la classe.  
En ayant une seule classe comme ceci pour un mode de jeu, ce n'est pas possible.  

On peut également difficilement tester les fonctions une à une, comme elles partagent outes les données communes à la classe, faisant office de variables globales dans le jeu. On ne peut pas tester une seule fonctionnalité sans avoir de répercutions non attendues à un autre endroit du programme, ces variables globales ayant changés de manière difficilement prédictibles.

```csharp
public class PuissanceQuatre
{
    public bool quiterJeu = false;
    public bool tourDuJoueur = true;
    public char[,] grille;
```
*attributs de la classe PuissanceQuatre*

On voit que la grille est un tableau de char où chaque fonction change ce qu'elle veut en son sein, sans auncune vérification possible.

## II

Pour corriger de tels problème, une première action sera de cloisonner le code dans plusieurs classes spécialisées et communicant entre elles à partir d'un nombre réduit de fonctions.

On pense par là à une classe grille, une stratégie par jeu, une classe joueur, une classe jeu contenant ces éléments, une possibilité d'implémenter une IA sous l'interface joueur pour simuler ce mode jeu.


On pourra par la suite créer un projet de test qui testera chacune de ces classes et leurs fonctions respectives de façon optimale, en utilisisant des doublures d'objets afin de tester une classe de façon isolée, sans que l'implémentation d'une autre classe puisse influer sur celle que l'on teste.

## III

Pour brancher un joueur contrôlé par l'ordinateur, il faut préparer des classe de communication avec le joueur courant. Qui permettront au joueur de voir le plateau de jeu et rentrer son choix au clavier.  
On pourra ensuite faire appel à ces classes pour faire jouer le joueur courant.  
Si c'est un ordinateur, un autre objet implémentant l'interface joueur pourra donner au jeu ses propres classes d'affichage et d'entrée d'action, sous une même interface afin que le jeu ne soit pas au courant, et y réupérer les informations dont il a besoin et entrer l'action de jeu choisie.

On pourra facilement tester le jeu, les autres classes n'étant pas modifiées par un tel changement, il suffira uniquement de tester ces nouvelles classes relatives à l'IA.

Pour l'historisation, on peut imaginer une classe faisant le lien avec les fichiers de l'ordinateur, qui va être appelée dans la boucle principale du jeu, afin d'enregistrer la grille et le joueur courant.

De la même manière il faudra que cette classe n'aie pas d'incidence sur l'état du jeu afin de ne pas casser les tests déjà faits.