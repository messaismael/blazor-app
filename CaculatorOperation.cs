namespace BlazorApp
{
    public class CaculatorOperation
    {
        public string num = " 0";
        double num2 = 0.0;
        double res = 0.0;

        public void addElement(char el){
            num+= el;
        }

        public double equalOperator(){
            return Evaluate(num);
        }

        public double Evaluate(string expression)  
       {  
           System.Data.DataTable table = new System.Data.DataTable();  
           table.Columns.Add("expression", string.Empty.GetType(), expression);  
           System.Data.DataRow row = table.NewRow();  
           table.Rows.Add(row);  
           return double.Parse( (string)row["expression"]);  
       }

    }
}