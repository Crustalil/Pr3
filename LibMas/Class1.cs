using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LibMas
{
    public class WorkWithMassiv
    {
        /// <summary>
        /// Заполнение матрицы случайными значениями
        /// </summary>
        /// <param name="matr">Матрица</param>
        /// <param name="row">Колличество строк</param>
        /// <param name="column">Колличество  столбцов</param>
        public static void InitMas(out int[,] matr, int row, int column)
        {
            Random Rnd = new Random();
            matr = new Int32[row, column];
            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(1); j++) matr[i, j] = Rnd.Next(7);
        }

        /// <summary>
        /// Очистка матрицы
        /// </summary>
        /// <param name="matr">Матрица</param>
        public static void ClearMas(ref int[,] matr)
        {
            matr = null;
        }

        /// <summary>
        /// Сохранения матрицы в текстовый документ
        /// </summary>
        /// <param name="matr">Матрица</param>
        public static void SaveMas(int[,] matr)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) |*.*| Текстовые файлы | *.txt*";
            save.FilterIndex = 1;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                StreamWriter outfile = new StreamWriter(save.FileName, false);
                outfile.WriteLine(matr.GetLength(0));
                outfile.WriteLine(matr.GetLength(1));
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        outfile.WriteLine(matr[i, j]);
                    }
                }
                outfile.Close();
            }
            else MessageBox.Show("Не удалось открыть окно");
        }

        /// <summary>
        /// Открытие текстовго документа с матрицой
        /// </summary>
        /// <param name="matr">Матрица</param>
        public static void OpenMas(ref int[,] matr)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) |*.*| Текстовые файлы | *.txt*";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int row = Convert.ToInt32(file.ReadLine());
                int col = Convert.ToInt32(file.ReadLine());
                matr = new int[row, col];
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        string a = file.ReadLine();
                        bool f1;
                        int value;
                        f1 = int.TryParse(a, out value);
                        if (f1)
                        {
                            matr[i, j] = value;
                            
                        }

                        else MessageBox.Show("Некоректные значения");
                    }
                }
                file.Close();
            }
        }
    }
}