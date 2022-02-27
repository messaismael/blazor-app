using System.Text.RegularExpressions;
namespace BlazorApp
{
  public class CaculatorOperation
  {
    public string strNum = $"{'0'}";
    public string num = $"{'0'}";
    public bool resetStatus = true;

    private string strPattern = "\\d{1,}[+÷×-]\\d{1,}";

    public void addElement(char el)
    {
			if(num.Length < 18 || Regex.IsMatch(strNum, "([+÷×-])$"))
			{
				if (string.Equals(strNum, "0"))
				{
					strNum = $"{el}";
					num = $"{el}";
				}
				else
				{
					if (num.Equals("0") || num.Equals("-0"))
					{
						strNum = Regex.Replace(strNum, "(0)$", ""); // "3.14+0" to "3.10+"
					}
					strNum += el;
					String mt = getLastEl();
					num = $"{mt}";
				}
				isResetable();
			}
    }

    public void addComma(char el)
    {

      if (Regex.IsMatch(strNum, "([+÷×-])$"))
      {
        strNum += $"0{el}";
      }
      else if (strNum.Equals("0"))
      {
        strNum = $"0{el}";

      }
      else if (!Regex.IsMatch(num, "[.]+"))
      {
        strNum += $"{el}";
      }
      num = getLastEl();
    }

    public void addSign()
    {
      string last = getLastEl();

      if (num.Equals("0") || num.Equals("0.") || Regex.IsMatch(strNum, "([+÷×-])$"))
      {
        num = $"-0";
      }
      else if (Regex.IsMatch(num, "^[-]+"))
      {
        num = Regex.Replace(num, "^[-]+", ""); ;
      }
      else
      {
        num = $"-{num}";
      }

      strNum = Regex.Replace(num, last, num);
    }
    public void addOperator(char op)
    {

      equalOperator();
      if (Regex.IsMatch(num, "[.]$"))
      { // 3.+
        strNum = Regex.Replace(strNum, "[.]$", "");
      }

      if (Regex.IsMatch(strNum, "([×+÷-])$"))
      {
        strNum = Regex.Replace(strNum, @"([×+÷-])$", $"{op}");
      }
      else
      {
        strNum += op;
      }
      isResetable();
    }

    public void percentage()
    {
      isResetable();

      strNum += "÷100";
      equalOperator();
      num = strNum;
    }
    public void reset()
    {
      strNum = "0";
      num = strNum;
    }
    public void erase()
    {
      if (!strNum.Equals("0"))
      {
        strNum = Regex.Replace(strNum, "(\\d{0,1}|[.])$", ""); // ex 3.14 (4)  or 3. (.)
        string mt = getLastEl(); // (3.1) (3)

        if (mt.Equals(""))
        {
          strNum += "0";
          num = "0";
        }
        else
        {
          num = mt;
        }
      }
    }
    public void isResetable()
    {
      if (Regex.IsMatch(strNum, "([×+÷-]+)$"))
      {
        resetStatus = true;
      }
      else
      {
        resetStatus = false;
      }
    }
    public void equalOperator()
    {
      resetStatus = true;
      if (Regex.IsMatch(strNum, strPattern))
      {
        strNum = Regex.Replace(strNum, @"[×]", "*");
        strNum = Regex.Replace(strNum, @"[÷]", "/");
        strNum = Convert.ToString(Evaluate(strNum));
        num = strNum;
      }
    }

    public String getLastEl()
    {
      Match mt = Regex.Match(strNum, "([-]?\\d+)$");

      if (Regex.IsMatch(strNum, "([-]?\\d+[.])$"))
      {
        mt = Regex.Match(strNum, "([-]?\\d+[.])$");
        if (mt.Success)
        {
          return mt.Value;
        }
      }
      else if (Regex.IsMatch(strNum, "([-]?\\d+[.]\\d+)$"))
      {
        mt = Regex.Match(strNum, "([-]?\\d+[.]\\d+)$");
        if (mt.Success)
        {
          return mt.Value;
        }
      }
      return mt.Value;
    }

    /**
    * Evaluate methon convent an operation of number in double quotes to number
    */
    public double Evaluate(string expression)
    {
      System.Data.DataTable table = new System.Data.DataTable();
      table.Columns.Add("expression", string.Empty.GetType(), expression);
      System.Data.DataRow row = table.NewRow();
      table.Rows.Add(row);
      return double.Parse((string)row["expression"]);
    }

  }
}