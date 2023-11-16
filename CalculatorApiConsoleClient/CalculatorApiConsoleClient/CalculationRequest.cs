namespace CalculatorApiConsoleClient
{
    internal class CalculationRequest
    {
        public CalculationRequest(string methodName, double num1, double num2)
        {
            MethodName = methodName;
            Num1 = num1;
            Num2 = num2;
        }

        public string MethodName { get; set; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public double Result { get; set; }

    }

}
