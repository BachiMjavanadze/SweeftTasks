// --------------------- Call ---------------------

Console.WriteLine(IsProperly("()"));          // True
Console.WriteLine(IsProperly("(()())"));      // True
Console.WriteLine(IsProperly("((()())())"));  // True
Console.WriteLine(IsProperly(")"));           // False
Console.WriteLine(IsProperly("))"));          // False
Console.WriteLine(IsProperly("("));           // False
Console.WriteLine(IsProperly("(("));          // False
Console.WriteLine(IsProperly("())()"));       // False
Console.WriteLine(IsProperly("(())())"));     // False

// ------------------ Declaration -----------------

/* TODO
   მოცემულია String რომელიც შედგება „(„ და „)“ ელემენტებისგან.
   დაწერეთ ფუნქცია რომელიც აბრუნებს ფრჩხილები არის თუ არა მათემატიკურად სწორად დასმული.
   მაგ: (()()) სწორი მიმდევრობაა, ())() არასწორია
*/
bool IsProperly(string sequence)
{
    int count = 0;

    foreach (char bracket in sequence)
    {
        if (bracket == '(')
        {
            count++;
        }
        else if (bracket == ')')
        {
            count--;
        }
    }

    return count == 0;
}