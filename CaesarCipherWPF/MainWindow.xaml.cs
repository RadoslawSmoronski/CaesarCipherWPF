﻿using CaesarCipher;
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

namespace CaesarCipherWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICipherService _cipherService;
        public MainWindow(ICipherService cipherService)
        {
            _cipherService = cipherService;

            DataContext = _cipherService;

            InitializeComponent();
        }

        private void IncreaseButtonClick(object sender, RoutedEventArgs e)
        {
            _cipherService.IncreaseMoveAmount();
            MoveAmount.Text = _cipherService.MoveAmount.ToString();

            var text = TextTextBox.Text;
            CipherTextBox.Text = _cipherService.ConvertFromTextToCipher(text);
        }

        private void DecreaseButtonClick(object sender, RoutedEventArgs e)
        {
            _cipherService.DecreaseMoveAmount();
            MoveAmount.Text = _cipherService.MoveAmount.ToString();

            var text = TextTextBox.Text;
            CipherTextBox.Text = _cipherService.ConvertFromTextToCipher(text);
        }

        private void TextTextChanged(object sender, RoutedEventArgs e)
        {
            var text = TextTextBox.Text;
            CipherTextBox.Text = _cipherService.ConvertFromTextToCipher(text);
        }

        private void CipherTextChanged(object sender, RoutedEventArgs e)
        {
        }
    }
}