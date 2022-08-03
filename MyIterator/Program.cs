public static class Program
{
    public static IEnumerable<int> GetEnumaration()
    {
        int i = 0;
        while (i < 10)
        {
            yield return i++;
        }
    }

    public static IEnumerable<int> MyWhere(this IEnumerable<int> enumerator, Func<int, bool> predicate)
    {
        // return enumerator.Where(predicate);

        int[] array = enumerator.ToArray();
        int whereSize = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (predicate(array[i]))
            {
                whereSize++;
            }
        }

        int[] result = new int[whereSize];
        int j = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (predicate(array[i]))
            {
                result[j] = array[i];
                j++;
            }
        }

        return result.AsEnumerable();
    }

    public static IEnumerable<int> MyTake(this IEnumerable<int> enumerator, int count)
    {
        // return enumerator.Take(count);

        int[] array = enumerator.ToArray();
        int[] result = new int[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = array[i];
        }

        return result.AsEnumerable();
    }

    public static void Main()
    {
        foreach (var item in GetEnumaration().Where(x => x % 2 == 0).Take(5))
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("------------");

        foreach (var item in GetEnumaration().MyWhere(x => x % 2 == 0).MyTake(5))
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
}