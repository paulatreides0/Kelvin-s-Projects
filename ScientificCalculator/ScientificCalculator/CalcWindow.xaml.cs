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
		//Checks if equal sign has been used, 
		//bool EqualsUsed = false;
		//Checks for fatal errors
		bool ErrorCheck = false;

		//For Later: Implement by using char list checking operation symbols as delimiters when operation is invoked

		public CalcWindow()
		{
			InitializeComponent();
		}

		//Operations
		//Generic Operation Implementer
		private void ImplementOperation(char oper)
		{
			if (RegOper == false)
			{
				Operand1 = Operand2;
				Operand2 = string.Empty;
				Operation = oper;
				Input = String.Format("{0} {1} ", Operand1, Operation);
				this.Output.Text = Input;
				RegOper = true;
			}

			else
			{
				//For Future: Implement Error Message
			}
		}

		//Multiplication
		protected void Button_Click_Multiply(object sender, RoutedEventArgs e)
		{
			ImplementOperation('*');
		}

		private void Button_Click_Divide(object sender, RoutedEventArgs e)
		{
			ImplementOperation('/');
		}

		private void Button_Click_Add(object sender, RoutedEventArgs e)
		{
			ImplementOperation('+');
		}

		private void Button_Click_Subtract(object sender, RoutedEventArgs e)
		{
			ImplementOperation('-');
		}

		private void Button_Click_Power(object sender, RoutedEventArgs e)
		{
			if (RegOper == false)
			{
				Operand1 = Operand2;
				Operand2 = string.Empty;
				Operation = '^';
				Input = String.Format("{0}{1}", Operand1, Operation);
				this.Output.Text = Input;
				RegOper = true;
			}

			else
			{
				//For Future: Implement Error Message
			}
		}

		private void Button_Click_SqRt(object sender, RoutedEventArgs e)
		{
			if (RegOper == false)
			{
				Operand1 = Operand2;
				Operand2 = string.Empty;
				Operation = '√';
				Input = String.Format("{0}{1}", Operand1, Operation);
				this.Output.Text = Input;
				RegOper = true;
			}

			else
			{
				//For Future: Implement Error Message
			}
		}


		//Numbers
		private void NewMethod(string numString)
		{
			this.Output.Text = string.Empty;
			Operand2 += numString;
			this.Output.Text += Input + Operand2;
		}

		private void Button_Click_0(object sender, RoutedEventArgs e)
		{
			NewMethod("0");
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			NewMethod("1");
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			NewMethod("2"); ;
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			NewMethod("3"); ;
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			NewMethod("4"); ;
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			NewMethod("5"); ;
		}

		private void Button_Click_6(object sender, RoutedEventArgs e)
		{
			NewMethod("6"); ;
		}

		private void Button_Click_7(object sender, RoutedEventArgs e)
		{
			NewMethod("7"); ;
		}

		private void Button_Click_8(object sender, RoutedEventArgs e)
		{
			NewMethod("8");
		}

		private void Button_Click_9(object sender, RoutedEventArgs e)
		{
			NewMethod("9");
		}

		private void Button_Click_Period(object sender, RoutedEventArgs e)
		{
			NewMethod(".");
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
			double tempNum;
			double.TryParse(Operand2, out tempNum);

			if (tempNum != 0)
			{
				tempNum = -tempNum;
				Operand2 = tempNum.ToString();

				this.Output.Text = string.Empty;
				this.Output.Text += Input + Operand2;
			}

			else
			{
				Operand2 = "-";

				this.Output.Text = string.Empty;
				this.Output.Text += Input + Operand2;
			}


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

		//Clear Window - Click Once to Clear Line, Twice to Clear Memory Also
		private void Button_Click_Clear(object sender, RoutedEventArgs e)
		{
			//If double-clicked, clear entire history
			if ((WipeFlag == true) && (Operand2 == string.Empty) && (ErrorCheck == false))
			{
				Input = string.Empty;
				Operand1 = string.Empty;
				Operand2 = string.Empty;
				Operation = '\0';
				this.Output.Text = string.Empty;

				WipeFlag = false;
				RegOper = false;
				//EqualsUsed = false;
			}

			else
			{
				Operand2 = string.Empty;
				this.Output.Text = Input;
				WipeFlag = true;
			}
		}

		//Get Final Output
		private void Button_Click_Enter(object sender, RoutedEventArgs e)
		{
			Calculate();
		}

		private void Calculate()
		{
			//Makes sure that there is both a) a number to work with, and b) that there is an operation being used
			if ((Operand2 != string.Empty) && (Operation != '\0'))
			{
				double num1;
				double num2;
				double tempNum;

				double.TryParse(Operand1, out num1);
				double.TryParse(Operand2, out num2);


				switch (Operation)
				{
					case '*':
						{
							Result = num1 * num2;
							break;
						}

					case '/':
						{
							if (num2 != 0)
							{
								Result = num1 / num2;
							}

							else
							{
								ErrorCheck = true;
								this.Output.Text = "ERROR! DIVIDE BY ZERO!";
								Operand2 = string.Empty;
							}

							break;
						}

					case '+':
						{
							Result = num1 + num2;
							break;
						}

					case '-':
						{
							Result = num1 - num2;
							break;
						}

					case '^':
						{
							if (((num2 % 1) == 0) && ((num1 != 0) || (num2 >= 0)))
							{
								Result = Math.Pow(num1, num2);
							}

							else if ((num2 % 1) != 0)
							{
								ErrorCheck = true;
								this.Output.Text = "ERROR! EXPONENT IS NOT AN INTEGER!";
								Operand2 = string.Empty;
							}

							else if ((num2 < 0) && (num1 == 0))
							{
								ErrorCheck = true;
								this.Output.Text = "ERROR! DIVIDE BY ZERO!";
								Operand2 = string.Empty;
							}

							else
							{
								ErrorCheck = true;
								this.Output.Text = "UNEXPECTED ERROR! PLEASE NOTE AND RESOLVE!";
								Operand2 = string.Empty;
							}

							break;
						}

					case '√':
						{
							if ((num2 >= 0) && (num1 != 0) && ((num1 % 1) == 0))
							{
								Result = Math.Pow(num2, 1/num1);
							}

							else if (num1 == 0)
							{
								Result = Math.Pow(num2, 0.5);
							}

							else if ((num2 % 1) != 0)
							{
								ErrorCheck = true;
								this.Output.Text = "ERROR! EXPONENT IS NOT AN INTEGER!";
								Operand2 = string.Empty;
							}

							else if ((num2 == 0) && (num1 < 0))
							{
								ErrorCheck = true;
								this.Output.Text = "ERROR! DIVIDE BY ZERO!";
								Operand2 = string.Empty;
							}

							else if (((num1 % 2) == 0) && (num1 < 0))
							{
								ErrorCheck = true;
								this.Output.Text = "ERROR! ANSWER IS A COMPLEX NUMBER!";
								Operand2 = string.Empty;
							}

							else
							{
								ErrorCheck = true;
								this.Output.Text = "UNEXPECTED ERROR! PLEASE NOTE AND RESOLVE!";
								Operand2 = string.Empty;
							}

							break;
						}
				}

				//Prevent 
				if (ErrorCheck == false)
				{
					this.Output.Text = String.Format("{0} = {1}", this.Output.Text, Result.ToString());

					//Reset Variables
					//ResetOper & WipeFlag Flag
					RegOper = false;
					WipeFlag = false;
					ErrorCheck = false;
					//Carry Over/Continuation Code
					//Set Use Flag & Operand1 for carry over
					//EqualsUsed = true;
					Operand1 = Result.ToString();
					//Input = Operand1;
					//Reset Values to Default
					Input = string.Empty;
					Operand2 = string.Empty;
					Operation = '\0';
					Result = 0.0;
				}
				else
				{
					//RegOper = false;
					//WipeFlag = false;
					ErrorCheck = false;
					//For Future: Implement Error Message
				}


			}

			else
			{
				//For Future: Implement Error Message
			}
		}
	}
}

//Error & Implementation List:
//- I: Need to implement pop-up error messages (ideally temporary/fading pop-up messages)
//- I: Is EqualsUsed necessary? Double check.
//- I: Add keyboard input
//- I: "Fix" roots, as currently implemented you assign Operand2 first then Operand1, and Clearing erases everything
//- E: -3root(0) = infinity, not an Error Message