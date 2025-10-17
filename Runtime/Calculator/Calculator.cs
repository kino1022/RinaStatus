namespace RinaStatus.Calculator {
    
    public interface ICalculator<ValueType> {
        
        ValueType Add (ValueType left, ValueType right);
        
        ValueType Subtract(ValueType left, ValueType right);
        
        ValueType Multiply(ValueType left, ValueType right);
        
        ValueType Divide(ValueType left, ValueType right);
        
        /// <summary>
        /// 0に当たる値
        /// </summary>
        ValueType Zero { get; }
        
        /// <summary>
        /// -1.0に当たる値
        /// </summary>
        ValueType Minus { get; }
        
        bool Equals(ValueType left, ValueType right);
        
        bool Greater(ValueType left, ValueType right);
        
        bool Less(ValueType left, ValueType right);
    }

    public class IntCalculator : ICalculator<int> {
        
        public int Add (int left, int right) => left + right;
        
        public int Subtract(int left, int right) => left - right;
        
        public int Multiply(int left, int right) => left * right;
        
        public int Divide(int left, int right) => left / right;
        
        public int Zero => 0;

        public int Minus => -1;
        
        public bool Equals(int left, int right) => left == right;
        
        public bool Greater(int left, int right) => left > right;
        
        public bool Less(int left, int right) => left < right;
    }
    
    public class FloatCalculator : ICalculator<float> {
        
        public float Add (float left, float right) => left + right;
        
        public float Subtract(float left, float right) => left - right;
        
        public float Multiply(float left, float right) => left * right;
        
        public float Divide(float left, float right) => left / right;

        public float Zero => 0.0f;

        public float Minus => -1.0f;
        
        public bool Equals(float left, float right) => left == right;
        
        public bool Greater(float left, float right) => left > right;
        
        public bool Less(float left, float right) => left < right;
    }
}