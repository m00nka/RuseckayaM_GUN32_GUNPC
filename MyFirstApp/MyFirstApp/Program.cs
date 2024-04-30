class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number:");
        if (!Int32.TryParse(Console.ReadLine(), out var a))
        {
            Console.WriteLine("No a number!");
            return; 
        }

        Console.WriteLine("Enter the second number:");
        if (!Int32.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine("Not a number!");
            return;
        }

        Console.WriteLine("Enter the bitwise operation (&, | or ^):");
        var s = Console.ReadLine();

        if (s.Length !=1 || (s[0] != '&' && s[0] != '|' && s[0] != '^'))
        {
            Console.WriteLine("Wrong operator!");
            return;
        }

        switch(s[0]) 
        {
            case '&':
                Console.WriteLine("Result of {0} & {1} = {2}", a, b, a & b);
                Console.WriteLine("Binary result: {0}", Convert.ToString(a & b, 2));
                Console.WriteLine("Hexadecimal result: {0}", Convert.ToString(a & b, 16));
                break;
            case '|':
                Console.WriteLine("Result of {0} | {1} = {2}", a, b, a | b);
                Console.WriteLine("Binary result: {0}", Convert.ToString(a | b, 2));
                Console.WriteLine("Hexadecimal result: {0}", Convert.ToString(a | b, 16));
                break;
            case '^':
                Console.WriteLine("Result of {0} ^ {1} = {2}", a, b, a ^ b);
                Console.WriteLine("Binary result: {0}", Convert.ToString(a ^ b, 2));
                Console.WriteLine("Hexadecimal result: {0}", Convert.ToString(a ^ b, 16));
                break;
            default: 
                Console.WriteLine("Wrong operator!");
                break;
        }
    
    }
}
