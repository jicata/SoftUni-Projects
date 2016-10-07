namespace _01HarestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    class HarvestingFieldsTest
    {
        static void Main(string[] args)
        {
            //Type harvestingFieldsType = Type.GetType("_01HarestingFields.HarvestingFields");
            Type harvestingFieldsType = typeof(HarvestingFields);
            FieldInfo[] fields = harvestingFieldsType
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            FieldInfo[] privateFields = fields.Where(field => field.IsPrivate).ToArray();
            FieldInfo[] publicFields = fields.Where(field => field.IsPublic).ToArray();
            FieldInfo[] protectedFields = fields.Where(field => field.IsFamily).ToArray();

            string command = Console.ReadLine();
            while(command != "HARVEST")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                switch (command)
                {
                    case "private":
                        //TODO refactor to get access modifier with reflection
                        foreach (var field in privateFields)
                        {
                            Console.WriteLine("private {0} {1}", field.FieldType.Name, field.Name);
                        }
                        break;
                    case "public":
                        //TODO refactor to get access modifier with reflection
                        foreach (var field in publicFields)
                        {
                            Console.WriteLine("public {0} {1}", field.FieldType.Name, field.Name);
                        }
                        break;
                    case "protected":
                        //TODO refactor to get access modifier with reflection
                        foreach (var field in protectedFields)
                        {
                            Console.WriteLine("protected {0} {1}", field.FieldType.Name, field.Name);
                        }
                        break;
                    case "all": //TODO optimize
                        foreach (var field in fields)
                        {
                            if (field.IsFamily)
                            {
                                Console.WriteLine("protected {0} {1}", field.FieldType.Name, field.Name);
                            }
                            if (field.IsPrivate)
                            {
                                Console.WriteLine("private {0} {1}", field.FieldType.Name, field.Name);
                            }
                            if (field.IsPublic)
                            {
                                Console.WriteLine("public {0} {1}", field.FieldType.Name, field.Name);
                            }
                        }
                        break;
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                command = Console.ReadLine();
            }
        }
    }
}
