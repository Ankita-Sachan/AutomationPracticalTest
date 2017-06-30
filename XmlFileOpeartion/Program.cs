using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XmlFileOperation
{
    class Program
    {
        static void Main(string[] args)
        {


            string fileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Persons.xml");

            XmlOperations.CreateXmlFile(fileName);
            Console.WriteLine("Xml File has already been created.\nPath is " + fileName + ".\n\n");
            bool correct = true;
            int option;
            while (correct)
            {
                Console.WriteLine("\nSelect Following Option/s\n");

                Console.WriteLine("1 - Read the xml file.");
                Console.WriteLine("2 - Delete Node");
                Console.WriteLine("3 - Insert Node");
                Console.WriteLine("4 - Get Node");
                Console.WriteLine("5 - Exit\n");

                Console.WriteLine("Please provide valid input 1 or 2 or 3 or 4.\n");
                while (!Int32.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Please provide valid input 1 or 2 or 3 or 4.\n");
                }
                switch (option)
                {
                    case 1:
                        //Using XDocument
                        XmlOperations.ReadXml(fileName);
                        break;
                    case 2:
                        //Using XmlDocument
                        int id = Convert.ToInt32(Console.ReadLine());
                        XmlOperations.DeleteNode(fileName, id);
                        break;
                    case 3:
                        Person person = new Person();
                        Console.WriteLine("\nPlease Enter Id : ");
                        person.id = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("\nPlease Enter Name : ");
                        person.Name = Console.ReadLine();
                        Console.WriteLine("\nPlease Enter Age : ");
                        person.Age = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("\nPlease Enter Gender : ");
                        person.Gender = Console.ReadLine();
                        //XmlOperations.CheckIdsIsCorrect(ref id1, ref id2, ref id3);
                        XmlOperations.InsertNode(fileName, person);
                        break;
                    case 4:
                        Console.WriteLine("Please enter the person id-\n");
                        string personId = Console.ReadLine();
                        XmlOperations.GetNode(fileName, personId);
                        break;
                    case 5:
                        correct = false;
                        break;
                }
            }


        }
    }
    public class XmlOperations
    {
        public static void CreateXmlFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Person person = new Person();
                person.Name = "Ankita Sachan";
                person.Age = 25;
                person.Gender = "Female";

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("    ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(fileName, settings))
                {
                    writer.WriteStartElement("Persons");
                    writer.WriteStartElement("Person");
                    writer.WriteAttributeString("id", "1");
                    writer.WriteElementString("Name", person.Name);
                    writer.WriteElementString("Age", person.Age.ToString());
                    writer.WriteElementString("Gender", person.Gender);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.Flush();
                }
                Console.WriteLine("Xml File Path has been Created.\nPath is " + fileName + ".\n");
            }
        }
        public static void GetNode(string fileName, string id)
        {
            XmlDocument doc2 = new XmlDocument();
            doc2.Load(fileName);
            XmlNodeList nodes = doc2.GetElementsByTagName("Person");
            XmlNode xmlnode = doc2.SelectSingleNode("//Person[@id=\"" + id + "\"]");
            if (xmlnode != null)
            {
                foreach (XmlNode node in nodes)
                {
                    string personid = node.Attributes[0].Value;
                    string personName = node.ChildNodes[0].Value;
                    string personAge = node.ChildNodes[1].Value;
                    string personGender = node.ChildNodes[2].Value;
                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        Console.WriteLine(attribute.Name + ": " + attribute.Value + "\n");
                    }
                    foreach (XmlNode childnode in node.ChildNodes)
                    {

                        Console.WriteLine((childnode.ChildNodes[0].ParentNode).Name + ": " + childnode.ChildNodes[0].Value + "\n");
                    }

                }
            }
            else
                Console.WriteLine("id not wxist");

        }

        public static void DeleteNode(string fileName, int id)
        {
            Console.WriteLine("\n\nPlease Enter the id of the person you want to delete\n\n");

            XmlDocument doc1 = new XmlDocument();
            doc1.Load(fileName);
            XmlNode t = doc1.SelectSingleNode("Persons/Person[@id='" + id + "']");
            Console.WriteLine("OUTPUT\n");
            if (t == null)
            {
                Console.WriteLine("Not Exist");
            }

            else
            {
                t.ParentNode.RemoveChild(t);
                doc1.Save(fileName);
                Console.WriteLine("\nDeleted Successfully");
            }

        }

        public static void InsertNode(string fileName, Person person)
        {

            XmlDocument doc2 = new XmlDocument();
            doc2.Load(fileName);
            XmlNodeList nodes = doc2.GetElementsByTagName("Person");
            List<int> lstIds = new List<int>();
            foreach (XmlNode node in nodes)
            {
                lstIds.Add(Convert.ToInt16(node.Attributes[0].Value));
            }
            lstIds.Sort();
            int idAfter;
            if (person.id > lstIds[lstIds.Count - 1])
            {
                idAfter = lstIds[lstIds.Count - 1];
            }
            else if (lstIds.Contains(person.id))
            {
                Console.WriteLine("Node with this id alraedy exist");
                return;
            }
            else
            {
                int i = 0;
                while (person.id > lstIds[i])
                {
                    i++;
                }
                i = i - 1;
                idAfter = lstIds[i];

            }


            XmlNode xmlnode = doc2.SelectSingleNode("//Person[@id=\"" + idAfter + "\"]");
            XmlElement xmlElement = doc2.CreateElement("Person");
            xmlElement.SetAttribute("id", person.id.ToString());
            doc2.DocumentElement.InsertAfter(xmlElement, xmlnode);

            xmlnode = doc2.SelectSingleNode("//Person[@id=\"" + person.id + "\"]");
            XmlElement child = doc2.CreateElement("Name");
            child.Attributes.RemoveNamedItem("xmlns");
            child.InnerXml = person.Name;
            xmlnode.AppendChild(child);

            child = doc2.CreateElement("Age");
            child.InnerXml = person.Age.ToString();

            xmlnode.AppendChild(child);
            child = doc2.CreateElement("Gender");
            child.InnerXml = person.Gender;
            xmlnode.AppendChild(child);

            doc2.Save(fileName);
            Console.WriteLine("OUTPUT\n");
            Console.WriteLine("Added Successfully\n");


        }


        public static void ReadXml(string fileName)
        {
            XDocument doc = null;
            doc = XDocument.Load(fileName);
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                doc = XDocument.Load(reader);
            }
            var query = from d in doc.Root.Descendants("Person")
                        select d;
            Console.WriteLine("OUTPUT\n");
            foreach (var q in query)
            {
                Console.WriteLine("\nName:" + q.Element("Name").Value + " Age:" + q.Element("Age").Value + " Gender:" + q.Element("Gender").Value + "");
            }
        }
    }
    public class Person
    {
        public int id;
        public string Name;
        public string Gender;
        public int Age;

    }
}
