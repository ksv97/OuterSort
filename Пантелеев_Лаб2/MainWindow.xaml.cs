using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Пантелеев_Лаб2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DivideToFourFiles();
        }

        public void DivideToFourFiles ()
        {
            using (FileStream myStream = File.OpenRead("input.txt"))
            {
                FileInfo[] filesForSorting = new FileInfo[4];
                for (int i = 0; i < 4; i++)
                {
                    filesForSorting[i] = new FileInfo((i+1).ToString() + ".txt");
                    //filesForSorting[i].Create();
                    
                }


                int currentKey;
                int lastKey = -1;
                List<int> sery = new List<int>();
                debugTxtblock.Text += "Данные из файла: " + Environment.NewLine;
                while ((currentKey = myStream.ReadByte()) != -1) // пока возможно считывание
                {
                    if (currentKey != 32)
                        debugTxtblock.Text += Convert.ToChar(currentKey).ToString() + " "; // СЧИТЫВАНИЕ ИДЕТ ПО СИМВОЛУ, НУЖНО ПО ЧИСЛАМ!
                    // А дальше пока ошибки
                    /*
                    int currentFileIndex = 0;                    
                    if (currentKey != 32) // 32 - код пробела
                    {
                        if (lastKey == -1)
                        {                            
                            sery.Add(lastKey);
                        }                            
                        else
                        {
                            // если выполнено условие монотонного возрастания, добавить в серию текущий ключ
                            if (currentKey >= lastKey)
                                sery.Add(currentKey);
                            else // иначе записать серию в текущий файл и изменить индекс файла
                            {
                                using (StreamWriter current = filesForSorting[currentFileIndex].AppendText())
                                {
                                    foreach (int elem in sery)
                                    {
                                        current.Write(Convert.ToChar(elem));
                                        current.Write(" ");
                                    }
                                    
                                }
                                currentFileIndex = (currentFileIndex + 1 == 4) ? 0 : currentFileIndex++;
                            }
                        }
                        // запомнить последний записанный символ
                        lastKey = currentKey;
                    }
                    */
                }

            }

            
        }
    }
}
