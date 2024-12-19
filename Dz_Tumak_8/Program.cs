using Dz_DmitriyNikolaevichTumakov_7;
using System;
namespace Tumakov
{
    class Program
    {
        static void Main(string[] args)
        {
            Upr_9_1_2_3();
            Dz_9_1();
        }
        static void Upr_9_1_2_3()
        {
            Console.WriteLine(@"Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить
            методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить
            конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
            для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
            банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
            счета.");
            Console.WriteLine(@"Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию
            о всех банковских операциях. При изменении баланса счета создается новый объект класса
            BankTransaction, который содержит текущую дату и время, добавленную или снятую со
            счета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса
            передается один параметр – сумма. В классе банковский счет добавить закрытое поле типа
            System.Collections.Queue, которое будет хранить объекты класса BankTransaction для
            данного банковского счета; изменить методы снятия со счета и добавления на счет так,
            чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в
            переменную типа System.Collections.Queue.");
            Console.WriteLine(@"Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные о
            проводках из очереди запишет в файл. Не забудьте внутри метода Dispose вызвать метод
            GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
            завершения для указанного объекта.");
            Bank_account account = new Bank_account(56789, Account.сберегательный);
            Bank_account account2 = new Bank_account(5678, Account.текущий);
            bool flag = true;
            decimal res;
            while (flag)
            {
                Console.WriteLine("\nВыберите операцию:\n1.Пополнить\n2.Снять\n3.Отобразить счёт\n4.Перевести деньги\n5.Записать данные об операциях в файл");
                switch (Console.ReadLine())
                {
                    case "1": account.Deposit(); account.Print(); break;
                    case "2": account.Withdraw(); account.Print(); break;
                    case "3": account.Print(); break;
                    case "4":
                        Console.WriteLine("Введите сумму, которую хотите перевести.\n");
                        while (!decimal.TryParse(Console.ReadLine(), out res))
                        {
                            Console.WriteLine("\nНеверный формат данных. Повторите попытку\n");
                        }
                        account.Transfer(account2, res);
                        break;
                    case "5": account.Dispose(); break;
                    default: flag = false; break;
                }
            }

        }
        static void Dz_9_1()
        {
            Console.WriteLine(@"Домашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие
            конструкторы:
            1) параметры конструктора – название и автор песни, указатель на предыдущую песню
            инициализировать null.
            2) параметры конструктора – название, автор песни, предыдущая песня. В методе Main
            создать объект mySong. Возникнет ли ошибка при инициализации объекта mySong
            следующим образом: Song mySong = new Song(); ?
            Исправьте ошибку, создав необходимый конструктор.");
            List<Song> songs = new List<Song>
            {
            new Song("Рюмка водки на столе","Григорий Лепс"),
            new Song("Лирика","Сектор Газа"),
            new Song("Кукушка","КИНО"),
            new Song("Сenturies","Fall out boy")
            };
            for (int i = 1; i < songs.Count; i++)
            {
                songs[i].GetPrev(songs[i - 1]);
            }
            Console.WriteLine("\nСписок песен:");
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title());
            }
            Console.WriteLine("\nСравнение первой и второй песни:");
            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine("Первая и вторая песни одинаковы.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песни разные.");
            }
        }
    }
}