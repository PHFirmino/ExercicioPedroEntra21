CREATE TABLE tb_categorias(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nome VARCHAR(25) NOT NULL
);	

INSERT INTO tb_categorias(nome) VALUES
("Carnes"),
("Frutas"),
("Açúcares");

CREATE TABLE tb_produtos(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nome VARCHAR(25) NOT NULL,
    quantidade INT NOT NULL,
    
	id_categoria INT NOT NULL,

	FOREIGN KEY (id_categoria) REFERENCES tb_categorias(id)
);

INSERT INTO tb_produtos(nome,quantidade, id_categoria) VALUES
("Carne Moída", 3, 1),
("Banana", 2, 2),
("Bala", 4, 3);

CREATE TABLE tb_fornecedores(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nome VARCHAR(20) NOT NULL	
);

INSERT INTO tb_fornecedores(nome) VALUES
("Fruits"),
("Friboi"),
("Dori");
		
CREATE TABLE tb_compras_produtos(
	id INT PRIMARY KEY AUTO_INCREMENT,
		
	id_produto INT NOT NULL,
	id_fornecedor INT NOT NULL,
    preco_produto INT NOT NULL,
    quantidade INT NOT NULL,
    
	FOREIGN KEY (id_produto) REFERENCES tb_produtos(id),
	FOREIGN KEY (id_fornecedor) REFERENCES tb_fornecedores(id)
);	

INSERT INTO tb_compras_produtos(id_produto, id_fornecedor, preco_produto, quantidade) VALUES
(1, 2, 10, 3),
(2, 1, 2, 3),
(3, 3, 1, 3);

CREATE TABLE tb_clientes(
	id INT PRIMARY KEY AUTO_INCREMENT,
	nome VARCHAR(20) NOT NULL
);

INSERT INTO tb_clientes(nome) VALUES
("Felipe"),
("Breno"),
("Sidney");


CREATE TABLE tb_vendas_clientes(
	id INT PRIMARY KEY AUTO_INCREMENT,
    
    id_cliente INT NOT NULL,
    id_venda_produto INT NOT NULL,
	quantidade INT NOT NULL,
    preco_produto INT NOT NULL,
    
    FOREIGN KEY (id_cliente) REFERENCES tb_clientes(id),
    FOREIGN KEY (id_venda_produto) REFERENCES tb_produtos(id)
);

INSERT INTO tb_vendas_clientes(id_cliente, id_venda_produto, quantidade, preco_produto) VALUES
(2, 2, 2, 4),
(3, 1, 3, 15),
(1, 3, 3, 2);