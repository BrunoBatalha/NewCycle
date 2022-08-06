

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Posts` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Content` longtext CHARACTER SET utf8mb4 NOT NULL,
    `UserName` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Url` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ReactionsQuantity` int NOT NULL,
    `CommentsQuantity` int NOT NULL,
    CONSTRAINT `PK_Posts` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220717163453_InitialCreation', '6.0.7');

COMMIT;

START TRANSACTION;

ALTER TABLE `Posts` MODIFY COLUMN `Content` text CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220728163929_ChangeTypes', '6.0.7');

COMMIT;

START TRANSACTION;

ALTER TABLE `Posts` MODIFY COLUMN `Id` varchar(50) CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220728165919_ChangeTypeIdPost', '6.0.7');

COMMIT;


