using System;
using System.Linq;
using System.Windows;

namespace RandomSentenceGenerator
{
    class Program
    {
        public static int nbPhrases;

        static void Main(string[] args)
        {
            TrueMain();
        }

        static void TrueMain()
        {
            Console.Write("Combien de phrases ? : ");
            nbPhrases = getNumberPositif(Console.ReadLine());
            generateTest();
        }

        public static void generateTest()
        {
            var sujets = new string[] {
              "Un lapin",
              "Une grand-mère",
              "Un chat",
              "Un bonhomme de neige",
              "Une limace",
              "Une fee",
              "Un magicien",
              "Une tortue",
              "    _______\n" + 
              "   /      /,\n" +
              "  /      //\n" +
              " /______//\n" +
              "(______(/",
              "         ((`\\\n" +
              "      ___ \\\\ '--._\n" +
              "   .'`   `'    o  )\n" +
              "  /    \\   '. __.'\n" +
              " _|    /_  \\ \\_\\_\n" +
              "{_\\______\\-'\\__\\_\\",
              };

            var verbes = new string[]
            {
                "mange",
                "détruit",
                "écrase",
                "porte",
                "lèche",
                "avale",
                "regarde",
                "se bat contre",
                "danse avec",
            };

            var complements = new string[]
            {
                "Paul",
                "Loïc",
                "Max",
                "Hugo",
                "Alban",
                "Victor",
                "Nicolas",
                "Elsa",
                "Momo",
            };

            TabDisplay(sujets, verbes, complements, nbPhrases);

            Console.Write("Voulez-vous relancer le programme ? ");
            getAnswer(Console.ReadLine());

        }

        static void TabDisplay(string[] subjects, string[] verbs, string[] comp, int nbSentence)
        {
            string[] display = new string[nbSentence];

            for (int i = 0; i< nbSentence; i++)
            {
                Random rand = new Random();
                int index = rand.Next(0, subjects.Length);
                int index2 = rand.Next(0, verbs.Length);
                int index3 = rand.Next(0, comp.Length);

                display[i] = subjects[index] + " " + verbs[index2] + " " + comp[index3];
            }

            string[] noDupesArray = display.Distinct().ToArray();

            for (int i = 0; i < noDupesArray.Length; i++)
            {
                Console.WriteLine(noDupesArray[i]);
            }
        }

        private static int getNumberPositif(string entry)
        {
            bool state = int.TryParse(entry, out int q);
            bool positif = isPositiv(q);

            while (state == false || positif == false)
            {
                Console.Write("Valeur entrée incorrecte, veuillez entrer un nombre entier POSITIF : ");
                entry = Console.ReadLine();
                state = int.TryParse(entry, out q);
                positif = isPositiv(q);
            }

            return q;
        }

        /*
         * @description Vérifie que le nombre est positif ou non
         * @return bool positif ou non
         */

        private static bool isPositiv(int number)
        {
            if (number > 0)
                return true;
            else
                return false;
        }

        private static void getAnswer(string s)
        {
            while (s != "oui" && s != "non")
            {
                Console.Write("Valeur entrée incorrecte, veuillez entrer \"oui ou non\" : ");
                s = Console.ReadLine();
            }

            if (s == "oui")
            {
                Console.Clear();
                TrueMain();
            }
        }
    }
}
