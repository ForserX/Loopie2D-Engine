using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

//Класс для чтения/записи INI-файлов
public class INIManager
{
    //Конструктор, принимающий путь к INI-файлу
    public INIManager(string aPath) => path = aPath;

    //Конструктор без аргументов (путь к INI-файлу нужно будет задать отдельно)
    public INIManager() : this("") { }

    //Возвращает значение из INI-файла (по указанным секции и ключу) 
    public string GetPrivateString(string aSection, string aKey)
    {
        //Для получения значения
        StringBuilder buffer = new StringBuilder(SIZE);

        //Получить значение в buffer
        GetPrivateString(aSection, aKey, null, buffer, SIZE, path);

        //Вернуть полученное значение
        return buffer.ToString();
    }
     //и ключу) 
    public string GetPrivateString(string afile, string aSection, string aKey)
    {
        //Для получения значения
        StringBuilder buffer = new StringBuilder(SIZE);

        //Получить значение в buffer
        GetPrivateString(aSection, aKey, null, buffer, SIZE, @".\" + afile);

        //Вернуть полученное значение
        return buffer.ToString();
    }
    //Пишет значение в INI-файл (по указанным секции и ключу) 
    public void WritePrivateStringA(string aSection, string aKey, string aValue, string aFile)
    {
        //Записать значение в INI-файл
        WritePrivateString(aSection, aKey, aValue, @".\" + aFile);
    }

    //Возвращает или устанавливает путь к INI файлу
    public string Path { get => path; set { path = value; } }

    //Поля класса
    private const int SIZE = 1024; //Максимальный размер (для чтения значения из файла)
    private string path = null; //Для хранения пути к INI-файлу

    //Импорт функции GetPrivateProfileString (для чтения значений) из библиотеки kernel32.dll
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
    private static extern int GetPrivateString(string section, string key, string def, StringBuilder buffer, int size, string path);

    //Импорт функции WritePrivateProfileString (для записи значений) из библиотеки kernel32.dll
    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
    private static extern int WritePrivateString(string section, string key, string str, string path);
}