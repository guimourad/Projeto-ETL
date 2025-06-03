# Projeto-ETL
Mini-projeto de ETL para popular o DW

-- Criar banco de dados
CREATE DATABASE IF NOT EXISTS ecommerce;
USE ecommerce;

-- Tabela de contas de usuários
CREATE TABLE IF NOT EXISTS Contas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    SenhaHash VARCHAR(255) NOT NULL,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de logins
CREATE TABLE IF NOT EXISTS Logins (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
    DataLogin DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de pedidos faturados
CREATE TABLE IF NOT EXISTS Pedidos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    EmailCliente VARCHAR(100) NOT NULL,
    ValorTotal DECIMAL(10,2) NOT NULL,
    Itens JSON NOT NULL,
    DataFaturamento DATETIME DEFAULT CURRENT_TIMESTAMP
);
