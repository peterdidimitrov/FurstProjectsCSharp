namespace _06.QuickSortSoftUniInplementation
{
    public class QuickSortExample
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Quick.Sort<int>(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
    public class Quick
    {
        public static void Sort<T>(T[] array)
            where T : IComparable<T>
        {
            Shuffle(array);
            Sort(array, 0, array.Length - 1);
        }
        private static void Sort<T>(T[] array, int lo, int hi)
            where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return;
            }
            int p = Partition(array, lo, hi);
            Sort(array, lo, p - 1); //Sort the smaler elements
            Sort(array, p + 1, hi); //Sort the larger elements
        }
        private static int Partition<T>(T[] array, int lo, int hi)
            where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return lo;
            }
            int left = lo;
            int right = hi + 1;
            while (true)
            {
                while (Less(array[++left], array[lo]))
                {
                    if (left == hi)
                    {
                        break;
                    }
                }
                while (Less(array[lo], array[--right]))
                {
                    if (right == lo)
                    {
                        break;
                    }
                }
                if (left >= right)
                {
                    break;
                }
                Swap(array, left, right);
            }
            Swap(array, lo, right);
            return right;
        }
        private static void Swap<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            var temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }
        private static bool Less<T>(T arrayOne, T arrayTwo) where T : IComparable<T>
        {
            return arrayOne.CompareTo(arrayTwo) < 0;
        }
        private static void Shuffle<T>(T[] array) where T : IComparable<T>
        {
            Random random = new Random();
            for (int left = 0; left < array.Length; left++)
            {
                int right = left + random.Next(0, array.Length - left);
                Swap(array, left, right);
            }
        }
    }
}