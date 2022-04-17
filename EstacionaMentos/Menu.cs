using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionaMentos
{
    class Menu
    {
        dao dao;
        public int opcao;
        public int codigo;
        public Menu()
        {

            dao = new dao("EstacionaMentos");
            opcao = 0;

        }// Fim do método construtor;





        public void Executar()
        {
            MostrarOpcoes();

            do
            {
                switch (opcao)
                {
                    case 0:

                        Console.Clear();
                        Console.WriteLine("Obrigado!");
                        break;

                    case 1:

                        dao.Tabela("ControleEntradaSaida");

                        ExecutarControleDeEntradaESaida();

                        break;

                    case 2:

                        dao.Tabela("mensalista");

                        Console.Clear();

                        ExecutarMensalista();

                        break;

                    case 3:

                        dao.Tabela("funcionario");

                        Console.Clear();

                        VerificarAcessoFuncionario();

                        break;

                    default:

                        Console.WriteLine("Digite uma opção válida!");

                        break;

                }// Fim do switch

            } while (opcao != 0); // Fim do do

        }// Fim do méteodo Executar()





        public void MostrarOpcoes()
        {
            Console.WriteLine("Selecione uma das opções abaixo\n\n" +
                "1. Controle de Entrada e Saída\n" +
                "2. Mensalista \n" +
                "3. Funcionário\n" +
                "0.Sair");

            opcao = Convert.ToInt32(Console.ReadLine());

        }// Fim do método MostrarOpcoes()





        public void VerificarAcessoFuncionario()
        {

            do
            {

                Console.WriteLine("Você é gerente ou funcionário?\n\n1.Gerente;\n2.Funcionario\n0.Voltar\n");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:

                        Console.Clear();

                        Executar();

                        break;

                    case 1:

                        dao.PreencherVetor();
                        dao.LerDados(dao.nomeTabela);

                        bool validador = false;

                        do
                        {

                            Console.WriteLine("\n\nInsira o seu login de gerente:");
                            string loginGerente = Console.ReadLine();

                            Console.WriteLine("Insira a sua senha de gerente:");
                            string senhaGerente = Console.ReadLine();


                            for (int i = 0; i < dao.contador; i++)
                            {
                                if (loginGerente == dao.gerenteLogin[i] & senhaGerente == dao.gerenteSenha[i])
                                {

                                    Console.Clear();

                                    ExecutarGerente();

                                    validador = true;
                                }
                            }
                        } while (validador == false);

                        break;

                    case 2:

                        Console.Clear();
                        Console.WriteLine("Acesso permitido somente a gerentes. Você foi redirecionado para a tela principal.\n\n");

                        Executar();

                        break;
                    default:

                        Console.WriteLine("Valor incorreto! Digite um valor entre entre 0 e 2.");
                        break;
                }

            } while (opcao != 0);

        }// Fim do método VerificarAcessoFuncionario()










        // MÉTODOS QUE PODEM SER FEITOS DENTRO DE CADA ESCOLHA

        public void CadastrarFuncionario()
        {
            Console.WriteLine("\nInsira o nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira a data de nascimento");
            DateTime dataDeNascimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("\nInsira o telefone:");
            string telefone = Console.ReadLine();

            Console.WriteLine("\nInsira o endereço:");
            string endereco = Console.ReadLine();

            Console.WriteLine("\nInsira a função:");
            string funcao = Console.ReadLine();

            Console.WriteLine("\nInsira o salário:");
            double salario = Convert.ToDouble(Console.ReadLine());

            dao.InserirFuncionario(nome, dataDeNascimento, telefone, endereco, funcao, salario);
        }





        public void CadastrarMensalista()
        {
            Console.WriteLine("Insira o CPF : ");
            long documento = (long)Convert.ToDouble(Console.ReadLine());



            Console.WriteLine("Insira o Nome do Mensalista: ");
            string nome = Console.ReadLine();



            Console.WriteLine("Insira o Telefone do Mensalista: ");
            string telefone = Console.ReadLine();



            Console.WriteLine("Insira o Endereço do Mensalista: ");
            string endereco = Console.ReadLine();



            Console.WriteLine("Insira a Fabricante do Carro:");
            string fabricante = Console.ReadLine();



            Console.WriteLine("Insira o Modelo do Carro do Mensalista! :");
            string modelo = Console.ReadLine();



            Console.WriteLine("Insira a Placa do Carro do Mensalista :");
            string placa = Console.ReadLine();



            Console.WriteLine("Insira a Cor do Carro :");
            string cor = Console.ReadLine();



            Console.WriteLine("Insira a Data de Pagamento :");
            DateTime dataPagamento = Convert.ToDateTime(Console.ReadLine());



            Console.WriteLine("Insira o Valor Mensal :");
            double valorMensal = Convert.ToDouble(Console.ReadLine());



            dao.CadastrarMensalista(documento, nome, telefone, endereco, fabricante, modelo, placa, cor, dataPagamento, valorMensal);

        }





        public void ConsultarTudo()
        {
            long documento = 0;
            int codigo = 0;

            Console.WriteLine("Quer consultar um funcionário ou um mensalista?\n1. Funcionario\n2.Mensalista\n");
            opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Informe o cpf que deseja consultar:\n");
                codigo = Convert.ToInt32(Console.ReadLine());

                documento = 0;

                Console.WriteLine($"Nome:{dao.ConsultarNome(codigo, documento)}\n" +
                   $"\nEndereço:{dao.ConsultarEndereco(codigo, documento)}\nTelefone:{dao.ConsultarTelefone(codigo, documento)}");
            }
            else
            {
                if (opcao == 2)
                {
                    Console.WriteLine("Informe o código que deseja consultar:\n");
                    documento = (long)Convert.ToDouble(Console.ReadLine());

                    codigo = 0;

                    Console.WriteLine($"Nome:{dao.ConsultarNome(codigo, documento)}\n" +
                        $"Endereço:{dao.ConsultarEndereco(codigo, documento)}\nTelefone:{dao.ConsultarTelefone(codigo, documento)}");

                }
            }
        }





        public void Excluir()
        {
            long documento = 0;
            int codigo = 0;

            do
            {

                Console.WriteLine("Quer excluir um funcionário ou um mensalista?\n1.Funcionário\n2.Mensalista\n0.Voltar\n\n");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:

                        if (dao.nomeTabela == "funcionario")
                        {
                            ExecutarGerente();
                        }
                        else
                        {
                            ExecutarMensalista();
                        }

                        break;

                    case 1:

                        bool verificador = false;

                        do
                        {

                            Console.WriteLine("\n\nDigite o seu login de gerente:");
                            string login = Console.ReadLine();

                            Console.WriteLine("\nDigite a sua senha de gerente:");
                            string senha = Console.ReadLine();

                            dao.PreencherVetor();
                            dao.LerDados("funcionario");

                            for (int i = 0; i < dao.contador; i++)
                            {
                                if (login == dao.gerenteLogin[i] & senha == dao.gerenteSenha[i])
                                {
                                    Console.WriteLine("\nInforme o código que deseja excluir:\n");
                                    codigo = Convert.ToInt32(Console.ReadLine());

                                    dao.Excluir(codigo, documento);
                                }
                                else
                                {
                                    Console.WriteLine("\n\nLogin ou senha incorretos!\n\n");
                                }
                            }

                        } while (verificador == false);

                        break;

                    case 2:

                        dao.PreencherVetor();
                        dao.LerDados("mensalista");

                        Console.WriteLine("Informe o cpf que deseja excluir:\n");
                        documento = (long)Convert.ToDouble(Console.ReadLine());

                        dao.Excluir(codigo, documento);

                        break;

                    default:

                        Console.WriteLine("Digite uma opção válida!\n\n");

                        break;
                }

            } while (opcao != 0);

        }// Fim do método Excluir()





        public void AtualizarMensalista()
        {
            int codigo = 0;

            Console.WriteLine("Informe o campo que deseja atualizar:\n");
            string campo = Console.ReadLine();

            Console.WriteLine("Informe o novo dado para registro:\n");
            string novoDado = Console.ReadLine();


            if (campo == "cor" | campo == "placa" | campo == "modelo" | campo == "fabricante")
            {

                Console.WriteLine("Informe a placa do veículo que deseja atualizar:");
                string placa = Console.ReadLine();

                dao.AtualizarVeiculo(campo, novoDado, codigo, placa);

            }
            else
            {

                Console.WriteLine("Informe o CPF que deseja atualizar:\n");
                long documento = (long)Convert.ToDouble(Console.ReadLine());

                dao.Atualizar(campo, novoDado, codigo, documento);
            }

        }// Fim do método AtualizarMensalita()





        public void AtualizarFuncionario()
        {
            Console.WriteLine("Informe o campo que deseja atualizar:\n");
            string campo = Console.ReadLine();

            Console.WriteLine("Informe o novo dado para registro:\n");
            string novoDado = Console.ReadLine();

            Console.WriteLine("Informa o código que deseja atualizar:\n");
            int codigo = Convert.ToInt32(Console.ReadLine());

            long documento = 0;


            dao.Atualizar(campo, novoDado, codigo, documento);
        }// Fim do método AtualizarFuncionario()





        public void AdicionarFaturaMensalista()
        {
            Console.WriteLine("Insira o CPF do mensalista para adicionar o valor da diária:");
            long documento = (long)Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Insira o valor da diária:");
            double valorDiaria = Convert.ToDouble(Console.ReadLine());

            dao.ValorTotalMensal(valorDiaria, documento);

        }// Fim do método AdicionarFaturaMensalista









        // MENU DE OPÇÕES DO GERENTE

        public void ExecutarGerente()
        {

            do
            {

                Console.WriteLine("\n\nSelecione uma das opções abaixo\n\n1.Cadastrar Funcionário\n2.Consultar tudo\n3.Consultar individual\n4.Atualizar Funcionario\n5.Excluir\n0.Sair");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:

                        Console.Clear();

                        break;

                    case 1:

                        Console.Clear();

                        CadastrarFuncionario();

                        break;

                    case 2:

                        Console.Clear();

                        dao.ConsultarTudo();

                        break;

                    case 3:

                        Console.Clear();

                        bool validador = false;

                        do
                        {

                            Console.WriteLine($"Insira o código do mensalista:");
                            int codigo = Convert.ToInt32(Console.ReadLine());

                            long documento = 0;

                            for (int i = 0; i < dao.contador; i++)
                            {
                                if (codigo == dao.cod[i])
                                {
                                    Console.WriteLine($" | Nome: {dao.ConsultarNome(codigo, documento)} | Data de Nascimento: {dao.ConsultarDataDeNascimento(codigo)} | Telefone: {dao.ConsultarTelefone(codigo, documento)} | Endereço: {dao.ConsultarEndereco(codigo, documento)}\n" +
                                        $" | Salário: {dao.ConsultarSalario(codigo)} | Cargo: {dao.ConsultarCargo(codigo)}\n\n");
                                    validador = true;
                                }
                            }




                        } while (validador == false);

                        break;

                    case 4:

                        Console.Clear();

                        AtualizarFuncionario();

                        break;

                    case 5:

                        Console.Clear();

                        Excluir();

                        break;

                    case 6:

                        Console.Clear();

                        validador = false;

                        do
                        {

                            Console.WriteLine("Insira o código do gerente:");

                            codigo = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < dao.contador; i++)
                            {
                                if (codigo == dao.cod[i])
                                {

                                    Console.WriteLine($"Login: {dao.ConsultarLoginGerente(codigo)} | Senha: {dao.ConsultarSenhaGerente(codigo)}\n\n");
                                    validador = true;

                                }// Fim do if
                            }// Fim do for

                        } while (validador == false); //Fim do while

                        break;


                    default:

                        Console.Clear();

                        Console.WriteLine("Valor digitado não é válido!");
                        break;

                }// Fim do switch

            } while (opcao != 0);// Fim do while

            Executar();

        }// Fim do método ExecutarGerente()










        // MENU DE OPCÕES DO FUNCIONARIO

        public void ExecutarMensalista()
        {

            do
            {

                Console.WriteLine("Selecione uma das opções abaixo\n\n1.Cadastrar mensalista\n2.Consultar tudo\n3.Consultar individual\n4.Atualizar mensalista\n5.Excluir\n6.Adicionar fatura do mensalista\n7.Registrar pagamento\n8.Verificar valores do mensalista\n0.Voltar");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:

                        Console.Clear();

                        Console.WriteLine("Obrigado!");

                        break;

                    case 1:

                        Console.Clear();

                        CadastrarMensalista();

                        break;

                    case 2:

                        Console.Clear();

                        dao.ConsultarTudo();

                        break;

                    case 3:

                        Console.Clear();

                        Console.WriteLine($"Insira o código do mensalista:");
                        long documento = (long)Convert.ToDouble(Console.ReadLine());
                        int codigo = 0;

                        Console.WriteLine($" | Nome: {dao.ConsultarNome(codigo, documento)} | Telefone: {dao.ConsultarTelefone(codigo, documento)} | Endereço: {dao.ConsultarEndereco(codigo, documento)}\n" +
                              $" | Fabricante do carro: {dao.ConsultarFabricanteCarro(documento)} | Modelo do carro: {dao.ConsultarModeloCarro(documento)}\n" +
                              $" | Placa do carro: {dao.ConsultarPlacaCarro(documento)} | Cor do carro: {dao.ConsultarCorCarro(documento)}\n" +
                              $" | Data de pagamento: {dao.ConsultarDataDePagamento(documento)} | Valor Mensal: {dao.ConsultarValorMensal(documento)}");


                        break;

                    case 4:

                        Console.Clear();

                        AtualizarMensalista();

                        break;

                    case 5:

                        Console.Clear();

                        Excluir();

                        break;

                    case 6:

                        Console.Clear();

                        AdicionarFaturaMensalista();

                        break;

                    case 7:

                        Console.Clear();

                        Console.WriteLine("Insira o CPF do mensalista que pagou:");
                        documento = (long)Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Insira o valor que pagou do débito:");
                        double valor = Convert.ToDouble(Console.ReadLine());

                        dao.RegistrarPagamento(documento, valor);

                        break;

                    case 8:

                        Console.Clear();

                        bool validador = false;

                        do
                        {

                            Console.WriteLine("Digite o CPF do mensalista que deseja verificar:");
                            documento = (long)Convert.ToDouble(Console.ReadLine());

                        } while (dao.VerificarValoresMensalista(documento, validador) == false); // Fim do while


                        break;

                    default:

                        Console.WriteLine("Valor digitado não é válido!");
                        break;

                }// Fim do switch

            } while (opcao != 0);// Fim do while

            Executar();

        }// Fim do método ExecutarFuncionario





        //MENU OPÇÕES CONTROLE DE ENTRADA E SAÍDA
        public void ExecutarControleDeEntradaESaida()
        {

            do
            {
                Console.WriteLine("Selecione uma das opções abaixo:" +
                             "\n\n1.Cadastrar Entrada" +
                             "\n2.Cadastrar Saída" +
                             "\n0.Voltar");

                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0://Voltar.

                        Console.Clear();

                        Executar();

                        break;


                    case 1: //Cadastrar Cliente que entrou na hora.

                        Console.WriteLine("Insira o Nome do Cliente que entrou: ");
                        string nomeCliente = Console.ReadLine();

                        dao.CadastrarEntrada(nomeCliente);

                        DateTime horaEntrada = new DateTime();
                        horaEntrada = DateTime.Now;

                        Console.WriteLine(dao.EmitirCodigo(horaEntrada));

                        break;


                    case 2: //Cadastrar Saída:

                        Console.WriteLine("Insira o código que você quer emitir");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        Console.Write(dao.EmitirRecibo(codigo) + "\n\n");

                        break;


                    default:

                        Console.WriteLine("Insira um valor correto!");

                        break;
                }



            } while (opcao != 0);//Fim do While.


        }//Fim do Executar Controle de Entrada e Saída.

    }// Fim da Classe Menu;

}// Fim do namespace EstacionaMentos;
