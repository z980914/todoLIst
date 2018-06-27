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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 開啟檔案
            string[] lines = System.IO.File.ReadAllLines(@"C:\data.txt");

            // 分析
            foreach (string line in lines)
            {
                // 隔開
                string[] parts = line.Split('|');


                price price = new price();

                //讀取
                price.date.Text = parts[0];
                price.TaskName.Text = parts[1];
                price.TaskPrice.Text = parts[2];

                //增加項目
                TaskList.Children.Add(price);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            int AddPrice = 0;

            //按enter時會計算
            if (e.Key == Key.Return)
            {

                foreach (price item in TaskList.Children)
                {

                    AddPrice += item.itemPriceValue;
                }

                //顯示總價
                totalPrice.Text = AddPrice.ToString();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // 新增串列裝每個項目的文字
            List<string> datas = new List<string>();

            // 轉換項目
            foreach (price price in TaskList.Children)
            {
                //設置一個字串
                string data = "";

                //每一種資料區隔加入字串
                data += price.date.Text + "|" + price.TaskName.Text + "|" + price.TaskPrice.Text;


                datas.Add(data);
            }

            System.IO.File.WriteAllLines(@"c:\data.txt", datas);
        }


        private void addTask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 產生
            price price = new price();

            //放到清單
            TaskList.Children.Add(price);
            int sum = 0;

            foreach (price item in TaskList.Children)
            {
                sum += int.Parse(item.TaskPrice.Text);
                totalPrice.Text = sum.ToString();
            }
        }

        private void total_Click(object sender, RoutedEventArgs e)
        {
            int a = 0;
            foreach (price item in TaskList.Children)
            {

                a += item.itemPriceValue;
            }

            //顯示總價
            totalPrice.Text = a.ToString();
        }
    }
    }
