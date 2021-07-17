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

namespace JapaneseKeyinTest
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        int testIndex = 1;
        List<ItemCollection> list; 
        Random rng = new Random();
        bool isWrong = false;
        public MainWindow()
        {

            InitializeComponent();
            list = Model.HiraganaClean;
            list.AddRange(Model.KatakanaClean);
            testIndex = rng.Next(1, list.Count());

            lblWord.Content = list[testIndex].Name;

        }
        private void KeyBlock_KeyUp(object sender, KeyEventArgs e)
        {
            if (KeyBlock.Text.Length >= list[testIndex].Spell.Length
                || e.Key == Key.Return || e.Key == Key.Space)
            {
                if (isWrong) {
                    KeyBlock.Text = "";
                    isWrong = false;
                }
                else if (KeyBlock.Text == list[testIndex].Spell || KeyBlock.Text == list[testIndex].Name)
                {
                    KeyBlock.Text = "";
                    GetNext();
                }
                else {
                    //錯誤
                    KeyBlock.Text = list[testIndex].Spell;
                    isWrong = true;

                }
            }
        }
        private void GetNext()
        {
           
            testIndex = rng.Next(1, list.Count());
            lblWord.Content = list[testIndex].Name;

        }
    }
}
