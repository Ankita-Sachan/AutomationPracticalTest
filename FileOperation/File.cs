using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileOperation
{
    public static class TextFileOperation
    {
        static void Main(string[] args)
        {
            Operations opeartions = new Operations();
            bool correct = true;
            int option;
            while (correct)
            {                
                Console.WriteLine("\n/*****Select Following Option/s\n");
                Console.WriteLine("1 - Create file.");
                Console.WriteLine("2 - Search file");
                Console.WriteLine("3 - Rename file");
                Console.WriteLine("4 - Copy file");
                Console.WriteLine("5 - Delete file");
                Console.WriteLine("6 - Exit****/");

                Console.WriteLine("Please provide valid input 1 or 2 or 3 or 4 or 5.\n");
                while (!Int32.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Please provide valid input 1 or 2 or 3 or 4 or 5.\n");
                }
                switch (option)
                {
                    case 1:

                        Console.WriteLine("Please Enter the full path with directory and file-\n");
                        string fullPath = Console.ReadLine();
                        string data = "This is vfirst line . \r\n" +
             "This is the second line. next two line space \r\n\r\n" +
             "\t This comes after a tab space";
                        opeartions.CreateFile(fullPath, data);
                        break;
                    case 2:

                        Console.WriteLine("Please provide full directory path \n");
                        string dirPath = Console.ReadLine();
                        Console.WriteLine("Please provide file name which you want to search-\n");
                        string fileName = Console.ReadLine();
                        List<String> files = new List<String>();

                        files = opeartions.SearchFileInDirectory(dirPath, fileName);

                        if (files.Count > 0)
                        {
                            for (int i = 0; i < files.Count; i++)
                                Console.WriteLine(files[i]);
                        }


                        break;
                    case 3:

                        Console.WriteLine("Please provide the full path of file which you want to rename\n");
                        fullPath = Console.ReadLine();
                        try
                        {
                            if (Directory.Exists(Path.GetDirectoryName(fullPath)))
                            {
                                if (File.Exists(fullPath))
                                {

                                    Console.WriteLine("Please input new name of the file-");
                                    string newFileName = Console.ReadLine();
                                    fileName = Path.GetFileName(fullPath);
                                    string newFilePath = Path.Combine(Path.GetDirectoryName(fullPath), newFileName);
                                    if (!File.Exists(newFilePath))
                                    {
                                        opeartions.RenameFile(fullPath, newFilePath);
                                    }
                                    else
                                    {
                                        Console.WriteLine("New file name already exist in a directory.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("File doesn't exist");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Directory doesn't exist");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                        break;
                    case 4:
                        Console.WriteLine("Please provide the full path of the source with file name\n");
                        string sourceFilePath = Console.ReadLine();
                        try
                        {
                            if (File.Exists(sourceFilePath))
                            {
                                Console.WriteLine("Please provide the full path of the destination with file Name\n");
                                string destinationFilePath = Console.ReadLine();
                                opeartions.CopyFile(sourceFilePath, destinationFilePath);

                            }
                            else
                            {
                                Console.WriteLine("File doesn't exist");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                        break;
                    case 5:
                        Console.WriteLine("Please provide directory path. It will show you all the files in the directory\n\n\n");

                        string directory = Console.ReadLine();

                        try
                        {
                            if (Directory.Exists(directory))
                            {
                                string[] filePaths = Directory.GetFiles(directory);
                                foreach (string filePath in filePaths)
                                    Console.WriteLine(Path.GetFileName(filePath));
                                Console.WriteLine("\nPlease provide filename which You want to delete?\n");
                                fileName = Console.ReadLine();
                                opeartions.DeleteFile(directory, fileName);

                            }
                            else
                            {
                                Console.WriteLine("Directory doesn't exist");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                        break;
                    case 6:
                        correct = false;
                        break;
                }
            }

        }


    }
    public class Operations
    {
        public void CreateFile(string fullPath, string data)
        {

            if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            }

            try
            {
                if (string.IsNullOrEmpty(Path.GetFileName(fullPath)))
                {
                    Console.WriteLine("Please write file name with directory name.");
                    return;
                }
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                // Check if file already exists. If yes, delete it. 


                // Create a new file 
                using (FileStream fs = File.Create(fullPath))
                {
                    // Add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes(data);
                    fs.Write(title, 0, title.Length);

                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(fullPath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        public void DeleteFile(string directory, string fileName)
        {
            string fullFilePath = Path.Combine(directory, fileName);
            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
                Console.WriteLine("File deleted successfully");
            }
            else
            {
                Console.WriteLine("File doesn't exist in selected directory");
            }
        }
        public void RenameFile(string fullPath, string newFilePath)
        {
            if (File.Exists(fullPath))
            {
                File.Move(fullPath, newFilePath);
                Console.WriteLine("File renamed successfully");
            }
            else
                Console.WriteLine("File doesn't exist");
        }

        public void CopyFile(string sourceFilePath, string destinationFilePath)
        {
            if (!File.Exists(destinationFilePath))
            {

                File.Copy(sourceFilePath, destinationFilePath, true);
                Console.WriteLine("Copied Successfully");
            }
            else
            {
                Console.WriteLine("New file name already exist in a directory.");
            }
        }
        public List<String> SearchFileInDirectory(string rootDir, string fileName)
        {
            List<String> files = new List<String>();
            if (Directory.Exists(rootDir))
            {
                try
                {
                    foreach (string @f in Directory.GetFiles(rootDir))
                    {
                        if (f.Contains(fileName))
                            files.Add(f);
                    }
                    foreach (string d in Directory.GetDirectories(rootDir))
                    {
                        SearchFileInDirectory(d, fileName);

                        files.AddRange(SearchFileInDirectory(d, fileName));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return files;
        }
    }
}
