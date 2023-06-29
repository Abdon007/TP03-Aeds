using System;

class Program
{
    public static void Main(string[] args)
    {
        Jogador[] time = new Jogador[30];
        Geracao gerador = new Geracao(30);
        DateTime[] vet = new DateTime[30];
        int n = 0;
        string linha = Console.ReadLine();
        while (linha != "FIM")
        {
            time[n] = new Jogador();
            time[n].Leitura(linha);
            vet[n] =time[n].Nascimento;
            n++;
            linha = Console.ReadLine();
        }
        gerador.Entrada(vet);
        gerador.Sort();

        for (int i = 0; i < gerador.GetArrayLength(); i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (gerador.GetArray()[i] == time[j].Nascimento)
                {
                    time[j].Imprimir();
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
    protected DateTime[] array;
    protected int n;

    public Geracao(int tamanho)
    {
        array = new DateTime[tamanho];
        n = tamanho;
    }

    public DateTime[] GetArray()
    {
        return array;
    }

    public int GetArrayLength()
    {
        return array.Length;
    }

    public void Entrada(DateTime[] vet)
    {
        for (int i = 0; i < n; i++)
        {
            array[i] = vet[i];
        }
    }

    public void Sort()
    {
        SortMergesort(0, n - 1);
    }

    private void SortMergesort(int esq, int dir)
    {
        if (esq < dir)
        {
            int meio = (esq + dir) / 2;
            SortMergesort(esq, meio);
            SortMergesort(meio + 1, dir);
            Intercalar(esq, meio, dir);
        }
    }

    public void Intercalar(int esq, int meio, int dir)
    {
        int n1, n2, i, j, k;

        n1 = meio - esq + 1;
        n2 = dir - meio;

        DateTime[] a1 = new DateTime[n1];
        DateTime[] a2 = new DateTime[n2];

        for (i = 0; i < n1; i++)
        {
            a1[i] = array[esq + i];
        }

        for (j = 0; j < n2; j++)
        {
            a2[j] = array[meio + j + 1];
        }

        i = j = 0;
        k = esq;

        while (i < n1 && j < n2)
        {
            if (a1[i] <= a2[j])
            {
                array[k] = a1[i];
                i++;
            }
            else
            {
                array[k] = a2[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            array[k] = a1[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            array[k] = a2[j];
            j++;
            k++;
        }
    }
}
