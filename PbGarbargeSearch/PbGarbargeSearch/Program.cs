using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbGarbargeSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wsObjectsPath = "F:\\LongBow\\MASTER\\Longbow2022v1";
            List<string> files = Directory.GetFiles(wsObjectsPath + "\\ws_objects", "*", SearchOption.AllDirectories).ToList();
            List<string> unused = new List<string>();

            foreach (string objectFile in files)
            {
                bool uses = false;
                string[] splitted = objectFile.Split('\\', '.');
                string objectName = splitted[splitted.Length - 2];

                foreach (string file in files)
                {
                    if (file == objectFile)
                    {
                        continue;
                    }

                    string[] allText = File.ReadAllLines(file);

                    foreach (string text in allText)
                    {
                        if (text.Contains(objectName + "") || text.Contains("\"" + objectName + "\""))
                        {
                            uses = true;
                            continue;
                        }

                        //if ( (text.Contains(".dataobject=") || text.Contains(".dataobject =")) && text.Contains("+"))
                        //{
                        //    Console.WriteLine(text);
                        //}

                    }
                }

                if (!uses)
                {
                    unused.Add(objectFile);
                    Console.WriteLine(objectFile);
                }                
            }

            File.WriteAllLines("out.txt", unused);
            Console.ReadLine();
        }
    }


}
