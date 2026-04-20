# Travail évalué
# Groupe de 1 ou 2 personnes

Le projet consiste à bâtir une réplique visuelle de l’interface principale de Discord en utilisant Electron JS. L'objectif est de se concentrer sur l'architecture de la fenêtre et la navigation structurelle plutôt que sur la logique de messagerie.

La fenêtre doit être configurée en mode frameless. Cela implique de supprimer les bordures natives de l'OS et de concevoir une barre de titre personnalisée en HTML et CSS capable de piloter les fonctions de réduction, de maximisation et de fermeture via les modules de communication inter-processus. Cette zone doit également permettre le déplacement de l'application à la souris.

L'interface se découpe en trois zones majeures : la colonne des serveurs à l'extrême gauche, la liste des salons au milieu et l'espace de discussion principal. Vous devez implémenter la logique de navigation entre les serveurs : le clic sur une icône de serveur doit visuellement activer ce dernier (conversation) et mettre à jour la liste des salons correspondante. De même, la sélection d'un salon doit simuler l'ouverture d'une conversation en changeant l'en-tête de la zone centrale.

L'aspect système est crucial. Une icône de tray doit être présente dans la barre des tâches de l'ordinateur pour permettre de restaurer ou de quitter l'application. Vous devez également coder un menu contextuel qui se déclenche au clic droit sur les éléments de l'interface, offrant des options spécifiques à l'élément ciblé.

Le rendu visuel doit être le plus fidèle possible au thème sombre original, avec une attention particulière portée aux arrondis des icônes de serveurs, aux états de survol et aux barres de défilement personnalisées. Le but est de créer une coquille vide mais parfaitement fonctionnelle du point de vue de l'utilisateur qui navigue dans l'arborescence des salons.

Envoyer TP romain.dinel.pro@gmail.com