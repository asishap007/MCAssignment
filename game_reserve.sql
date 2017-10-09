-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 09, 2017 at 01:43 PM
-- Server version: 5.5.37
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `game_reserve`
--

-- --------------------------------------------------------

--
-- Table structure for table `animals`
--

CREATE TABLE IF NOT EXISTS `animals` (
  `animalId` int(11) NOT NULL AUTO_INCREMENT,
  `categoryId` int(11) NOT NULL,
  `gpsDeviceId` varchar(255) NOT NULL,
  `createdAt` datetime NOT NULL,
  PRIMARY KEY (`animalId`),
  UNIQUE KEY `gpsDeviceId` (`gpsDeviceId`),
  KEY `categoryId` (`categoryId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=64 ;

--
-- Dumping data for table `animals`
--

INSERT INTO `animals` (`animalId`, `categoryId`, `gpsDeviceId`, `createdAt`) VALUES
(1, 1, 'SERIAL100010', '2017-10-05 00:00:00'),
(2, 1, 'SERIAL100011', '2017-10-05 05:00:00'),
(3, 2, 'SERIAL200010', '2017-10-05 07:00:00'),
(4, 2, 'SERIAL200011', '2017-10-05 08:00:00'),
(36, 1, 'SERIAL100012', '2017-10-07 17:58:56'),
(47, 1, 'SERIAL100013', '2017-10-09 14:47:54'),
(49, 1, 'SERIAL100014', '2017-10-09 14:50:58'),
(50, 1, 'SERIAL100015', '2017-10-09 14:51:06'),
(51, 2, 'SERIAL200012', '2017-10-09 14:51:32'),
(52, 2, 'SERIAL200013', '2017-10-09 14:51:42'),
(53, 3, 'SERIAL300010', '2017-10-09 14:53:51'),
(56, 3, 'SERIAL300011', '2017-10-09 14:54:30'),
(57, 10, 'SERIAL400010', '2017-10-09 14:55:38'),
(60, 10, 'SERIAL400011', '2017-10-09 14:56:16'),
(61, 10, 'SERIAL400012', '2017-10-09 14:56:23'),
(62, 10, 'SERIAL400013', '2017-10-09 14:56:32'),
(63, 10, 'SERIAL400014', '2017-10-09 14:56:40');

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(255) NOT NULL,
  `colorIndication` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `categoryName` (`categoryName`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=23 ;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `categoryName`, `colorIndication`) VALUES
(1, 'Tiger', '#ff4dd2'),
(2, 'Monkey', '#ff1a75'),
(3, 'Snake', '#ff6600'),
(10, 'Lion', '#c44dff');

-- --------------------------------------------------------

--
-- Table structure for table `gpstracking`
--

CREATE TABLE IF NOT EXISTS `gpstracking` (
  `trackingId` int(11) NOT NULL AUTO_INCREMENT,
  `animalId` int(11) NOT NULL,
  `latitude` double NOT NULL,
  `longitude` double NOT NULL,
  `createdAt` datetime NOT NULL,
  PRIMARY KEY (`trackingId`),
  KEY `deviceId` (`animalId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=26 ;

--
-- Dumping data for table `gpstracking`
--

INSERT INTO `gpstracking` (`trackingId`, `animalId`, `latitude`, `longitude`, `createdAt`) VALUES
(1, 1, -30.2555, 31.2555, '2017-10-05 00:00:00'),
(3, 2, 8.5241, 76.9366, '2017-10-05 00:00:00'),
(4, 2, -26.2041, 28.0473, '2017-10-05 02:00:00'),
(5, 3, -25.7479, 28.2293, '2017-10-05 05:00:00'),
(6, 3, -28.7282, 24.7499, '2017-10-05 06:00:00'),
(7, 1, -30.2555, 31.2555, '2017-10-09 15:10:27'),
(8, 2, -25.966688, 32.58052, '2017-10-09 15:12:30'),
(14, 63, 8.5241, 76.9366, '2017-10-09 15:15:02'),
(19, 56, -26.2041, 28.0473, '2017-10-09 15:16:43'),
(23, 50, -28.8016, 28.5331, '2017-10-09 15:18:15');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `animals`
--
ALTER TABLE `animals`
  ADD CONSTRAINT `animals_ibfk_1` FOREIGN KEY (`categoryId`) REFERENCES `category` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `gpstracking`
--
ALTER TABLE `gpstracking`
  ADD CONSTRAINT `gpstracking_ibfk_1` FOREIGN KEY (`animalId`) REFERENCES `animals` (`animalId`) ON DELETE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
