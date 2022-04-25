create database EstacionaMentos;
use EstacionaMentos;

create table Cliente(
CPF bigint(11) primary key not null,
nome VARCHAR(100) not null,
dataDeNascimento DATE,
telefone VARCHAR(15) not null,
valor DECIMAL(10,2) not null
)Engine = InnoDB;

create table Veiculo(
placa VARCHAR(9) primary key not null,
modelo VARCHAR(45) not null,
cor VARCHAR(45) not null,
fabricante VARCHAR(45) not null
)Engine = InnoDB;

create table ControleEntradaSaida(
codigo int not null auto_increment primary key,
nome varchar(150) not null,
dataEntrada date not null,
horaEntrada time not null,
dataSaida date not null,
horaSaida time not null
)Engine = InnoDB;

create table Funcionario(
cod int primary key auto_increment not null,
nome varchar(150) not null,
dataDeNascimento date not null,
telefone varchar(15) not null,
endereco varchar(150) not null,
funcao varchar(45) not null,
salario decimal(10,2) not null
)Engine = InnoDB;

create table Mensalista(
cpf bigint(11) auto_increment primary key not null,
nome varchar(150) not null,
endereco varchar(150) not null,
telefone varchar(15) not null,
dataPagamento date not null,
valorMensal decimal(10,2)
)Engine = InnoDB;
