CREATE DATABASE  IF NOT EXISTS `heroku_165e3a9fb7020b6` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `heroku_165e3a9fb7020b6`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: eu-cluster-west-01.k8s.cleardb.net    Database: heroku_165e3a9fb7020b6
-- ------------------------------------------------------
-- Server version	8.0.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '2668430b-c07c-11ee-b23d-ff3f3a1e3939:1-917893,
47f58cc6-8fb7-11ee-93d6-b60521a029a4:1-50,
65dd3588-78a1-11ee-b126-ffd086e6313d:1-1622464,
6bdae23d-c07c-11ee-a3a3-2257b4b879cb:1-48,
86a6afcf-45d4-11ee-85d2-4a92d512f212:1-159186,
c794e26f-cd84-11ee-b829-62faae7ba72b:1-7,
e02a53d3-ccf3-11ee-b86b-6e80cd2ff369:1';

--
-- Table structure for table `avis`
--

DROP TABLE IF EXISTS `avis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avis` (
  `nom` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `prenom` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `commentaire` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `titre` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `note` int DEFAULT NULL,
  `id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avis`
--

LOCK TABLES `avis` WRITE;
/*!40000 ALTER TABLE `avis` DISABLE KEYS */;
INSERT INTO `avis` VALUES ('Coupart','Sandrine','Test Commentaire','Blanc de volaille maison',NULL,22),('Coupart','Sandrine','Test Commentaire','Blanc de volaille maison',NULL,25),('Coupart','Sandrine','Test Commentaire','Blanc de volaille maison',NULL,28),('Coupart','Sandrine','Test Commentaire','Blanc de volaille maison',NULL,31),(NULL,NULL,NULL,'Blanc de volaille maison',5,37),(NULL,NULL,NULL,'Blanc de volaille maison',4,40),('Lesage','Thomas','Test Tomate','Tomates farcies au poisson blanc',NULL,41),(NULL,NULL,NULL,'Tomates farcies au poisson blanc',3,44),('Lesage','Thomas','trop top','Tomates farcies au poisson blanc',NULL,47),(NULL,NULL,NULL,'Tomates farcies au poisson blanc',5,50);
/*!40000 ALTER TABLE `avis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipes`
--

DROP TABLE IF EXISTS `recipes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipes` (
  `titre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `image` varchar(10000) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `time` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `timeRepos` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `timePrepa` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(1100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `allergenes` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `regime` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `ingredients` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `etapes` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `estPatient` enum('FALSE','TRUE') COLLATE utf8mb4_unicode_ci NOT NULL,
  `id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipes`
--

LOCK TABLES `recipes` WRITE;
/*!40000 ALTER TABLE `recipes` DISABLE KEYS */;
INSERT INTO `recipes` VALUES ('Blanc de volaille maison','https://www.votredieteticienne.fr/images/_site/private/recettes/2022%2007%20roti%20dinde%20-%20maison.JPG','30 Minutes','0 Minute','20 Minutes','Soyez prêt à épater votre entourage avec cette recette, attention les papilles','Oeuf','Sans Sucre','1 oeuf,600 g d’escalope de poulet ou d’escalope de dinde,Herbes de provence ou thym ou romarin,Sel,Epices au choix (curry ras el hanout cumin coriandre …),1 cuillère à soupe de paprika doux ou fumé','Couper les escalopes en morceaux et les mettre dans un mixeur avec l’œuf le sel le poivre les épices (sauf le paprika) et les herbes.,Verser la préparation sur un film alimentaire (supportant la chaleur) puis façonner un gros boudin en lui donnant la forme d’un rouleau et rouler le paprika. Refermer soigneusement le boudin.,Le faire cuire dans de l’eau frémissante environ 10 min ou à la vapeur environ 30 min.,A la fin de la cuisson réserver hors du cuit vapeur attendre le refroidissement retirer le film alimentaire égoutter le boudin puis mettre au frais pour faciliter le tranchage.','FALSE',61),('Tomates farcies au poisson blanc','https://www.votredieteticienne.fr/images/_site/private/recettes/2022%2006%20tomates%20farcies%20au%20poisson%20blanc.JPG','30 Minutes','30 Minutes','20 Minutes','Une recette très diététique','','','6 tomates,200g de filet de lieu noir ou autre poisson blanc,2 tranches de pain de mie complet,1 cuillère à soupe de sauce basilic ou pesto,1 cuillère à soupe d’huile d’olive,Sel Poivre,Fines herbes (basilic persil)','Au préalable laver les tomates et les creuser à l’aide d’une cuillère parisienne. Saler légèrement l’intérieur et les mettre à dégorger à l’envers environ 30 min., Faire préchauffer le four à 190°.,Pendant ce temps enlever les arêtes du poisson si besoin. Le placer dans un mixeur.,Rajouter le pain de mie en morceaux la sauce l’huile et les fines herbes. Saler et poivrer.,Mixer bien.,Répartir la farce dans chaque tomate.,Mettre au four pendant au moins 30 min.','FALSE',76),('Brownie Home Made','https://www.votredieteticienne.fr/images/_site/private/recettes/2023%2002%20brownie%20papy%20brossard%20-%20home.JPG','20-25 Minutes','Sans Repos','1 Heure','Un classique, mais ici moins sucré que l\'original.','Oeuf,Chocolat','','90 g de farine,100 g de sucre roux,3 oeufs,75 ml d’huile,100g de chocolat noir,80g de pépites de chocolat (ou de chocolat dessert que vous aurez concassé) à réserver au congélateur avant,2 cuillères à soupe rases de cacao en poudre non sucré','Préchauffer le four à 180°C. Dans un saladier mélangez les oeufs le sucre l’huile le cacao en poudre.,Faites fondre 100 g de chocolat coupé en morceaux  tout doucement à la casserole au micro-ondes ou au bain-marie. L’ajouter au mélange précédent et bien mélanger. Ajouter la farine.,Ajouter les pépites de chocolat.,Verser le tout dans un moule en silicone et enfourner pour 20 à 25 minutes environ.','TRUE',82);
/*!40000 ALTER TABLE `recipes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateur` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `prenom` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `password` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `role_users` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `allergenes` text COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateur`
--

LOCK TABLES `utilisateur` WRITE;
/*!40000 ALTER TABLE `utilisateur` DISABLE KEYS */;
INSERT INTO `utilisateur` VALUES (1,'Lesage','Thomas','thomas59.lesage@gmail.com','oui','Patient','Gluten,Oeuf'),(7,'Coupart','Sandrine','SCoupart@gmail.com','SCoupart','Administrateur',''),(15,'Geralt','DeRiv','GeraltDeriv@gmail.com','Witcher','Patient','Arachide'),(16,'Test','Utilisateur','TestUtilisateur@gmail.com','Non','Visiteur','Gluten'),(19,'Vengerberg','Yennefer','Yennefer@gmail.com','Vengerberg','Visiteur','Oeuf');
/*!40000 ALTER TABLE `utilisateur` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-02-19 10:54:13
