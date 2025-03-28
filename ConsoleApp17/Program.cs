using System;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

string pathRead = "/Users/DSKW/Documents/app/DimonTest.txt";
string pathWrite = "/Users/DSKW/Documents/app/DimonTest.srd";
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
string textWrite=null;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
string[] words;

Console.WriteLine("Введите номер столбца который надо переопределить");
string? strNumOfTable= Console.ReadLine(); ;
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL, для параметра "s" в "int int.Parse(string s)".
Int32 numOfTable= Int32.Parse(strNumOfTable)-1;
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL, для параметра "s" в "int int.Parse(string s)".

Console.WriteLine("Введите Значение, которое надо записать в этот столбец");
string? strValue = Console.ReadLine(); ;
Single valOfTable = Single.Parse(strNumOfTable);



// асинхронное чтение
using (StreamReader reader = new StreamReader(pathRead))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        words = line.Split(new char[] { ',' });
        words[numOfTable] = ' '+strValue;

        //foreach (string s in words)
        //{
        //Console.WriteLine(s);
        //}
       if (words != null)
        textWrite += string.Join(",", words)+"\n";
       
    }
    Console.WriteLine(textWrite);
}


// полная перезапись файла 
Encoding utf8WithoutBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
using (StreamWriter writer = new StreamWriter(pathWrite, false, utf8WithoutBom))
{
    //writer.NewLine = "\n";
    await writer.WriteAsync(textWrite);
}