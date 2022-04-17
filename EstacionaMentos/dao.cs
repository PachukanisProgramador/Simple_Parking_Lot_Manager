using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EstacionaMentos
{
    class dao
    {
        MySqlConnection conexao;

        public string nomeTabela;
        public string dados;
        public string resultado;
        public int i;
        public int contador;
        public string msg;
        public int contadorValor;
        public double valorTotal;
        public int[] cod;
        public long[] cpf;
        public string[] nomeFuncionario;
        public string[] nomeMensalista;
        public string[] enderecoFuncionario;
        public string[] enderecoMensalista;
        public string[] telefoneFuncionario;
        public string[] telefoneMensalista;
        public double[] valorMensal;
        public string[] funcao;
        public double[] salario;
        public string[] gerenteLogin;
        public string[] gerenteSenha;
        public string[] fabricanteMensalista;
        public string[] modeloMensalista;
        public string[] placaMensalista;
        public string[] corMensalista;
        public int[] codigoEntradaSaida;
        public string[] nomeCliente;
        public DateTime[] dataHoraEntrada;
        public DateTime[] dataHoraSaida;
        public DateTime[] dataEntrada;
        public DateTime[] horaEntrada;
        public DateTime[] dataSaida;
        public DateTime[] horaSaida;
        public DateTime[] dataDeNascimento;
        public DateTime[] dataPagamento;


        // CONTROLE DE ENTRADA E SAÍDA



        public dao(string nomeBancoDeDados)
        {

            conexao = new MySqlConnection();

            conexao = new MySqlConnection($"server=localhost;DataBase={nomeBancoDeDados};Uid=root;Password=;Convert Zero Datetime=True;"); // Convert Zero DateTime=True é para evitar erros com datas zeradas.

            try
            {
                conexao.Open();
                Console.WriteLine("I'm in!!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro de conexão com o servidor do Banco de Dados:\n\n{e}");
                conexao.Close();

            }// Fim da tentativa de conexão com o banco de dados

            dados = "";
            resultado = "";
            i = 0;
            contador = 0;
            msg = "";
            contadorValor = 0;
            valorTotal = 0;
            nomeTabela = "";

            cod = new int[100];
            cpf = new long[100];
            nomeFuncionario = new string[100];
            nomeMensalista = new string[100];
            telefoneFuncionario = new string[100];
            telefoneMensalista = new string[100];
            enderecoFuncionario = new string[100];
            enderecoMensalista = new string[100];
            valorMensal = new double[100];
            funcao = new string[100];
            salario = new double[100];
            gerenteLogin = new string[100];
            gerenteSenha = new string[100];
            fabricanteMensalista = new string[100];
            modeloMensalista = new string[100];
            placaMensalista = new string[100];
            corMensalista = new string[100];
            codigoEntradaSaida = new int[100];
            nomeCliente = new string[100];
            dataHoraEntrada = new DateTime[100];
            dataHoraSaida = new DateTime[100];
            dataEntrada = new DateTime[100];
            horaEntrada = new DateTime[100];
            dataSaida = new DateTime[100];
            horaSaida = new DateTime[100];
            dataDeNascimento = new DateTime[100];
            dataPagamento = new DateTime[100];


        }// Fim do método construtor

        public string Tabela(string nome)
        {

            nomeTabela = nome;

            return nomeTabela;
        }
        public void InserirFuncionario(string nome, DateTime dataDeNascimento, string telefone, string endereco, string funcao, double salario)
        {
            try
            {

                dados = $"('{dataDeNascimento.ToString("yyyy-MM-dd")}','{telefone}','{endereco}','{funcao}','{salario}','','{nome}')";
                resultado = $"Insert into funcionario(dataDeNascimento, telefone, endereco, funcao, salario, cod, nome) values{dados}";

                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                Console.WriteLine($"{resultado} Linhas afetadas!");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Algo de errado não está certo!\n\n{e}");
            }

        } //Fim do método InserirCliente().

        public void InserirMensalista(long cpf, string nome, string endereco, string telefone, DateTime dataPagamento, double valorMensal)
        {
            try
            {

                dados = $"('{cpf}','{nome}','{endereco}','{telefone}','{dataPagamento.ToString("yyyy-MM-dd")}','{valorMensal}')";
                resultado = $"Insert into mensalista(cpf, nome, endereco, telefone, dataPagamento, valorMensal) values{dados}";

                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery(); 

                Console.WriteLine($"{resultado} Linhas afetadas!");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Algo de errado não está certo!\n\n{e}");
            }
        } //Fim do método InserirCliente().
        




        public void PreencherVetor()
        {

            for (int i = 0; i < 100; i++)
            {
                cod[i] = 0;
                cpf[i] = 0;
                nomeFuncionario[i] = "";
                nomeMensalista[i] = "";
                telefoneFuncionario[i] = "";
                telefoneMensalista[i] = "";
                enderecoFuncionario[i] = "";
                enderecoMensalista[i] = "";
                valorMensal[i] = 0;
                funcao[i] = "";
                salario[i] = 0;
                gerenteLogin[i] = "";
                gerenteSenha[i] = "";
                fabricanteMensalista[i] = "";
                modeloMensalista[i] = "";
                placaMensalista[i] = "";
                corMensalista[i] = "";
                codigoEntradaSaida[i] = 0;
                nomeCliente[i] = "";
                dataHoraEntrada[i] = new DateTime();
                dataHoraSaida[i] = new DateTime();
                dataEntrada[i] = new DateTime();
                horaEntrada[i] = new DateTime();
                dataSaida[i] = new DateTime();
                horaSaida[i] = new DateTime();
                dataPagamento[i] = new DateTime();
                dataDeNascimento[i] = new DateTime();

            }//fim da repeticao if

        }// Fim do método PreencherVetor().





        public void LerDados(string nomeTabela)
        {

            string query = $"select * from {nomeTabela}";

            MySqlCommand coletar = new MySqlCommand(query, conexao);

            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {


                if (nomeTabela == "funcionario")
                {

                    dataDeNascimento[i].ToString("yyyy-MM-dd");

                    cod[i] = Convert.ToInt32(leitura["cod"]);
                    nomeFuncionario[i] = "" + leitura["nome"];
                    dataDeNascimento[i] = DateTime.Parse("" + leitura["dataDeNascimento"]);
                    telefoneFuncionario[i] = "" + leitura["telefone"];
                    enderecoFuncionario[i] = "" + leitura["endereco"];
                    funcao[i] = "" + leitura["funcao"];
                    salario[i] = Convert.ToDouble(leitura["salario"]);
                    gerenteLogin[i] = "" + leitura["loginGerente"];
                    gerenteSenha[i] = "" + leitura["senhaGerente"];

                }
                else
                {
                    if (nomeTabela == "mensalista")
                    {

                        dataPagamento[i].ToString("yyyy-MM-dd");

                        cpf[i] = (long)Convert.ToDouble(leitura["cpf"]);
                        nomeMensalista[i] = "" + leitura["nome"];
                        enderecoMensalista[i] = "" + leitura["endereco"];
                        telefoneMensalista[i] = "" + leitura["telefone"];
                        dataPagamento[i] = DateTime.Parse("" + leitura["dataPagamento"]);
                        valorMensal[i] = Convert.ToDouble(leitura["valorMensal"]);

                        
                        query = $"select * from veiculo";

                        coletar = new MySqlCommand(query, conexao);

                        leitura = coletar.ExecuteReader();

                        i = 0;

                        while (leitura.Read())
                        {

                            fabricanteMensalista[i] = "" + leitura["fabricante"];
                            modeloMensalista[i] = "" + leitura["modelo"];
                            placaMensalista[i] = "" + leitura["placa"];
                            corMensalista[i] = "" + leitura["cor"];

                        }

                    }// Fim do if Mensalista
                    else
                    {
                        if (nomeTabela == "ControleEntradaSaida")
                        {

                            while (leitura.Read())
                            {
                                
                                dataEntrada[i].ToString("yyyy-MM-dd");
                                horaEntrada[i].ToString("HH:mm:ss");
                                dataSaida[i].ToString("yyyy-MM-dd");
                                horaSaida[i].ToString("HH:mm:ss");

                                codigoEntradaSaida[i] = Convert.ToInt32("" + leitura["codigo"]);
                                nomeCliente[i] = "" + leitura["nome"];
                                dataEntrada[i] = Convert.ToDateTime("" + leitura["dataEntrada"]);
                                horaEntrada[i] = Convert.ToDateTime("" + leitura["horaEntrada"]);
                                dataSaida[i] = Convert.ToDateTime("" + leitura["dataSaida"]);
                                horaSaida[i] = Convert.ToDateTime("" + leitura["horaSaida"]);

                            }// Fim do while

                        }// Fim do i do ControleEntradaSaida

                    }// Fim do else

                }// Fim do else

                i++;

                contador++;

            }// Fim do while

            //Fechar o dataReader

            leitura.Close();

        }// Fim do método lerDados()





        // AÇÕES QUE APENAS O GERENTE PODE FAZER

        public void CadastrarEntrada(string nomeCliente)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            DateTime dataEntrada = new DateTime();
            dataEntrada = DateTime.Now;

            DateTime horaEntrada = new DateTime();
            horaEntrada = DateTime.Now;

            string dados = $"('','{nomeCliente}','{dataEntrada.ToString("yyyy-MM-dd")}','{horaEntrada.ToString("HH:mm:ss")}','0000-00-00', '00:00:00')";

            string resultado = $"insert into controleentradasaida (codigo, nome, dataEntrada, horaEntrada, dataSaida, horaSaida) values{dados}";

            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();

            Console.WriteLine($"\n\n{resultado} Linhas afetadas!");
        }





        public string EmitirCodigo(DateTime horaEntradaParamentro)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {

                if (horaEntrada[i].ToString("HH:mm:ss") == horaEntradaParamentro.ToString("HH:mm:ss"))
                {

                    return "Código: " + codigoEntradaSaida[i] + "\n\n";

                }// Fim do if

            }// Fim do for

            return "\nErro!";

        }
        
        
        public string EmitirRecibo(int cod)
        {
            PreencherVetor();
            LerDados(nomeTabela);

            string mensagem;

            for (int i = 0; i < contador; i++)
            {

                if (codigoEntradaSaida[i] == cod)
                {

                    DateTime dataSaidaManipulado = new DateTime();
                    dataSaidaManipulado = DateTime.Now;

                    DateTime horaSaidaManipulado = new DateTime();
                    horaSaidaManipulado = DateTime.Now;

                    string resultado = $"update controleentradasaida set  dataSaida = '{dataSaidaManipulado.ToString("yyyy-MM-dd")}' where codigo = '{codigoEntradaSaida[i]}';";
                    MySqlCommand sql = new MySqlCommand(resultado, conexao);
                    resultado = "" + sql.ExecuteNonQuery();

                    resultado = $"update controleentradasaida set  horaSaida = '{horaSaidaManipulado.ToString("HH:mm:ss")}' where codigo = '{codigoEntradaSaida[i]}'";
                    sql = new MySqlCommand(resultado, conexao);
                    resultado = "" + sql.ExecuteNonQuery();

                    dataSaida[i] = dataSaidaManipulado;
                    horaSaida[i] = horaSaidaManipulado;

                    mensagem = $" | Código {codigoEntradaSaida[i]}" +
                        $" | Nome: {nomeCliente[i]}\n" +
                        $" | Data entrada: {dataEntrada[i].ToShortDateString()}\n" +
                        $" | Hora entrada: {horaEntrada[i].ToString("HH:mm:ss")}\n" +
                        $" | Data saída: {dataSaida[i].ToShortDateString()}\n" +
                        $" | Hora saída: {horaSaida[i].ToString("HH:mm:ss")}\n";

                    return mensagem;

                }// Fim do if

            }// Fim do for

            return "Código não encontrado!";

        }// Fim do método MensagemRecibo()

        public void CadastrarFuncionario(string nomeFuncionario, DateTime dataDeNascimento, string telefoneFuncionario, string enderecoFuncionario, string funcao, double salario)
        {
            PreencherVetor();
            LerDados(nomeTabela);

            try
            {
                dados = $"('','{nomeFuncionario}','{dataDeNascimento.ToString("yyyy-MM-dd")}','{telefoneFuncionario}','{enderecoFuncionario}','{funcao}','{salario}')";
                resultado = $"insert into funcionario values{dados}";

                MySqlCommand sql = new MySqlCommand(resultado, conexao); // Toda vez que eu tenho comando no C# que eu quero que execute no banco de dados eu usarei esse método. Você criou uma variavel de comando inserindo por parametro o comando, no caso a variáel 'resultado' e o banco de dados, no caso a variável 'conexao'
                resultado = "" + sql.ExecuteNonQuery(); // Está pedindo que faça o ctrl + enter do MySQL para executar.

                Console.WriteLine($"{resultado} Linhas afetadas!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Algo de errado não está certo!\n\n{e}");
            }

        }// Fim do método CadastrarFuncionario()

        public void CadastrarMensalista(long documento, string nomeMensalista, string telefoneMensalista, string enderecoMensalista, string fabricanteMensalista, string modeloMensalista, string placaMensalista, string corMensalista, DateTime dataPagamento, double valorMensal)
        {
            PreencherVetor();
            LerDados(nomeTabela);
            try
            {


                dados = $"('{documento}','{nomeMensalista}','{enderecoMensalista}','{telefoneMensalista}','{dataPagamento.ToString("yyyy-MM-dd")}','{valorMensal}')";
                resultado = $"insert into mensalista values{dados}";

                MySqlCommand sql = new MySqlCommand(resultado, conexao); // Toda vez que eu tenho comando no C# que eu quero que execute no banco de dados eu usarei esse método. Você criou uma variavel de comando inserindo por parametro o comando, no caso a variáel 'resultado' e o banco de dados, no caso a variável 'conexao'
                resultado = "" + sql.ExecuteNonQuery(); // Está pedindo que faça o ctrl + enter do MySQL para executar.

                Console.WriteLine($"{resultado} Linhas afetadas!");

                dados = "";
                resultado = "";

                dados = $"('{placaMensalista}','{modeloMensalista}','{corMensalista}','{fabricanteMensalista}')";
                resultado = $"insert into veiculo values{dados}";

                sql = new MySqlCommand(resultado, conexao); // Toda vez que eu tenho comando no C# que eu quero que execute no banco de dados eu usarei esse método. Você criou uma variavel de comando inserindo por parametro o comando, no caso a variáel 'resultado' e o banco de dados, no caso a variável 'conexao'
                resultado = "" + sql.ExecuteNonQuery(); // Está pedindo que faça o ctrl + enter do MySQL para executar.

                Console.WriteLine($"{resultado} Linhas afetadas!");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Algo de errado não está certo!\n\n{e}");
            }

        }// Fim do método CadastrarFuncionario()










        // AÇÕES QUE TODOS PODEM FAZER
        public bool VerificarValoresMensalista(long documento, bool validador)
        {
            PreencherVetor();
            LerDados(nomeTabela);


            for (int i = 0; i < contador; i++)
            {
                if (documento == cpf[i])
                {
                    if (valorMensal[i] == 0)
                    {

                        Console.WriteLine($"\nNão há débitos.\nData de pagamento do mês: {dataPagamento[i].ToShortDateString()}\n\n");
                        validador = true;
                        return validador;

                    }
                    else
                    {
                        if (valorMensal[i] != 0)
                        {
                            Console.WriteLine($"\nDébito do mensalista {nomeMensalista[i]}: {valorMensal[i]:C2}\n\n");
                            validador = true;
                            return validador;
                        }
                        else
                        {
                            Console.WriteLine("Código não encontrado!\n\n");
                            return validador;
                        }
                    }// Fim do if

                }// Fim do if

            }// Fim do for

            return validador;

        }// Fim do método VeriicarValoresMensalista()





        public void RegistrarPagamento(long documento, double valor)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (documento == cpf[i])
                {
                    dataPagamento[i] = DateTime.Today;
                    valorMensal[i] += -valor;

                    resultado = $"update mensalista set valorMensal = '{valorMensal[i]}' where cpf = '{documento}'";

                    MySqlCommand sql = new MySqlCommand(resultado, conexao);
                    resultado = "" + sql.ExecuteNonQuery();

                    resultado = $"update mensalista set dataPagamento = '{dataPagamento[i].ToString("yyyy-MM-dd")}' where cpf = '{documento}'";

                    sql = new MySqlCommand(resultado, conexao);
                    resultado = "" + sql.ExecuteNonQuery();

                }// Fim do if

            }// Fim do for

        }// Fim do método RegistrarPagamento()






        public void ValorTotalMensal(double valor, long documento)
        {
            PreencherVetor();
            LerDados(nomeTabela);

            try
            {
                for (int i = 0; i < contador; i++)
                {

                    if (documento == cpf[i])
                    {
                        valorMensal[i] += valor;

                        resultado = $"update mensalista set valorMensal = '{valorMensal[i]}' where cpf = '{documento}';";

                        MySqlCommand sql = new MySqlCommand(resultado, conexao); // Toda vez que eu tenho comando no C# que eu quero que execute no banco de dados eu usarei esse método. Você criou uma variavel de comando inserindo por parametro o comando, no caso a variáel 'resultado' e o banco de dados, no caso a variável 'conexao'
                        resultado = "" + sql.ExecuteNonQuery(); // Está pedindo que faça o ctrl + enter do MySQL para executar.

                    }// Fim do if

                }// Fim do for

                Console.WriteLine($"{resultado} Linhas afetadas!");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Algo de errado não está certo!\n\n{e}");
            }

        }// Fim do método valorTotalMensal()





        public void ConsultarTudo() // Vai mostrar em tela os dados do banco
        {

            //Preencher o vetor

            PreencherVetor();
            LerDados(nomeTabela);

            if (nomeTabela == "funcionario")
            {

                for (int i = 0; i < contador; i++)
                {
                    Console.WriteLine($"\n | Código: {cod[i]}\n" +
                        $" | Nome: {nomeFuncionario[i]}\n" +
                        $" | Data de Nascimento: {dataDeNascimento[i].ToShortDateString()}\n" +
                        $" | Telefone: {telefoneFuncionario[i]}\n" +
                        $" | Endereço: {enderecoFuncionario[i]}\n" +
                        $" | Função: {funcao[i]}\n" +
                        $" | Salário: {salario[i]}\n\n");

                }// Fim do if

            }
            else
            {
                if (nomeTabela == "mensalista")
                {

                    for (int i = 0; i < contador; i++)
                    {
                        Console.WriteLine($"\nLISTA\n" +
                            $"{i + 1}°\n" +
                            $" | CPF: {cpf[i]}\n" +
                            $" | Nome: {nomeMensalista[i]}\n" +
                            $" | Endereço: {enderecoMensalista[i]}\n" +
                            $" | Telefone: {telefoneMensalista[i]}\n" +
                            $" | Data de Pagamento: {dataPagamento[i].ToShortDateString()}\n" +
                            $" | Débito Mensal: {valorMensal[i]:C2}\n" +
                            $" | Placa do veículo: {placaMensalista[i]}\n" +
                            $" | Cor do veículo: {corMensalista[i]}\n" +
                            $" | Fabricante do veículo: {fabricanteMensalista[i]}\n" +
                            $" | Modelo do veículo: {modeloMensalista[i]}\n\n");

                    }// Fim do if

                }
            }


        }//Fim do método ConsultarTudo()




        public string ConsultarNome(int codigo, long documento)
        {
            PreencherVetor();
            LerDados(nomeTabela);

            if (nomeTabela == "funcionario")
            {
                for (int i = 0; i < contador; i++)
                {

                    if (codigo == cod[i])
                    {
                        return nomeFuncionario[i];
                    }// Fim do if

                }// Fim do for

                return "Código não encontrado!";
            }
            else
            {
                if (nomeTabela == "mensalista")
                {

                }
                for (int i = 0; i < contador; i++)
                {

                    if (documento == cpf[i])
                    {
                        return nomeMensalista[i];
                    }// Fim do if

                }// Fim do for

                return "Código não encontrado!";

            }// Fim do if

        }// Fim do método ConsultarNome




        public string ConsultarTelefone(int codigo, long documento)
        {
            PreencherVetor();
            LerDados(nomeTabela);


            if (nomeTabela == "funcionario")
            {
                for (int i = 0; i < contador; i++)
                {

                    if (codigo == cod[i])
                    {
                        return telefoneFuncionario[i];
                    }// Fim do if

                }// Fim do for

                return "Código não encontrado!";
            }
            else
            {
                if (nomeTabela == "mensalista")
                {

                }
                for (int i = 0; i < contador; i++)
                {

                    if (documento == cpf[i])
                    {
                        return telefoneMensalista[i];
                    }// Fim do if

                }// Fim do for

                return "Código não encontrado!";

            }// Fim do if
        }// Fim do método ConsultarTelefone




        public string ConsultarEndereco(int codigo, long documento)
        {
            PreencherVetor();
            LerDados(nomeTabela);

            if (nomeTabela == "funcionario")
            {
                for (int i = 0; i < contador; i++)
                {

                    if (codigo == cod[i])
                    {
                        return enderecoFuncionario[i];
                    }// Fim do if

                }// Fim do for
            }
            else
            {
                if (nomeTabela == "mensalista")
                {
                    for (int i = 0; i < contador; i++)
                    {

                        if (documento == cpf[i])
                        {
                            return enderecoMensalista[i];
                        }// Fim do if

                    }// Fim do for
                }
            }

            return "Código não encontrado!";
        }// Fim do método ConsultarEndereco




        public string ConsultarLoginGerente(int codigo)
        {
            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {

                if (codigo == cod[i])
                {
                    return gerenteLogin[i];
                }// Fim do if

            }// Fim do for

            return "Código não encontrado!";
        }// Fim do método ConsultarLogin

        public string ConsultarSenhaGerente(int codigo)
        {
            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {

                if (codigo == cod[i])
                {
                    return gerenteSenha[i];
                }// Fim do if

            }// Fim do for 

            return "Código não encontrado!";

        }// Fim do método ConsultarSenha






        //ATUALIZAR

        public void Atualizar(string campo, string novoDado, int codigo, long documento)
        {

            try
            {
                if (nomeTabela == "funcionario")
                {
                    for (int i = 0; i < contador; i++)
                    {

                        if (codigo == cod[i])
                        {
                            resultado = $"update funcionario set {campo} = '{novoDado}' where cod = '{codigo}'";

                            MySqlCommand sql = new MySqlCommand(resultado, conexao);

                            resultado = "" + sql.ExecuteNonQuery();

                            Console.WriteLine($"{campo} atualizado com sucesso!");

                        }// Fim do if

                    }// Fim do for
                }
                else
                {
                    if (nomeTabela == "mensalista")
                    {
                        for (int i = 0; i < contador; i++)
                        {

                            if (documento == cpf[i])
                            {
                                resultado = $"update mensalista set {campo} = '{novoDado}' where cpf = '{documento}'";

                                MySqlCommand sql = new MySqlCommand(resultado, conexao);

                                resultado = "" + sql.ExecuteNonQuery();

                                Console.WriteLine($"{campo} atualizado com sucesso!");

                            }// Fim do if

                        }// Fim do for
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine($"Algo de errado não está certo!\n\n{e}");

            }// Fim do try

        }// Fim do método Atualizar()

        public void AtualizarVeiculo(string campo, string novoDado, int codigo, string placa)
        {

            try
            {
                resultado = $"update veiculo set {campo} = '{novoDado}' where placa = '{placa}'";

                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                Console.WriteLine($"{campo} atualizado com sucesso");
            }
            catch (Exception e)
            {

                Console.WriteLine($"Algo de errado não está certo!\n\n{e}");

            }

        }






        // EXCLUIR
        public void Excluir(int codigo, long documento)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            try
            {
                if (nomeTabela == "funcionario")
                {
                    for (int i = 0; i < contador; i++)
                    {

                        if (codigo == cod[i])
                        {
                            resultado = $"delete from funcionario where cod = '{codigo}'";

                            MySqlCommand sql = new MySqlCommand(resultado, conexao);

                            resultado = "" + sql.ExecuteNonQuery();

                            Console.WriteLine("\n\nConta excluída com sucesso!");

                        }// Fim do if

                    }// Fim do for
                }
                else
                {
                    if (nomeTabela == "mensalista")
                    {
                        for (int i = 0; i < contador; i++)
                        {

                            if (documento == cpf[i])
                            {
                                resultado = $"delete from mensalista where cpf = '{documento}'";

                                MySqlCommand sql = new MySqlCommand(resultado, conexao);

                                resultado = "" + sql.ExecuteNonQuery();

                                Console.WriteLine("\n\nConta excluída com sucesso!");

                            }// Fim do if

                        }// Fim do for
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine($"Algo de errado não está certo!\n\n{e}");

            }

        }// Fim do método Excluir().











        // CONSULTAR DO MENSALISTA
        public string ConsultarFabricanteCarro(long documento)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (documento == cpf[i])
                {
                    return fabricanteMensalista[i];
                }
            }

            return "Código não encontrado!";

        }// Fim do método ConsultarFabricanteCarro()





        public string ConsultarModeloCarro(long documento)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (documento == cpf[i])
                {
                    return modeloMensalista[i];
                }
            }

            return "Código não encontrado!";

        }// Fim do método ConsultarModeloCarro()





        public string ConsultarPlacaCarro(long documento)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (documento == cpf[i])
                {
                    return placaMensalista[i];
                }
            }

            return "Código não encontrado!";

        }// Fim do método ConsultarPlacaCarro()





        public string ConsultarCorCarro(long documento)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (documento == cpf[i])
                {
                    return corMensalista[i];
                }
            }

            return "Código não encontrado!";

        }// Fim do método ConsultarCorCarro()





        public string ConsultarDataDePagamento(long documento)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (documento == cpf[i])
                {
                    return "" + dataPagamento[i].ToString("dd/MM/yyyy");
                }
            }

            return "Código não encontrado!";

        }// Fim do método ConsultarDataDePagamento()





        public string ConsultarValorMensal(long documento)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (documento == cpf[i])
                {
                    return "" + valorMensal[i];
                }
            }

            return "Código não encontrado!";

        }// Fim do método ConsultarValorMensal()










        //CONSULTAR DO FUNCIONARIO

        public string ConsultarDataDeNascimento(int codigo)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return "" + dataDeNascimento[i].ToString("dd/MM/yyyy"); ;
                }
            }

            return "Código não encontrado!";

        }// Fim do método ConsultarDataDeNascimento()





        public string ConsultarSalario(int codigo)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return "" + salario[i];
                }
            }

            return "Código não encontrado!";

        }// Fim do método ConsultarSalario()





        public string ConsultarCargo(int codigo)
        {

            PreencherVetor();
            LerDados(nomeTabela);

            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return funcao[i];
                }
            }

            return "Código não encontrado!";

        }// Fim do método ConsultarCargo()

    }//Fim da Classe dao


}// Fim do namespace EstacionaMentos
