using System;


class Program
{
    public static void Main(string[] args)
    {
        Jogadores[] time = new Jogadores[30];
        Geracao Gerador = new Geracao(30);
        int[] Vet = new int[30];

        int n = 0;
        string linha = Console.ReadLine();
        while (linha != "FIM")
        {
            time[n] = new Jogadores();
            time[n].Leitura(linha);
            Vet[n] = time[n].Id;
            n++;
            linha = Console.ReadLine();
        }
        Gerador.Entrada(Vet);
        Gerador.Sort();
        int aux = 0;
        for (int i = 0; i < time.Length; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (Gerador.GetArray()[aux] == time[j].Id)
                {
                    time[j].Imprimir();
                }
            }
            aux++;
        }
    }
}
class Jogadores{
     public string Nome;
     public string Foto;
     public int Id;
     public string Nascimento;
     public int[] Times;

    public void Leitura(string linha)
    {
        string exclui = linha.Replace('"' , '$');
        string exclui0 = exclui.Replace("[" , "$");
        string exclui1 = exclui0.Replace("]" , "$");
        string exclui2 = exclui1.Replace("$", "");
        linha = exclui2;
        int contador = 6;
        string[] Formatada = linha.Split(',');
        Nome = Formatada[1];
        Id = int.Parse(Formatada[5]);
        Foto = Formatada[2];
        Nascimento = Formatada[3];

        if (Formatada.Length <= 7)
        {
            Times = new int[1];
            Times[0] = int.Parse(Formatada[6]);
        }
        else
        {
            Times = new int[Formatada.Length - 6];
            for (int i = 0; i < Times.Length; i++)
            {
                Times[i] = int.Parse(Formatada[contador]);
                contador++;
            }
        }
    }

    public void Imprimir()
    {
        Console.Write(Id + " " + Nome + " " + Nascimento + " " + Foto + " " + "(");
        for (int i = 0; i < Times.Length; i++)
        {
            if (i == Times.Length - 1)
            {
                Console.Write(Times[i]);
                break;
            }
            else
            {
                Console.Write(Times[i] + ", ");
            }
        }
        Console.Write(")");
        Console.WriteLine("");
    }
}


class Geracao : Jogadores
{
    protected int[] array;
    protected int n;

    public Geracao()
    {
        array = new int[100];
        n = array.Length;
    }

    public Geracao(int tamanho)
    {
        array = new int[tamanho];
        n = array.Length;
    }
    public int[] GetArray()
    {
        return array;
    }

    public void EntradaPadrao()
    {
        n = Convert.ToInt32(Console.ReadLine());
        array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    public void Entrada(int[] vet)
    {
        n = vet.Length;
        array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = vet[i];
        }
    }
    public void Swap(int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    public void Sort()
    {
        for (int i = 0; i < (array.Length - 1); i++)
        {
            int menor = i;
            for (int j = (i + 1); j < array.Length; j++)
            {
                if (array[menor] > array[j])
                {
                    menor = j;
                }
            }
            Swap(menor, i);
        }
    }
}