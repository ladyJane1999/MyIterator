public static class Program
{
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
        return new MyEnumerable(-2, predicate); ; 
    }

    public static int[] MyTake(this IEnumerable<int> enumer, int count)
    {
        var en = enumer.GetEnumerator();
        var arr = new int[count];   
        int cnt = 0;
      
        while (cnt < count)
        {
            if(en.MoveNext())
            {
                arr[cnt]=en.Current;
                cnt++;
            }
        }

        return arr;
    }

    public static void Main()
    {
        foreach (var item in GetEnumaration().Where(x => x % 2 == 0).Take(5))
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("------------");

        foreach (var item in GetEnumaration().MyWhere( x => x % 2 == 0).MyTake(5))
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
}

