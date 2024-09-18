using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        // Переменные для хранения данных калькулятора
        private string displayText = "0";  // Текст, отображаемый на дисплее
        private string currentNumber = ""; // Текущее вводимое число
        private string operation = "";    // Выбранная математическая операция
        private double firstOperand = 0;  // Первое число для операции
        private bool isOperationPressed = false; // Флаг, указывающий, была ли нажата кнопка операции

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик события для кнопок с цифрами
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            // Если была нажата кнопка операции, очищаем текущее число 
            // и сбрасываем флаг isOperationPressed
            if (isOperationPressed)
            {
                currentNumber = "";
                isOperationPressed = false;
            }
            // Добавляем нажатую цифру к текущему числу
            currentNumber += button.Content.ToString();
            // Обновляем текст на дисплее
            UpdateDisplay();
        }

        // Обработчик события для кнопок операций
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            // Проверяем, что уже введено число 
            if (currentNumber != "")
            {
                // Запоминаем операцию, первое число и устанавливаем флаг isOperationPressed 
                operation = button.Content.ToString();
                firstOperand = double.Parse(currentNumber);
                isOperationPressed = true;
            }
        }

        // Обработчик события для кнопки "="
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что введено число и выбрана операция
            if (currentNumber != "" && operation != "")
            {
                // Получаем второе число
                double secondOperand = double.Parse(currentNumber);
                // Вычисляем результат по выбранной операции
                double result = 0;
                switch (operation)
                {
                    case "+":
                        result = firstOperand + secondOperand;
                        break;
                    case "-":
                        result = firstOperand - secondOperand;
                        break;
                    case "*":
                        result = firstOperand * secondOperand;
                        break;
                    case "/":
                        if (secondOperand != 0)
                        {
                            result = firstOperand / secondOperand;
                        }
                        else
                        {
                            MessageBox.Show("Деление на ноль невозможно!");
                            return;
                        }
                        break;
                }
                // Записываем результат в currentNumber
                currentNumber = result.ToString();
                // Обновляем текст на дисплее
                UpdateDisplay();
                // Сбрасываем значения для новой операции
                operation = "";
                firstOperand = 0;
                isOperationPressed = false;
            }
        }

        // Обработчик события для кнопки "C" (очистка)
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Сбрасываем все значения калькулятора
            displayText = "0";
            currentNumber = "";
            operation = "";
            firstOperand = 0;
            isOperationPressed = false;
            // Обновляем текст на дисплее
            UpdateDisplay();
        }

        // Обновляем текст на дисплее (TextBlock)
        private void UpdateDisplay()
        {
            if (currentNumber == "")
            {
                DisplayTextBlock.Text = "0";
            }
            else
            {
                DisplayTextBlock.Text = currentNumber;
            }
        }
    }
}