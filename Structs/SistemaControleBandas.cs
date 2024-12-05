using System;
using System.IO;

class TipoBanda
{
    public string nome;
    public string genero;
    public int integrantes;
    public int ranking;
}
class SistemaControleBandas
{
    public static int menuBandas()
    {
        Console.WriteLine("*** Sistema de Cadrastro Bandas ***");
        Console.WriteLine("1 - Inserir");
        Console.WriteLine("2 - Mostrar");
        Console.WriteLine("3 - Busca por Nome");
        Console.WriteLine("4 - Busca por Genero");
        Console.WriteLine("5 - Alterar Banda Cadastrada");
        Console.WriteLine("6 - Excluir Banda Cadastrada");
        Console.WriteLine("0 - Sair");
        Console.Write("Digite a Opcao Desejada: ");
        int op = int.Parse(Console.ReadLine());

        return op;

    }

    public static void alteraBanda(List<TipoBanda> listaBandas, string nome)
    {
        bool encontrado = false;

        for (int i = 0; i < listaBandas.Count; i++)
        {
            string nomeAtual = listaBandas[i].nome.ToUpper();
            if (nomeAtual.Contains(nome.ToUpper()))
            {
                encontrado = true;
                Console.WriteLine($"\n*** Banda Selecionada {i + 1} ***");
                Console.WriteLine($"\nNome: {listaBandas[i].nome}");
                Console.WriteLine($"Genero: {listaBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Digite S para continuar a Operação ou N para cancelar: ");
                char resp = char.Parse(Console.ReadLine());
                Console.Clear();

                if (resp == 'S' || resp == 's')
                {
                    
                    TipoBanda novaBanda = new TipoBanda();

                    Console.WriteLine("\n*** Dados para Alteração da Banda ***");

                    Console.Write("Nome: ");
                    novaBanda.nome = Console.ReadLine();

                    Console.Write("Genero: ");
                    novaBanda.genero = Console.ReadLine();

                    Console.Write("Numero Integrantes: ");
                    novaBanda.integrantes = int.Parse(Console.ReadLine());

                    Console.Write("Ranking: ");
                    novaBanda.ranking = int.Parse(Console.ReadLine());

                    Console.WriteLine("Alterando...");

                    listaBandas [i] = novaBanda;

                    Console.WriteLine("\nDados Alterados com sucesso!!\n");

                }else{

                    Console.WriteLine("Operação Cancelada");
                }

            }
            
        }
        if (!encontrado == true)
        {
            Console.WriteLine("\nNome não encontrado");
        }
    }

    public static void excluirBanda(List<TipoBanda> listaBandas, string nome)
    {
        bool encontrado = false;

        for (int i = 0; i < listaBandas.Count; i++)
        {
            string nomeAtual = listaBandas[i].nome.ToUpper();

            if (nomeAtual.Contains(nome.ToUpper() ) )
                {
                Console.WriteLine("\n*** Excluir Banda Cadastrada ***");
                Console.WriteLine($"\n*** Banda Selecionada {i + 1} ***");
                Console.WriteLine($"\nNome: {listaBandas[i].nome}");
                Console.WriteLine($"Genero: {listaBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Digite S para continuar a Operação ou N para cancelar: ");
                char resp = char.Parse( Console.ReadLine() );
                

                if (resp == 'S' || resp == 's')
                {
                    Console.WriteLine("Excluindo...");
                    listaBandas.Remove(listaBandas[i]);

                }
                else
                {
                    Console.WriteLine("Operação Cancelada");
                }
            }
        }

        if (encontrado == false)
        {
            Console.WriteLine("\nNome não encontrado");
        }
    }
    public static void buscaGenero(List<TipoBanda> listaBandas, string genero)
    {
        bool encontrado = false;

        for (int i = 0; i < listaBandas.Count; i++)
        {
            string generoAtual = listaBandas[i].genero.ToUpper();

            if (generoAtual.Equals(genero.ToUpper() ) )
            {
                Console.WriteLine("\n*** Busca Das Bandas Cadastradas ***");
                Console.WriteLine($"\n*** Banda {i + 1} ***");
                Console.WriteLine($"\nNome: {listaBandas[i].nome}");
                Console.WriteLine($"Genero: {listaBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
                Console.WriteLine("-----------------------------------------");
            }
            
        }

        if (encontrado == false)
        {
            Console.WriteLine("\nGenero não encontrado");
        }

    }
    public static void buscaNome(List < TipoBanda > listaBandas, string nome)
    {
        bool encontrado = false;

        for (int i = 0; i < listaBandas.Count; i++)
        {
            string nomeAtual = listaBandas[i].nome.ToUpper();

            if (nomeAtual.Contains(nome.ToUpper() ) )
            {
                Console.WriteLine("\n*** Busca Das Bandas Cadastradas ***");
                Console.WriteLine($"\n*** Banda {i + 1} ***");
                Console.WriteLine($"\nNome: {listaBandas[i].nome}");
                Console.WriteLine($"Genero: {listaBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
                Console.WriteLine("-----------------------------------------");
                break;
            }
            
        }

        if (encontrado == false)
        {
            Console.WriteLine("\nNome não encontrado");
        }

    }
    public static void mostraBanda(List < TipoBanda > listaBandas)
    {
        Console.WriteLine("\n*** Bandas Cadastradas ***");

        for (int i = 0; i < listaBandas.Count; i++)
        {
            Console.WriteLine($"\n*** Banda {i+1} ***");
            Console.WriteLine($"\nNome: {listaBandas[i].nome}");
            Console.WriteLine($"Genero: {listaBandas[i].genero}");
            Console.WriteLine($"Integrantes: {listaBandas[i].integrantes}");
            Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
            Console.WriteLine("-----------------------------------------");
           
        }
    }
    public static void salvarDados(List<TipoBanda> listaBandas, string nomeArquivo)
    {
        StreamWriter writer = new StreamWriter(nomeArquivo);

        foreach (TipoBanda banda in listaBandas)
        {
            writer.WriteLine($"{banda.nome},{banda.genero},{banda.integrantes},{banda.ranking}");
        }

        Console.WriteLine("Dados salvos com sucesso!");
        writer.Dispose();
    }

    public static void carregarDados(List<TipoBanda> listaBandas, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                TipoBanda banda = new TipoBanda();
                banda.nome = campos[0];
                banda.genero = campos[1];
                banda.integrantes = int.Parse(campos[2]);
                banda.ranking = int.Parse(campos[3]);
                listaBandas.Add(banda);
            }
            Console.WriteLine("Dados carregados com sucesso!");
            Console.WriteLine("\nPrecione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public static void addBanda(List < TipoBanda > listasbandas)
    {
        TipoBanda novaBanda = new TipoBanda ();

        Console.WriteLine("\n*** Dados para Banda ***");

        Console.Write("Nome: ");
        novaBanda.nome = Console.ReadLine();

        Console.Write("Genero: ");
        novaBanda.genero = Console.ReadLine();

        Console.Write("Numero Integrantes: ");
        novaBanda.integrantes = int.Parse(Console.ReadLine());

        Console.Write("Ranking: ");
        novaBanda.ranking = int.Parse(Console.ReadLine());

        listasbandas.Add(novaBanda);

        Console.WriteLine("Dados adicionados com sucesso!!\n");

    } 
    static void Main()
    {
        List < TipoBanda > listaBandas = new List < TipoBanda > ();
        int op;
        carregarDados(listaBandas, "dadossalvos");

        do
        {
            op = menuBandas();
            switch (op)
            {
                case 1:
                    Console.Clear();
                    addBanda(listaBandas);
                    break;

                case 2:
                    Console.Clear();
                    mostraBanda(listaBandas);
                    break; 

                case 3:
                    Console.Clear();
                    Console.Write("Nome da Banda para buscar: ");
                    string nome = Console.ReadLine();
                    buscaNome(listaBandas, nome);
                    break;

                case 4:
                    Console.Clear();
                    Console.Write("Genero da Banda para buscar: ");
                    string genero = Console.ReadLine();
                    buscaGenero(listaBandas, genero);
                    break;

                case 5:
                    Console.Clear();
                    Console.Write("Nome da Banda Para Alterar: ");
                    nome = Console.ReadLine();
                    alteraBanda(listaBandas, nome);
                    break;

                case 6:
                    Console.Clear();
                    Console.Write("Nome da Banda para Excluir: ");
                    nome = Console.ReadLine();
                    excluirBanda(listaBandas, nome);
                    break;

                case 0:
                    Console.Clear();
                    Console.Write("Nome do Arquivo para Salvar: ");
                    salvarDados(listaBandas, "dadossalvos");
                    Console.WriteLine("Saindo...");
                    Console.WriteLine("\nPrecione qualquer tecla para sair");
                    break;
            }
            Console.ReadLine();
            Console.Clear();

        } while (op != 0);
        
    }
}
