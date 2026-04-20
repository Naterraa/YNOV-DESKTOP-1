# Si toujours message d'erreur avec node-gyp, Python ou Visual Studio : 


En premier : 

- npm install --save-dev electron-rebuild
- npx electron-rebuild


Sinon : 


- npm install --global windows-build-tools (en admin)
- Si cette commande ne fonctionne pas ou semble bloquée, installe manuellement les "Desktop development with C++" via l'installeur de Visual Studio Community.
- npm config set python python3
- re-supprimer les node modules, le package-lock.json et relancer npm install