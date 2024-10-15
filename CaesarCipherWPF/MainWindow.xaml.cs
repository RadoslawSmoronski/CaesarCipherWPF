using CaesarCipher;
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
using static System.Net.Mime.MediaTypeNames;

namespace CaesarCipherWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isTextChangeing = false;
        bool isLastChangesTextIsText = true;

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

            if(isLastChangesTextIsText)
            {
                var text = TextTextBox.Text;
                isTextChangeing = true;
                CipherTextBox.Text = _cipherService.ConvertFromTextToCipher(text);
                isTextChangeing = false;
            }
            else
            {
                var text = CipherTextBox.Text;
                isTextChangeing = true;
                TextTextBox.Text = _cipherService.ConvertFromCipherToText(text);
                isTextChangeing = false;
            }
        }

        private void DecreaseButtonClick(object sender, RoutedEventArgs e)
        {
            _cipherService.DecreaseMoveAmount();
            MoveAmount.Text = _cipherService.MoveAmount.ToString();

            if (isLastChangesTextIsText)
            {
                isTextChangeing = true;
                var text = TextTextBox.Text;
                CipherTextBox.Text = _cipherService.ConvertFromTextToCipher(text);
                isTextChangeing = false;
            }
            else
            {
                isTextChangeing = true;
                var text = CipherTextBox.Text;
                TextTextBox.Text = _cipherService.ConvertFromCipherToText(text);
                isTextChangeing = false;
            }
        }

        private void TextTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender != TextTextBox || isTextChangeing == true) return;

            var text = TextTextBox.Text;

            isTextChangeing = true;
            CipherTextBox.Text = _cipherService.ConvertFromTextToCipher(text);
            isTextChangeing = false;
            isLastChangesTextIsText = true;
        }

        private void CipherTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender != CipherTextBox || isTextChangeing == true) return;

            var text = CipherTextBox.Text;

            isTextChangeing = true;
            TextTextBox.Text = _cipherService.ConvertFromCipherToText(text);
            isTextChangeing = false;
            isLastChangesTextIsText = false;
        }
    }
}