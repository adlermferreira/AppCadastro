using System;
// See https://aka.ms/new-console-template for more information
namespace AppCadastro
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                if(opcaoUsuario == "1") ListarSeries();
                else if(opcaoUsuario == "2") InserirSerie();
                //else if(opcaoUsuario == "3") AtualizarSerie();
                //else if(opcaoUsuario == "4") ExcluirSerie();
                //else if(opcaoUsuario == "5") VisualizarSerie();
                else if(opcaoUsuario == "C") Console.Clear();
                else throw new ArgumentOutOfRangeException();

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado.");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seja bem vindo.");
            Console.WriteLine("Escolha a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Insere(novaSerie);
        }
    }
}
