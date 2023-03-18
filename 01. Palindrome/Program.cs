// --------------------- Call ---------------------

Console.WriteLine(IsPalindrome("rotator")); // True
Console.WriteLine(IsPalindrome("bachi"));   // False

// ------------------ Declaration -----------------

/* TODO:
   დაწერეთ ფუნქცია, რომელსაც გადაეცემა ტექსტი და აბრუნებს პალინდრომია თუ არა. (პალინდრომი არის ტექსტი რომელიც ერთნაირად იკითხება ორივე მხრიდან). 
*/
bool IsPalindrome(string text)
{
    return text.SequenceEqual(text.Reverse());
}
