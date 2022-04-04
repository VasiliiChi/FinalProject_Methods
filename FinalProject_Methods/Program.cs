using System;

namespace FinalProject_Methods
{
    class Program
    {
        static (string Name, string LastName, int Age, string[] PetsName, string[] PrefColors) EnterUser()
        {
            (string Name, string LastName, int Age, string[] PetsName, string[] PrefColors) User;
            
            string checkEnter;
            int intage;
           
            do
            {
                Console.Write("Введите свое имя: ");
                checkEnter = Console.ReadLine();

            } while (!IsAllLetters(checkEnter));
            User.Name = checkEnter;
            


            do
            {
                Console.Write("Введите свою фамилию: ");
                checkEnter = Console.ReadLine();

            } while (!IsAllLetters(checkEnter));
            
            User.LastName = checkEnter;



            do
            {
                Console.Write("Введите свой возраст цифрами: ");
                checkEnter = Console.ReadLine();
            } while (!CheckNum(checkEnter, out intage));

            User.Age = intage;


            bool havePet;
            bool checkAnswer;
            do
            {

                Console.WriteLine("Имеете ли Вы домашних животных? Напишите да/нет.");
                switch (Console.ReadLine())
                {
                    case "да":
                        havePet = true;
                        checkAnswer = true;
                        break;

                    case "нет":
                        havePet = false;
                        checkAnswer = true;
                        break;

                    default:
                        havePet = false;
                        checkAnswer = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы ввели некорректное значение!!!");
                        Console.ResetColor();
                        break;
                }
            } while (!checkAnswer);

            if (havePet)
            {
                do
                {
                    Console.WriteLine("Введите количество Ваших питомцев: ");
                    checkEnter = Console.ReadLine();
                } while (!CheckNum(checkEnter, out intage));

                User.PetsName = Pets(intage);
            }
            else
            {
                User.PetsName = new string[1];
                for (int i = 0; i < User.PetsName.Length; i++)
                {
                    User.PetsName[i] = "-";
                }
            }

            do
            {
                Console.WriteLine("Введите количество Ваших любимых цветов: ");
                checkEnter = Console.ReadLine();
            } while (!CheckNum(checkEnter, out intage));

            User.PrefColors = Colors(intage);


            return User;
        }

        static bool IsAllLetters(string a)
        {
            foreach (char item in a)
            {
                if (!Char.IsLetter(item))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите данные корректно, используйте только буквы!!!");
                    Console.ResetColor();
                    return false;
                }
            }
            return true;
        }
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnumber))
            {
                if (intnumber > 0)
                {
                    corrnumber = intnumber;
                    return true;
                }
            }

            {
                corrnumber = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите данные корректно!!!");
                Console.ResetColor();
                return false;
            }
        }

        static string[] Pets(int num)
        {
            var pets = new string[num];
            for (int i = 0; i < pets.Length; i++)
            {
                Console.WriteLine("Введите имя {0} питомца: ", i + 1);
                pets[i] = Console.ReadLine();
            }

            return pets;
        }

        static string[] Colors(int num)
        {
            var pets = new string[num];
            for (int i = 0; i < pets.Length; i++)
            {
                Console.WriteLine("Введите цвет номер {0}: ", i + 1);
                pets[i] = Console.ReadLine();
            }

            return pets;

        }
        static void ShowDataUser((string Name, string LastName, int Age, string[] PetsName, string[] PrefColors) somebody)
        {
            // somebody = EnterUser(); почему то выдает ошибку, что отс. агрумент, соотв. требуемому параметру LastName???????

            Console.WriteLine("Здравствуйте,{0} {1}. \nВаш возраст: {2}.", somebody.Name, somebody.LastName, somebody.Age);

            Console.WriteLine("Имена вашего(-их) питомца(-ев): ");
            foreach (var item in somebody.PetsName)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nВаши любимые цвета: ");
            foreach (var item in somebody.PrefColors)
            {
                Console.Write(item + " ");
            }
        }

        static void Main(string[] args)

        {
            var user = EnterUser();
            ShowDataUser(user);
            Console.ReadKey();
        }

    }
}
