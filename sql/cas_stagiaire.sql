-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  jeu. 21 juin 2018 à 21:40
-- Version du serveur :  5.7.21
-- Version de PHP :  5.6.35

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `cas_stagiaire`
--

-- --------------------------------------------------------

--
-- Structure de la table `msections`
--

DROP TABLE IF EXISTS `msections`;
CREATE TABLE IF NOT EXISTS `msections` (
  `id_section` int(11) NOT NULL AUTO_INCREMENT,
  `debut_formation` date DEFAULT NULL,
  `nom` varchar(10) NOT NULL,
  `date_fin` date DEFAULT NULL,
  `code` varchar(20) NOT NULL,
  PRIMARY KEY (`id_section`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `msections`
--

INSERT INTO `msections` (`id_section`, `debut_formation`, `nom`, `date_fin`, `code`) VALUES
(1, NULL, 'cdi1', NULL, 'cdi');

-- --------------------------------------------------------

--
-- Structure de la table `mstagiaire`
--

DROP TABLE IF EXISTS `mstagiaire`;
CREATE TABLE IF NOT EXISTS `mstagiaire` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `numosia` int(11) NOT NULL,
  `rue` varchar(50) NOT NULL,
  `codepostal` int(11) NOT NULL,
  `ville` varchar(50) NOT NULL,
  `pointsnotes` double NOT NULL,
  `nbrenotes` int(11) NOT NULL,
  `type` char(3) NOT NULL,
  `typecif` char(4) DEFAULT NULL,
  `fongecif` varchar(20) DEFAULT NULL,
  `remu_afpa` tinyint(4) DEFAULT NULL,
  `id_section` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `numosia` (`numosia`) USING BTREE,
  KEY `msections_mstagiaire_fk` (`id_section`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `mstagiaire`
--

INSERT INTO `mstagiaire` (`id`, `nom`, `prenom`, `numosia`, `rue`, `codepostal`, `ville`, `pointsnotes`, `nbrenotes`, `type`, `typecif`, `fongecif`, `remu_afpa`, `id_section`) VALUES
(5, 'DURANT', 'jaques', 175, '45 rue de la resistance', 42410, 'LYON', 30, 2, 'CIF', 'CDI', '', NULL, 1),
(6, 'DURANT', 'pierre', 125, '1225', 42510, 'LYON', 30, 2, 'DE', NULL, NULL, 0, 1),
(7, 'DUPONT', 'paul', 145, '', 69420, 'CONDRIEU', 0, 0, 'DE', NULL, NULL, 0, 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
