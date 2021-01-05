namespace NonPrimitiveTypes.Math
{
    public static class Calculator
    {
        private static int result = 0;
        public static int Add(int input)
        {
            return result += input;
        }
        
        public static int Subtract(int input)
        {
            return result -= input;
        }
        
        public static int Multiply(int input)
        {
            return result *= input;
        }

        public static void Clear()
        {
            result = 0;
        }
    }
}