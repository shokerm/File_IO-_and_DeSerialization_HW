using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace File_IO_and_DeSerialization_HW
{//
    //
    public class Car
    {//
        //Properties
        public string Model { get; set; }
        public string Brand { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        private int Codan { get; set; }

        protected int numberOfSeats;

        //Ctorstructors
        public Car()
        {
        }

        public Car(string fileName)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car));
                Car car = (Car)xml.Deserialize(myStream);
                this.Model = car.Model;
                this.Year = car.Year;
                this.Color = car.Color;
                this.Codan = car.Codan;
                this.Brand = car.Brand;
                this.numberOfSeats = car.numberOfSeats;
            }

        }
        public Car(string model, string brand, int year, string color, int codan, int numberOfSeats)
        {
            Model = model;
            Brand = brand;
            Year = year;
            Color = color;
            Codan = codan;
            this.numberOfSeats = numberOfSeats;
        }
        //Funtions
        public int GetCodan(Car car)
        {
            return car.Codan;
        }

        public int GetNumberOfSeats(Car car)
        {
            return car.numberOfSeats;
        }

        public void ChangeNumberOfSeats(Car car, int newNumberOfSeats)
        {
            car.numberOfSeats = newNumberOfSeats;
        }

        public static void SerilizeACar(string fileName, Car car)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Append))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car));
                xml.Serialize(myStream, car);
            }
        }

        public static void SerilizeCarArray(string fileName, Car[] car)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Append))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car[]));
                xml.Serialize(myStream, car);
            }
        }

        public static Car DeSerilizeACar(string fileName)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer Dxml = new XmlSerializer(typeof(Car));
                Car xmlImporteredCar = (Car)Dxml.Deserialize(myStream);
                return xmlImporteredCar;
            }

        }

        public static Car[] DeSerilizeCarArray(string fileName)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer DxmlArray = new XmlSerializer(typeof(Car[]));

                Car[] xmlImporteredCarArray = (Car[])DxmlArray.Deserialize(myStream);
                return xmlImporteredCarArray;
            }

        }

        public bool CarCompare(string fileName)
        {
            using (Stream myStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer Dxml = new XmlSerializer(typeof(Car));
                Car xmlImporteredCar = (Car)Dxml.Deserialize(myStream);
                if (JsonSerializer.Serialize(xmlImporteredCar) == JsonSerializer.Serialize(this))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return true;
        }

        //Override
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
