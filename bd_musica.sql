-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: bd_musica
-- ------------------------------------------------------
-- Server version	8.0.33

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

--
-- Table structure for table `albuns`
--

DROP TABLE IF EXISTS `albuns`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `albuns` (
  `id_albuns` int NOT NULL AUTO_INCREMENT,
  `nome_album` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `num_musicas` int NOT NULL,
  `id_banda` int NOT NULL,
  `id_genero_album` int NOT NULL,
  PRIMARY KEY (`id_albuns`),
  KEY `FK_Genero_Banda_idx` (`id_genero_album`),
  KEY `FK_Banda_Album_idx` (`id_banda`),
  CONSTRAINT `FK_Banda_Album` FOREIGN KEY (`id_banda`) REFERENCES `bandas` (`id_banda`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Genero_Album` FOREIGN KEY (`id_genero_album`) REFERENCES `generos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `albuns`
--

LOCK TABLES `albuns` WRITE;
/*!40000 ALTER TABLE `albuns` DISABLE KEYS */;
INSERT INTO `albuns` VALUES (1,'AM',12,1,14),(2,'The Car',10,1,14),(3,'Changes',7,6,26),(4,'Tranquility Base Hotel & Casino',11,1,1),(5,'Queen II',11,7,4),(9,'Mood Valiant',12,14,17),(10,'Toxicity',14,2,4),(11,'In Utero',12,4,25),(12,'Nevermind',12,4,25),(13,'Damn',14,17,3),(14,'To Pimp a Butterfly',11,17,3),(16,'Quem Tem Medo De Baladas',14,19,22);
/*!40000 ALTER TABLE `albuns` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bandas`
--

DROP TABLE IF EXISTS `bandas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bandas` (
  `id_banda` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin DEFAULT NULL,
  `num_membros` int DEFAULT NULL,
  PRIMARY KEY (`id_banda`),
  UNIQUE KEY `nome_UNIQUE` (`nome`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bandas`
--

LOCK TABLES `bandas` WRITE;
/*!40000 ALTER TABLE `bandas` DISABLE KEYS */;
INSERT INTO `bandas` VALUES (1,'Arctic Monkeys',4),(2,'System of a Down',5),(3,'Coldplay',5),(4,'Nirvana',3),(5,'Foo Fighters',5),(6,'King Gizzard & the Lizard Wizard',7),(7,'Queen',4),(14,'Hiatus Kaiyote',4),(17,'Kendrick Lamar',1),(19,'José Cid',1);
/*!40000 ALTER TABLE `bandas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `generos`
--

DROP TABLE IF EXISTS `generos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `generos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome_genero` varchar(50) COLLATE utf8mb3_bin DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `generos`
--

LOCK TABLES `generos` WRITE;
/*!40000 ALTER TABLE `generos` DISABLE KEYS */;
INSERT INTO `generos` VALUES (1,'Indie'),(2,'Hip-Hop'),(3,'Rap'),(4,'Rock'),(5,'Classic'),(6,'Jazz'),(7,'Folk'),(8,'Country'),(9,'R&B'),(10,'Blues'),(11,'Soul'),(12,'Reggae'),(13,'Punk Rock'),(14,'Indie Rock'),(15,'Techno'),(16,'Dance'),(17,'Alternative'),(18,'Electronic'),(19,'New-age'),(20,'Dubstep'),(21,'EDM'),(22,'Pop'),(23,'Heavy Metal'),(24,'Pop Rock'),(25,'Grunge'),(26,'Alternative Rock');
/*!40000 ALTER TABLE `generos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `musicas`
--

DROP TABLE IF EXISTS `musicas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `musicas` (
  `id_musicas` int NOT NULL AUTO_INCREMENT,
  `nome_musicas` varchar(50) COLLATE utf8mb3_bin NOT NULL,
  `album` int NOT NULL,
  PRIMARY KEY (`id_musicas`),
  UNIQUE KEY `nome_musicas_UNIQUE` (`nome_musicas`),
  KEY `FK_Album_idx` (`album`),
  CONSTRAINT `FK_Album_Musica` FOREIGN KEY (`album`) REFERENCES `albuns` (`id_albuns`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `musicas`
--

LOCK TABLES `musicas` WRITE;
/*!40000 ALTER TABLE `musicas` DISABLE KEYS */;
INSERT INTO `musicas` VALUES (1,'Four out of Five',4),(2,'the world’s first ever monster truck front flip',4),(3,'tranquility base hotel + casino',4),(4,'Golden Trunks',4),(5,'Batphone',4),(7,'The Ultracheese',4),(8,'Star Treatment',4),(10,'American Sports',4),(11,'Science Fiction',4),(12,'One Point Perspective',4),(13,'Get Sun',9),(14,'Rose Water',9),(15,'The Loser in the End',5),(16,'Jet Pilot',10),(17,'X',10),(18,'Aerials',10),(19,'Very Ape',11),(21,'In Bloom',12),(22,'On a Plain',12),(23,'Polly',12),(24,'Complexion (a zulu love)',14),(25,'King Kunta',14),(26,'Wesley’s Theory',14),(28,'Cavalos de Fão',16);
/*!40000 ALTER TABLE `musicas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-26 16:57:35
