# Groupe de 1 ou 2 personnes

Le projet consiste à implémenter une version simplifiée et minimaliste du célèbre jeu Pac-Man. L'objectif est de maîtriser l'utilisation de la classe AnimationTimer pour créer une boucle de rendu fluide, ainsi que de gérer la détection de collisions et les déplacements dans une grille.

# Architecture et boucle de jeu

Le cœur de votre application repose sur l'utilisation d'AnimationTimer. Contrairement à un Timeline, cette classe permet de synchroniser le rafraîchissement de l'interface avec la fréquence de rafraîchissement de l'écran (généralement 60 FPS). Vous devrez implémenter une structure de boucle de jeu propre : Mise à jour (Update) des positions/états, suivie du Rendu (Draw) des éléments graphiques.

# Spécifications fonctionnelles

- Gestion de la grille et déplacement : Le plateau de jeu doit être représenté par une structure de données (matrice ou liste) définissant les murs et les zones libres. Le personnage doit se déplacer case par case ou de manière fluide sur la grille, en respectant les collisions avec les murs.

- Animation du personnage : Pac-Man doit être représenté par un élément graphique qui change d'orientation selon la direction choisie (haut, bas, gauche, droite). Vous devrez gérer les entrées clavier (KeyEvent) pour mettre à jour la direction souhaitée du personnage.

- Collecte de points : Des éléments (gommes) doivent être disposés dans les couloirs. Le joueur doit pouvoir "manger" ces points par simple superposition graphique. Un compteur de score doit être affiché dynamiquement dans une zone dédiée en haut de la fenêtre.

- Ennemi rudimentaire : Intégrez au moins un "fantôme" qui se déplace de manière autonome. Vous devrez implémenter un algorithme de déplacement simple (aléatoire ou poursuite basique) qui vérifie en permanence sa position par rapport à celle du joueur pour détecter une collision (fin de partie).