using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\PROGRAMOWANIE\C#\TextFileDataAccessDemo\demo.txt";

            //List<string> lines = File.ReadAllLines(filePath).ToList();

            //foreach (string line in lines)
            //{
            //    Console.WriteLine(line);
            //}

            //lines.Add("jim,tom,www.jimtom.com");

            //File.WriteAllLines(filePath, lines);

            List<Person> people = new List<Person>();

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                string[] entries = line.Split(',');

                Person newPerson = new Person();

                newPerson.FirstName = entries[0];
                newPerson.LastName = entries[1];
                newPerson.Url = entries[2];

                people.Add(newPerson);
            }

            Console.WriteLine("read from the text file:");

            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}: {person.Url}");
            }

            people.Add(new Person { FirstName = "John", LastName = "Rambo", Url = "www.bambo.pl" });

            List<string> output = new List<string>();

            foreach (var person in people)
            {
                output.Add($"{person.FirstName},{person.LastName},{person.Url}");
            }

            Console.WriteLine("writing to file...");

            File.WriteAllLines(filePath, output);

            Console.WriteLine("all entries written");
        }
    }
}
