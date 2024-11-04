namespace Behavioral_Mediator_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            IChatRoomMediator chatRoom = new ChatRoom();
            User user1 = new User(chatRoom, "Sam");
            User user2 = new User(chatRoom, "Pam");

            user1.SendMessage("Hi Pam");
            user2.SendMessage("Hi Sam, Hello Pam my friend");

            Console.ReadKey();
        }
    }
}
