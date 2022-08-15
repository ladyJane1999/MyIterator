public static class Program
{
    public static Func<int, bool> Predicate;

    public static IEnumerable<int> GetEnumaration()
    {
        int i = 0;
        while (true)
        {
            yield return i++;
        }
    }

    public static IEnumerable<int> MyWhere(this IEnumerable<int> enumerator, Func<int, bool> predicate)
    {
        Predicate = predicate;

        return new BaseEnumerator<int>(Predicate);
    }

    public static IEnumerable<int> MyTake(this IEnumerable<int> enumerator, int count)
    {
        var en = new IndexedEnumerator<int>(enumerator.GetEnumerator());

        int cnt = 0;
        while (cnt < count)
        {
            en.MoveNext();
        }

        return new IndexedEnumerator<int>().AsEnumerable();
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
