namespace Behavioral_ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ISupportHandler levelOne = new LevelOneSupport();
            ISupportHandler levelTwo = new LevelTwoSupport();
            ISupportHandler levelThree = new LevelThreeSupport();

            levelOne.SetNext(levelTwo).SetNext(levelThree);

            levelOne.HandleRequest("Simple issue");
            levelOne.HandleRequest("Complex issue");
            levelOne.HandleRequest("Very complex issue");
            levelOne.HandleRequest("unknown issue");
        }
    }
}
