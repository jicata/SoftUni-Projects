namespace _06Twitter
{
    using Interfaces;
    using Models;

    class TwitterTest
    {
        static void Main(string[] args)
        {
            IMessage tweet = new Tweet("test msg");
            IWriter console = new ConsoleWriter();
            IClient microwave = new MicrowaveOven(console);
            microwave.RetrieveMessage(tweet);
        }
    }
}
