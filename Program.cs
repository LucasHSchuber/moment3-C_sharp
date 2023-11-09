using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Threading;


namespace GuestBookEntry
{
    class Program
    {

        public static List<GuestBookEntry> guestBookEntries = new List<GuestBookEntry>();

        const string FilePath = "json/posts.json"; //filename for storing messages/data


        static void Main(String[] args)
        {

            guestBookEntries = LoadData(); // Load data when the application starts


            while (true)
            {

                Console.Clear();

                Console.WriteLine("-----------------------------");
                Console.WriteLine("L U C A S  G Ä S T B O K ");
                Console.WriteLine("-----------------------------");
                Console.WriteLine(" ");

                // Console.WriteLine("Menu:");
                // Console.WriteLine("-----");
                Console.WriteLine("1. Add message");
                Console.WriteLine("2. Delete message");
                Console.WriteLine("3. Show all messages");
                // Console.WriteLine("4. Save guestbook");
                Console.WriteLine(" ");
                Console.WriteLine("X. Save and quit guestbook");


                Console.WriteLine(" ");

                Console.Write("Choose a number: ");
                String? choice = Console.ReadLine();

                //Loads all posts
                LoadData();

                switch (choice)
                {
                    case "1":
                        AddPost();
                        break;
                    case "2":
                        RemovePost();
                        break;
                    case "3":
                        ShowAllPosts();
                        break;
                    // case "4":
                    //     SaveData(guestBookEntries);
                    //     break;
                    case "x":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;

                }
            }
        }

        static void AddPost()
        {

            Console.WriteLine("--------------");
            Console.WriteLine("Add message:");
            Console.WriteLine("--------------");

            //checking so name is not null with while loop
            string name = String.Empty;
            while (String.IsNullOrEmpty(name))
            {

                Console.Write("Name: ");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty. Enter a name: ");
                    Console.WriteLine("Press X to close ");


                }
                //return to menu if user press X
                else if (name == "x")
                {
                    return;
                }

            }

            //checking so message is not null with while loop
            string message = String.Empty;
            while (String.IsNullOrEmpty(message))
            {

                Console.Write("Write a message: ");
                message = Console.ReadLine();

                if (string.IsNullOrEmpty(message))
                {
                    Console.WriteLine("Message cannot be empty. Write a message: ");
                    Console.WriteLine("Press X to close ");
                }
                //return to menu if user press X
                else if (message == "x")
                {
                    return;
                }

            }


            GuestBookEntry entry = new GuestBookEntry(name, message);
            guestBookEntries.Add(entry);

            SaveData(guestBookEntries);

            Console.WriteLine("Message written!");
            Thread.Sleep(500);
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();

        }


        static void ShowAllPosts()
        {

            if (guestBookEntries != null && guestBookEntries.Count > 0)
            {

                Console.WriteLine(" ");
                Console.WriteLine("--------------");
                Console.WriteLine("ALL MESSAGES:");
                Console.WriteLine("--------------");

                int Number = 1;
                foreach (var data in guestBookEntries)
                {
                    Console.WriteLine($"[{Number}] {data.Name} - {data.Message} ({data.Date})");
                    Number++; //Adding 1 to each message when printing them in console
                }
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Press enter to return to menu");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("----");
                Console.WriteLine("The guesbook is empty");
                Console.WriteLine("----");
                Thread.Sleep(1000);
                Console.WriteLine("Press enter to return to menu");
                Console.ReadLine();

            }

        }



        static void RemovePost()
        {

            if (guestBookEntries != null && guestBookEntries.Count > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("----------------");
                Console.WriteLine("DELETE MESSAGES:");
                Console.WriteLine("----------------");
                Console.WriteLine("Messages:");
                Console.WriteLine("---------");

                int Number = 1;
                foreach (var data in guestBookEntries)
                {
                    Console.WriteLine($"[{Number}] {data.Name} - {data.Message} ({data.Date})");
                    Number++; //Adding 1 to each message when printing them in console
                }

                Console.WriteLine("--------------------------------------------------------------");
                Console.Write("Delete message number: ");

                //Checking if delete-number is bigger than 0 and less or same as the length of guestbookentries.
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= guestBookEntries.Count)
                {
                    // guestBookEntries.RemoveAt(index);
                    //Making sure array index is the same as user index (since its starting at 0 and user starting at 1) 
                    int index_new = index - 1;
                    guestBookEntries.RemoveAt(index_new);

                    Console.Write("Deleting");
                    for (int i = 0; i < 3; i++)
                    {
                        Thread.Sleep(500);
                        Console.Write(".");
                    }

                    SaveData(new List<GuestBookEntry>());

                    Thread.Sleep(1000);
                    Console.WriteLine(" - The message has been deleted.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Press enter to return to menu");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Invalid index. Try again.");
                }

            }
            else
            {

                Console.WriteLine("----");
                Console.WriteLine("No messages to delete. The guesbook is empty");
                Console.WriteLine("----");
                Thread.Sleep(1000);
                Console.WriteLine("Press enter to return to menu");
                Console.ReadLine();

            }


        }


        static List<GuestBookEntry> LoadData()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<GuestBookEntry>>(json) ?? new List<GuestBookEntry>();
            }
            else
            {
                SaveData(new List<GuestBookEntry>());
                return new List<GuestBookEntry>();
            }
            // return new List<GuestBookEntry>();
        }


        static void SaveData(List<GuestBookEntry> entries)
        {
            string json = JsonConvert.SerializeObject(entries);
            File.WriteAllText(FilePath, json);
        }


        static void Exit()
        {

            SaveData(guestBookEntries);
            Console.Write("Saving");
            for (int i = 0; i < 3; i++) 
            {
                Thread.Sleep(500);
                Console.Write(".");
            }

            Thread.Sleep(300); 
            Console.WriteLine();
            Console.Write("Saved succesfully!");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.Write("Exiting guestbook. Bye bye!");
            //exiting application without error message {0}
            Environment.Exit(0);
        }
    }
}


