/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

CREATE DATABASE IF NOT EXISTS `bugtracker` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_general_ci */;
USE `bugtracker`;

DROP TABLE IF EXISTS `mantis_api_token_table`;
CREATE TABLE IF NOT EXISTS `mantis_api_token_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `name` varchar(128) NOT NULL,
  `hash` varchar(128) NOT NULL,
  `date_created` int(10) unsigned NOT NULL DEFAULT '1',
  `date_used` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_user_id_name` (`user_id`,`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_api_token_table` DISABLE KEYS */;
INSERT INTO `mantis_api_token_table` (`id`, `user_id`, `name`, `hash`, `date_created`, `date_used`) VALUES
	(1, 1, 'Token API', '08083526e04806724f9c06413566d7a3bca2b72323c5219e82068af8bae708ab', 1619203777, 1631627389);
/*!40000 ALTER TABLE `mantis_api_token_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bugnote_table`;
CREATE TABLE IF NOT EXISTS `mantis_bugnote_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `bug_id` int(10) unsigned NOT NULL DEFAULT '0',
  `reporter_id` int(10) unsigned NOT NULL DEFAULT '0',
  `bugnote_text_id` int(10) unsigned NOT NULL DEFAULT '0',
  `view_state` smallint(6) NOT NULL DEFAULT '10',
  `note_type` int(11) DEFAULT '0',
  `note_attr` varchar(250) DEFAULT '',
  `time_tracking` int(10) unsigned NOT NULL DEFAULT '0',
  `last_modified` int(10) unsigned NOT NULL DEFAULT '1',
  `date_submitted` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_bug` (`bug_id`),
  KEY `idx_last_mod` (`last_modified`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bugnote_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bugnote_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bugnote_text_table`;
CREATE TABLE IF NOT EXISTS `mantis_bugnote_text_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `note` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bugnote_text_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bugnote_text_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bug_file_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_file_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `bug_id` int(10) unsigned NOT NULL DEFAULT '0',
  `title` varchar(250) NOT NULL DEFAULT '',
  `description` varchar(250) NOT NULL DEFAULT '',
  `diskfile` varchar(250) NOT NULL DEFAULT '',
  `filename` varchar(250) NOT NULL DEFAULT '',
  `folder` varchar(250) NOT NULL DEFAULT '',
  `filesize` int(11) NOT NULL DEFAULT '0',
  `file_type` varchar(250) NOT NULL DEFAULT '',
  `content` longblob,
  `date_added` int(10) unsigned NOT NULL DEFAULT '1',
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `bugnote_id` int(10) unsigned DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `idx_bug_file_bug_id` (`bug_id`),
  KEY `idx_diskfile` (`diskfile`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bug_file_table` DISABLE KEYS */;
INSERT INTO `mantis_bug_file_table` (`id`, `bug_id`, `title`, `description`, `diskfile`, `filename`, `folder`, `filesize`, `file_type`, `content`, `date_added`, `user_id`, `bugnote_id`) VALUES
	(1, 1, '', '', '4c3d86a4ccf35cd84ca7efde127f149a', 'arquivoteste.txt', '', 18, 'text/plain; charset=us-ascii', _binary 0x4172717569766F2070617261207465737465, 1622056254, 1, NULL),
	(2, 2, '', '', 'b0c72292dc02d9ced987c168881a636c', 'desafioapi.txt', '', 21, 'text/plain; charset=us-ascii', _binary 0x4465736166696F2041504920526573745368617270, 1631627387, 1, NULL);
/*!40000 ALTER TABLE `mantis_bug_file_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bug_history_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_history_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `bug_id` int(10) unsigned NOT NULL DEFAULT '0',
  `field_name` varchar(64) NOT NULL,
  `old_value` varchar(255) NOT NULL,
  `new_value` varchar(255) NOT NULL,
  `type` smallint(6) NOT NULL DEFAULT '0',
  `date_modified` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_bug_history_bug_id` (`bug_id`),
  KEY `idx_history_user_id` (`user_id`),
  KEY `idx_bug_history_date_modified` (`date_modified`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bug_history_table` DISABLE KEYS */;
INSERT INTO `mantis_bug_history_table` (`id`, `user_id`, `bug_id`, `field_name`, `old_value`, `new_value`, `type`, `date_modified`) VALUES
	(1, 1, 1, '', '', '', 1, 1622056254),
	(2, 1, 1, '', 'arquivoteste.txt', '', 9, 1622056254),
	(3, 1, 2, '', '', '', 1, 1631627387),
	(4, 1, 2, '', 'desafioapi.txt', '', 9, 1631627387),
	(5, 1, 3, '', '', '', 1, 1631627388),
	(6, 1, 4, '', '', '', 1, 1631627388),
	(7, 1, 5, '', '', '', 1, 1631627388);
/*!40000 ALTER TABLE `mantis_bug_history_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bug_monitor_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_monitor_table` (
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `bug_id` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`user_id`,`bug_id`),
  KEY `idx_bug_id` (`bug_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bug_monitor_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bug_monitor_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bug_relationship_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_relationship_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `source_bug_id` int(10) unsigned NOT NULL DEFAULT '0',
  `destination_bug_id` int(10) unsigned NOT NULL DEFAULT '0',
  `relationship_type` smallint(6) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `idx_relationship_source` (`source_bug_id`),
  KEY `idx_relationship_destination` (`destination_bug_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bug_relationship_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bug_relationship_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bug_revision_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_revision_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `bug_id` int(10) unsigned NOT NULL,
  `bugnote_id` int(10) unsigned NOT NULL DEFAULT '0',
  `user_id` int(10) unsigned NOT NULL,
  `type` int(10) unsigned NOT NULL,
  `value` longtext NOT NULL,
  `timestamp` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_bug_rev_type` (`type`),
  KEY `idx_bug_rev_id_time` (`bug_id`,`timestamp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bug_revision_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bug_revision_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bug_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT '0',
  `reporter_id` int(10) unsigned NOT NULL DEFAULT '0',
  `handler_id` int(10) unsigned NOT NULL DEFAULT '0',
  `duplicate_id` int(10) unsigned NOT NULL DEFAULT '0',
  `priority` smallint(6) NOT NULL DEFAULT '30',
  `severity` smallint(6) NOT NULL DEFAULT '50',
  `reproducibility` smallint(6) NOT NULL DEFAULT '10',
  `status` smallint(6) NOT NULL DEFAULT '10',
  `resolution` smallint(6) NOT NULL DEFAULT '10',
  `projection` smallint(6) NOT NULL DEFAULT '10',
  `eta` smallint(6) NOT NULL DEFAULT '10',
  `bug_text_id` int(10) unsigned NOT NULL DEFAULT '0',
  `os` varchar(32) NOT NULL DEFAULT '',
  `os_build` varchar(32) NOT NULL DEFAULT '',
  `platform` varchar(32) NOT NULL DEFAULT '',
  `version` varchar(64) NOT NULL DEFAULT '',
  `fixed_in_version` varchar(64) NOT NULL DEFAULT '',
  `build` varchar(32) NOT NULL DEFAULT '',
  `profile_id` int(10) unsigned NOT NULL DEFAULT '0',
  `view_state` smallint(6) NOT NULL DEFAULT '10',
  `summary` varchar(128) NOT NULL DEFAULT '',
  `sponsorship_total` int(11) NOT NULL DEFAULT '0',
  `sticky` tinyint(4) NOT NULL DEFAULT '0',
  `target_version` varchar(64) NOT NULL DEFAULT '',
  `category_id` int(10) unsigned NOT NULL DEFAULT '1',
  `date_submitted` int(10) unsigned NOT NULL DEFAULT '1',
  `due_date` int(10) unsigned NOT NULL DEFAULT '1',
  `last_updated` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_bug_sponsorship_total` (`sponsorship_total`),
  KEY `idx_bug_fixed_in_version` (`fixed_in_version`),
  KEY `idx_bug_status` (`status`),
  KEY `idx_project` (`project_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bug_table` DISABLE KEYS */;
INSERT INTO `mantis_bug_table` (`id`, `project_id`, `reporter_id`, `handler_id`, `duplicate_id`, `priority`, `severity`, `reproducibility`, `status`, `resolution`, `projection`, `eta`, `bug_text_id`, `os`, `os_build`, `platform`, `version`, `fixed_in_version`, `build`, `profile_id`, `view_state`, `summary`, `sponsorship_total`, `sticky`, `target_version`, `category_id`, `date_submitted`, `due_date`, `last_updated`) VALUES
	(1, 2, 1, 0, 0, 30, 50, 70, 10, 10, 10, 10, 1, '', '', '', '', '', '', 0, 10, 'Teste issue com anexo', 0, 0, '', 1, 1622056254, 1, 1622056254),
	(2, 2, 1, 0, 0, 30, 50, 70, 10, 10, 10, 10, 2, '', '', '', '', '', '', 0, 10, 'Issue com anexo', 0, 0, '', 1, 1631627387, 1, 1631627387),
	(3, 2, 1, 0, 0, 30, 50, 70, 10, 10, 10, 10, 3, '', '', '', '', '', '', 0, 10, 'Sumário Válido', 0, 0, '', 1, 1631627387, 1, 1631627387),
	(4, 1, 1, 0, 0, 30, 50, 70, 10, 10, 10, 10, 4, '', '', '', '', '', '', 0, 10, 'Teste Issue', 0, 0, '', 1, 1631627388, 1, 1631627388),
	(5, 1, 1, 0, 0, 30, 50, 70, 10, 10, 10, 10, 5, '', '', '', '', '', '', 0, 10, 'Bug Issue', 0, 0, '', 1, 1631627388, 1, 1631627388);
/*!40000 ALTER TABLE `mantis_bug_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bug_tag_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_tag_table` (
  `bug_id` int(10) unsigned NOT NULL DEFAULT '0',
  `tag_id` int(10) unsigned NOT NULL DEFAULT '0',
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `date_attached` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`bug_id`,`tag_id`),
  KEY `idx_bug_tag_tag_id` (`tag_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bug_tag_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bug_tag_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_bug_text_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_text_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `description` longtext NOT NULL,
  `steps_to_reproduce` longtext NOT NULL,
  `additional_information` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_bug_text_table` DISABLE KEYS */;
INSERT INTO `mantis_bug_text_table` (`id`, `description`, `steps_to_reproduce`, `additional_information`) VALUES
	(1, 'Esta issue possui um anexo em texto', '', ''),
	(2, 'Esta issue possui um anexo em texto', '', ''),
	(3, 'Descrição Válida', '', ''),
	(4, 'Descrição do Teste', '', ''),
	(5, 'Descrição do Bug', '', '');
/*!40000 ALTER TABLE `mantis_bug_text_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_category_table`;
CREATE TABLE IF NOT EXISTS `mantis_category_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT '0',
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `name` varchar(128) NOT NULL DEFAULT '',
  `status` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_category_project_name` (`project_id`,`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_category_table` DISABLE KEYS */;
INSERT INTO `mantis_category_table` (`id`, `project_id`, `user_id`, `name`, `status`) VALUES
	(1, 0, 0, 'General', 0);
/*!40000 ALTER TABLE `mantis_category_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_config_table`;
CREATE TABLE IF NOT EXISTS `mantis_config_table` (
  `config_id` varchar(64) NOT NULL,
  `project_id` int(11) NOT NULL DEFAULT '0',
  `user_id` int(11) NOT NULL DEFAULT '0',
  `access_reqd` int(11) DEFAULT '0',
  `type` int(11) DEFAULT '90',
  `value` longtext NOT NULL,
  PRIMARY KEY (`config_id`,`project_id`,`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_config_table` DISABLE KEYS */;
INSERT INTO `mantis_config_table` (`config_id`, `project_id`, `user_id`, `access_reqd`, `type`, `value`) VALUES
	('database_version', 0, 0, 90, 1, '210');
/*!40000 ALTER TABLE `mantis_config_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_custom_field_project_table`;
CREATE TABLE IF NOT EXISTS `mantis_custom_field_project_table` (
  `field_id` int(11) NOT NULL DEFAULT '0',
  `project_id` int(10) unsigned NOT NULL DEFAULT '0',
  `sequence` smallint(6) NOT NULL DEFAULT '0',
  PRIMARY KEY (`field_id`,`project_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_custom_field_project_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_custom_field_project_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_custom_field_string_table`;
CREATE TABLE IF NOT EXISTS `mantis_custom_field_string_table` (
  `field_id` int(11) NOT NULL DEFAULT '0',
  `bug_id` int(11) NOT NULL DEFAULT '0',
  `value` varchar(255) NOT NULL DEFAULT '',
  `text` longtext,
  PRIMARY KEY (`field_id`,`bug_id`),
  KEY `idx_custom_field_bug` (`bug_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_custom_field_string_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_custom_field_string_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_custom_field_table`;
CREATE TABLE IF NOT EXISTS `mantis_custom_field_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(64) NOT NULL DEFAULT '',
  `type` smallint(6) NOT NULL DEFAULT '0',
  `possible_values` text,
  `default_value` varchar(255) NOT NULL DEFAULT '',
  `valid_regexp` varchar(255) NOT NULL DEFAULT '',
  `access_level_r` smallint(6) NOT NULL DEFAULT '0',
  `access_level_rw` smallint(6) NOT NULL DEFAULT '0',
  `length_min` int(11) NOT NULL DEFAULT '0',
  `length_max` int(11) NOT NULL DEFAULT '0',
  `require_report` tinyint(4) NOT NULL DEFAULT '0',
  `require_update` tinyint(4) NOT NULL DEFAULT '0',
  `display_report` tinyint(4) NOT NULL DEFAULT '0',
  `display_update` tinyint(4) NOT NULL DEFAULT '1',
  `require_resolved` tinyint(4) NOT NULL DEFAULT '0',
  `display_resolved` tinyint(4) NOT NULL DEFAULT '0',
  `display_closed` tinyint(4) NOT NULL DEFAULT '0',
  `require_closed` tinyint(4) NOT NULL DEFAULT '0',
  `filter_by` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_custom_field_name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_custom_field_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_custom_field_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_email_table`;
CREATE TABLE IF NOT EXISTS `mantis_email_table` (
  `email_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `email` varchar(64) NOT NULL DEFAULT '',
  `subject` varchar(250) NOT NULL DEFAULT '',
  `metadata` longtext NOT NULL,
  `body` longtext NOT NULL,
  `submitted` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`email_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_email_table` DISABLE KEYS */;
INSERT INTO `mantis_email_table` (`email_id`, `email`, `subject`, `metadata`, `body`, `submitted`) VALUES
	(10, 'felipe_melo@gmail.com', '[MantisBT] Account registration', 'a:3:{s:7:"headers";a:0:{}s:7:"charset";s:5:"utf-8";s:8:"hostname";s:20:"host.docker.internal";}', 'The user administrator has created an account for you with username "isabela.martins27". In order to complete your registration, visit the following URL (make sure it is entered as the single line) and set your own access password:\n\nhttp://host.docker.internal:8989/verify.php?id=11&confirm_hash=vTHVCTnzNuuGN1PADV7WSFw_yP9eNu43edVR9ePWTe9d3Xn8hAFo9PcZ6wFC6exoH6CWIJdDzUAnaizU6WFP\n\nIf you did not request any registration, ignore this message and nothing will happen.\n\nDo not reply to this message', 1631627387),
	(11, 'joao.silva97@gmail.com', '[MantisBT] Password Reset', 'a:3:{s:7:"headers";a:0:{}s:7:"charset";s:5:"utf-8";s:8:"hostname";s:20:"host.docker.internal";}', 'Someone (presumably you) requested a password change through e-mail verification. If this was not you, ignore this message and nothing will happen.\n\nIf you requested this verification, visit the following URL to change your password: \n\nhttp://host.docker.internal:8989/verify.php?id=3&confirm_hash=0sGoMe4TzDAaebTBo2lQpvt7P1CxRhIEBekDGckXZHS5LA9P7zYTICc0EOTZEyj8qxaG6Ilo_P__QCCzZtEl \n\nUsername: leonardo55 \nRemote IP address: 172.18.0.1 \n\nDo not reply to this message', 1631627388),
	(12, 'email01@valid.com', '[MantisBT] Account registration', 'a:3:{s:7:"headers";a:0:{}s:7:"charset";s:5:"utf-8";s:8:"hostname";s:20:"host.docker.internal";}', 'The user administrator has created an account for you with username "test.updater". In order to complete your registration, visit the following URL (make sure it is entered as the single line) and set your own access password:\n\nhttp://host.docker.internal:8989/verify.php?id=12&confirm_hash=z8uVEOotFp3Oi8KMfQ7emywKrWrxIlj7scRcJfp7imMiOsW5QBfRhq4-Rsj6B6CS-pWExBWRltzNn2KloUjq\n\nIf you did not request any registration, ignore this message and nothing will happen.\n\nDo not reply to this message', 1631627388),
	(13, 'email02@valid.com', '[MantisBT] Account registration', 'a:3:{s:7:"headers";a:0:{}s:7:"charset";s:5:"utf-8";s:8:"hostname";s:20:"host.docker.internal";}', 'The user administrator has created an account for you with username "test.reporter". In order to complete your registration, visit the following URL (make sure it is entered as the single line) and set your own access password:\n\nhttp://host.docker.internal:8989/verify.php?id=13&confirm_hash=W8ix_OTq8NGVozTJ8IoWxJVvFI9l02saxoMJ4PewCbx-YydFVytopjVl9gROWUCvW-IjwaTVYvJ0x6bBuC39\n\nIf you did not request any registration, ignore this message and nothing will happen.\n\nDo not reply to this message', 1631627388),
	(14, 'email03@valid.com', '[MantisBT] Account registration', 'a:3:{s:7:"headers";a:0:{}s:7:"charset";s:5:"utf-8";s:8:"hostname";s:20:"host.docker.internal";}', 'The user administrator has created an account for you with username "test.developer". In order to complete your registration, visit the following URL (make sure it is entered as the single line) and set your own access password:\n\nhttp://host.docker.internal:8989/verify.php?id=14&confirm_hash=XHO1sT6IkSZDq_VvKHUlYnGTqRCQe6_vJhEflgPH4y_AKxJ0ECrHTVP_DO29TL8bjrY8aS0nP4ye3Ua0S6g0\n\nIf you did not request any registration, ignore this message and nothing will happen.\n\nDo not reply to this message', 1631627388);
/*!40000 ALTER TABLE `mantis_email_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_filters_table`;
CREATE TABLE IF NOT EXISTS `mantis_filters_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL DEFAULT '0',
  `project_id` int(11) NOT NULL DEFAULT '0',
  `is_public` tinyint(4) DEFAULT NULL,
  `name` varchar(64) NOT NULL DEFAULT '',
  `filter_string` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_filters_table` DISABLE KEYS */;
INSERT INTO `mantis_filters_table` (`id`, `user_id`, `project_id`, `is_public`, `name`, `filter_string`) VALUES
	(1, 1, 0, 0, '', 'v9#{"_version":"v9","_view_type":"simple","category_id":["0"],"severity":[70],"status":[10],"per_page":50,"highlight_changed":6,"reporter_id":[0],"handler_id":[0],"project_id":[-3],"sort":"last_updated","dir":"DESC","filter_by_date":false,"start_month":5,"start_day":1,"start_year":2021,"end_month":5,"end_day":18,"end_year":2021,"filter_by_last_updated_date":false,"last_updated_start_month":5,"last_updated_start_day":1,"last_updated_start_year":2021,"last_updated_end_month":5,"last_updated_end_day":18,"last_updated_end_year":2021,"search":"","hide_status":[90],"resolution":[0],"build":["0"],"version":["0"],"fixed_in_version":["0"],"target_version":["0"],"priority":[40],"monitor_user_id":[0],"view_state":0,"custom_fields":[],"sticky":true,"relationship_type":-1,"relationship_bug":0,"profile_id":[0],"platform":["0"],"os":["0"],"os_build":["0"],"tag_string":"","tag_select":0,"note_user_id":[0],"match_type":0,"_source_query_id":4}'),
	(2, 1, 0, 1, 'Filtro Pesquisa', 'v9#{"_version":"v9","_view_type":"simple","category_id":["0"],"severity":[0],"status":[10],"per_page":50,"highlight_changed":6,"reporter_id":[0],"handler_id":[0],"project_id":[-3],"sort":"last_updated","dir":"DESC","filter_by_date":false,"start_month":5,"start_day":1,"start_year":2021,"end_month":5,"end_day":18,"end_year":2021,"filter_by_last_updated_date":false,"last_updated_start_month":5,"last_updated_start_day":1,"last_updated_start_year":2021,"last_updated_end_month":5,"last_updated_end_day":18,"last_updated_end_year":2021,"search":"","hide_status":[90],"resolution":[0],"build":["0"],"version":["0"],"fixed_in_version":["0"],"target_version":["0"],"priority":[40],"monitor_user_id":[0],"view_state":0,"custom_fields":[],"sticky":true,"relationship_type":-1,"relationship_bug":0,"profile_id":[0],"platform":["0"],"os":["0"],"os_build":["0"],"tag_string":"","tag_select":0,"note_user_id":[0],"match_type":0}'),
	(3, 1, 0, 0, 'Filtro Teste', 'v9#{"_version":"v9","_view_type":"simple","category_id":["0"],"severity":[70],"status":[10],"per_page":50,"highlight_changed":6,"reporter_id":[0],"handler_id":[0],"project_id":[-3],"sort":"last_updated","dir":"DESC","filter_by_date":false,"start_month":5,"start_day":1,"start_year":2021,"end_month":5,"end_day":18,"end_year":2021,"filter_by_last_updated_date":false,"last_updated_start_month":5,"last_updated_start_day":1,"last_updated_start_year":2021,"last_updated_end_month":5,"last_updated_end_day":18,"last_updated_end_year":2021,"search":"","hide_status":[90],"resolution":[0],"build":["0"],"version":["0"],"fixed_in_version":["0"],"target_version":["0"],"priority":[40],"monitor_user_id":[0],"view_state":0,"custom_fields":[],"sticky":true,"relationship_type":-1,"relationship_bug":0,"profile_id":[0],"platform":["0"],"os":["0"],"os_build":["0"],"tag_string":"","tag_select":0,"note_user_id":[0],"match_type":0}');
/*!40000 ALTER TABLE `mantis_filters_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_news_table`;
CREATE TABLE IF NOT EXISTS `mantis_news_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT '0',
  `poster_id` int(10) unsigned NOT NULL DEFAULT '0',
  `view_state` smallint(6) NOT NULL DEFAULT '10',
  `announcement` tinyint(4) NOT NULL DEFAULT '0',
  `headline` varchar(64) NOT NULL DEFAULT '',
  `body` longtext NOT NULL,
  `last_modified` int(10) unsigned NOT NULL DEFAULT '1',
  `date_posted` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_news_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_news_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_plugin_table`;
CREATE TABLE IF NOT EXISTS `mantis_plugin_table` (
  `basename` varchar(40) NOT NULL,
  `enabled` tinyint(4) NOT NULL DEFAULT '0',
  `protected` tinyint(4) NOT NULL DEFAULT '0',
  `priority` int(10) unsigned NOT NULL DEFAULT '3',
  PRIMARY KEY (`basename`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_plugin_table` DISABLE KEYS */;
INSERT INTO `mantis_plugin_table` (`basename`, `enabled`, `protected`, `priority`) VALUES
	('MantisCoreFormatting', 1, 0, 3);
/*!40000 ALTER TABLE `mantis_plugin_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_project_file_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_file_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT '0',
  `title` varchar(250) NOT NULL DEFAULT '',
  `description` varchar(250) NOT NULL DEFAULT '',
  `diskfile` varchar(250) NOT NULL DEFAULT '',
  `filename` varchar(250) NOT NULL DEFAULT '',
  `folder` varchar(250) NOT NULL DEFAULT '',
  `filesize` int(11) NOT NULL DEFAULT '0',
  `file_type` varchar(250) NOT NULL DEFAULT '',
  `content` longblob,
  `date_added` int(10) unsigned NOT NULL DEFAULT '1',
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_project_file_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_project_file_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_project_hierarchy_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_hierarchy_table` (
  `child_id` int(10) unsigned NOT NULL,
  `parent_id` int(10) unsigned NOT NULL,
  `inherit_parent` tinyint(4) NOT NULL DEFAULT '0',
  UNIQUE KEY `idx_project_hierarchy` (`child_id`,`parent_id`),
  KEY `idx_project_hierarchy_child_id` (`child_id`),
  KEY `idx_project_hierarchy_parent_id` (`parent_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_project_hierarchy_table` DISABLE KEYS */;
INSERT INTO `mantis_project_hierarchy_table` (`child_id`, `parent_id`, `inherit_parent`) VALUES
	(2, 1, 1),
	(5, 1, 1);
/*!40000 ALTER TABLE `mantis_project_hierarchy_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_project_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(128) NOT NULL DEFAULT '',
  `status` smallint(6) NOT NULL DEFAULT '10',
  `enabled` tinyint(4) NOT NULL DEFAULT '1',
  `view_state` smallint(6) NOT NULL DEFAULT '10',
  `access_min` smallint(6) NOT NULL DEFAULT '10',
  `file_path` varchar(250) NOT NULL DEFAULT '',
  `description` longtext NOT NULL,
  `category_id` int(10) unsigned NOT NULL DEFAULT '1',
  `inherit_global` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_project_name` (`name`),
  KEY `idx_project_view` (`view_state`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_project_table` DISABLE KEYS */;
INSERT INTO `mantis_project_table` (`id`, `name`, `status`, `enabled`, `view_state`, `access_min`, `file_path`, `description`, `category_id`, `inherit_global`) VALUES
	(1, 'Projeto Mantis API REST', 10, 1, 10, 10, '/tmp/', 'Projeto Mantis API REST', 1, 1),
	(2, 'Projeto Teste Mantis API REST', 30, 1, 10, 10, '/tmp/', 'Projeto Teste Mantis API REST', 1, 1),
	(4, 'Projeto Teste Dois', 30, 0, 10, 10, '/tmp/', 'Projeto Teste Dois', 1, 1),
	(5, 'Teste Atualizar', 10, 1, 30, 10, '/tmp/', 'Projeto Dev', 1, 1),
	(6, 'Projeto Automação Mantis API REST', 10, 1, 10, 10, '/tmp/', 'Criação de Projeto Mantis', 1, 1);
/*!40000 ALTER TABLE `mantis_project_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_project_user_list_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_user_list_table` (
  `project_id` int(10) unsigned NOT NULL DEFAULT '0',
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `access_level` smallint(6) NOT NULL DEFAULT '10',
  PRIMARY KEY (`project_id`,`user_id`),
  KEY `idx_project_user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_project_user_list_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_project_user_list_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_project_version_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_version_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT '0',
  `version` varchar(64) NOT NULL DEFAULT '',
  `description` longtext NOT NULL,
  `released` tinyint(4) NOT NULL DEFAULT '1',
  `obsolete` tinyint(4) NOT NULL DEFAULT '0',
  `date_order` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_project_version` (`project_id`,`version`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_project_version_table` DISABLE KEYS */;
INSERT INTO `mantis_project_version_table` (`id`, `project_id`, `version`, `description`, `released`, `obsolete`, `date_order`) VALUES
	(1, 38, 'v1.1.0', 'Major new version', 1, 0, 1631047000);
/*!40000 ALTER TABLE `mantis_project_version_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_sponsorship_table`;
CREATE TABLE IF NOT EXISTS `mantis_sponsorship_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bug_id` int(11) NOT NULL DEFAULT '0',
  `user_id` int(11) NOT NULL DEFAULT '0',
  `amount` int(11) NOT NULL DEFAULT '0',
  `logo` varchar(128) NOT NULL DEFAULT '',
  `url` varchar(128) NOT NULL DEFAULT '',
  `paid` tinyint(4) NOT NULL DEFAULT '0',
  `date_submitted` int(10) unsigned NOT NULL DEFAULT '1',
  `last_updated` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_sponsorship_bug_id` (`bug_id`),
  KEY `idx_sponsorship_user_id` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_sponsorship_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_sponsorship_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_tag_table`;
CREATE TABLE IF NOT EXISTS `mantis_tag_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `name` varchar(100) NOT NULL DEFAULT '',
  `description` longtext NOT NULL,
  `date_created` int(10) unsigned NOT NULL DEFAULT '1',
  `date_updated` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`,`name`),
  KEY `idx_tag_name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_tag_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_tag_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_tokens_table`;
CREATE TABLE IF NOT EXISTS `mantis_tokens_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `owner` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `value` longtext NOT NULL,
  `timestamp` int(10) unsigned NOT NULL DEFAULT '1',
  `expiry` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `idx_typeowner` (`type`,`owner`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_tokens_table` DISABLE KEYS */;
INSERT INTO `mantis_tokens_table` (`id`, `owner`, `type`, `value`, `timestamp`, `expiry`) VALUES
	(10, 11, 7, 'vTHVCTnzNuuGN1PADV7WSFw_yP9eNu43edVR9ePWTe9d3Xn8hAFo9PcZ6wFC6exoH6CWIJdDzUAnaizU6WFP', 1631627387, 1632232187),
	(11, 1, 3, '2,5,4,3', 1631627387, 1631713811),
	(12, 3, 7, '0sGoMe4TzDAaebTBo2lQpvt7P1CxRhIEBekDGckXZHS5LA9P7zYTICc0EOTZEyj8qxaG6Ilo_P__QCCzZtEl', 1631627388, 1632232188),
	(13, 12, 7, 'z8uVEOotFp3Oi8KMfQ7emywKrWrxIlj7scRcJfp7imMiOsW5QBfRhq4-Rsj6B6CS-pWExBWRltzNn2KloUjq', 1631627388, 1632232188),
	(14, 13, 7, 'W8ix_OTq8NGVozTJ8IoWxJVvFI9l02saxoMJ4PewCbx-YydFVytopjVl9gROWUCvW-IjwaTVYvJ0x6bBuC39', 1631627388, 1632232188),
	(15, 14, 7, 'XHO1sT6IkSZDq_VvKHUlYnGTqRCQe6_vJhEflgPH4y_AKxJ0ECrHTVP_DO29TL8bjrY8aS0nP4ye3Ua0S6g0', 1631627388, 1632232188);
/*!40000 ALTER TABLE `mantis_tokens_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_user_pref_table`;
CREATE TABLE IF NOT EXISTS `mantis_user_pref_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `project_id` int(10) unsigned NOT NULL DEFAULT '0',
  `default_profile` int(10) unsigned NOT NULL DEFAULT '0',
  `default_project` int(10) unsigned NOT NULL DEFAULT '0',
  `refresh_delay` int(11) NOT NULL DEFAULT '0',
  `redirect_delay` int(11) NOT NULL DEFAULT '0',
  `bugnote_order` varchar(4) NOT NULL DEFAULT 'ASC',
  `email_on_new` tinyint(4) NOT NULL DEFAULT '0',
  `email_on_assigned` tinyint(4) NOT NULL DEFAULT '0',
  `email_on_feedback` tinyint(4) NOT NULL DEFAULT '0',
  `email_on_resolved` tinyint(4) NOT NULL DEFAULT '0',
  `email_on_closed` tinyint(4) NOT NULL DEFAULT '0',
  `email_on_reopened` tinyint(4) NOT NULL DEFAULT '0',
  `email_on_bugnote` tinyint(4) NOT NULL DEFAULT '0',
  `email_on_status` tinyint(4) NOT NULL DEFAULT '0',
  `email_on_priority` tinyint(4) NOT NULL DEFAULT '0',
  `email_on_priority_min_severity` smallint(6) NOT NULL DEFAULT '10',
  `email_on_status_min_severity` smallint(6) NOT NULL DEFAULT '10',
  `email_on_bugnote_min_severity` smallint(6) NOT NULL DEFAULT '10',
  `email_on_reopened_min_severity` smallint(6) NOT NULL DEFAULT '10',
  `email_on_closed_min_severity` smallint(6) NOT NULL DEFAULT '10',
  `email_on_resolved_min_severity` smallint(6) NOT NULL DEFAULT '10',
  `email_on_feedback_min_severity` smallint(6) NOT NULL DEFAULT '10',
  `email_on_assigned_min_severity` smallint(6) NOT NULL DEFAULT '10',
  `email_on_new_min_severity` smallint(6) NOT NULL DEFAULT '10',
  `email_bugnote_limit` smallint(6) NOT NULL DEFAULT '0',
  `language` varchar(32) NOT NULL DEFAULT 'english',
  `timezone` varchar(32) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_user_pref_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_user_pref_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_user_print_pref_table`;
CREATE TABLE IF NOT EXISTS `mantis_user_print_pref_table` (
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `print_pref` varchar(64) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_user_print_pref_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_user_print_pref_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_user_profile_table`;
CREATE TABLE IF NOT EXISTS `mantis_user_profile_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT '0',
  `platform` varchar(32) NOT NULL DEFAULT '',
  `os` varchar(32) NOT NULL DEFAULT '',
  `os_build` varchar(32) NOT NULL DEFAULT '',
  `description` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_user_profile_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_user_profile_table` ENABLE KEYS */;

DROP TABLE IF EXISTS `mantis_user_table`;
CREATE TABLE IF NOT EXISTS `mantis_user_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(191) NOT NULL DEFAULT '',
  `realname` varchar(191) NOT NULL DEFAULT '',
  `email` varchar(191) NOT NULL DEFAULT '',
  `password` varchar(64) NOT NULL DEFAULT '',
  `enabled` tinyint(4) NOT NULL DEFAULT '1',
  `protected` tinyint(4) NOT NULL DEFAULT '0',
  `access_level` smallint(6) NOT NULL DEFAULT '10',
  `login_count` int(11) NOT NULL DEFAULT '0',
  `lost_password_request_count` smallint(6) NOT NULL DEFAULT '0',
  `failed_login_count` smallint(6) NOT NULL DEFAULT '0',
  `cookie_string` varchar(64) NOT NULL DEFAULT '',
  `last_visit` int(10) unsigned NOT NULL DEFAULT '1',
  `date_created` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_user_cookie_string` (`cookie_string`),
  UNIQUE KEY `idx_user_username` (`username`),
  KEY `idx_enable` (`enabled`),
  KEY `idx_access` (`access_level`),
  KEY `idx_email` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `mantis_user_table` DISABLE KEYS */;
INSERT INTO `mantis_user_table` (`id`, `username`, `realname`, `email`, `password`, `enabled`, `protected`, `access_level`, `login_count`, `lost_password_request_count`, `failed_login_count`, `cookie_string`, `last_visit`, `date_created`) VALUES
	(1, 'administrator', 'Daniela Pochini', 'root@localhost', '200ceb26807d6bf99fd6f4f0d1ca54d4', 1, 0, 90, 5, 0, 0, '8Pfw94O1akdxwD4CcBau-EsWLVgenquSatYCSZdpsbvijzySBNQOzF9LvlenXFxA', 1631627417, 1619203676),
	(3, 'leonardo55', 'Alicia Carvalho', 'joao.silva97@gmail.com', 'f741229e47342b5616e9697b4e05c3d5', 1, 0, 40, 0, 0, 0, 'TXeB2YHfehnAfIT29Qxa64WQydBw4asxr9n7qvthnlJho0pCy2EX_A9-l6fEM9x1', 1621022507, 1621022507),
	(4, 'marli_macedo21', 'Giovanna Pereira', 'isabela43@gmail.com', '2165fc563da826eab6da80ad3a1bccd0', 1, 0, 40, 0, 0, 0, 'aAV9mRCaYufj3T-CATzDKTj5YeRtv75usbtpc_asXeJB8u5W53_6Ih7eJ1CzDWIg', 1621022518, 1621022518),
	(5, 'bruna73', 'Henrique Barros', 'beatriz_albuquerque93@gmail.com', '4c2b0706baa9475d92932d4f415a7738', 1, 0, 40, 0, 0, 0, 'fMZIVbGnausECxzNDBr8vWYsfuaDMQpAHj1Aak8ilM-EPjsDChJZqhj2lVafy5pH', 1621022530, 1621022530),
	(6, 'miguel.nogueira82', 'Marli Melo', 'murilo_albuquerque24@bol.com.br', '64bb674604f46918d9b82bb81cdd5763', 1, 0, 40, 0, 0, 0, 'CCEeT3t32d1E_p90CgSnJdBvUpRkmJPTHHjzOB5_o-K3B8xKxWImHauUL1v5AX5s', 1621022542, 1621022542),
	(7, 'valentina_franco', 'Davi Lucca Melo', 'kleber11@yahoo.com', 'd2d8424ac5cb228e089823ed60fd0f27', 1, 0, 40, 0, 0, 0, 'DQRQdVasvw_yVtgXS3XZdURTkASI6iq7jQUY6vlba2CjjSpzjQEeIPnIdDBa7g-n', 1621022557, 1621022557),
	(8, 'alexandre.santos', 'Marcela Pereira', 'antonio41@live.com', '1562ff6446db6363d8241200b9401a6b', 1, 0, 40, 0, 0, 0, 'tuJfIZ4xodX21muSPnDDBkOedFauzqvtiPl64aJ_P-Qe0uHIywUPSqmMwc2E2YQK', 1621022577, 1621022577),
	(9, 'joana_macedo', 'Renata Souza', 'joana11@hotmail.com', '6942f198ec20ae0d5148f63cdb510ea5', 1, 0, 40, 0, 0, 0, 'qSuteQy8Z9TpYC64ritx2QzHNN6ph__oIMVJ4Bs3oXKpopidHMlDLPoh4y3zzrM9', 1621022591, 1621022591),
	(10, 'julia_barros', 'Marli Costa', 'enzo_xavier40@live.com', 'affcd66a7924598a9e7080ddcb01c42f', 1, 0, 40, 0, 0, 0, '1zbQxLH0SSwBqgkYrKmzC8t1gCpdxa37OUwbmJ0MCfQGfse369jtdB6eCi8R5N07', 1621022603, 1621022603),
	(11, 'isabela.martins27', 'Marcos Franco', 'felipe_melo@gmail.com', '279468535f1c974fe2b954ba406877f9', 1, 0, 40, 0, 0, 0, 'RCGF3tGcI2wA0s5IzvWlABjumOKa773pzYLSDoOhIT7AvvF1zUzDeRnI5pjLhI9S', 1631627387, 1631627387),
	(12, 'test.updater', 'Usuario Nivel Updater', 'email01@valid.com', 'c5ce81ac1109df434c1e127ce95bbe89', 1, 0, 40, 0, 0, 0, 'w3VBmF2BGW7cMdc3IhRcNk815RFIfJdrh1HZksnYKMqqmDQnBcx3jruIWrUFqPnb', 1631627388, 1631627388),
	(13, 'test.reporter', 'Usuario Nivel Reporter', 'email02@valid.com', '5b5ddbb3035c3f87ff232011dd9691cd', 1, 0, 25, 0, 0, 0, 'iXxbGiVAvtQ_yc8FLJ4pZtCOT6RQaGXaOxjtEjVy2NRZnz4yGj79VT6WNP6XgGCU', 1631627388, 1631627388),
	(14, 'test.developer', 'Usuario Nivel Developer', 'email03@valid.com', 'e7898ec299764ff3bab2c427152f46e4', 1, 0, 55, 0, 0, 0, 'cwJAuVWlgnvDSUaSr51BuLsfdgY0q6IEACtE8CQU6-4v2UVoYRuKK-2d9SYPchc2', 1631627388, 1631627388);
/*!40000 ALTER TABLE `mantis_user_table` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
