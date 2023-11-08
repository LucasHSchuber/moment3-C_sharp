using System;

namespace GuestBookEntry
{

    [Serializable] // Markerar klassen som serialiserbar

    public class GuestBookEntry
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; private set; } //"private" can be set from within the class, and not modified from outside the class

        //Custructor -- Constructors have the same name as the class and do not have a return type.
        public GuestBookEntry(string name, string message)
        {
            Name = name;
            Message = message;
            Date = DateTime.Now;
        }

    }
}