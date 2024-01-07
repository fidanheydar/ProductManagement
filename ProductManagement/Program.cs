using System;

namespace MiniProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productNames = { "Milk", "Meat", "Bread", "Water" };
            string opt;

            do
            {

                ShowMainMenu();
                opt = Console.ReadLine();

                switch (opt)
                {

                    case "1":
                        Console.WriteLine("\n======Mehsullar======");
                        ShowAllProducts(productNames);
                        break;

                    case "2":
                        ChoosenProduct(ref productNames);
                        break;
                    case "3":
                        AddProduct(ref productNames);
                        break;
                    case "4":
                        Console.WriteLine("\n======Mehsullar======");
                        ShowAllProducts(productNames);
                        EditProduct(productNames);
                        break;
                    case "5":
                        Console.WriteLine("\n======Mehsullar======");
                        ShowAllProducts(productNames);
                        DeleteProduct(ref productNames);
                        break;
                    case "0":
                        Console.WriteLine("Chixhis olunur...");
                        break;
                    default:
                        Console.WriteLine("Yalnish emeliyyat ");
                        break;

                }

            } while (opt != "0");



             static void ShowMainMenu()
            {
                Console.WriteLine("\n======Menu======");
                Console.WriteLine("1. Butun mehsullara bax");
                Console.WriteLine("2. Sechilmish mehsula bax");
                Console.WriteLine("3. Yeni mehsul elave et");
                Console.WriteLine("4. Mehsul adini deyish");
                Console.WriteLine("5. Sechilmish mehsulu sil");
                Console.WriteLine("0. Chixhish");

                Console.Write("Emeliyyati sechin:");
            }
            static void ShowAllProducts(string[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                    Console.WriteLine($"{i}.{arr[i]}");
            }

            static void AddProduct(ref string[] arr)
            {
                string newName;
                bool isInvalid;

                do
                {
                    isInvalid = false;
                    Console.Write("Mehsul adi: ");
                    newName = Console.ReadLine();

                    int startIndex = 0;
                    while (startIndex < newName.Length && newName[startIndex] == ' ')
                    {
                        startIndex++; //     input = "   fidannn"
                    }
                    int endIndex = newName.Length - 1;
                    if (startIndex > endIndex)
                    {
                        Console.WriteLine("Mehsul Boshlugdan ibaret ola bilmez");
                        isInvalid = true;

                    }
                    else
                    {
                        while (endIndex >= 0 && newName[endIndex] == ' ')
                        {
                            endIndex--;
                        }

                        char[] newNameWithChars = new char[endIndex - startIndex + 1];
                        int charIndex = 0;
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            newNameWithChars[charIndex++] = newName[i];
                        }

                        newName = new string(newNameWithChars);
                    }

                    if (newName.Length < 2 || newName.Length > 20)
                    {
                        Console.WriteLine("Mehsul adi min 2 max 20 uzunlugunda olmalidir !");
                        isInvalid = true;
                    }

                    else if (newName.Length > 0 && newName.Length <= 2)
                    {
                        bool productExists = false;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i] == newName)
                            {
                                productExists = true;
                                break;
                            }
                        }

                        if (productExists)
                        {
                            Console.WriteLine("Bu ad`da olan mehsul movcuddur.");
                        }
                        else
                        {
                            string[] newArr = new string[arr.Length + 1];
                            for (int i = 0; i < arr.Length; i++)
                            {
                                newArr[i] = arr[i];
                            }

                            newArr[newArr.Length - 1] = newName;
                            arr = newArr;

                            Console.WriteLine("Mehsul elave edildi");
                        }
                    }


                } while (isInvalid);
            }

            static void EditProduct(string[] products)
            {
                Console.Write("Mehsulu sechin: ");
                string indexStr = Console.ReadLine();

                try
                {
                    int index = Convert.ToInt32(indexStr);
                    Console.Write("Yeni ad daxil edin: ");
                    string newName = Console.ReadLine().Trim();

                    if (newName.Length < 2 || newName.Length > 20)
                    {
                        Console.WriteLine("Mehsul adi min 2 max 20 uzunlugunda olmalidir !");
                    }
                    else
                    {
                        products[index] = newName;
                        Console.WriteLine("Mehsul adi deyishdirildi");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Xeta bash verdi !");
                }


            }

            static void ChoosenProduct(ref string[] productNames)
            {
                Console.WriteLine("\nIndexi daxil edin");
                string indexStr = Console.ReadLine();
                try
                {
                    int index = Convert.ToInt32(indexStr);
                    Console.WriteLine($"Mehsul adi: {productNames[index]}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Xeta bash verdi !");
                }
            }
            static string[] RemoveElement(string[] arr, int index)
            {
                string[] newArr = new string[arr.Length - 1];
                for (int i = 0, j = 0; i < arr.Length; i++)
                {
                    if (i != index)
                    {
                        newArr[j++] = arr[i];
                    }
                }
                return newArr;
            }

            static void DeleteProduct(ref string[] arr)
            {
                Console.Write("Silmek istediyiniz mehsul indexi  daxil edin : ");
                string indexStr = Console.ReadLine();

                try
                {
                    int index = Convert.ToInt32(indexStr);

                    if (index >= 0 && index < arr.Length)
                    {
                        string deletedProductName = arr[index];
                        arr = RemoveElement(arr, index);
                        Console.WriteLine($"{deletedProductName} mehsul silindi.");
                    }
                    else
                    {
                        Console.WriteLine("Index duzgun deyil");
                    }
                }
                catch
                {
                    Console.WriteLine("Xeta bash verdi !");
                }
            }


        }
    }
}