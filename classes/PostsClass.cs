using System;

namespace GuestBookEntry
{

    [Serializable] 

    public class GuestBookEntry
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; private set; } 

        //Custructor -- Constructors have the same name as the class and do not have a return type.
        public GuestBookEntry(string name, string message)
        {
            Name = name;
            Message = message;
            Date = DateTime.Now;
        }

    }
}