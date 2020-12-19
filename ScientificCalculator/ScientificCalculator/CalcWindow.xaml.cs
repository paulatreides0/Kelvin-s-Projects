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
		string Input;
		string Operand1;
		string Operand2;
		char? Operation;
		double Result;

		//Determines if you just clear line, or wipe memory also
		bool HaveWiped = false;
		//Ensures there is no saved operation
		bool RegOper = false;
		//Checks if equal sign has been used, 
		//bool EqualsUsed = false;
		//Checks for fatal errors
		bool HasError = false;

		public CalcWindow()
		{
			InitializeComponent();

			this.Input = string.Empty;
			this.Operand1 = string.Empty;
			this.Operand2 = string.Empty;
			this.Operation = null;
			this.Result = 0.0;

			this.HaveWiped = false;
			this.RegOper = false;
			//this.EqualsUsed = false;
			this.HasError = false;
		}

		//Operations
		//Generic Operation Implementer
		private void ImplementOperation(char oper)
		{
			if (!this.RegOper)
			{
				this.Operand1 = Operand2;
				this.Operand2 = string.Empty;
				this.Operation = oper;
				this.Input = String.Format("{0} {1} ", Operand1, Operation);
				this.Output.Text = Input;
				this.RegOper = true;
			}
			else
			{
				//For Future: Implement Error Message
			}
		}

		protected void Button_Click_Multiply(object sender, RoutedEventArgs e)
		{
			this.ImplementOperation('*');
		}

		private void Button_Click_Divide(object sender, RoutedEventArgs e)
		{
			this.ImplementOperation('/');
		}

		private void Button_Click_Add(object sender, RoutedEventArgs e)
		{
			this.ImplementOperation('+');
		}

		private void Button_Click_Subtract(object sender, RoutedEventArgs e)
		{
			this.ImplementOperation('-');
		}

		private void Button_Click_Power(object sender, RoutedEventArgs e)
		{
			if (!this.RegOper)
			{
				this.Operand1 = Operand2;
				this.Operand2 = string.Empty;
				this.Operation = '^';
				this.Input = String.Format("{0}{1}", Operand1, Operation);
				this.Output.Text = Input;
				this.RegOper = true;
			}
			else
			{
				//For Future: Implement Error Message
			}
		}

		private void Button_Click_SqRt(object sender, RoutedEventArgs e)
		{
			if (!this.RegOper)
			{
				this.Operand1 = Operand2;
				this.Operand2 = string.Empty;
				this.Operation = '√';
				this.Input = String.Format("{0}{1}", Operand1, Operation);
				this.Output.Text = Input;
				this.RegOper = true;
			}
			else
			{
				//For Future: Implement Error Message
			}
		}


		//Numbers
		private void ButtonInput(string numString)
		{
			this.Operand2 += numString;
			this.Output.Text = Input + Operand2;
		}

		private void Button_Click_0(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("0");
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("1");
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("2"); ;
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("3"); ;
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("4"); ;
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("5"); ;
		}

		private void Button_Click_6(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("6"); ;
		}

		private void Button_Click_7(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("7"); ;
		}

		private void Button_Click_8(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("8");
		}

		private void Button_Click_9(object sender, RoutedEventArgs e)
		{
			this.ButtonInput("9");
		}

		private void Button_Click_Period(object sender, RoutedEventArgs e)
		{
			this.ButtonInput(".");
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
			
			if (double.TryParse(Operand2, out tempNum))
			{

			}
			else if (Operand1 == "")
			{
				tempNum = 0;
			}
			else
			{
				//For Future: Implement Error
			}

			if (tempNum != 0)
			{
				tempNum = -tempNum;
				this.Operand2 = tempNum.ToString();
				this.Output.Text = Input + Operand2;
			}
			else
			{
				this.Operand2 = "-";
				this.Output.Text = Input + Operand2;
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
		private  void ImplementClear(bool clearAll)
		{
			if (clearAll)
			{
				this.Input = string.Empty;
				this.Operand1 = string.Empty;
				this.Operand2 = string.Empty;
				this.Operation = null;
				this.Output.Text = string.Empty;

				this.HaveWiped = false;
				this.RegOper = false;
				//EqualsUsed = false;
				this.HasError = false;
			}
			else
			{
				this.Operand2 = string.Empty;
				this.Output.Text = Input;

				this.HaveWiped = true;
				this.HasError = false;
			}
		}

		//Clear Window - Click Once to Clear Line, Twice to Clear Memory Also
		private void Button_Click_Clear(object sender, RoutedEventArgs e)
		{
			//If double-clicked, clear entire history
			if ((this.HaveWiped) && (this.Operand2 == string.Empty) && (!this.HasError))
			{
				this.ImplementClear(true);
			}
			else
			{
				this.ImplementClear(false);
			}
		}

		//Get Final Output
		private void Button_Click_Enter(object sender, RoutedEventArgs e)
		{
			this.Calculate();
		}

		private void Calculate()
		{
			double num1;
			double num2;
			double tempNum;

			//Makes sure that there is both a) a number to work with, and b) that there is an operation being used
			if ((this.Operand2 != string.Empty) && (this.Operation != null))
			{
				if (double.TryParse(this.Operand1, out num1))
				{

				}
				else if (this.Operand1 == string.Empty)
				{
					num1 = 0;
				}
				else
				{
					//For Future: Implement Error
				}

				if (double.TryParse(this.Operand2, out num2))
				{

				}
				else if (this.Operand1 == string.Empty)
				{
					num2 = 0;
				}
				else
				{
					//For Future: Implement Error
				}

				switch (this.Operation)
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
								this.HasError = true;
								this.Output.Text = "ERROR! DIVIDE BY ZERO!";
								this.Operand2 = string.Empty;
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
							double baseNum = num1;
							double exponent = num2;

							if (((exponent % 1) == 0) && ((baseNum != 0) || (exponent >= 0)))
							{
								this.Result = Math.Pow(baseNum, exponent);
							}

							else if ((exponent % 1) != 0)
							{
								this.HasError = true;
								this.Output.Text = "ERROR! EXPONENT IS NOT AN INTEGER!";
								this.Operand2 = string.Empty;
							}

							else if ((exponent < 0) && (baseNum == 0))
							{
								this.HasError = true;
								this.Output.Text = "ERROR! DIVIDE BY ZERO!";
								this.Operand2 = string.Empty;
							}

							else
							{
								this.HasError = true;
								this.Output.Text = "UNEXPECTED ERROR! PLEASE NOTE AND RESOLVE!";
								this.Operand2 = string.Empty;
							}

							break;
						}

					case '√':
						{
							double radicand = num2;
							double root = num1;

							if ((((radicand >= 0) && (root > 0)) || ((radicand > 0) && (root < 0))) && ((root % 1) == 0))
							{
								this.Result = Math.Pow(radicand, 1.0/root);
							}

							//Default to SqRt if no root is provided
							else if (root == 0)
							{
								this.Result = Math.Pow(radicand, 0.5);
							}

							else if ((root % 1) != 0)
							{
								this.HasError = true;
								this.Output.Text = "ERROR! EXPONENT IS NOT AN INTEGER!";
								this.Operand2 = string.Empty;
								//This is currently kind of borked, need to change Operand1, not Operand2
							}

							else if ((radicand == 0) && (root < 0))
							{
								this.HasError = true;
								this.Output.Text = "ERROR! DIVIDE BY ZERO!";
								this.Operand2 = string.Empty;
							}

							else if (((root % 2) == 0) && (radicand < 0))
							{
								this.HasError = true;
								this.Output.Text = "ERROR! ANSWER IS A COMPLEX NUMBER!";
								this.Operand2 = string.Empty;
							}

							else
							{
								this.HasError = true;
								this.Output.Text = "UNEXPECTED ERROR! PLEASE NOTE AND RESOLVE!";
								this.Operand2 = string.Empty;
							}

							break;
						}
				}

				//Prevent code with error from running
				if (!HasError)
				{
					this.Output.Text = String.Format("{0} = {1}", this.Output.Text, Result.ToString());

					//Reset Variables
					//ResetOper & HaveWiped Flag
					this.RegOper = false;
					this.HaveWiped = false;
					this.HasError = false;
					//Carry Over/Continuation Code
					//Set Use Flag & Operand1 for carry over
					//this.EqualsUsed = true;
					this.Operand1 = Result.ToString();
					//Input = Operand1;
					//Reset Values to Default
					this.Input = string.Empty;
					this.Operand2 = string.Empty;
					this.Operation = null;
					this.Result = 0.0;
				}
				else
				{
					//this.RegOper = false;
					//this.HaveWiped = false;
					this.HasError = false;
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
//- I: Add keyboard input
//- I: "Fix" roots, as currently implemented you assign Operand2 first then Operand1, and Clearing erases everything
//- I: Need to implement pop-up error messages (ideally temporary/fading pop-up messages)
// -I: Implement ability to read and interpret arbitrarily long string before using equals
//- I: Is EqualsUsed necessary? Double check.
// -I: Implement input by using char list checking operation symbols as delimiters when operation is invoked?