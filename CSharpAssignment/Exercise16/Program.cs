using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise16
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:/FileOperations";
            System.Console.WriteLine("Enter the directory(example:C:/FileOperations)");
            path = System.Console.ReadLine();
            System.Console.WriteLine("");
            if (Directory.Exists(path)) {
                DirectoryInfo mydir = new DirectoryInfo(path);
                FileInfo[] txtfiles = mydir.GetFiles("*.txt", SearchOption.AllDirectories);
                System.Console.WriteLine("a) Total number of text files(.txt) in the directory are : {0}", txtfiles.Length);
                System.Console.WriteLine("   Names of the text files are :");
                foreach (FileInfo file in txtfiles) { 
                    System.Console.WriteLine("     " + file.Name);
                }
                var total_files = mydir.EnumerateFiles("*.*", SearchOption.AllDirectories)
                              .GroupBy(x => x.Extension)
                              .Select(a => new { Extension = a.Key, Count = a.Count() })
                              .ToList();
                System.Console.WriteLine("");
                System.Console.WriteLine("b) Number of files per extension type are :");
                foreach (var group in total_files) { 
                    System.Console.WriteLine($"      There are {group.Count} files with extension {group.Extension}");
                }
                System.Console.WriteLine("");
                var result = mydir.GetFiles().OrderByDescending(x => x.Length).Take(5).ToList();
                System.Console.WriteLine("c) The 5 largest file with their size are :");
                foreach(var i in result)
                {
                    System.Console.WriteLine($"      The file \"{i.Name}\" has size {i.Length}.");
                }
                long max_length = 0;
                FileInfo index = null;
                FileInfo[] txtfiles1 = mydir.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                foreach (var i in txtfiles1) { 
                    if (i.Length > max_length) { 
                        index = i;
                        max_length = i.Length;
                    }
                }
                System.Console.WriteLine("");
                System.Console.WriteLine($"d) The file \"{index.Name }\" has the maximum length of {index.Length} bytes.");
                System.Console.WriteLine("");
            }
            else
            {
                System.Console.WriteLine("Directory does not exist.");
            }
          
        }
    }
}
