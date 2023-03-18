// --------------------- Call ---------------------

int[] array = { -10, 3, 2, 5, 9 };     // 1
array = new int[] { -10, 1, 2, 3, 4 }; // 5
array = new int[] { 0, 2, 2, 3, 4 };   // 1

Console.WriteLine(NotContains(array));

// ------------------ Declaration -----------------

/* TODO:
   მოცემულია მასივი, რომელიც შედგება მთელი რიცხვებისგან.
   დაწერეთ ფუნქცია რომელსაც გადაეცემა ეს მასივი და აბრუნებს მინიმალურ მთელ რიცხვს, რომელიც 0-ზე მეტია და ამ მასივში არ შედის.
*/
int NotContains(int[] array)
{
    var sortedArray = array.Where(n => n >= 0).OrderBy(i => i).ToArray();
    int result = 1;

    foreach (var item in sortedArray)
    {
        if (result == item)
        {
            result++;
        }
    }

    return result;
}