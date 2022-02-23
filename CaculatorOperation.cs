using System.Text.RegularExpressions;
namespace BlazorApp
{
    public class CaculatorOperation
    {
        public string strNum = " 0";
        public string num = " 0";
        public bool resetStatus = true;

        private string strPattern = "\\d{1,}[+÷×-]\\d{1,}";

        public void addElement(char el){
            Regex rg = new Regex("(\\d+)$");


            if(string.Equals(strNum, " 0") || string.Equals(strNum, "0")){
                strNum = $"{el}";
                num = $"{el}";
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
            isResetable();

        }
        public void addOperator(char op){
            
            if(Regex.IsMatch(strNum, strPattern)){
                strNum = Regex.Replace(strNum,@"[×]", "*");
                strNum = Regex.Replace(strNum,@"[÷]", "/");
                strNum = Convert.ToString(Evaluate(strNum));
                num = strNum;
            }
            
            if(Regex.IsMatch(strNum, "([×+÷-])$")){
                    strNum = Regex.Replace(strNum, @"([×+÷-])$", $"{op}");
            } else {
                strNum+= op;
            }
            isResetable();
        }

        public void percentage () {
            isResetable();

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
            Regex rg = new Regex("(\\d+)$");
            if(resetStatus)
                Console.WriteLine("redet",resetStatus);

            if(!strNum.Equals(" 0")) {
                strNum = Regex.Replace(strNum, "(\\d{1,1}|[.]{1,1})$", "");
                Match mt = rg.Match(strNum);
                if(mt.Success){
                    num= $"{mt.Value}";
                }else if(mt.Value.Equals("")){
                    strNum +=0;
                    num = " 0";
                }
                else{
                    num= strNum;
                }
            }
        }
        public void isResetable () {
            if(Regex.IsMatch(strNum, "([×+÷-]+)$")){
                resetStatus = true;
            }else{
                resetStatus = false;
            }
        }
        public void equalOperator(){
            resetStatus = true;
            if(Regex.IsMatch(strNum, strPattern)) {
                strNum = Regex.Replace(strNum,@"[×]", "*");
                strNum = Regex.Replace(strNum,@"[÷]", "/");
                strNum = Convert.ToString(Evaluate(strNum));
                num = strNum;
            }
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