-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 19 May 2022, 01:29:29
-- Sunucu sürümü: 10.4.24-MariaDB
-- PHP Sürümü: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `canliebatvdb`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admintable`
--

CREATE TABLE `admintable` (
  `id` int(11) NOT NULL,
  `User_Name` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Password` varchar(255) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `admintable`
--

INSERT INTO `admintable` (`id`, `User_Name`, `Password`) VALUES
(1, 'admin', '21232f297a57a5a743894a0e4a801fc3');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `canliebatvtable`
--

CREATE TABLE `canliebatvtable` (
  `id` int(11) NOT NULL,
  `User_Name` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Password` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Email` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Sinif` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Banned` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Reset_ID` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Olay_ID` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Kayit_Tarih` varchar(255) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sikayettable`
--

CREATE TABLE `sikayettable` (
  `id` int(11) NOT NULL,
  `User_Name` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Sikayetci_User_Name` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `Sikayet_Neden` text COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admintable`
--
ALTER TABLE `admintable`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `canliebatvtable`
--
ALTER TABLE `canliebatvtable`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `User_Name` (`User_Name`,`Email`);

--
-- Tablo için indeksler `sikayettable`
--
ALTER TABLE `sikayettable`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `admintable`
--
ALTER TABLE `admintable`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `canliebatvtable`
--
ALTER TABLE `canliebatvtable`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `sikayettable`
--
ALTER TABLE `sikayettable`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
