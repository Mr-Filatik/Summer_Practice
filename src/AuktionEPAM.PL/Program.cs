
using AuktionEPAM.BLL;
using AuktionEPAM.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuktionEPAM.PL
{
    class Program
    {
        public static ILotsManager ILotsManager { get; } = new ILotsManager();

        static void Main(string[] args)
        {
            SelectByUser();
        }
        private static void SelectByUser()
        {
            Console.WriteLine("Выберите опцию");
            Console.WriteLine("1 - создать лот");
            Console.WriteLine("2 - показать все лоты");
            Console.WriteLine("3 - повысить цену");
            Console.WriteLine("0 - выйти");
            var input = Console.ReadLine();
            if (uint.TryParse(input, out uint result)
                && result >= 0
                && result <= 3)
            {
                switch (result)
                {
                    case 0:
                        return;
                    case 1:
                        string name = Console.ReadLine();
                        int price = Convert.ToInt32(Console.ReadLine());
                        var newLot = new Lot(1, 1, name, price, DateTime.Now, false);
                        ILotsManager.AddLot(newLot);
                        SelectByUser();
                        break;
                    case 2:
                        ICollection<Lot> lots = ILotsManager.SelectAllLots();
                        ShowLots(lots);
                        SelectByUser();
                        break;
                    case 3:
                        int id_lot = Convert.ToInt32(Console.ReadLine());
                        ILotsManager.DeleteLot(id_lot);
                        SelectByUser();
                        break;
                }
            }
        }
        private static void ShowLots(ICollection<Lot> lots)
        {
            foreach (Lot i in lots)
            {
                Console.WriteLine("№ {0} Наименование: {1}", i.Id_lot, i.Name);
                Console.WriteLine("Начало - Цена: {0} Время: {1}", i.Start_price, i.Start_price);
                Console.WriteLine("Создатель: {0} {1}", i.Name_1, i.Surname_1);
                Console.WriteLine("Последнее - Цена: {0} Время: {1}", i.Finish_price, i.Finish_price);
                Console.WriteLine("Желающий: {0} {1}", i.Name_2, i.Surname_2);
                Console.WriteLine();
            }
        }
    }
}
