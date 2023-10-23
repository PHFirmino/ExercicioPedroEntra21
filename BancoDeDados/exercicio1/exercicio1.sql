CREATE TABLE tb_contatos(
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(20) NOT NULL,
    email VARCHAR(20) NOT NULL,
    telefone VARCHAR(20) NOT NULL
);

INSERT INTO tb_contatos (nome, email, telefone) VALUES 
("Breno", "breno@gmail.com", "98898545"),
("Sidney", "sidney@gmail.com", "986756756"),
("Felipe", "felipe@gmail.com", "984535354");

CREATE TABLE tb_locais (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(45) NOT NULL,
    rua VARCHAR(45) NOT NULL,
    numero VARCHAR(14) NOT NULL
);

INSERT INTO tb_locais(nome, rua, numero) VALUES 
("Arena", "Rua Goiás", "88"),
("Biblioteca", "Rua 7 de Setembro", "11"),
("Academia", "Rua Amazonas", "44");


CREATE TABLE tb_compromissos(
	id INT PRIMARY KEY AUTO_INCREMENT,
    descricao VARCHAR(30) NOT NULL,
    dta DATE NOT NULL,
    hora TIME NOT NULL,
    
    id_local INT NOT NULL,
    
    FOREIGN KEY (id_local) REFERENCES tb_locais(id)
);

INSERT INTO tb_compromissos(descricao, dta, hora, id_local) VALUES 
("Jogar", "2023-10-02", "00:00:00", 1),
("Ler", "2023-08-01", "13:00:00", 2),
("Correr", "2023-06-04", "15:00:00", 3);

CREATE TABLE tb_compromissos_contatos(
	id INT PRIMARY KEY AUTO_INCREMENT,
    
    id_contato INT NOT NULL,
    id_compromisso INT NOT NULL,

    FOREIGN KEY (id_contato) REFERENCES tb_contatos(id),
    FOREIGN KEY (id_compromisso) REFERENCES tb_compromissos(id)
);

INSERT INTO tb_compromissos_contatos(id_contato, id_compromisso) VALUES 
(1, 1),
(2, 2),
(3, 3);