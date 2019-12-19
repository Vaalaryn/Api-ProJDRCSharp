# Bienvenue sur l'api du projet ProJDRCSharp

# Sommaire

## 1.Route
#### Utilisateur
#### Stock
#### Personnage
#### Partie
#### Log
#### Joueur
#### Classe

## 2.FileWatcher


# 1.Routes

## /Utilisateur/(méthode)

### [Get] - GetByID(int id): 

Retourne les infos d'un utilisateur dont l'id est passer en paramètre
       
Retour : 
       
       {
           "ID_UTIL": INT,
           "MAIL": STRING,
           "PSEUDO": STRING,
           "AVATAR": BLOB)
       }
        
### [Get] - GetByPseudo(string pseudo):

Retourne les infos d'un utilisateur dont le pseudo est passer en paramètre
       
Retour : 
       
       {
           "ID_UTIL": INT,
           "MAIL": STRING,
           "PSEUDO": STRING,
           "AVATAR": BLOB)
       }
       
### [Get] - GetByMail(string mail):

Retourne les infos d'un utilisateur du mail qui est passer en paramètre
       
Retour : 
       
       {
           "ID_UTIL": INT,
           "MAIL": STRING,
           "PSEUDO": STRING,
           "AVATAR": BLOB)
       }
       
### [Get] - Connexion(string pseudo, string pass):

Permet la connexion d'un utilisateur, retourne true si c'est bon sinon false

Retour : 
        
        BOOL
        
### [Post] - Inscription(string mail, string pseudo, string mdp, string mdpConfirm, byte[] avatar)

Envoie des infos d'inscription d'un nouvel utilisateur, retourne true si tout c'est bien passez sinon false

Retour :
        
        BOOL
        
### [Post] - UpdateUtilisateur)([string mail = ""], [string pseudo = ""], [string mdp = ""], [string mdpConfirm = ""], [byte[] avatar = null]):

Envoie des information a mettre a jour d'un utilisateur, "ok" si c'est bon sinon message d'erreur

Retour:

        STRING
        
### [Get] - PseudoExist(string pseudo)

Retourne true si le pseudo est déjà present dans la bdd sinon false

Retour :

        BOOL
        
### [Get] - MailExist(string mail)

Retourne true si le mail est déjà present dans la bdd sinon false

Retour :

        BOOL
        
## /Stock/(methode)

### [Post] - Ajouter(int idPerso, int idObjet, short quantite)

Ajoute un nouveau stock d'objet au personnage dont l'id est associé, retourne "ok" si bon sinon false

Retour : 

        STRING
        
### [Post] - Update(int idStock, short quantite)

Met a jout la quantite stocker d'un objet d'un personage, retourne "ok" si tout se passe bien sinon un message d'erreur

Retour : 
        
        STRING
        
### [Get] - StockPerso(int idPerso)

Renvoie le stock d'objets d'un personage

Retour : 

            [
                {
                    "objet": {
                        "ID_OBJET": INT,
                        "NOM_OBJET": STRING,
                        "DESC_OBJET": STRING,
                        "ATTRIBUT": STRING
                    },
                    "ID_INVENTAIRE": INT,
                    "ID_PERSO": INT,
                    "ID_OBJET": INT,
                    "QUANTITE": INT
                }
            ]

## /Personnage/(methode)

### [Get] - GetByJoueur(int idJoueur)

Renvoie le personnage d'un joueur

Retour : 

        {
            "ID_PERSO": INT,
            "ID_CLASSE": INT,
            "ID_JOUEUR": INT,
            "NOM": STRING,
            "PRENOM": STRING,
            "VIVANT": BOOL,
            "DESCRIPTION": STRING,
            "BLOCNOTE": STRING,
            "VIE": SHORT,
            "MANA": SHORT,
            "EXPERIENCE": SHORT,
            "NIVEAU": SHORT
        }
        
### [Get] - GetByPartie(string idPartie)

Renvoie la liste des personnages d'une partie

Retour : 

        {
            "ID_PERSO": INT,
            "ID_CLASSE": INT,
            "ID_JOUEUR": INT,
            "NOM": STRING,
            "PRENOM": STRING,
            "VIVANT": BOOL,
            "DESCRIPTION": STRING,
            "BLOCNOTE": STRING,
            "VIE": SHORT,
            "MANA": SHORT,
            "EXPERIENCE": SHORT,
            "NIVEAU": SHORT
        }

### [Get] - GetById(string idPerso)

Renvoie les infos du perso 

Retour : 

        {
            "ID_PERSO": INT,
            "ID_CLASSE": INT,
            "ID_JOUEUR": INT,
            "NOM": STRING,
            "PRENOM": STRING,
            "VIVANT": BOOL,
            "DESCRIPTION": STRING,
            "BLOCNOTE": STRING,
            "VIE": SHORT,
            "MANA": SHORT,
            "EXPERIENCE": SHORT,
            "NIVEAU": SHORT
        }
        
### [Post] - Ajouter(int idJoueur, int idClasse, string nom, string prenom, string description, string blocnote, [short vie = -1], [short mana = -1], [short experience = -1], [short niveau = -1])

Ajoute un nouveau personage dans la bdd, retourne "ok" si c'est bon sinon un message d'erreur

Retour : 

        STRING
        
### [Post] - UpdatePersonnage(int idPersonnage, [string vivant = ""], [string nom = ""], [string prenom = ""], [string description = ""], [string blocnote = ""], [short vie = -1], [short mana = -1], [short experience = -1], [short niveau = -1])

Met a jour les infos du personnage, retourne "ok" si tout se passe bien sinon un message d'erreur

Retour : 

        STRING
        
## /Partie/(methode)

### [Post] - Ajouter(int idUtilisateur, string titre, string description)

Ajoute une nouvelle partie, retourne "ok" si tout se passe bien sinon un message d'erreur

Retourne : 
        
        STRING
        
### [Post] - UpdatePartie(string idPartie, [string titre = ""], [string description = ""])

Met a jour la partie avec les nouvelles valeurs transmise, retourne "ok" si tout se passe bien sinon un message d'erreur

Retour : 

        STRING
        
### [Get] - GetAllPerso(string idPartie)
Retourne tout les perso d'une partie

Retour : 

        [
            {
                "perso": {
                    "ID_PERSO": INT,
                    "ID_CLASSE": INT,
                    "ID_JOUEUR": INT,
                    "NOM": STRING,
                    "PRENOM": STRING,
                    "VIVANT": BOOL,
                    "DESCRIPTION": STRING,
                    "BLOCNOTE": STRING,
                    "VIE": INT,
                    "MANA": INT,
                    "EXPERIENCE": INT,
                    "NIVEAU": INT
                },
                "classePerso": {
                    "ID_CLASSE": INT,
                    "MAX_VIE": INT,
                    "MAX_MANA": INT,
                    "PUISSANCE": INT,
                    "MAGIE": INT,
                    "DEXTERITE": INT,
                    "OBSERVATION": INT,
                    "INTELLIGENCE": INT,
                    "CHANCE": INT,
                    "CHARISME": INT,
                    "DESIGNATION": STRING,
                    "DESCRIPTION": STRING
                },
                "objetPerso": [
                    {
                        "ID_OBJET": INT,
                        "NOM_OBJET": STRING,
                        "DESC_OBJET": STRING,
                        "ATTRIBUT": STRING
                    }
                ]
            }
        ]
        
## /Log/(methode)
        
### [Post] - Ajouter(string idPartie,short type, string message)

Ajoute un nouveau log, retourne "ok" si tout se passe bien sinon un message d'erreur

Retour : 

        STRING
      
## /Classe/(methode)      
  
### [Get] - GetAll()

Retourne toute les infos de classe

Retour : 

        [
            {
                "ID_CLASSE": INT,
                "MAX_VIE": INT,
                "MAX_MANA": INT,
                "PUISSANCE": INT,
                "MAGIE": INT,
                "DEXTERITE": INT,
                "OBSERVATION": INT,
                "INTELLIGENCE": INT,
                "CHANCE": INT,
                "CHARISME": INT,
                "DESIGNATION": STRING,
                "DESCRIPTION": STRING
            },
        ]
        
# 2.FileWatcher

Le FileWatcher sert a mettre a jour un fichier .json qui va contenir toutes les infos d'une partie, il se met a jour en temps reel et donc pouvoir mettre a jour en temps reel les infos d'une partie

Pour utiliser le file watcher il faut mettre en place un FileSystemWatcher le parametré avec le chemin suivant 

        \\10.176.131.132\Users\Elise\Documents\Watcher\Parties
ou

        \\10.176.131.132\Users\Elise\Documents\Watcher\Log
        
ce chemin vous permettera d'accedez au fichier json qui contiennent les infos de partie ensuite il ne vous reste plus qu'a filtré le fichier qui vous intéressent et le lire

    jsonPartie = JObject.Parse(File.ReadAllText(e.FullPath));
    if (e.FullPath.Split('\').Last() == idPartie + ".json")
    {
        jsonPartie = JObject.Parse(File.ReadAllText(e.FullPath));
    }
    
Voici un example de a quoi ressemble un fichier .json

    { 
       "ID_PARTIE": STRING,
       "TITRE": STRING,
       "DESCRIPTION_PARTIE": STRING,
       "image":[ 
       ],
       "joueur":[ 
          { 
             "utilisateur":{ 
                "ID_UTIL": INT,
                "MAIL": STRING,
                "PSEUDO": STRING,
                "AVATAR": BLOB
             },
             "personnage":[ 
                { 
                   "ID_PERSO": INT,
                   "ID_CLASSE": INT,
                   "ID_JOUEUR": INT,
                   "NOM": STRING,
                   "PRENOM": STRING,
                   "VIVANT": BOOL,
                   "DESCRIPTION": STRING,
                   "BLOCNOTE": STRING,
                   "VIE": INT,
                   "MANA": INT,
                   "EXPERIENCE": INT,
                   "NIVEAU": INT
                }
             ],
             "ID_JOUEUR": INT,
             "ID_UTIL": INT,
             "ID_PARTIE": STRING,
             "IS_MJ": BOOL
          },
       ]
    }
    ]