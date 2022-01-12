using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace users_parsing
{


    class Program
    {
        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Company { get; set; }
        }

        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            const string Filename = @"C:\Users\anatolii.butko\source\repos\users_parsing\users.xml";
            xDoc.Load(Filename);
            List<User> users = new List<User>();
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    User user = new User();
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    user.Name = attr?.Value;

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "company")
                            user.Company = childnode.InnerText;

                        if (childnode.Name == "age")
                            user.Age = int.Parse(childnode.InnerText);
                    }
                    users.Add(user);
                }
                foreach (User u in users)
                    Console.WriteLine($"{u.Name} ({u.Company}) - {u.Age}");
            }


            
        }
    }
}
