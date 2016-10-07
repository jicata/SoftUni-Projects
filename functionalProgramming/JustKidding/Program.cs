namespace JustKidding
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
       
        static void Main()
        {
            Dictionary<string, HashSet<Method>> methodsByClass = new Dictionary<string, HashSet<Method>>();
            string pattern = "^([A-Z][a-zA-Z0-9]+)\\s\\|\\s([A-Z][a-zA-Z0-9]+)\\s\\|\\s([A-Z][a-zA-Z0-9]+)$";
            Regex matcher = new Regex(pattern);
            
            string inputLine = Console.ReadLine();
            while (inputLine != "It's testing time!")
            {
                
                if (matcher.IsMatch(inputLine))
                {
                    Match matched = matcher.Match(inputLine); 
                    string className = matched.Groups[1].Value;
                    string methodName = matched.Groups[2].Value;
                    string unitTestName = matched.Groups[3].Value;
                    
                    if (!methodsByClass.ContainsKey(className))
                    {
                        methodsByClass.Add(className, new HashSet<Method>());
                        var method = new Method(methodName);
                        var unitTest = new UnitTest(unitTestName);
                        method.UnitTests.Add(unitTest);
                        methodsByClass[className].Add(method);
                    }
                    else if (methodsByClass.ContainsKey(className) &&
                             !methodsByClass[className].Any(x => x.Name == methodName))
                    {  
                        var method = new Method(methodName);
                        var unitTest = new UnitTest(unitTestName);
                        method.UnitTests.Add(unitTest);
                        methodsByClass[className].Add(method);
                    }
                    else if (methodsByClass.ContainsKey(className)
                             && methodsByClass[className].Any(x => x.Name == methodName)
                             && !methodsByClass[className].First(x => x.Name == methodName).UnitTests.Any(x=>x.Name == unitTestName))
                    {
                        var existingMethod = methodsByClass[className].First(m => m.Name == methodName);
                        var unitTest = new UnitTest(unitTestName);
                        existingMethod.UnitTests.Add(unitTest);
                    }
                }
                inputLine = Console.ReadLine();
            }

            var sorted =
                methodsByClass.OrderByDescending(x => methodsByClass[x.Key].Sum(ut => ut.UnitTests.Count))
                    .ThenBy(s => s.Value.Count)
                    .ThenBy(s => s.Key,StringComparer.Ordinal);
                   
           
            foreach (var classes in sorted)
            {
                Console.WriteLine(classes.Key+":");
                var itemz = methodsByClass[classes.Key].OrderByDescending(x => x.UnitTests.Count)
                    .ThenBy(x => x.Name, StringComparer.Ordinal);
                foreach (var method in itemz)
                {
                    Console.WriteLine("##" + method.Name);
                    var items = methodsByClass[classes.Key].First(x => x.Name == method.Name).UnitTests;
                    var kur = items.OrderBy(x => x.Name.Length).ThenBy(x => x.Name,StringComparer.Ordinal).ToList();
                    foreach (var unitTest in kur)
                    {
                        Console.WriteLine("####"+unitTest.Name);
                    }
                }
            }
        }
    }

    public class Method : IComparable<Method>
    {
        private string name;
        private HashSet<UnitTest> unitTests;

        public Method(string name)
        {
            this.Name = name;
            this.UnitTests = new HashSet<UnitTest>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public HashSet<UnitTest> UnitTests
        {
            get
            {
                return unitTests;
            }

            set
            {
                unitTests = value;
            }
        }

        public int CompareTo(Method other)
        {
            int result = 0;
            if (this.UnitTests.Count > other.unitTests.Count)
            {
                result = 1;
            }
            else if (this.UnitTests.Count < other.unitTests.Count)
            {
                result = -1;
            }
            else
            {
                StringComparer sc = StringComparer.Ordinal;
                result = sc.Compare(this.Name, other.Name);
            }
            return result;
        }
    }

    public class UnitTest : IComparable<UnitTest>
    {
        public UnitTest(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int CompareTo(UnitTest other)
        {
            int result = this.Name.Length.CompareTo(other.Name.Length);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }
            return result;
        }
    }
}
