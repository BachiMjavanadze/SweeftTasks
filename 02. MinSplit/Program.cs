/* TODO:
   გვაქვს 1,5,10,20 და 50 თეთრიანი მონეტები.
   დაწერეთ ფუნქცია, რომელსაც გადაეცემა თანხა (თეთრებში) და აბრუნებს მონეტების მინიმალურ რაოდენობას, რომლითაც შეგვიძლია ეს თანხა დავახურდაოთ.
*/

// --------------------- Call ---------------------

int[] coins = { 5, 50, 20, 10, 1 };

Console.WriteLine(MinSplit(coins, 280)); // 7 (5*50+20+10)
Console.WriteLine(MinSplit(coins, 150)); // 3 (3*50)
Console.WriteLine(MinSplit(coins, 97));  // 6 (50+20+20+5+1+1)

// ------------------ Declaration -----------------

int MinSplit(int[] coins, int amount)
{
    Array.Sort(coins);
    Array.Reverse(coins);
    int count = 0;

    for (int i = 0; i < coins.Length; i++)
    {
        count += amount / coins[i];
        amount %= coins[i];
    }

    return count;
}