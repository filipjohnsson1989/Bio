using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio
{
    //En generisk klass för att få en giltig input för olika typer av input från användaren.
    static class Tool<T>
    {
        //infoPrompt används för den första prompten. errorPrompt används för ogiltig inmatning.
        public static T AskForAnInput(string infoPrompt, string errorPrompt)
        {
            T result;

            //Det är specialt för string type annars fick vi runtime del.
            if (typeof(T) == typeof(string)) result = (T)Activator.CreateInstance(typeof(T), string.Empty.ToCharArray());
            else result = Activator.CreateInstance<T>();

            bool success = false;
            string answer;

            Console.WriteLine(infoPrompt);
            do
            {
                answer = Console.ReadLine();

                try
                {
                    //Om appen inte kan ändra den önskade typen ger den ett exception. Så vi måste hantera det med try-catch.
                    result = (T)Convert.ChangeType(answer, typeof(T));
                    //Om användaren inte anger en ingång gör vi ett exception för att göra samma sak eftersom det är en ogiltig inmatning.
                    if (string.IsNullOrWhiteSpace(answer)) throw new Exception();

                    success = true;
                }
                catch
                {
                    Console.WriteLine($"Du bör skriva upp {errorPrompt}");
                }

            } while (!success);

            return result;

        }
    }
}
