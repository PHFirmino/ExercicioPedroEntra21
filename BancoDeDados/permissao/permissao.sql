CREATE SCHEMA vendas;

CREATE USER empregado@localhost IDENTIFIED BY "123456";
GRANT SELECT, INSERT, UPDATE, ALTER ON vendas.tb_produtos TO empregado@localhost;

CREATE USER dba@localhost IDENTIFIED BY "123456";
GRANT ALL ON vendas.tb_produtos TO dba@localhost;

CREATE USER gerente@localhost IDENTIFIED BY "123456";
GRANT ALL ON vendas.tb_produtos TO gerente@localhost;