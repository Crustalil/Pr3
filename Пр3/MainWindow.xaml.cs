using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Пример_таблицы_WPF;
using LibMas;
using Lib_2;

namespace Пр3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[,] matr;
        int value, value1;
        bool f, c;
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана матрица размера M × N и целое число K (1 ≤ K ≤ N). Найти сумму и \r\nпроизведение элементов K-го столбца данной матрицы. \nРазарботчик: Кузнецов М.Н. ИСП-31");
        }

        public void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //Заполнение
        public void miFill_Click(object sender, RoutedEventArgs e)
        {
            f = Int32.TryParse(tbColumnCount.Text, out value);
            c = Int32.TryParse(tbRowCount.Text, out value1);
            if (f && c == true)
            {
                WorkWithMassiv.InitMas(out matr, value1, value);
                dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                tbColumnCount.Clear();
                tbRowCount.Clear();
                tbSum.Clear();
                tbChisloK.Clear();
                tbProduct.Clear();
            }
            else MessageBox.Show("Введите корректные значения");
        }

        //Создание
        public void miCreate_Click(object sender, RoutedEventArgs e)
        {
            f = Int32.TryParse(tbColumnCount.Text, out value);
            c = Int32.TryParse(tbRowCount.Text, out value1);
            if (f && c == true)
            {
                matr = new int[value1, value];
                dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            else MessageBox.Show("Введиет корректные значания");
            tbColumnCount.Clear();
            tbRowCount.Clear();
            tbSum.Clear();
            tbChisloK.Clear();
            tbProduct.Clear();
        }


        //Очистка
        public void miClear_CLick(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            WorkWithMassiv.ClearMas(ref matr);
            tbColumnCount.Clear();
            tbRowCount.Clear();
            tbSum.Clear();
            tbChisloK.Clear();
            tbProduct.Clear();
        }

        //Сохранение
        private void Save_CLick(object sender, RoutedEventArgs e)
        {
            WorkWithMassiv.SaveMas(matr);
        }

        //Открытие
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            WorkWithMassiv.OpenMas(ref matr);
            dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
        }


        //Проверка на корректность значений и обновление данных
        public void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {


            DataGrid grid = sender as DataGrid;
            if (grid != null)
            {
                int rowIndex = e.Row.GetIndex();
                int columnIndex = e.Column.DisplayIndex;

                TextBox editedTextbox = e.EditingElement as TextBox;
                if (editedTextbox != null)
                {
                    int newValue;
                    if (int.TryParse(editedTextbox.Text, out newValue))
                    {
                        // Обновляем значение в матрице matr
                        matr[rowIndex, columnIndex] = newValue;
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное числовое значение.");
                        // Возвращаем предыдущее значение в ячейку
                        editedTextbox.Text = matr[rowIndex, columnIndex].ToString();
                    }
                }
            }

        }


        //Расчет
        public void miCalc_CLick(object sender, RoutedEventArgs e)
        {
            int K;
            f = Int32.TryParse(tbChisloK.Text, out K);
            int sum;
            int product;
            if (matr != null && f == true && K>=1 && K<= matr.GetLength(0))
            {
               RaschetInMatr.SumAndProduct(matr, K, out sum, out product);
                tbSum.Text = Convert.ToString(sum);
                tbProduct.Text = Convert.ToString(product);
            }
            else MessageBox.Show("Введите значения");
        }
    }
}


    
