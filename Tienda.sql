-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.28 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para tienda
CREATE DATABASE IF NOT EXISTS `tienda` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tienda`;

-- Volcando estructura para tabla tienda.producto
CREATE TABLE IF NOT EXISTS `producto` (
  `idproducto` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(125) DEFAULT NULL,
  `descripcion` text,
  `precio` decimal(65,2) DEFAULT NULL,
  PRIMARY KEY (`idproducto`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla tienda.producto: ~1 rows (aproximadamente)
DELETE FROM `producto`;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` (`idproducto`, `nombre`, `descripcion`, `precio`) VALUES
	(1, 'Jitomate', 'Fruta de color rojo', 35.50),
	(2, 'Huevo', 'Huevo de gallina de granja', 22.00),
	(4, 'Aceite 123', 'Aceite de cocina', 48.50);
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;

-- Volcando estructura para procedimiento tienda.p_Productos
DELIMITER //
CREATE PROCEDURE `p_Productos`(
IN p_idproducto INT,
IN p_nombre VARCHAR(255),
IN p_descripcion TEXT,
IN p_precio DECIMAL(65,2),
IN p_opcion INT
)
BEGIN
	CASE p_opcion
		when 1 then 
			INSERT INTO Producto(nombre,descripcion,precio)
			VALUES(p_nombre,p_descripcion,p_precio);
		when 2 then
			UPDATE producto
			SET nombre=p_nombre,
			descripcion=p_descripcion, precio=p_precio
			WHERE idproducto=p_idproducto;
		when 3 then
			DELETE FROM producto
			WHERE idproducto=p_idproducto;
	END case;
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
