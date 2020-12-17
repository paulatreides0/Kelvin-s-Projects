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
		char Operation = '\0';
		double Result = 0.0;

		//Determines if you just clear line, or wipe memory also
		bool WipeFlag = false;
		//Ensures there is no saved operation
		bool RegOper = false;

		public CalcWindow()
		{
			InitializeComponent();
		}

		//Operations
		//Multiplication
		protected void Button_Click_Multiply(object sender, RoutedEventArgs e)
		{
			if (RegOper == false)
			{
				Operand1 = Input;
				Operation = '*';
				Input = String.Format("{0} {1} ", Operand1, Operation);
				RegOper = true;
			}
			else
			{
				//For Future: Implement Error Message
			}
		}

		private void Button_Click_Divide(object sender, RoutedEventArgs e)
		{
			if(RegOper == false)
			{
				Operand1 = Input;
				Operation = '/';
				Input = String.Format("{0} {1} ", Operand1, Operation);
				RegOper = true;
			}
			else
			{
				//For Future: Implement Error Message
			}
		}

		private void Button_Click_Add(object sender, RoutedEventArgs e)
		{
			if (RegOper == false)
			{
				Operand1 = Input;
				Operation = '+';
				Input = String.Format("{0} {1} ", Operand1, Operation);
				RegOper = true;
			}
			else
			{
				//For Future: Implement Error Message
			}
		}

		private void Button_Click_Subtract(object sender, RoutedEventArgs e)
		{
			if (RegOper == false)
			{
				Operand1 = Input;
				Operation = '-';
				Input = String.Format("{0} {1} ", Operand1, Operation);
				RegOper = true;
			}
			else
			{
				//For Future: Implement Error Message
			}
		}

		private void Button_Click_Power(object sender, RoutedEventArgs e)
		{
			if (RegOper == false)
			{
				Operand1 = Input;
				Operation = '^';
				Input = String.Format("{0}{1}", Operand1, Operation);
				RegOper = true;
			}
			else
			{
				//For Future: Implement Error Message
			}
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
				this.Operation = '\0';

				WipeFlag = false;
				RegOper = false;
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
					this.Result = num1 * num2;
					break;
				}

				case '/':
				{
					if (num2 != 0)
					{
						this.Result = num1 / num2;
					}

					else
					{
						this.Output.Text = "ERROR! DIVIDE BY ZERO!";
					}
				
					break;
				}

				case '+':
				{
					this.Result = num1 + num2;
					break;
				}

				case '-':
				{
					this.Result = num1 - num2;
					break;
				}

				case '^':
				{
					this.Result = Math.Pow(num1, num2);
					break;
				}
			}

			this.Output.Text = String.Format("{0} = {1}", this.Output.Text, Result.ToString());

			//Reset Variables
			//ResetOper & WipeFlag Flag
			RegOper = false;
			WipeFlag = false;
			//Set Operand1 for carry over
			Operand1 = this.Result.ToString();
			//Reset Values to Default
			Input = string.Empty;
			Operand2 = string.Empty;
			Operation = '\0';
			Result = 0.0;
		}
	}
}
