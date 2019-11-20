-- --------------------------------------------------------
-- Hôte :                        
-- Version du serveur:           5.7.24 - MySQL Community Server (GPL)
-- SE du serveur:                Win64
-- HeidiSQL Version:             9.5.0.5332
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Listage de la structure de la base pour jdr
CREATE DATABASE IF NOT EXISTS `jdr` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `jdr`;

-- Listage de la structure de la table jdr. classe
CREATE TABLE IF NOT EXISTS `classe` (
  `ID_CLASSE` int(11) NOT NULL AUTO_INCREMENT,
  `MAX_VIE` smallint(6) NOT NULL,
  `MAX_MANA` smallint(6) NOT NULL,
  `PUISSANCE` smallint(6) NOT NULL,
  `MAGIE` smallint(6) NOT NULL,
  `DEXTERITE` smallint(6) NOT NULL,
  `OBSERVATION` smallint(6) NOT NULL,
  `INTELLIGENCE` smallint(6) NOT NULL,
  `CHANCE` smallint(6) NOT NULL,
  `CHARISME` smallint(6) NOT NULL,
  `DESIGNATION` varchar(50) NOT NULL,
  `DESCRIPTION` text,
  PRIMARY KEY (`ID_CLASSE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table jdr.classe : ~0 rows (environ)
/*!40000 ALTER TABLE `classe` DISABLE KEYS */;
/*!40000 ALTER TABLE `classe` ENABLE KEYS */;

-- Listage de la structure de la fonction jdr. générerCléPartie
DELIMITER //
CREATE DEFINER=`root`@`localhost` FUNCTION `générerCléPartie`() RETURNS tinytext CHARSET latin1
BEGIN
SET @mavar="";

SELECT substring(MD5(RAND()), -16) INTO @mavar ;
RETURN @mavar;
END//
DELIMITER ;

-- Listage de la structure de la table jdr. image
CREATE TABLE IF NOT EXISTS `image` (
  `ID_IMAGE` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PARTIE` varchar(16) NOT NULL,
  `IMAGE` longblob NOT NULL,
  `DATEAJOUT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID_IMAGE`),
  KEY `FK_ASSOCIATION_7` (`ID_PARTIE`),
  CONSTRAINT `FK_ASSOCIATION_7` FOREIGN KEY (`ID_PARTIE`) REFERENCES `partie` (`ID_PARTIE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table jdr.image : ~0 rows (environ)
/*!40000 ALTER TABLE `image` DISABLE KEYS */;
/*!40000 ALTER TABLE `image` ENABLE KEYS */;

-- Listage de la structure de la table jdr. joueur
CREATE TABLE IF NOT EXISTS `joueur` (
  `ID_JOUEUR` int(11) NOT NULL AUTO_INCREMENT,
  `ID_UTIL` int(11) NOT NULL,
  `ID_PARTIE` varchar(16) NOT NULL,
  `IS_MJ` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID_JOUEUR`),
  KEY `FK_ASSOCIATION_5` (`ID_UTIL`),
  KEY `FK_LIE` (`ID_PARTIE`),
  CONSTRAINT `FK_ASSOCIATION_5` FOREIGN KEY (`ID_UTIL`) REFERENCES `utilisateur` (`ID_UTIL`),
  CONSTRAINT `FK_LIE` FOREIGN KEY (`ID_PARTIE`) REFERENCES `partie` (`ID_PARTIE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table jdr.joueur : ~0 rows (environ)
/*!40000 ALTER TABLE `joueur` DISABLE KEYS */;
/*!40000 ALTER TABLE `joueur` ENABLE KEYS */;

-- Listage de la structure de la table jdr. log
CREATE TABLE IF NOT EXISTS `log` (
  `ID_LOG` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PARTIE` varchar(16) NOT NULL,
  `TYPE` smallint(6) NOT NULL,
  `MESSAGE` varchar(255) NOT NULL,
  `DATE_ENVOI` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID_LOG`),
  KEY `FK_ASSOCIATION_6` (`ID_PARTIE`),
  CONSTRAINT `FK_ASSOCIATION_6` FOREIGN KEY (`ID_PARTIE`) REFERENCES `partie` (`ID_PARTIE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table jdr.log : ~0 rows (environ)
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
/*!40000 ALTER TABLE `log` ENABLE KEYS */;

-- Listage de la structure de la table jdr. objet
CREATE TABLE IF NOT EXISTS `objet` (
  `ID_OBJET` int(11) NOT NULL AUTO_INCREMENT,
  `NOM_OBJET` varchar(50) DEFAULT NULL,
  `DESC_OBJET` text,
  `ATTRIBUT` text,
  PRIMARY KEY (`ID_OBJET`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table jdr.objet : ~0 rows (environ)
/*!40000 ALTER TABLE `objet` DISABLE KEYS */;
/*!40000 ALTER TABLE `objet` ENABLE KEYS */;

-- Listage de la structure de la table jdr. partie
CREATE TABLE IF NOT EXISTS `partie` (
  `ID_PARTIE` varchar(16) NOT NULL,
  `TITRE` varchar(255) NOT NULL,
  `DESCRIPTION_PARTIE` text,
  PRIMARY KEY (`ID_PARTIE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table jdr.partie : ~0 rows (environ)
/*!40000 ALTER TABLE `partie` DISABLE KEYS */;
/*!40000 ALTER TABLE `partie` ENABLE KEYS */;

-- Listage de la structure de la table jdr. personnage
CREATE TABLE IF NOT EXISTS `personnage` (
  `ID_PERSO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_CLASSE` int(11) NOT NULL,
  `ID_JOUEUR` int(11) NOT NULL,
  `NOM` varchar(50) NOT NULL,
  `PRENOM` varchar(50) NOT NULL,
  `VIVANT` tinyint(1) NOT NULL,
  `DESCRIPTION` text,
  `BLOCNOTE` varchar(255) DEFAULT NULL,
  `VIE` smallint(6) DEFAULT NULL,
  `MANA` smallint(6) DEFAULT '0',
  `EXPERIENCE` int(11) DEFAULT '0',
  `NIVEAU` int(11) DEFAULT '1',
  PRIMARY KEY (`ID_PERSO`),
  KEY `FK_APPARTIENT` (`ID_CLASSE`),
  KEY `FK_POSSEDE` (`ID_JOUEUR`),
  CONSTRAINT `FK_APPARTIENT` FOREIGN KEY (`ID_CLASSE`) REFERENCES `classe` (`ID_CLASSE`),
  CONSTRAINT `FK_POSSEDE` FOREIGN KEY (`ID_JOUEUR`) REFERENCES `joueur` (`ID_JOUEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table jdr.personnage : ~0 rows (environ)
/*!40000 ALTER TABLE `personnage` DISABLE KEYS */;
/*!40000 ALTER TABLE `personnage` ENABLE KEYS */;

-- Listage de la structure de la table jdr. stock
CREATE TABLE IF NOT EXISTS `stock` (
  `ID_INVENTAIRE` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PERSO` int(11) NOT NULL,
  `ID_OBJET` int(11) NOT NULL,
  `QUANTITE` smallint(6) NOT NULL,
  PRIMARY KEY (`ID_INVENTAIRE`),
  KEY `FK_ASSOCIATION_8` (`ID_PERSO`),
  KEY `FK_ASSOCIATION_9` (`ID_OBJET`),
  CONSTRAINT `FK_ASSOCIATION_8` FOREIGN KEY (`ID_PERSO`) REFERENCES `personnage` (`ID_PERSO`),
  CONSTRAINT `FK_ASSOCIATION_9` FOREIGN KEY (`ID_OBJET`) REFERENCES `objet` (`ID_OBJET`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table jdr.stock : ~0 rows (environ)
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;

-- Listage de la structure de la table jdr. utilisateur
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `ID_UTIL` int(11) NOT NULL AUTO_INCREMENT,
  `MAIL` varchar(140) NOT NULL,
  `PSEUDO` varchar(40) NOT NULL,
  `MDP` varchar(40) NOT NULL,
  `AVATAR` longblob NOT NULL,
  PRIMARY KEY (`ID_UTIL`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table jdr.utilisateur : ~0 rows (environ)
/*!40000 ALTER TABLE `utilisateur` DISABLE KEYS */;
/*!40000 ALTER TABLE `utilisateur` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
