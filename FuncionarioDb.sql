create database FuncionarioDb;
use FuncionarioDb;
SET GLOBAL validate_password.policy = LOW;
SET GLOBAL validate_password.length = 8;
CREATE USER 'FuncionarioDb'@'localhost' IDENTIFIED BY '12345678';
GRANT ALL PRIVILEGES ON teds.* TO 'FuncionarioDb'@'localhost';
FLUSH PRIVILEGES;