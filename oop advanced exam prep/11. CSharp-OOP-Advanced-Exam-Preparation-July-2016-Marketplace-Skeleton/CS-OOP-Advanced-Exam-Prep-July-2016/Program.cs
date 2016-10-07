namespace CS_OOP_Advanced_Exam_Prep_July_2016
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Parser;

    public class Program
    {
        static void Main(string[] args)
        {
            IParser parser = new AttributeParser();
            parser.Parse();
        }
    }
}
