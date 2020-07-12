
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
            Console.WriteLine("Введите 1 чтобы создать лот");
            Console.WriteLine("Введите 2 чтобы показать все доступные лоты");
            Console.WriteLine("Введите 3 чтобы показать созданные мною лоты");
            Console.WriteLine("Введите 4 чтобы предложить цену");
            Console.WriteLine("Введите 5 чтобы удалить лот");
            Console.WriteLine("Введите 0 чтобы выйти из приложения");
            var input = Console.ReadLine();
            if (uint.TryParse(input, out uint result)
                && result >= 0
                && result <= 5)
            {
                int id_lot;
                int price;
                ICollection<Lot> lots = null;
                switch (result)
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine("Введите название добавляемого лота");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите цену для добавляемого лота");
                        price = Convert.ToInt32(Console.ReadLine());
                        var newLot = new Lot()
                        {
                            Id_lot = 0,
                            Id_creator = 1,
                            Name = name,
                            Start_price = price,
                            Start_time = DateTime.Now,
                            Status = false,
                            Creator = null
                        };
                        ILotsManager.AddLot(newLot);
                        SelectByUser();
                        break;
                    case 2:
                        lots = ILotsManager.SelectAllLots();
                        ShowLots(lots);
                        SelectByUser();
                        break;
                    case 3:
                        lots = ILotsManager.SelectMyLots();
                        ShowLots(lots);
                        SelectByUser();
                        break;
                    case 4:
                        Console.WriteLine("Введите номер выбранного лота");
                        id_lot = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите новыу цену лота");
                        price = Convert.ToInt32(Console.ReadLine());
                        ILotsManager.DeleteLot(id_lot);
                        SelectByUser();
                        break;
                    case 5:
                        Console.WriteLine("Введите номер удаляемого лота");
                        id_lot = Convert.ToInt32(Console.ReadLine());
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
                Console.WriteLine("Лот номер: {0}.  Наименование лота: {1}", i.Id_lot, i.Name);
                Console.WriteLine("Цена: {0}.  Время изменения цены: {1}", i.Start_price, i.Start_time);
                Console.WriteLine("Создатель: {0} {1}", i.Creator.Name, i.Creator.Surname);
                Console.WriteLine();
            }
        }
    }
}
