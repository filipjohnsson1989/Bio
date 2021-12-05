using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio
{
    static class Tool<T>
    {
        public static T AskForAnInput(string infoPrompt, string errorPrompt)
        {
            T result;


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
                    result = (T)Convert.ChangeType(answer, typeof(T));
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
