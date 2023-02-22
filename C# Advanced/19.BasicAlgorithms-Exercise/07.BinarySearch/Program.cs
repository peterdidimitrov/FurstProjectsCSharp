namespace _07.BinarySearch
{
    public class BinarySearch
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            int index = int.Parse(Console.ReadLine());

            Console.WriteLine(IndexOf(input, index));
        }
        public static int IndexOf(int[] arr, int key)
        {
            int lo = 0;
            int hi = arr.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key < arr[mid])
                {
                    hi = mid - 1;
                }
                else if (key > arr[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}