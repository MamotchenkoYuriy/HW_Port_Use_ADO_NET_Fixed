using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tables;
using Factory.Implements;
using Factory.Interfaces;

namespace InteractiveConsole
{
    public class InteractiveConsole
    {
        public void Menu(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Работа с городами");
                Console.WriteLine("2 - Работа с портами");
                Console.WriteLine("3 - Работа с капитанами");
                Console.WriteLine("4 - Работа с кораблями");
                Console.WriteLine("5 - Работа с типами грузов");
                Console.WriteLine("6 - Работа с грузами");
                Console.WriteLine("7 - Работа с перевозками");
                Console.WriteLine("8 - Выход");
                int consoleCommand = ReadIntValueFromConsole(1, 3);
                if (consoleCommand == 1)
                {
                    EntityMenu<City>(path + "->Города");
                }
                else if (consoleCommand == 2)
                {
                    EntityMenu<Port>(path + "->Порты");
                }
                else if (consoleCommand == 3)
                {
                    EntityMenu<Captain>(path + "->Капитаны");
                }
                else if (consoleCommand == 4)
                {
                    EntityMenu<Ship>(path + "->Корабли");
                }
                else if (consoleCommand == 5)
                {
                    EntityMenu<CargoType>(path + "->Типы грузов");
                }
                else if (consoleCommand == 6)
                {
                    EntityMenu<Cargo>(path + "->Грузы");
                }
                else if (consoleCommand == 7)
                {
                    EntityMenu<Trip>(path + "->Перевозки");
                }
                else if (consoleCommand == 8)
                {
                    return;
                }
            }
        }


        private void EntityMenu<T>(string path) where T : BaseEntity
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Добавить запись");
                Console.WriteLine("2 - Просмотреть все записи");
                Console.WriteLine("3 - Удалить запись");
                Console.WriteLine("4 - Редактировать запись");
                Console.WriteLine("5 - Выход");
                int consoleCommand = ReadIntValueFromConsole(1, 4);
                if (consoleCommand == 1)
                {
                    AddEntityMenu<T>(path + "->Добавление");
                }
                else if (consoleCommand == 2)
                {
                    ShowAll<T>(path + "->Все записи");
                }
                else if (consoleCommand == 3)
                {
                    DeleteEntityMenu<T>(path + "->Удаление");
                }
                else if (consoleCommand == 4)
                {
                    EditEntityMenu<T>(path + "->Редактирование");
                }
                else if (consoleCommand == 5) break;
            }
        }

        private void AddEntityMenu<T>(string path) where T : BaseEntity
        {
            Console.Clear();
            Console.WriteLine(path);
            var constractor = typeof(T).GetConstructors().Where(m => m.GetParameters().Length > 0).FirstOrDefault();
            var constractorAttributes = constractor.GetParameters().Where(m => m.Name != "Id").ToList();
            List<object> listParameters = new List<object>();
            listParameters.Add(1);
            foreach (var attribut in constractorAttributes)
            {
                if (attribut.ParameterType == typeof(string))
                {
                    Console.WriteLine("Введите значение атрибута " + attribut.Name.ToUpper() + " -->");
                    listParameters.Add(Console.ReadLine());
                }
                else if (attribut.ParameterType == typeof(Int32))
                {
                    Console.WriteLine("Введите значение атрибута " + attribut.Name.ToUpper() + "-->");
                    listParameters.Add(ReadIntValueFromConsole());
                }
            }

            Assembly assembly = Assembly.GetAssembly(typeof(T));
            Object o = assembly.CreateInstance(typeof(T).FullName, false,
                BindingFlags.ExactBinding,
                null, listParameters.ToArray(), null, null);
            var addItem = (T)o;
            try
            {
                Factory.Factory.getInstanse().getDAO<T>().Add(addItem);
                Console.WriteLine("Изменения внесены!!!");
                Console.ReadKey();
            }
            catch (Exception err)
            {
                Console.WriteLine("Возникла ошибка при добавлении записи ");
            }
        }

        private void ShowAll<T>(string messsage)
        {
            Console.Clear();
            Console.WriteLine(messsage);
            foreach (var item in Factory.Factory.getInstanse().getDAO<T>().GetList())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }

        private void DeleteEntityMenu<T>(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Console.WriteLine("Выбирите дейтвие: ");
                Console.WriteLine("1 - Удалить по ID: ");
                Console.WriteLine("2 - Удалить по номеру: ");
                Console.WriteLine("3 - Выход");
                int commandNumber = ReadIntValueFromConsole(1, 3);
                if (commandNumber == 1)
                {
                    Console.WriteLine("Введите ID: ");
                    int Id = ReadIntValueFromConsole();
                    var item = Factory.Factory.getInstanse().getDAO<T>().GetList().Where(m => m.Id == Id).FirstOrDefault();
                    if (item != null)
                    {
                        Factory.Factory.getInstanse().getDAO<T>().Remove(item);
                        Console.WriteLine("Запись удаленна");
                    }
                    Console.WriteLine("Запись с ID = " + Id + "не найденна");
                }
                else if (commandNumber == 2)
                {
                    Console.WriteLine("Введите номер записи в списке");
                    int number = ReadIntValueFromConsole();
                    var list = Factory.Factory.getInstanse().getDAO<T>().GetList();
                    if (number <= list.Count - 1)
                    {
                        Factory.Factory.getInstanse().getDAO<T>().Remove(list[number]);
                        Console.WriteLine("Запись удаленна");
                    }
                    Console.WriteLine("Вы ввели число, которое выходит за диаппазон существующих записей");
                }
                else if (commandNumber == 3)
                {
                    break;
                }
            }
        }

        private void EditEntityMenu<T>(string path) where T : BaseEntity
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                T entity = null;
                Console.WriteLine("1 - Редактировать по ID -->");
                Console.WriteLine("2 - Редактировать № -->");
                Console.WriteLine("3 - Выход -->");
                int consoleCommand = ReadIntValueFromConsole();
                if (consoleCommand == 1)
                {
                    Console.WriteLine("Введите Id --> ");
                    int id = ReadIntValueFromConsole();
                    entity = (T)Factory.Factory.getInstanse().getDAO<T>().GetList().Where(m => m.Id == id).FirstOrDefault();
                    if (entity == null) { Console.Write("Сущьность с Id = " + id + " не найденна!!!"); break; }
                }
                else if (consoleCommand == 2)
                {
                    Console.WriteLine("Введите номер записи --> ");
                    int pos = ReadIntValueFromConsole();
                    if (pos >= Factory.Factory.getInstanse().getDAO<T>().GetList().Count) { Console.WriteLine("Вы ввели не корректный номер!!!"); break; }
                    entity = (T)Factory.Factory.getInstanse().getDAO<T>().GetList()[pos];
                }
                else if (consoleCommand == 3) { break; }

                var type = typeof(T);
                var constractor = type.GetConstructors().Where(m => m.GetParameters().Length > 0).FirstOrDefault();
                var constractorAttributes = constractor.GetParameters().Where(m => m.Name != "Id");
                List<object> listParameters = new List<object>();
                listParameters.Add(entity.Id);
                //var mmm = typeof(T).GetType().GetMethod("").Invoke(typeof(T), new object[2]);
                foreach (var attribut in constractorAttributes)
                {
                    if (attribut.ParameterType == typeof(string))
                    {
                        Console.WriteLine("Введите значение атрибута " + attribut.Name.ToUpper() + " -->");
                        listParameters.Add(Console.ReadLine());
                    }
                    else if (attribut.ParameterType == typeof(Int32))
                    {
                        Console.WriteLine("Введите значение атрибута " + attribut.Name.ToUpper() + "-->");
                        listParameters.Add(ReadIntValueFromConsole());
                    }
                }
                Assembly assembly = Assembly.GetAssembly(typeof(T));
                Object o = assembly.CreateInstance(typeof(T).FullName, false,
                    BindingFlags.ExactBinding,
                    null, listParameters.ToArray(), null, null);
                var addItem = (T)o;
                Factory.Factory.getInstanse().getDAO<T>().Update(addItem);
                Console.WriteLine("Изменения внесены!!!");
                Console.ReadKey();
            }
        }



        private int ReadIntValueFromConsole(int min, int max)
        {
            while (true)
            {
                int value = ReadIntValueFromConsole();
                if (Enumerable.Range(1, 10).Contains(value)) { return value; }
            }
        }

        private int ReadIntValueFromConsole()
        {
            string errMessage = string.Empty;
            while (true)
            {
                Console.WriteLine(errMessage);
                string strValue = Console.ReadLine();
                int result = 0;
                if (Int32.TryParse(strValue, out result))
                {
                    return result;
                }
                else { errMessage = "Вы ввели не корректное значение!!!"; }
            }
        }
    }
}
