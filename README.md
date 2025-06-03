# Projeto-ETL
Mini-projeto de ETL para popular o DW

tabelas do banco de dados:

/*
USE ecommerce;

-- Tabela Users (clientes)
CREATE TABLE users (
    user_id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    senha_hash VARCHAR(255) NOT NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabela Produtos
CREATE TABLE produtos (
    produto_id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descricao TEXT,
    preco DECIMAL(10, 2) NOT NULL
);

-- Tabela Pedidos
CREATE TABLE pedidos (
    pedido_id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNSIGNED NOT NULL,
    data_pedido TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(20) DEFAULT 'pendente',
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

-- Tabela Itens_Pedido
CREATE TABLE itens_pedido (
    item_id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    pedido_id INT UNSIGNED NOT NULL,
    produto_id INT UNSIGNED NOT NULL,
    quantidade INT NOT NULL,
    preco_unitario DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (pedido_id) REFERENCES pedidos(pedido_id),
    FOREIGN KEY (produto_id) REFERENCES produtos(produto_id)
);

CREATE DATABASE dw_ecommerce;
USE dw_ecommerce;

CREATE TABLE pedidos_completos (
    pedido_id INT PRIMARY KEY,
    data_pedido TIMESTAMP,
    status VARCHAR(20),
    valor_total DECIMAL(10, 2),
    user_info JSON,
    itens_pedido JSON,
    criado_em TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
*/

