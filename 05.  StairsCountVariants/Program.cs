/* TODO:
   გვაქვს n სართულიანი კიბე, ერთ მოქმედებაში შეგვიძლია ავიდეთ 1 ან 2 საფეხურით.
   დაწერეთ ფუნქცია რომელიც დაითვლის n სართულზე ასვლის ვარიანტების რაოდენობას.
*/

// --------------------- Call ---------------------

Console.WriteLine(CountVariants(-5)); // 0
Console.WriteLine(CountVariants(0));  // 0
Console.WriteLine(CountVariants(1));  // 1
Console.WriteLine(CountVariants(2));  // 2
Console.WriteLine(CountVariants(5));  // 8
Console.WriteLine(CountVariants(6));  // 13
Console.WriteLine(CountVariants(7));  // 21

// ------------------ Declaration -----------------

int CountVariants(int n)
{
    if (n <= 0)
    {
        return 0;
    }
    else if (n <= 2)
    {
        return n;
    }

    int[] array = new int[n + 1];

    array[1] = 1;
    array[2] = 2;

    for (int i = 3; i <= n; i++)
    {
        array[i] = array[i - 1] + array[i - 2];
    }

    return array[n];
}