using System;
using BusinessLayer.Managers;
using Model;
using DataAccessLayer.Repository;


namespace ToDoList
{
    public class Program
    {
        static void Main(string[] args)
        {
            //XX
            // @"Data Source=DESKTOP-JUEFI31;Initial Catalog=ToDo;Integrated Security=True"
            ToDo toDo = new ToDo();
            Settings settings = new Settings();
            settings.ConnectionString = @"Data Source=DESKTOP-JUEFI31;Initial Catalog=ToDo;Integrated Security=True";
            ToDoRepos toDoRepos = new ToDoRepos(settings);
            ToDoManager toDoManager = new ToDoManager(toDoRepos);

        menu:
            Console.WriteLine("Lütfen Seçiniz:"
                + "\n" + "1-Yapılacak Ekle"
                + "\n" + "2-Yapılacakları Listele"
                + "\n" + "3-Yapılacak Sil"
                + "\n" + "4-Yapılacakları Güncelle");
            var secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    {
                        Console.WriteLine("Lütfen Yapılacak Ekleyin: ");
                        toDo.ToDoStr = Console.ReadLine();
                        toDoManager.Add(toDo);
                        Console.WriteLine("Ekleme başarılı.");
                        goto menu;
                    }

                case "2":
                    {
                        var toDos = toDoManager.Get();
                        foreach (var i in toDos)
                        {
                            Console.WriteLine($"ID : {i.ToDoID}  Yapılacak : {i.ToDoStr}");
                        }
                        Console.ReadLine();
                        goto menu;
                    }

                case "3":
                    {
                        var toDos = toDoManager.Get();
                        foreach (var i in toDos)
                        {
                            Console.WriteLine($"ID : {i.ToDoID}  Yapılacak : {i.ToDoStr}");
                        }
                        Console.WriteLine("Lütfen Kaldırmak İstediğinizin Idsini giriniz : ");
                        var Input = int.Parse(Console.ReadLine());
                        toDoManager.DeleteToDo(Input);
                        Console.WriteLine("Silme başarılı.");
                        goto menu;
                    }
                case "4":
                    {
                        var toDos = toDoManager.Get();
                        foreach (var i in toDos)
                        {
                            Console.WriteLine($"ID : {i.ToDoID}  Yapılacak : {i.ToDoStr}");
                        }
                        Console.WriteLine("Lütfen düzeltmek istediğinizin Idsini giriniz: ");
                        var Input = int.Parse(Console.ReadLine());
                        Console.WriteLine("Yeni veri giriniz: ");
                        toDo.ToDoStr = Console.ReadLine();
                        toDoManager.Update(toDo, Input);
                        Console.WriteLine("Güncelleme başarılı.");
                        goto menu;
                    }
            }

            Console.ReadLine();
        }
    }
}

