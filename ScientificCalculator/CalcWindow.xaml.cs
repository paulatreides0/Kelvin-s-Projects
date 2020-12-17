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

namespace ScientificCalculator
{
	/// <summary>
	/// Interaction logic for CalcWindow.xaml
	/// </summary>
	public partial class CalcWindow : Window
	{
		string Input = string.Empty;
		string Operand1 = string.Empty;
		string Operand2 = string.Empty;
		char Operation;
		double Result = 0.0;

		//Determines if you just clear line, or wipe memory also
		bool WipeFlag = false;

		public CalcWindow()
		{
			InitializeComponent();
		}

		//Operations
		//Multiplication
		protected void Button_Click_Multiply(object sender, RoutedEventArgs e)
		{
			Operand1 = Input;
			Operation = '*';
			Input = string.Empty;
		}

		private void Button_Click_Divide(object sender, RoutedEventArgs e)
		{
			Operand1 = Input;
			Operation = '/';
			Input = string.Empty;
		}

		private void Button_Click_Add(object sender, RoutedEventArgs e)
		{
			Operand1 = Input;
			Operation = '+';
			Input = string.Empty;
		}

		private void Button_Click_Subtract(object sender, RoutedEventArgs e)
		{
			Operand1 = Input;
			Operation = '-';
			Input = string.Empty;
		}

		//Numbers
		private void Button_Click_0(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "0";
			this.Output.Text += Input;
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "1";
			this.Output.Text += Input;
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "2";
			this.Output.Text += Input;
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "3";
			this.Output.Text += Input;
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "4";
			this.Output.Text += Input;
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "5";
			this.Output.Text += Input;
		}

		private void Button_Click_6(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "6";
			this.Output.Text += Input;
		}

		private void Button_Click_7(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "7";
			this.Output.Text += Input;
		}

		private void Button_Click_8(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "8";
			this.Output.Text += Input;
		}

		private void Button_Click_9(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "9";
			this.Output.Text += Input;
		}

		private void Button_Click_Period(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += ".";
			this.Output.Text += Input;
		}

		//Implement Later
		private void Button_Click_Pi(object sender, RoutedEventArgs e)
		{
		}

		private void Button_Click_NatNum(object sender, RoutedEventArgs e)
		{
		}

		private void Button_Click_SignChange(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			Input += "0";
			this.Output.Text += Input;
		}


		//Built-In Functions
		private void Button_Click_Sin(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_Cos(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_Tan(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_Log(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_Power(object sender, RoutedEventArgs e)
		{

		}

		//Clear Window - Click Once to Clear Line, Twice to Clear Memory Also
		private void Button_Click_Clear(object sender, RoutedEventArgs e)
		{
			this.Output.Text = "";
			this.Operand2 = string.Empty;

			WipeFlag = true;

			if(WipeFlag == true)
			{
				this.Input = string.Empty;
				this.Operand1 = string.Empty;

				WipeFlag = false;
			}
		}

		//Get Final Output
		private void Button_Click_Enter(object sender, RoutedEventArgs e)
		{
			Calculate();

			WipeFlag = false;
		}

		private void Calculate()
		{
			Operand2 = Input;
			double num1;
			double num2;

			double.TryParse(Operand1, out num1);
			double.TryParse(Operand2, out num2);

			switch (Operation)
			{
				case '*':
				{
					this.Output.Text = (num1 * num2).ToString();
					break;
				}

				case '/':
				{
					if (num2 != 0)
					{
						this.Output.Text = (num1 / num2).ToString();
					}

					else
					{
						this.Output.Text = "";
						this.Output.Text = "ERROR! DIVIDE BY ZERO!";
					}
				
					break;
				}

				case '+':
				{
					this.Output.Text = (num1 + num2).ToString();
					break;
				}

				case '-':
				{
					this.Output.Text = (num1 - num2).ToString();
					break;
				}
			}
		}
	}
}
