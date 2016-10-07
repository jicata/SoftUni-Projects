namespace _08PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    class Program
    {
        static void Main()
        {
            Dictionary<string, Pet> pets = new Dictionary<string, Pet>();
            Dictionary<string, Clinic> clinics = new Dictionary<string, Clinic>();


            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                string[] parameters = line.Split();
                switch (parameters[0])
                {
                    case "Create":
                        if (parameters[1] == "Pet")
                        {
                            Pet pet = new Pet(parameters[2], int.Parse(parameters[3]), parameters[4]);
                            pets[pet.Name] = pet;
                        }
                        else if (parameters[1] == "Clinic")
                        {
                            try
                            {
                                Clinic clinic = new Clinic(int.Parse(parameters[3]));
                                clinics[parameters[2]] = clinic;
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine("Invalid Operation!");
                                
                            }
                        }
                        break;
                    case "Add":
                        {
                            Pet pet = pets[parameters[1]];
                            Clinic clinic = clinics[parameters[2]];
                            Console.WriteLine(clinic.Add(pet));
                            break;
                        }
                    case "Release":
                        {
                            Clinic clinic = clinics[parameters[1]];
                            Console.WriteLine(clinic.Release());
                            break;
                        }
                    case "HasEmptyRooms":
                        {
                            Clinic clinic = clinics[parameters[1]];
                            Console.WriteLine(clinic.HasEmptyRooms());
                            break;
                        }
                    case "Print":
                        {
                            Clinic clinic = clinics[parameters[1]];
                            if (parameters.Length == 2)
                            {
                                Console.WriteLine(clinic.Print());
                            }
                            else if (parameters.Length == 3)
                            {
                                Console.WriteLine(clinic.Print(int.Parse(parameters[2])));
                            }
                            break;
                        }
                }
            }
        }
    }
}
