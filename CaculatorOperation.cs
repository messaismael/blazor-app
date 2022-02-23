using System.Text.RegularExpressions;
namespace BlazorApp
{
    public class CaculatorOperation
    {
        public string strNum = " 0";
        public string num = " 0";

        private string strPattern = "\\d{1,}[+÷×-]\\d{1,}";

        public void addElement(char el){
            Regex rg = new Regex("(\\d+)$");
            if(string.Equals(strNum, " 0")){
                strNum = $" {el}";
                num = $" {el}";
            } 
            else {
                strNum+=el;
                Match mt = rg.Match(strNum);

                if( mt.Success){
                    num = $"{mt.Value}";
                }else{
                    num= strNum;
                }
            }
        }
        public void addOperator(char op){

            if(Regex.IsMatch(strNum, strPattern)){
                strNum = Regex.Replace(strNum,@"[×]", "*");
                strNum = Regex.Replace(strNum,@"[÷]", "/");
                strNum = Convert.ToString(Evaluate(strNum));
                num = strNum;
            }
            
            if(Regex.IsMatch(strNum, "([×+÷-])$")){
                    Console.WriteLine("IT'S TRUEE;;;;;");
                    strNum = Regex.Replace(strNum, @"([×+÷-])$", $"{op}");
            } else {
                strNum+= op;
            }
        }

        public void percentage () {
            strNum +="/100";
            strNum = Regex.Replace(strNum,@"[×]", "*");
            strNum = Regex.Replace(strNum,@"[÷]", "/");
            strNum = Convert.ToString(Evaluate(strNum));
        }
        public void reset(){
            strNum = " 0";
            num = strNum;
        }
        public void erase(){
            if(!strNum.Equals(" 0")) {
                strNum = Regex.Replace(strNum, @"(\\d[×+.÷-])$", "");
            }
        }
        public void equalOperator(){
            if(Regex.IsMatch(strNum, strPattern))
                strNum = Regex.Replace(strNum,@"[×]", "*");
                strNum = Regex.Replace(strNum,@"[÷]", "/");
                strNum = Convert.ToString(Evaluate(strNum));
                num = strNum;
        }

        /**
        * Evaluate methon convent an operation of number in double quotes to number
        */
        public double Evaluate(string expression) {
           System.Data.DataTable table = new System.Data.DataTable();
           table.Columns.Add("expression", string.Empty.GetType(), expression);
           System.Data.DataRow row = table.NewRow();
           table.Rows.Add(row);
           return double.Parse( (string)row["expression"]);
        }

    }
}