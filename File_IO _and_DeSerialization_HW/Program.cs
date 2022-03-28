using System;
using System.Xml.Serialization;


namespace File_IO_and_DeSerialization_HW
{
    public class Program
    {//
        static void Main(string[] args)
        {   //Ex 16
            #region Printing the first 10 direcories on my pc
            string[] myDirectories = Directory.GetDirectories(@"C:\", "*.*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine(myDirectories[i]);
                while (i == null)
                {
                    break;
                }


            }
            #endregion
            //Ex 17
            #region Print the 3 largest file name, size and last changing date
            GetDirAndPrintThe3largestfilesAndTheirLastChange(@"C:\Users\USER\Desktop\DotNet\מצגות וחומרים");
            #endregion

            Car c1 = new Car() { Brand = "Toyota", Color = "Red", Model = "AutoCars", Year = 2010 };
            Car c3 = new Car() { Brand = "Toyota", Color = "White", Model = "AutoCars", Year = 2014 };
            Car c4 = new Car() { Brand = "Toyota", Color = "Blue", Model = "Tranzit", Year = 2021 };
            Car c5 = new Car() { Brand = "Mercedes", Color = "Gray", Model = "MiniBus", Year = 2004 };
            Car c6 = new Car() { Brand = "Renu", Color = "Black", Model = "Private", Year = 2008 };

            string path = @"C:\Users\USER\Desktop\DotNet\HomeWork\File_IO_and_DeSerialization_HW\myXml.txt";
            string path2 = @"C:\Users\USER\Desktop\DotNet\HomeWork\File_IO_and_DeSerialization_HW\myXmlForArray.txt";
            //// export to xml file
            //using (Stream myStream = new FileStream(path, FileMode.Append))
            //{
            //    XmlSerializer xml = new XmlSerializer(typeof(Car));
            //    xml.Serialize(myStream, c1);

            //}
            //// import from xml file
            using (Stream myStream2 = new FileStream(path, FileMode.Open))
            {
                XmlSerializer DeXml = new XmlSerializer(typeof(Car));
                Car c2 = (Car)DeXml.Deserialize(myStream2);
            }

            //// export to xml file with array
            //using (Stream myStream3 = new FileStream(path2, FileMode.Append))
            //{
            //    XmlSerializer arrayXml = new XmlSerializer(typeof(Car[]));
            //    Car[] myCarArray = { c1, c3, c4, c5, c6 };
            //    arrayXml.Serialize(myStream3, myCarArray);
            //}

            //// import from xml file with array
            using(Stream myStream3 = new FileStream(path2,FileMode.Open))
            {
                XmlSerializer DeXmlForArray = new XmlSerializer(typeof(Car[]));
                Car[] newCarArray = (Car[])DeXmlForArray.Deserialize(myStream3);
            }

            Car c7 = new Car(path);

            //Car.SerilizeACar(@"C:\Users\USER\Desktop\DotNet\HomeWork\File_IO_and_DeSerialization_HW\staticSerializerAcar.txt", c5);
            Car.SerilizeCarArray(@"C:\Users\USER\Desktop\DotNet\HomeWork\File_IO_and_DeSerialization_HW\staticSerializerAcarArray.txt", new Car[] { c1, c3, c6 });

            Car c8 = Car.DeSerilizeACar(path);

            Car[] c9 = Car.DeSerilizeCarArray(@"C:\Users\USER\Desktop\DotNet\HomeWork\File_IO_and_DeSerialization_HW\myXmlForArray.txt");
            Console.WriteLine(c8.CarCompare(@"C:\Users\USER\Desktop\DotNet\HomeWork\File_IO_and_DeSerialization_HW\staticSerializerAcar.txt"));
        }

        public static void GetDirAndPrintThe3largestfilesAndTheirLastChange(string dirName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(dirName);
            List<FileInfo> myFiles = directoryInfo.GetFiles().ToList();          
            List<FileInfo> myList2 = myFiles.OrderBy(FileInfo => FileInfo.Length).Reverse().ToList();
            Console.WriteLine($"Name: {myList2[0].Name}\nLenght: {myList2[0].Length}\n {myList2[0].LastWriteTime}");
            Console.WriteLine($"Name: {myList2[1].Name}\nLenght: {myList2[1].Length}\n {myList2[1].LastWriteTime}");
            Console.WriteLine($"Name: {myList2[2].Name}\nLenght: {myList2[2].Length}\n {myList2[2].LastWriteTime}");

        }
    }
}
