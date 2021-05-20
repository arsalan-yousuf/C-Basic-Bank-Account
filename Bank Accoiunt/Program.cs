using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Bank_Accoiunt
{
    class Customer
    {
        protected string name,CNIC,contact,address,title,type,carname,line;
        protected double income, balance,carprice=0,downpay=0,monthly=0;
        protected int accnumber,years;
        protected string[] data=new string[]{};
        public string newline;
        public int c = 0,p=0;
        public Customer()
        {
            Console.WriteLine();
        }
        protected void getdata()
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
            {
                int index = 0;
                while ((data[index] = sr.ReadLine()) != null)
                {
                    /*data[index] = line;*/
                    index++;
                }
            }
            Console.WriteLine(data.Length);
        }
        protected void putdata()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
            {
                int index;
                for (index = 0; index < (data.Length); index++)
                {
                    sw.WriteLine(data[index]);
                }
            }
        }
        protected void getline(int a)
        {
            
            using (StreamReader sr = new StreamReader(@"c:\users\open\documents\visual studio 2010\Projects\edit txt\edit txt\TextFile1.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    char[] delimiters = new char[] { ',' };
                    string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    if (int.Parse(parts[0]) == a)
                    {
                        break;
                    }
                }
            }
        }
        public Customer(string acc)
        {
            
            using (StreamReader sr = new StreamReader(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                char[] delimiters = new char[] { ',' };
                                string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                if (parts[0] == acc)
                                {
                                    p++;
                                    if (parts[1] == "M")
                                    {
                                        accnumber = int.Parse(parts[0]);
                                        type = parts[1];
                                        title = parts[2];
                                        name = parts[3];
                                        CNIC = parts[4];
                                        contact = parts[5];
                                        balance = double.Parse(parts[6]);
                                        address = parts[7];
                                    }
                                    else
                                    {
                                        if (parts.Length > 9)
                                        {
                                            accnumber = int.Parse(parts[0]);
                                            type = parts[1];
                                            title = parts[2];
                                            name = parts[3];
                                            CNIC = parts[4];
                                            contact = parts[5];
                                            balance = double.Parse(parts[6]);
                                            income = double.Parse(parts[7]);
                                            address = parts[8];
                                            carname = parts[9];
                                            carprice = double.Parse(parts[10]);
                                            downpay = double.Parse(parts[11]);
                                            years = int.Parse(parts[12]);
                                            monthly = double.Parse(parts[13]);
                                        }
                                        else
                                        {
                                            accnumber = int.Parse(parts[0]);
                                            type = parts[1];
                                            title = parts[2];
                                            name = parts[3];
                                            CNIC = parts[4];
                                            contact = parts[5];
                                            balance = double.Parse(parts[6]);
                                            income = double.Parse(parts[7]);
                                            address = parts[8];
                                        }
                                    }
                                    break;
                                }
                             }
                            if (p == 0) Console.WriteLine("Account doesnot exist");
                         }
            }
        public void Inquiry()
        {
            Console.WriteLine("Current Balance: Rs.{0}",balance);
        }
        public void Deposit()
        {
            double dep;
            Console.Write("Enter depositing amount: ");
            dep = double.Parse(Console.ReadLine());
            if (dep > 0)
            {
                c++;
                balance = balance + dep;
                Console.WriteLine("Amount Deposited\nNew Balance = {0}", balance);
                if (type == "M")
                {
                    newline = accnumber + "," + type + "," + title + "," + name + "," + CNIC + "," + contact + "," + balance + "," + address;
                }
                else
                {
                    if (carprice != 0)
                    {
                        newline = accnumber + "," + type + "," + title + "," + name + "," + CNIC + "," + contact + "," + balance + "," + income + "," + address + "," + carname + "," + carprice + "," + downpay + "," + years + "," + monthly;
                    }
                    else
                    {
                        newline = accnumber + "," + type + "," + title + "," + name + "," + CNIC + "," + contact + "," + balance + "," + income + "," + address;
                    }
                }
            }
            else Console.WriteLine("\nInvalid Amount Entered!");
        }
        public void Withdraw()
        {
            double with;
            Console.Write("Enter withdrawal amount: ");
            with = double.Parse(Console.ReadLine());
            if (with < balance && with > 0)
            {
                if (type == "B")
                {
                    if ((balance - with) < 25000)
                    {
                        Console.Write("Balance getting less than Rs.25,000!, Proceed transaction (Y/N):");
                        if (Console.ReadLine() == "Y")
                        {
                            c++;
                            balance = balance - with;
                            Console.WriteLine("\nAmount Withdrawed\nNew Balance = Rs.{0}", balance);
                        }
                        else Console.WriteLine("\nThank You\nCurrent Balance = Rs.{0}", balance);
                    }
                    else
                    {
                        c++;
                        balance = balance - with;
                        Console.WriteLine("\nAmount Withdrawed\nNew Balance = Rs.{0}", balance);
                    }
                }
                else
                {
                    c++;
                    balance = balance - with;
                    Console.WriteLine("\nAmount Withdrawed\nNew Balance = Rs.{0}", balance);
                }
                if (type == "M")
                {
                    newline = accnumber + "," + type + "," + title + "," + name + "," + CNIC + "," + contact + "," + balance + "," + address;
                }
                else
                {
                    if (carprice != 0)
                    {
                        newline = accnumber + "," + type + "," + title + "," + name + "," + CNIC + "," + contact + "," + balance + "," + income + "," + address + "," + carname + "," + carprice + "," + downpay + "," + years + "," + monthly;
                    }
                    else
                    {
                        newline = accnumber + "," + type + "," + title + "," + name + "," + CNIC + "," + contact + "," + balance + "," + income + "," + address;
                    }
                }
            }
            else Console.WriteLine("\nInvalid or greater amount entered");
        }
        
        public void car()
        {
            if (type != "M")
            {
                if (income >= 20000)
                {
                    c++;
                    Console.Write("Enter name of car: ");
                    carname = Console.ReadLine();
                    Console.Write("Car price(Rs.): ");
                    carprice = double.Parse(Console.ReadLine());
                    Console.Write("Down payment in rupees(min 20%): ");
                    downpay = double.Parse(Console.ReadLine());
                    Console.Write("Tenure(1-7 Years): ");
                    years = int.Parse(Console.ReadLine());
                    monthly = (carprice - downpay) / (years * 12);
                    Console.WriteLine("\nDescription:\nPrice of Car: Rs.{0}\nTotal Down Payment + Processing fee(i.e. Rs. 5000): Rs.{1}\nNumber of monthly installments: {2}\nMonthly repayment: Rs.{3}",carprice,downpay+5000,years*12,monthly);
                    
                }
                else Console.WriteLine("Sorry, Car financing not available for person with monthly income less than Rs.20,000");
            }
            else Console.WriteLine("\nSorry, Car financing not available for Minor account type.");
            newline = "," + carname + "," + carprice + "," + downpay + "," + years*12 + "," + monthly;
        }
    }
    class Admin : Customer
    {

        public Admin()
        {
            Console.WriteLine("** ADMIN PANEL **\nUsername: Arsalan");
        }
        public void create(int account)                                                                    // public
        {
            Console.WriteLine("\nAccount type:\n'S'\tSaving Account\n'C'\tCurrent Account\n'B'\tBusiness Plus Account\n'M'\tMinor Account\n");
            Console.Write("Enter alphabet of desired type: ");
            type = Console.ReadLine();
            accnumber = account;
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter your CNIC/B-Form number (13 digits): ");
            CNIC = Console.ReadLine();
            Console.Write("Enter Contact number: ");
            contact = Console.ReadLine();
            Console.Write("Enter residential adddress: ");
            address = Console.ReadLine();
            Console.Write("Enter account title: ");
            title = Console.ReadLine();
            if (type != "M")
            {
                Console.Write("Enter monthly income: ");
                income = double.Parse(Console.ReadLine());
            }
            if (type == "S") Console.Write("Depositing amount(minimum Rs.100): ");
            else if (type == "C") Console.Write("Depositing amount(minimum Rs.1000): ");
            else if (type == "B") Console.Write("NOTE: Free services available only if an average monthly balance of Rs.25,000 is maintained in the account\nDepositing amount(minimum Rs.100): ");
            else if (type == "M") Console.Write("Depositing amount(minimum Rs.500): ");
            balance = double.Parse(Console.ReadLine());
            if (type != "M")
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt", true))
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", accnumber, type, title, name, CNIC, contact, balance, income, address);
                }
            }
            else if (type == "M")
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt", true))
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", accnumber, type, title, name, CNIC, contact, balance, address);
                }
            }
        }
       
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n\t\t\t\t\t*** BANK ACCOUNT MANAGEMENT SYSTEM ***\n\nWho are you:\n");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Customer\n");
            Console.Write("Enter here: ");
            int choice = int.Parse(Console.ReadLine());
            string line;
            int p=0,account = 1;
            switch (choice)
            {
                case 1:
                    {
                        Admin ad = new Admin();
                        
                        Console.Write("Password: ");
                        string pass = Console.ReadLine();
                        
                        if (pass == "hello")
                        {
                            Console.WriteLine("\nChoose any:\n\n1. Create Account\n2. View an Account\n3. Delete an Account\n4. View all Accounts\n ");
                            Console.Write("Enter here: ");
                            choice = int.Parse(Console.ReadLine());
                            string[] array = new string[] { "Account Number: ", "Account Type: ", "Account Title: ", "Name: ", "CNIC/B-Form Number: ", "Contact Number: ", "Balance: Rs.", "Monthly Income: ", "Residential Address: " };
                            string[] arrayc = new string[] { "Account Number: ", "Account Type: ", "Account Title: ", "Name: ", "CNIC/B-Form Number: ", "Contact Number: ", "Balance: Rs.", "Monthly Income: ", "Residential Address: ","Car Name: ","Car Price: Rs.","Down Payment: Rs.","Number Of Installments: ","Monthly Repayment: Rs." };
                            string[] arraym = new string[] { "Account Number: ", "Account Type: ", "Account Title: ", "Name: ", "CNIC/B-Form Number: ", "Contact Number: ", "Balance: Rs.", "Residential Address: " };
                            switch (choice)
                            {
                                case 1:
                                    {
                                        using (StreamReader sr = new StreamReader(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
                                        {
                                            while ((line = sr.ReadLine()) != null)
                                            {
                                                account++;
                                            }
                                        }
                                        ad.create(account);
                                        Console.WriteLine("\nAccount created successfully :-)");
                                        
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Write("Enter account number: ");
                                        string acc = Console.ReadLine();
                                        Console.WriteLine();
                                        
                                        using (StreamReader sr = new StreamReader(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
                                        {
                                            while ((line = sr.ReadLine()) != null)
                                            {
                                                char[] delimiters = new char[] { ',' };
                                                string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                                if (parts[0] == acc)
                                                {
                                                    p++;
                                                    if (parts.Length > 9)
                                                    {
                                                        for (int i = 0; i < parts.Length; i++)
                                                        {
                                                            Console.WriteLine(arrayc[i] + parts[i]);
                                                            if (i == 8)
                                                            {
                                                                Console.WriteLine("\nCar Financing Details:\n");
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (parts[1] == "M")
                                                        {
                                                            for (int i = 0; i < parts.Length; i++)
                                                            {
                                                                Console.WriteLine(arraym[i] + parts[i]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            for (int i = 0; i < parts.Length; i++)
                                                            {
                                                                Console.WriteLine(array[i] + parts[i]);
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }

                                            }
                                            if (p == 0) Console.WriteLine("Account does not exist");
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Write("\nEnter account number to be deleted: ");
                                        string acc = Console.ReadLine();
                                        string[] data = File.ReadAllLines(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt");

                                        using (StreamReader sr = new StreamReader(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
                                        {
                                            while ((line = sr.ReadLine()) != null)
                                            {
                                                char[] delimiters = new char[] { ',' };
                                                string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                                if (parts[0] == acc)
                                                {
                                                    data = data.Where(w => w != line).ToArray();
                                                }
                                            }
                                        }

                                        File.WriteAllLines(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt", data);
                                        Console.WriteLine("Account deleted successfully");
                                        break;
                                    }
                                case 4:
                                    {
                                        using (StreamReader sr = new StreamReader(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
                                        {
                                            while ((line = sr.ReadLine()) != null)
                                            {
                                                Console.WriteLine();
                                                char[] delimiters = new char[] { ',' };
                                                string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                                if (parts.Length > 9)
                                                {
                                                    Console.WriteLine();
                                                    for (int i = 0; i < parts.Length; i++)
                                                    {
                                                        Console.WriteLine(arrayc[i] + parts[i]);
                                                        if (i == 8)
                                                        {
                                                            Console.WriteLine("\nCar Financing Details:\n");
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (parts[1] == "M")
                                                    {
                                                        for (int i = 0; i < parts.Length; i++)
                                                        {
                                                            Console.WriteLine(arraym[i] + parts[i]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        for (int i = 0; i < parts.Length; i++)
                                                        {
                                                            Console.WriteLine(array[i] + parts[i]);
                                                        }
                                                    }
                                                }
                                                Console.WriteLine();
                                            }
                                        }
                                        break;
                                        
                                    }
                                default:
                                    {
                                        Console.WriteLine("Invalid Input!");
                                        break;
                                    }
                            }
                        }
                        else Console.WriteLine("Wrong Password !");
                        break;
                    }
                case 2:
                    {
                        
                        Console.WriteLine("\n** CUSTOMER PANEL **");
                        Console.Write("\nEnter your account number: ");
                        string acc = Console.ReadLine();
                        Customer cus = new Customer(acc);

                        if (cus.p != 0)
                        {
                            Console.WriteLine("Choose any of the below:\n");
                            Console.WriteLine("1. Balance Inquiry\n2. Cash Deposit.\n3. Cash Withdraw.\n4. Apply car financing.\n");
                            Console.Write("Enter choice here: ");
                            choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    {
                                        cus.Inquiry();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("\nCASH DEPOSIT\n");
                                        cus.Deposit();
                                        if (cus.c != 0)
                                        {
                                            string[] data = File.ReadAllLines(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt");

                                            using (StreamReader sr = new StreamReader(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
                                            {
                                                while ((line = sr.ReadLine()) != null)
                                                {
                                                    char[] delimiters = new char[] { ',' };
                                                    string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                                    if (parts[0] == acc)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }

                                            for (int k = 0; k < (data.Length); k++)
                                            {
                                                if (data[k] == line)
                                                {
                                                    data[k] = cus.newline;
                                                    break;
                                                }
                                            }
                                            File.WriteAllLines(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt", data);
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("\nCASH WITHDRAWAL\n");
                                        cus.Withdraw();
                                        if (cus.c != 0)
                                        {
                                            string[] data = File.ReadAllLines(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt");

                                            using (StreamReader sr = new StreamReader(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
                                            {
                                                while ((line = sr.ReadLine()) != null)
                                                {
                                                    char[] delimiters = new char[] { ',' };
                                                    string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                                    if (parts[0] == acc)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }

                                            for (int k = 0; k < (data.Length); k++)
                                            {
                                                if (data[k] == line)
                                                {
                                                    data[k] = cus.newline;
                                                    break;
                                                }
                                            }
                                            File.WriteAllLines(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt", data);
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        Console.WriteLine("\nCAR FINANCING\n");
                                        cus.car();
                                        if (cus.c != 0)
                                        {
                                            string[] data = File.ReadAllLines(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt");

                                            using (StreamReader sr = new StreamReader(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt"))
                                            {
                                                while ((line = sr.ReadLine()) != null)
                                                {
                                                    char[] delimiters = new char[] { ',' };
                                                    string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                                    if (parts[0] == acc)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }

                                            for (int k = 0; k < (data.Length); k++)
                                            {
                                                if (data[k] == line)
                                                {
                                                    data[k] = string.Concat(data[k], cus.newline);
                                                    break;
                                                }
                                            }
                                            File.WriteAllLines(@"C:\Users\Open\Documents\Visual Studio 2010\Projects\Bank Accoiunt\Bank Accoiunt\Directory.txt", data);
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Invalid Input!");
                                        break;
                                    }
                            }
                        }
                            break;
                        
                    }
                default:
                    {
                        Console.WriteLine("Invalid Input!");
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}
