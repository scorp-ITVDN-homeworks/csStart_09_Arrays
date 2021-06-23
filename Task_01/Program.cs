using System;
using System.Threading;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] randomNumbersArray = new int[] { };
            Commands menuItemChoice = Commands.create;
            bool showMenu = true;

            do
            {
                if (!showMenu)
                {
                    CheckCommandInput(ref menuItemChoice, ref showMenu);
                    if (menuItemChoice == Commands.menu) showMenu = true;
                }

                if (showMenu)
                {
                    ShowMenu(ref menuItemChoice, ref showMenu);
                    CheckCommandInput(ref menuItemChoice, ref showMenu);
                }

                switch (menuItemChoice)
                {
                    case Commands.create:
                        {
                            CreateNewArray(ref randomNumbersArray);
                            break;
                        }

                    case Commands.view:
                        {
                            if (randomNumbersArray.Length == 0)
                            {
                                EmptyArrayWarning();
                                break;
                            }
                            ViewArray(randomNumbersArray);
                            break;
                        }

                    case Commands.min:
                        {
                            if (randomNumbersArray.Length == 0)
                            {
                                EmptyArrayWarning();
                                break;
                            }
                            ShowMinValue(randomNumbersArray);
                            break;
                        }

                    case Commands.max:
                        {
                            if (randomNumbersArray.Length == 0)
                            {
                                EmptyArrayWarning();
                                break;
                            }
                            ShowMaxValue(randomNumbersArray);
                            break;
                        }

                    case Commands.sum:
                        {
                            if (randomNumbersArray.Length == 0)
                            {
                                EmptyArrayWarning();
                                break;
                            }
                            GetArrayItemsSum(randomNumbersArray);
                            break;
                        }

                    case Commands.average:
                        {
                            if (randomNumbersArray.Length == 0)
                            {
                                EmptyArrayWarning();
                                break;
                            }
                            Average(randomNumbersArray);
                            break;
                        }

                    case Commands.odd:
                        {
                            if (randomNumbersArray.Length == 0)
                            {
                                EmptyArrayWarning();
                                break;
                            }
                            GetOddArrayItems(randomNumbersArray);
                            break;
                        }

                    case Commands.reverse:
                        {
                            if (randomNumbersArray.Length == 0)
                            {
                                EmptyArrayWarning();
                                break;
                            }
                            ReverseArray(ref randomNumbersArray);
                            break;
                        }

                    case Commands.sub:
                        {
                            if (randomNumbersArray.Length == 0)
                            {
                                EmptyArrayWarning();
                                break;
                            }
                            GetSubArray(randomNumbersArray);
                            break;
                        }

                    case Commands.add:
                        {
                            AddElementToArray(ref randomNumbersArray);
                            break;
                        }

                    case Commands.remove:
                        {
                            if(randomNumbersArray.Length == 0)
                            {
                                EmptyArrayWarning();
                                break;
                            }
                            RemoveElementToArray(ref randomNumbersArray);
                            break;
                        }

                    case Commands.clear:
                        {
                            Console.Clear();
                            break;
                        }

                    case Commands.menu:
                        {
                            showMenu = true;
                            break;
                        }
                }

                if (menuItemChoice == Commands.exit) break;

            } while (true);
        }

        public static void ShowMenu(ref Commands choice, ref bool showMenu)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Commands.create}   - Create new random array");
            Console.WriteLine($"{Commands.view}     - View array");
            Console.WriteLine($"{Commands.min}      - Show min array value");
            Console.WriteLine($"{Commands.max}      - Show max array value");
            Console.WriteLine($"{Commands.sum}      - Show sum of numbers in array");
            Console.WriteLine($"{Commands.average}  - Show array average");
            Console.WriteLine($"{Commands.odd}      - Show all odd numbers in array");
            Console.WriteLine($"{Commands.reverse}  - Reverse array");
            Console.WriteLine($"{Commands.sub}      - Get sub array by indicies");
            Console.WriteLine($"{Commands.add}      - Add element to array");
            Console.WriteLine($"{Commands.remove}   - Remove element from array");
            Console.WriteLine($"{Commands.clear}    - Clear console");
            Console.WriteLine($"{Commands.menu}     - Show Menu");
            Console.WriteLine($"{Commands.exit}     - Exit");
            Console.ResetColor();
            showMenu = false;
        }

        public static void SymbolsAppears(char symbol, int numberOfSymbols, int speed)
        {
            for (int i = 0; i < numberOfSymbols; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(speed);
            }
        }

        public static void ShowHeading(string headingText)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            int totalLength = 80;
            int stringLength = headingText.Length;
            int symbolStringLength = totalLength - stringLength;

            Console.WriteLine($"***{headingText}{new string('*', symbolStringLength)}");
            Console.ResetColor();
            if (headingText.Length > 0) Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void CheckCommandInput(ref Commands command, ref bool showMenu)
        {
            bool commandNotCorrect = true;

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;

                if (!commandNotCorrect == false)
                {
                    Console.Write("type command here: ");
                    Console.ResetColor();
                }

                commandNotCorrect = !Enum.TryParse(Console.ReadLine(), out command);
                if (commandNotCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("COMMAND INPUT IS NOT CORRECT, MAKE RIGHT INPUT");
                    Console.ResetColor();
                    ShowMenu(ref command, ref showMenu);
                }
            }
            while (commandNotCorrect);
            Console.ResetColor();
        }

        //поздно понял, что в аргументы метода ShowHeading надо было вносить и цвет
        //чтобы уже на заморачиваться и наконец сдать просто скопировал всё сюда
        public static void EmptyArrayWarning()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int totalLength = 80;
            string text = "EMPTY ARRAY WARNING";
            int stringLength = text.Length;
            int symbolStringLength = totalLength - stringLength;
            Console.WriteLine($"***{text}{new string('*', symbolStringLength)}");
            Console.WriteLine("array not defined - " +
                "\nplease, input command \"create\" or \"add\" before do anything else");
            Console.WriteLine($"***{new string('*', symbolStringLength + stringLength)}");
            Console.ResetColor();
        }

        public static void CreateNewArray(ref int[] randomNumbersArray)
        {
            Console.WriteLine();
            ShowHeading("Create new array");
            
            Console.Write("Let's create an array. Input an array size here: ");
            int size = Convert.ToInt32(Console.ReadLine());

            Console.Write("---Array creating");
            SymbolsAppears('-', 60, 25);


            randomNumbersArray = new int[size];

            for (int i = 1; i <= size; i++)
            {
                Random r = new Random();
                int randomNumber = r.Next(0, 1000);
                randomNumbersArray[i - 1] = randomNumber;
            }

            Console.WriteLine("Done!");
            
            ShowHeading("");
        }

        public static void ViewArray(int[] randomNumbersArray)
        {
            Console.WriteLine();
            ShowHeading("View array");
            
            int length = randomNumbersArray.Length;

            for (int i = 0; i < length; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine(randomNumbersArray[i]);
            }
            
            ShowHeading("");
        }

        public static void ShowMinValue(int[] numbersArray)
        {
            Console.WriteLine();
            ShowHeading("Minimum value in array");
            
            int[] tempArray = numbersArray;
            Array.Sort(tempArray);
            Console.WriteLine($"min value = {tempArray[0]}");
            
            ShowHeading("");
            Console.WriteLine();
        }

        public static void ShowMaxValue(int[] numbersArray)
        {
            Console.WriteLine();
            ShowHeading("Maximum value in array");
            
            int[] tempArray = numbersArray;
            Array.Sort(tempArray);
            Array.Reverse(tempArray);
            Console.WriteLine($"max value = {tempArray[0]}");
            
            ShowHeading("");
            Console.WriteLine();
        }

        public static void Average(int[] numbersArray)
        {
            Console.WriteLine();
            ShowHeading("Array items average");
            
            int sum = 0;
            int len = numbersArray.Length;
            for (int i = 0; i < len; i++)
            {
                sum += numbersArray[i];
            }
            Console.WriteLine($"items average = {sum / len}");
            
            ShowHeading("");
            Console.WriteLine();
        }

        public static void GetArrayItemsSum(int[] numbersArray)
        {
            Console.WriteLine();
            ShowHeading("Array items sum");
            
            int sum = 0;
            int len = numbersArray.Length;
            for (int i = 0; i < len; i++)
            {
                sum += numbersArray[i];
            }
            Console.WriteLine($"items sum = {sum}");
            
            ShowHeading("");
            Console.WriteLine();
        }

        public static void GetOddArrayItems(int[] numbersArray)
        {
            Console.WriteLine();
            ShowHeading("Show all odd numbers in array");
            
            int len = numbersArray.Length;

            for (int i = 0; i < len; i++)
            {
                if ((numbersArray[i] & 1) == 1)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(numbersArray[i]);
                }
            }
            
            Thread.Sleep(100);
            ShowHeading("");
            Console.WriteLine();
        }

        public static void ReverseArray(ref int[] numbersArray)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            ShowHeading("Reverse items in array");
            Console.Write("---reversing");
            SymbolsAppears('-', 60, 25);
            Array.Reverse(numbersArray);
            Console.WriteLine("Done!");
            Console.ResetColor();
            ShowHeading("");
        }

        public static void GetSubArray(int[] numbersArray)
        {
            Console.WriteLine();
            ShowHeading("Reverse items in array");

            //TODO проверка на корректность
            Console.Write("input first index: ");
            int firstIndex = Convert.ToInt32(Console.ReadLine());
            Console.Write("input second index: ");
            int secondIndex = Convert.ToInt32(Console.ReadLine());
            int len = Math.Abs(secondIndex - firstIndex);
            int index = 0;

            for(int i = 0; i < len; i++)
            {
                index = firstIndex < secondIndex ? firstIndex + i : firstIndex - i;
                if(index > numbersArray.Length - 1)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(1);
                    continue;
                }

                Thread.Sleep(100);
                Console.WriteLine(numbersArray[index]);
            }

            Thread.Sleep(100);
            ShowHeading("");
        }

        public static void AddElementToArray(ref int[] numbersArray)
        {
            Console.WriteLine();
            ShowHeading("Add element to array");
            Console.Write("input integer number as new item of array: ");
            int newItem = Convert.ToInt32(Console.ReadLine());
            Array.Resize<int>(ref numbersArray, numbersArray.Length + 1);
            numbersArray[numbersArray.Length - 1] = newItem;
            Console.Write("---adding");
            SymbolsAppears('-', 60, 10);
            Console.WriteLine("Done!");
            ShowHeading("");
        }

        public static void RemoveElementToArray(ref int[] numbersArray)
        {
            Console.WriteLine();
            ShowHeading("Remove element from array");
            Array.Resize<int>(ref numbersArray, numbersArray.Length - 1);
            Console.Write("---removing");
            SymbolsAppears('-', 60, 10);
            Console.WriteLine("Done!");
            ShowHeading("");
        }
    }

    public enum Commands
    {
        create = 1,
        view = 2,
        min = 3,
        max = 4,
        sum = 5,
        average = 6,
        odd = 7,
        reverse = 8,
        sub = 9,
        add = 10,
        remove = 11,
        clear = 12,
        menu = 13,
        exit = 14
    }
}
