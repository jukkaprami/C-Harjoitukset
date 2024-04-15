﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Libraries needed to access SQL Server
using System.Data;
using System.Data.SqlClient;

// Libraries used when converting dates
using System.Globalization;


namespace DeviceDb
{
    // CLASS DEFINITIONS FOR DIFFERENT DEVICE TYPES
    // --------------------------------------------

    // A super class for all kind of devices
    // =====================================
    class Device
    {
        // Fields and properties
        // ----------------------

        string name = "Uusi laite";

        public string Name { get { return name; } set { name = value; } }

        string purchaseDate = "1.1.1900";
        public string PurchaseDate { get { return purchaseDate; } set { purchaseDate = value; } }


        double price = 0.0d;
        public double Price { get { return price; } set { price = value; } }

        int warranty = 12;
        public int Warranty { get { return warranty; } set { warranty = value; } }


        string processorType = "N/A";
        public string ProcessorType { get { return processorType; } set { processorType = value; } }

        int amountRAM = 0;
        public int AmountRam { get { return amountRAM; } set { amountRAM = value; } }

        int storageCapacity = 0;
        public int StorageCapacity { get { return storageCapacity; } set { storageCapacity = value; } }

        // Constructors
        // -------------

        public Device()
        {

        }

        public Device(string name)
        {
            this.name = name;
        }

        public Device(string name, string purchaseDate, double price, int warranty)
        {
            this.name = name;
            this.purchaseDate = purchaseDate;
            this.price = price;
            this.warranty = warranty;
        }

        // Other methods in the superclass
        // ------------
        public void ShowPurchaseInfo()
        {
            // Show purchasing data
            Console.WriteLine();
            Console.WriteLine("Laitteen hankintatiedot");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Laitteen nimi: " + this.name);
            Console.WriteLine("Ostopäivä: " + this.purchaseDate);
            Console.WriteLine("Hankinta: " + this.price);
            Console.WriteLine("Takuu: " + this.warranty + " kk");
        }

        // Show technical data
        public void ShowBasicTechnicalInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Laitteen tekniset tiedot");
            Console.WriteLine("------------------------");
            Console.WriteLine("Koneen nimi: " + Name);
            Console.WriteLine("Prosessori: " + ProcessorType);
            Console.WriteLine("Keskusmuisti: " + AmountRam);
            Console.WriteLine("Levytila: " + StorageCapacity);

        }

        // Calculate the ending date of warranty
        public void CalculateWarrantyEndingDate()
        {
            // Convert date sring to date time
            DateTime startDate = DateTime.ParseExact(this.PurchaseDate,
                                        "yyyy-MM-dd",
                                         CultureInfo.InvariantCulture);

            // Add warranty months to purchase date
            DateTime endDate = startDate.AddMonths(this.Warranty);

            // Convert it to ISO standard format
            endDate = endDate.Date;

            string isoDate = endDate.ToString("yyyy-MM-dd");

            Console.WriteLine("Takuu päättyy: " + isoDate);
        }

    }

    // Compurer class, a subclass of Device
    // ====================================
    class Computer : Device
    {

        // Constructors
        // ------------
        public Computer() : base()
        { }

        public Computer(string name) : base(name)
        { }


    }

    // Tablet class, a subclass of Device
    // ====================================
    class Tablet : Device
    {
        // subclass specific fields and properties
        // ---------------------------------------

        string operatingSystem;
        public string OperatingSystem { get { return operatingSystem; } set { operatingSystem = value; } }
        bool stylusEnabled = false;
        public bool StylusEnabled { get { return stylusEnabled; } set { stylusEnabled = value; } }

        // Constructors
        // --------------

        public Tablet() : base() { }

        public Tablet(string name) : base(name) { }


        // Methods specific to Tablet class
        // ----------------------------
        public void TabletInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Tabletin erityitiedot");
            Console.WriteLine("---------------------");
            Console.WriteLine("Käyttöjärjestelmä: " + OperatingSystem);
            Console.WriteLine("Kynätuki: " + StylusEnabled);
        }

    }
    // THE PROGRAM
    // ===========
    internal class Program
    {


        static void Main(string[] args)
        {
            // For ever loop to run the program
            while (true)
            {
                Console.WriteLine("Minkä laitteen tietot tallenetaan?");
                Console.Write("1 tietokone, 2 tabletti ");
                string type = Console.ReadLine();

                // Choises for different type of devices
                switch (type)
                {
                    case "1":

                        // Prompt user to enter device information
                        Console.Write("Nimi: ");
                        string computerName = Console.ReadLine();
                        Computer computer = new Computer(computerName);
                        Console.Write("Ostopäivä muodossa vvvv-kk-pp: ");
                        computer.PurchaseDate = Console.ReadLine();
                        Console.Write("Hankintahinta: ");
                        string price = Console.ReadLine();

                        // Use error handling while trying to convert string values to numerical values
                        try
                        {
                            computer.Price = double.Parse(price);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen hintatieto, käytä desimaalipilkkua (,)" + ex.Message);

                            break;
                        }

                        Console.Write("Takuun kesto kuukausina: ");
                        string warranty = Console.ReadLine();

                        try
                        {
                            computer.Warranty = int.Parse(warranty);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen takuutieto, vain kuukausien määrä kokonaislukuna " + ex.Message);
                            break;
                        }

                        Console.Write("Prosessorin tyyppi: ");
                        computer.ProcessorType = Console.ReadLine();
                        Console.Write("Keskumuistin määrä (GB): ");
                        string amountRam = Console.ReadLine();

                        try
                        {
                            computer.AmountRam = int.Parse(amountRam);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen muistin määrä, vain kokonaisluvut sallittu " + ex.Message);
                            break;
                        }

                        Console.Write("Tallennuskapasiteetti (GB): ");
                        string storageCapacity = Console.ReadLine();

                        try
                        {
                            computer.StorageCapacity = int.Parse(storageCapacity);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen tallennustilan koko, vain kokonaisluvut sallittu " + ex.Message);
                            break;
                        }



                        // Use methods to show entered values
                        computer.ShowPurchaseInfo();
                        computer.ShowBasicTechnicalInfo();

                        try
                        {
                            computer.CalculateWarrantyEndingDate();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ostopäivä virheellinen " + ex.Message);
                            break;
                        }

                        // Add the computer to Device table
                        Console.WriteLine("Lisätään tietokone Laite-tauluun");

                        // Create a connection to DB server
                        // --------------------------------

                        // Conncection string to the database using Windows authentication
                        string connectionString = "Data Source=DESKTOP-2Q0KJ7B\\SQLEXPRESS;Initial Catalog=Laiterekisteri;Integrated Security=True";

                        // Convert all data types to a string, add quotes to original string values
                        string valuesString = "'" + computer.Name + "', " + computer.Price.ToString() + ", '" + computer.PurchaseDate + "', " + computer.Warranty.ToString() + ", '" + computer.ProcessorType + "', " + computer.AmountRam.ToString() + ", " + computer.StorageCapacity.ToString() + ", " + "'Tietokone'";

                        string insertCommand = "INSERT INTO dbo.Laite (Nimi, Hankintahinta, Hankintapaiva, Takuu, Prosessori, Keskusmuisti, Tallennustila, Laitetyyppi) VALUES(" + valuesString + ");";

                        // More readable way to create the SQL clause
                        string insertCommand2 = $"INSERT INTO dbo.Laite (Nimi, Hankintahinta, Hankintapaiva, Takuu, Prosessori, Keskusmuisti, Tallennustila, Laitetyyppi) VALUES('{computer.Name}', {computer.Price}, '{computer.PurchaseDate}', {computer.Warranty}, '{computer.ProcessorType}', {computer.AmountRam}, {computer.StorageCapacity}, 'Tietokone');";

                        // Connect to the database inside using clause (to 
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(insertCommand2, connection);
                            // Execute the sql clause, no result set
                            command.ExecuteNonQuery();
                            connection.Close();
                        }

                        break;

                    case "2":
                        Console.Write("Nimi: ");
                        string tabletName = Console.ReadLine();
                        Tablet tablet = new Tablet(tabletName);
                        break;


                    default:
                        Console.WriteLine("Virheellinen valinta, anna pelkkä numero");
                        break;
                }
                // End the program, exit the loop
                Console.WriteLine("Haluatko jatkaa K/e");
                string continueAnswer = Console.ReadLine();
                continueAnswer = continueAnswer.Trim();
                continueAnswer = continueAnswer.ToLower();
                if (continueAnswer == "e")
                {
                    // Conncection string to the database using Windows authentication
                    string connectionString = "Data Source=DESKTOP-2Q0KJ7B\\SQLEXPRESS;Initial Catalog=Laiterekisteri;Integrated Security=True";
                    // Query only systems with processor information to avoid nulle exception.
                    string sqlQuery = "SELECT Nimi, Prosessori, Keskusmuisti, Tallennustila, Laitetyyppi FROM dbo.Laite WHERE Prosessori IS NOT NULL;";
                    // Select all from Laite table
                    // Connect to the database inside using clause (to 
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        connection2.Open();
                        SqlCommand command = new SqlCommand(sqlQuery, connection2);
                        command.CommandTimeout = 10;
                        // Execute the sql clause using reader
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4));
                        }

                        connection2.Close();

                        break;
                    }
                }

                Console.ReadLine();
            }

        }
    }
}