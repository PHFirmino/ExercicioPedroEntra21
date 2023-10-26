CREATE TABLE tb_categorias(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nome VARCHAR(25) NOT NULL
);	

INSERT INTO tb_categorias(nome) VALUES
("Carnes"),
("Frutas"),
("Açúcares");

CREATE TABLE tb_fornecedores(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nome VARCHAR(20) NOT NULL	
);

INSERT INTO tb_fornecedores(nome) VALUES
("Fruits"),
("Friboi"),
("Dori");

CREATE TABLE tb_produtos(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nome VARCHAR(25) NOT NULL,
    quantidade INT NOT NULL,
    
	id_categoria INT NOT NULL,
    id_fornecedor INT NOT NULL,

	FOREIGN KEY (id_categoria) REFERENCES tb_categorias(id),
	FOREIGN KEY (id_fornecedor) REFERENCES tb_fornecedores(id)
);

INSERT INTO tb_produtos(nome, quantidade, id_categoria, id_fornecedor) VALUES
("Carne Moída", 10, 1, 2),
("Banana", 8, 2, 1),
("Bala", 7, 3, 3);

CREATE TABLE tb_metodos_compras(
	id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(20) NOT NULL
);

INSERT INTO tb_metodos_compras(nome) VALUES
("Pix"),
("Cartão");

CREATE TABLE tb_compras_produtos (
	id INT PRIMARY KEY AUTO_INCREMENT,
	
	id_produto INT NOT NULL,
    id_metodo_compra INT NOT NULL,
    quantidade INT NOT NULL,
	preco_produto DOUBLE NOT NULL,
    vezes_parcela INT,

	FOREIGN KEY (id_produto) REFERENCES tb_produtos(id),
    FOREIGN KEY (id_metodo_compra) REFERENCES tb_metodos_compras(id)
);	

INSERT INTO tb_compras_produtos(id_produto, id_metodo_compra, quantidade, preco_produto, vezes_parcela) VALUES
(1, 2, 5, 12.5, 2),
(2, 1, 4, 5.5, 0),
(3, 1, 8, 1, 0);

CREATE TABLE tb_clientes(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nome VARCHAR(20) NOT NULL
);

INSERT INTO tb_clientes(nome) VALUES
("Felipe"),
("Breno"),
("Sidney");

CREATE TABLE tb_metodos_vendas(
	id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(20)
);

INSERT INTO tb_metodos_vendas(nome) VALUES
("À Vista"),
("Cartão");

CREATE TABLE tb_vendas_clientes(
	id INT PRIMARY KEY AUTO_INCREMENT,
    
    id_cliente INT NOT NULL,
    id_venda_produto INT NOT NULL,
    id_metodo_venda INT NOT NULL,
	quantidade INT NOT NULL,
	preco_produto DOUBLE NOT NULL,
    vezes_parcela INT,
    
    FOREIGN KEY (id_metodo_venda) REFERENCES tb_metodos_vendas(id),
    FOREIGN KEY (id_cliente) REFERENCES tb_clientes(id),
    FOREIGN KEY (id_venda_produto) REFERENCES tb_produtos(id)
);

INSERT INTO tb_vendas_clientes(id_cliente, id_venda_produto, quantidade, preco_produto, id_metodo_venda, vezes_parcela) VALUES
(2, 2, 2, 8, 1, 0),
(3, 1, 2, 15, 2, 2),
(1, 3, 4, 2, 1, 0);