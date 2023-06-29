using System;

class Program
{
    public static void Main(string[] args)
    {
        Jogador[] time = new Jogador[30];
        Geracao gerador = new Geracao(30);
        string[] vet = new string[30];

        int n = 0;
        string linha = Console.ReadLine();
        while (linha != "FIM")
        {
            time[n] = new Jogador();
            time[n].Leitura(linha);
            vet[n] = time[n].Nome;
            n++;
            linha = Console.ReadLine();
        }

        gerador.Entrada(vet);
        gerador.Sort();

        for (int i = 0; i < gerador.GetArrayLength(); i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (gerador.GetArray()[i] == time[j].Nome)
                {
                    time[j].Imprimir();
                    break;
                }
            }
        }
    }
}

class Jogador
{
    public string Nome;
    public string Foto;
    public int Id;
    public DateTime Nascimento;
    public int[] Times;

    public void Leitura(string linha)
    {
        string remove = linha.Replace("[", "");
        string remove1 = remove.Replace("]", "");
        string remove2 = remove1.Replace('"', '@');
        string remove3 = remove2.Replace("@", "");
        linha = remove3;
        int contador = 6;
        string[] Formatada = linha.Split(',');
        Nome = Formatada[1];
        Id = int.Parse(Formatada[5]);
        Foto = Formatada[2];
        Nascimento = DateTime.Parse(Formatada[3]);
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
        Console.Write(Id + " " + Nome + " " + Nascimento.ToString("d/MM/yyyy") + " " + Foto + " (");
        for (int i = 0; i < Times.Length; i++)
        {
            Console.Write(Times[i]);
            if (i < Times.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(")");
    }
}

class Geracao
{
    protected string[] array;
    protected int n;

    public Geracao(int tamanho)
    {
        array = new string[tamanho];
        n = tamanho;
    }

    public string[] GetArray()
    {
        return array;
    }

    public int GetArrayLength()
    {
        return array.Length;
    }

    public void Entrada(string[] vet)
    {
        for (int i = 0; i < n; i++)
        {
            array[i] = vet[i];
        }
    }

    public void Sort()
    {
        SortQuicksort(0, n - 1);
    }

    public void Swap(int i, int j)
    {
        string temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    private void SortQuicksort(int esq, int dir)
    {
        if (esq < dir)
        {
            int i = esq, j = dir;
            string pivo = array[(dir + esq) / 2];
            while (i <= j)
            {
                while (String.Compare(array[i], pivo) < 0)
                {
                    i++;
                }
                while (String.Compare(array[j], pivo) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap(i, j);
                    i++;
                    j--;
                }
            }
            if (esq < j)
            {
                SortQuicksort(esq, j);
            }
            if (i < dir)
            {
                SortQuicksort(i, dir);
            }
        }
    }
}
