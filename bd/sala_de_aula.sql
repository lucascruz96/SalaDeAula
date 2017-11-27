-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.7.18-log


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema sala_de_aula
--

CREATE DATABASE IF NOT EXISTS sala_de_aula;
USE sala_de_aula;

--
-- Definition of table `alternativa`
--

DROP TABLE IF EXISTS `alternativa`;
CREATE TABLE `alternativa` (
  `codigo_alternativa` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `codigo_questao` int(10) unsigned NOT NULL,
  `texto_alternativa` text NOT NULL,
  `correta` tinyint(1) NOT NULL,
  PRIMARY KEY (`codigo_alternativa`),
  KEY `FK_alternativa_questao` (`codigo_questao`),
  CONSTRAINT `FK_alternativa_questao` FOREIGN KEY (`codigo_questao`) REFERENCES `questao` (`codigo_questao`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;


--
-- Definition of table `atividade`
--

DROP TABLE IF EXISTS `atividade`;
CREATE TABLE `atividade` (
  `codigo_atividade` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `codigo_turma` int(10) unsigned NOT NULL,
  `nome_atividade` varchar(50) NOT NULL,
  `data_limite` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `data_criacao` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`codigo_atividade`),
  KEY `FK_atividade_turma` (`codigo_turma`),
  CONSTRAINT `FK_atividade_turma` FOREIGN KEY (`codigo_turma`) REFERENCES `turma` (`codigo_turma`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;


--
-- Definition of table `mensagem`
--

DROP TABLE IF EXISTS `mensagem`;
CREATE TABLE `mensagem` (
  `codigo_mensagem` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `codigo_turma` int(10) unsigned NOT NULL,
  `codigo_usuario` int(10) unsigned NOT NULL,
  `texto` varchar(255) NOT NULL,
  `data_postagem` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`codigo_mensagem`),
  KEY `FK_mensagem_turma` (`codigo_turma`),
  KEY `FK_mensagem_usuario` (`codigo_usuario`),
  CONSTRAINT `FK_mensagem_turma` FOREIGN KEY (`codigo_turma`) REFERENCES `turma` (`codigo_turma`),
  CONSTRAINT `FK_mensagem_usuario` FOREIGN KEY (`codigo_usuario`) REFERENCES `usuario` (`codigo_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;


--
-- Definition of table `questao`
--

DROP TABLE IF EXISTS `questao`;
CREATE TABLE `questao` (
  `codigo_questao` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `codigo_atividade` int(10) unsigned NOT NULL,
  `texto_questao` text NOT NULL,
  `valor` decimal(10,0) NOT NULL,
  PRIMARY KEY (`codigo_questao`),
  KEY `FK_questao_atividade` (`codigo_atividade`),
  CONSTRAINT `FK_questao_atividade` FOREIGN KEY (`codigo_atividade`) REFERENCES `atividade` (`codigo_atividade`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Definition of table `resposta`
--

DROP TABLE IF EXISTS `resposta`;
CREATE TABLE `resposta` (
  `codigo_resposta` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `codigo_usuario` int(10) unsigned NOT NULL,
  `codigo_questao` int(10) unsigned NOT NULL,
  `codigo_alternativa` int(10) unsigned NOT NULL,
  `data_envio` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`codigo_resposta`),
  KEY `FK_resposta_usuario` (`codigo_usuario`),
  KEY `FK_resposta_questao` (`codigo_questao`),
  KEY `FK_resposta_alternativa` (`codigo_alternativa`),
  CONSTRAINT `FK_resposta_alternativa` FOREIGN KEY (`codigo_alternativa`) REFERENCES `alternativa` (`codigo_alternativa`),
  CONSTRAINT `FK_resposta_questao` FOREIGN KEY (`codigo_questao`) REFERENCES `questao` (`codigo_questao`),
  CONSTRAINT `FK_resposta_usuario` FOREIGN KEY (`codigo_usuario`) REFERENCES `usuario` (`codigo_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


/*!40000 ALTER TABLE `resposta` DISABLE KEYS */;
/*!40000 ALTER TABLE `resposta` ENABLE KEYS */;


--
-- Definition of table `turma`
--

DROP TABLE IF EXISTS `turma`;
CREATE TABLE `turma` (
  `codigo_turma` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome_turma` varchar(50) NOT NULL,
  `token_acesso` varchar(35) NOT NULL,
  `data_criacao` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`codigo_turma`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Definition of table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `codigo_usuario` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome_usuario` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `senha` varchar(35) NOT NULL,
  `token_usuario` varchar(35) NOT NULL,
  PRIMARY KEY (`codigo_usuario`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Definition of table `usuario_turma`
--

DROP TABLE IF EXISTS `usuario_turma`;
CREATE TABLE `usuario_turma` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `codigo_usuario` int(10) unsigned NOT NULL,
  `codigo_turma` int(10) unsigned NOT NULL,
  `professor` tinyint(1) NOT NULL,
  `data_entrada` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`codigo`),
  KEY `FK_usuario_turma_turma` (`codigo_turma`),
  KEY `FK_usuario_turma_usuario` (`codigo_usuario`),
  CONSTRAINT `FK_usuario_turma_turma` FOREIGN KEY (`codigo_turma`) REFERENCES `turma` (`codigo_turma`),
  CONSTRAINT `FK_usuario_turma_usuario` FOREIGN KEY (`codigo_usuario`) REFERENCES `usuario` (`codigo_usuario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;