using System;
using System.Collections.Generic;

namespace atm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            int add = 0;
            process pro = new process();
            pro.add();
            Console.Clear();
            bool check;
            do
            {
                check = pro.select();

            } while (check == false);

            do
            {
                Console.Clear();
                menuATM.menu();
                System.Console.Write("gozine mored nazar ra entekhab konid:");
                add = int.Parse(Console.ReadLine());

                switch (add)
                {
                    case 1:
                        pro.credit();

                        break;
                    case 2:
                        pro.update();

                        break;
                    case 3:
                        pro.CtoC();

                        break;
                    case 4:
                        pro.cash();

                        break;
                    case 5:
                        pro.cash();

                        break;
                }

            } while (add == 1 || add == 2 || add == 3 || add == 4);
            Console.Clear();
            System.Console.WriteLine("        *------ba tashakor------*");







        }
    }
    interface atm
    {
        void add();
        bool select();
        void CtoC();
        void update();
        void credit();
        void cash();
    }
    class card
    {
        public string id;
        public string name;
        public int price;
        public string pass;

    }
    class process : atm
    {

        static List<card> list_card = new List<card>();
        int i = 1;
        static string card_no;


        public void add()
        {
            System.Console.WriteLine("add 2 card for run ATM");
            do
            {
                card c = new card();

                System.Console.WriteLine("enter name-" + i);
                c.name = Console.ReadLine();
                System.Console.WriteLine("enter card number-" + i);
                c.id = Console.ReadLine();
                System.Console.WriteLine("enter pass-" + i);
                c.pass = Console.ReadLine();
                System.Console.WriteLine("enter credit ($)-" + i);
                c.price = int.Parse(Console.ReadLine());
                list_card.Add(c);
                i++;
            } while (i < 3);
        }

        public void credit()
        {
            foreach (var item in list_card)
            {
                if (item.id == card_no)
                {
                    System.Console.WriteLine(item.price);


                }
                Console.ReadLine();

            }

        }


        public void update()
        {

            foreach (var item in list_card)
            {
                Console.Clear();

                System.Console.WriteLine("enter old pass");
                string oldpass = Console.ReadLine();

                if (card_no == item.id)
                {
                    if (item.pass == oldpass)
                    {

                        System.Console.WriteLine("enter new pass");
                        item.pass = Console.ReadLine();

                        System.Console.WriteLine("successful");
                        Console.ReadLine();
                    }
                    else
                    {
                        System.Console.WriteLine("wrong password");
                    }

                }

            }
        }
        public void cash()
        {
            Console.Clear();

            System.Console.Write("Mablagh darkhasti ra vared konid:");
            int cash = Convert.ToInt32(Console.ReadLine());


            foreach (var item in list_card)
            {
                if (item.id == card_no)
                {
                    Console.Clear();
                    if (item.price - cash >= 0)
                    {
                        item.price = item.price - cash;
                        System.Console.WriteLine("success");
                        System.Console.WriteLine("new credit:" + item.price);
                    }
                    else
                    {
                        System.Console.WriteLine("Adame mojodi");
                    }
                    Console.ReadLine();

                }
            }
        }

        public void CtoC()
        {
            foreach (var item in list_card)
            {

                Console.Clear();

                if (item.id == card_no)
                {
                    System.Console.WriteLine("please enter card_no maghsad ");
                    string card_maghsad = Console.ReadLine();
                    System.Console.WriteLine("mablagh ra vared konid");
                    int price = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    if (item.price >= price)
                    {
                        foreach (var item1 in list_card)
                        {
                            if (item1.id == card_maghsad)
                            {
                                item1.price = item1.price + price;
                                item.price = item.price - price;
                                System.Console.WriteLine("success");
                            }
                            else
                            {
                                System.Console.WriteLine("card peyda nashod");
                            }
                            Console.ReadLine();
                            
                        }
                    }
                }


            }
        }

        public bool select()
        {
            System.Console.WriteLine("enter card number");
            card_no = Console.ReadLine();
            System.Console.WriteLine("enter your pass");
            string password = Console.ReadLine();
            foreach (var item in list_card)
            {
                if (item.id == card_no && item.pass == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class menuATM
    {
        public static void menu()
        {
            System.Console.WriteLine("*--------------ATM menu--------------*");
            System.Console.WriteLine("*                                    *");
            System.Console.WriteLine("*1-sorat hesab          taghir ramz-2*");
            System.Console.WriteLine("*                                    *");
            System.Console.WriteLine("*3-card to card        daryaft pool-4*");
            System.Console.WriteLine("*                                    *");
            System.Console.WriteLine("*                              exit-5*");
            System.Console.WriteLine("*------------------------------------*");

        }
    }
}
