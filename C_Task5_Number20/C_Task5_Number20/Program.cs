using System;
using System.Collections.Generic;

// Определение интерфейса "Телефон"
public interface IPhone
{
    string Model { get; set; } // Свойство модели телефона
    bool IsOn { get; set; } // Свойство состояния включения/выключения телефона


    void Call(string phoneNumber); // Метод для совершения звонка
    void SendMessage(string phoneNumber, string message); // Метод для отправки сообщения
}

// Абстрактный класс "Мобильный телефон"
public abstract class MobilePhone : IPhone
{
    public string Model { get; set; } // Реализация свойства модели из интерфейса

    public int BatteryLevel { get; set; } // Свойство уровня заряда батареи
    public bool IsOn { get; set; } // Свойство, показывающее включен ли телефон
    public string PhoneNumber { get; set; } // Свойство номера телефона
    public string Manufacturer { get; set; } // Свойство производителя телефона

    public abstract void ConnectToInternet(); // Абстрактный метод для подключения к интернету

    public void Call(string phoneNumber)
    {
        if (IsOn)
        {
            Console.WriteLine("Calling " + phoneNumber + "...");
        }
        else
        {
            Console.WriteLine("Phone is turned off.");
        }
    }

    public void SendMessage(string phoneNumber, string message)
    {
        if (IsOn)
        {
            Console.WriteLine("Sending message to " + phoneNumber + ": " + message);
        }
        else
        {
            Console.WriteLine("Phone is turned off.");
        }
    }
}

// Класс "Смартфон" наследуется от абстрактного класса "Мобильный телефон"
public class Smartphone : MobilePhone
{
    public bool HasTouchScreen { get; set; } // Дополнительное свойство - наличие сенсорного экрана
    public string OperatingSystem { get; set; } // Дополнительное свойство - операционная система

    public override void ConnectToInternet()
    {
        if (IsOn)
        {
            Console.WriteLine("Connected to the internet.");
        }
        else
        {
            Console.WriteLine("Phone is turned off.");
        }
    }

    public void InstallApp(string appName)
    {
        if (IsOn)
        {
            Console.WriteLine("Installing app: " + appName);
        }
        else
        {
            Console.WriteLine("Phone is turned off.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Создание объектов типа интерфейса
        IPhone phone1 = new Smartphone { Model = "iPhone X", HasTouchScreen = true, OperatingSystem = "iOS" };
        IPhone phone2 = new Smartphone { Model = "Samsung Galaxy S10", HasTouchScreen = true, OperatingSystem = "Android" };

        // Работа со списком объектов типа интерфейса
        List<IPhone> phones = new List<IPhone>();
        phones.Add(phone1);
        phones.Add(phone2);

        foreach (var phone in phones)
        {
            Console.WriteLine("Model: " + phone.Model);

            // Включение телефона
            phone.IsOn = true;

            // Вызов методов
            phone.Call("123456789");
            phone.SendMessage("123456789", "Hello!");

            Console.WriteLine();
        }

        Console.ReadLine();
    

    Console.ReadLine();
    }
}
