using R3;
using RinaStatus.Runtime.Value;

namespace RinaStatus {
    public interface IStatus<ValueType> {
        
        /// <summary>
        /// 現在の値
        /// </summary>
        ReadOnlyReactiveProperty<ValueType> Value { get; }
        
        /// <summary>
        /// 値を上書きする
        /// </summary>
        /// <param name="next"></param>
        void Set(ValueType next);
        
        /// <summary>
        /// 値を増加させる
        /// </summary>
        /// <param name="amount"></param>
        void Increase (ValueType amount);
        
        /// <summary>
        /// 値を減少させる
        /// </summary>
        /// <param name="amount"></param>
        void Decrease (ValueType amount);
    }
}