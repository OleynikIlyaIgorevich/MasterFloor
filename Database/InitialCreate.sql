DROP DATABASE IF EXISTS master_floor;
CREATE DATABASE master_floor;
USE master_floor;

CREATE TABLE partner_types(
	id int primary key auto_increment,
    title varchar(32) NOT NULL UNIQUE
);

CREATE TABLE material_types(
	id int primary key auto_increment,
    title varchar(32) NOT NULL UNIQUE,
    rejection_rate decimal(5, 2) NOT NULL
);

CREATE TABLE product_types(
	id int primary key auto_increment,
    title varchar(32) NOT NULL UNIQUE,
    product_type_factor decimal(5, 2) NOT NULL
);

CREATE TABLE partners(
	id int primary key auto_increment,
	partner_type_id int NOT NULL,
    title varchar(32) NOT NULL UNIQUE,
    director_lastname varchar(64) NOT NULL,
    director_firstname varchar(64) NOT NULL,
    director_middlename varchar(64), 
    email varchar(128) UNIQUE NOT NULL,
    phone varchar(32) UNIQUE NOT NULL,
    address varchar(256) unique NOT NULL, 
    inn varchar(32) UNIQUE NOT NULL,
    rate int NOT NULL DEFAULT 0,
    FOREIGN KEY (partner_type_id) REFERENCES partner_types(id)
);

CREATE TABLE products(
	id int primary key auto_increment,
    product_type_id int NOT NULL,
    title varchar(128) NOT NULL UNIQUE, 
    articul varchar(32) NOT NULL UNIQUE,
    minimal_price decimal NOT NULL,
	FOREIGN KEY (product_type_id) REFERENCES product_types(id)
);


CREATE TABLE partner_products(
	id int primary key auto_increment,
	product_id int NOT NULL,
    partner_id int NOT NULL,
    sell_price decimal NOT NULL,
    sell_at date NOT NULL,
    FOREIGN KEY (product_id) references products(id),
    FOREIGN KEY (partner_id) references partners(id)
);
