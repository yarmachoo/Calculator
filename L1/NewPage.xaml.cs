using System;

namespace L1;

public partial class NewPage : ContentPage
{
    private bool IsFloat = false;
    public string Expr { get; set; }
    private double num1 { get; set; } = 0;
    private double num2 { get; set; } = 0;
    private string mathOperator {  get; set; }
    private int curState { get; set; } = 0;
                                       //0 - wait to input first num
                                       //1 - first num is inputed and operator is clicked, wait to input second num
                                       //2 - second num is inputed after clicking GetResult (=) 
                                       //3 - if operator is clicked after input of second/else operator
	public NewPage()
	{

		InitializeComponent();
	}
	public void ClickedOnNumber(object sender, EventArgs e)
	{

        if (sender == One)
        {
            if(Expr=="0")
                Expr="1";
            else Expr+="1" +
                    "";
        }
        else if (sender == Two)
        {
            if (Expr == "0")
                Expr = "2";
            else Expr += "2";
        }
        else if (sender == Three)
        {
            if (Expr == "0")
                Expr = "3";
            else Expr += "3";
        }
        else if (sender == Four)
        {
            if (Expr == "0")
                Expr = "4";
            else Expr += "4";
        }
        else if (sender == Fife)
        {
            if (Expr == "0")
                Expr = "5";
            else Expr += "5";
        }
        else if (sender == Six)
        {
            if (Expr == "0")
                Expr = "6";
            else Expr += "6";
        }
        else if (sender==Seven)
		{
            if (Expr == "0")
                Expr = "7";
            else Expr += "7";
		}	
		else if (sender == Eight)
        {
            if (Expr == "0")
                Expr = "8";
            else Expr += "8";
        }
        else if (sender == Nine)
        {
            if (Expr == "0")
                Expr = "9";
            else Expr += "9";
        }
        else if (sender == Zero)
        {
            if (Expr == "0")
                Expr = "0";
            else Expr += "0";
        }

        UpdateExpression();
    }
    public void GetExpression(object sender, EventArgs e)
    {  
        double num = double.Parse(Expr);
        if (curState == 1)
        {
            num2 = num;
            curState = 2;
            Expr = Calculate.Solve(num1, num2, mathOperator);
            num1 = double.Parse(Expr);
            num2 = 0;
        }
        UpdateExpression();
    }
    public void GetFloatNum(object sender, EventArgs e) 
    {
        if (!IsFloat)
        {
            Expr += ",";
            IsFloat = true;
        }
        UpdateExpression();
    }
    public void ChangeSign(object sender, EventArgs e)
    {
        double num = double.Parse(Expr);

        num*=-1;
        Expr = num.ToString();
        UpdateExpression();
    }
    public void ClickOnOperator(object sender, EventArgs e)
    {
        Button button = sender as Button;
        mathOperator = button.Text;
        double num = double.Parse(Expr);
        Expr = "0";
        UpdateExpression();
        if (curState == 0)
        {
            num1 = num;
            curState = 1;
        }
        else if(curState == 1) 
        {
            num2 = num;
            curState = 1;
            Expr = Calculate.Solve(num1, num2, mathOperator);
            num1 = double.Parse(Expr);
            num2 = 0;
            curState = 2;
        }
        else if(curState == 2)
        {
            curState = 1;
        }
    }
    public void UnaryOperatorClicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        mathOperator = button.Text;
        double num = double.Parse(Expr);
        num1 = num;
        Expr = Calculate.UnaryOperator(num1, mathOperator);
        num1 = double.Parse(Expr);
        num2 = 0;
        curState = 2;
        UpdateExpression();
    }
    public void Clean(object sender, EventArgs e) 
    {
        Delete(sender, e);
    }
    public void CleanEntry(object sender, EventArgs e)
    {

        Expr = "0";
        curState = 0;
        num1 = 0;
        num2 = 0;

        UpdateExpression();
    }
    public void Delete(object sender, EventArgs e) 
    {
        if (Expr.Length > 0 && Expr != "0")
            Expr = Expr.Remove(Expr.Length - 1, 1);
        if (Expr == "")
        {
            Expr = "0";
            curState = 0;
            num1 = 0;
            num2 = 0;
        }

        UpdateExpression();
    }
    private void UpdateExpression()
    {
        Expression.Text = Expr;
    }
}