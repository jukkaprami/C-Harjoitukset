using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Libraries for serialization
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialisointi1
{
    // All classes to be saved into disk must be marked as serializable
    [Serializable]
    public class Student
    {
        // Fields with lower case 1st letter, these are private by scope
        string firstName;
        string lastName;
        string dateOfBirth;
        int startYear;
        string occupation;

        // Properties with uppercase 1st letter public by scope
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public int StartYear
        {
            get { return startYear; }
            set { startYear = value; }
        }
        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }

        }

        // Constructors
        // ------------

        // Default constructor, public 
        public Student()
        {
            this.firstName = "Etunimi";
            this.lastName = "Sukunimi";
            this.dateOfBirth = "1970-12-31";
            this.startYear = 2024;
            this.occupation = "Ohjelmistokehittäjä";

        }

        // Constructor with all arguments, public
        public Student(string firstName, string lastName, string dateOfBirth, int startYear, string occupation)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.startYear = startYear;
            this.occupation = occupation;

        }

        // Methods
        // -------
        // Method to echo all field values to the screen
        public void ShowStudentDetails()
        {
            Console.WriteLine("OPISKELIJAN TIEDOT");
            Console.WriteLine("------------------");
            Console.WriteLine("Tutkinto: " + this.occupation);
            Console.WriteLine("Etunimi: " + this.firstName);
            Console.WriteLine("Sukunimi: " + this.lastName);
            Console.WriteLine("Syntymäaika: " + this.dateOfBirth);
            Console.WriteLine("Aloitusvuosi: " + this.startYear);
        }

    }

    internal class Program
    {
        static void Main()
        {
            // Create an array of Student objects
            Student[] students = new Student[3];
            students[0] = new Student("Essi", "Esimerkki", "1997-11-20", 2023, "IT-tukihenkilö");
            students[1] = new Student("Jonne", "Janttari", "2017-05-15", 2022, "Ohjelmistokehittäjä");
            students[2] = new Student();

            // Create a binary formatter
            IFormatter formatter = new BinaryFormatter();

            // Create a stream for writting to the file
            Stream writeStream = new FileStream("StudentData.dat", FileMode.Create, FileAccess.Write);


            // Serialize to the file
            formatter.Serialize(writeStream, students);

            // Close the stream when finished serializing, if not closed prevents opening for reading later
            writeStream.Close();

            // Create a stream for reading data from the file
            Stream readStream = new FileStream("StudentData.dat", FileMode.Open, FileAccess.Read);

            // Create an array to store student data
            Student[] studentsFromDisk;

            // Deserialize from the file
            studentsFromDisk = (Student[])formatter.Deserialize(readStream);

            // Close the file after read operation
            readStream.Close();

            // Show all data in a loop
            foreach (var item in studentsFromDisk)
            {
                item.ShowStudentDetails();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}