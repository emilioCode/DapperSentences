CREATE DATABASE dbdirectorio;

CREATE TABLE contacto(
	id int IDENTITY(1,1) NOT NULL,
	nombre varchar(100) NOT NULL,
	telefono varchar(20) NULL,
	celular varchar(20) NULL,
	correo varchar(40) NULL,
	direccion varchar(max) NULL,
	comentario varchar(max) NULL,
	foto image NULL);