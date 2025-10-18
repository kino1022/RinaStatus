using System;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace RinaStatus.Runtime.Value {
    
    /// <summary>
    /// 値を保持するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="ValueType"></typeparam>
    public interface IValueModule<ValueType> {
        
        /// <summary>
        /// 管理している現在の値
        /// </summary>
        ReadOnlyReactiveProperty<ValueType> Value { get; }

        /// <summary>
        /// 値の上書きを行う
        /// </summary>
        /// <param name="next"></param>
        void Set(ValueType next);
        
    }

    [Serializable]
    public class ValueModule<ValueType> : IValueModule<ValueType> {

        [OdinSerialize]
        [LabelText("現在の値")]
        private ReactiveProperty<ValueType> m_value;
        
        public ReadOnlyReactiveProperty<ValueType> Value => m_value;
        
        #if UNITY_EDITOR
        
        [ShowInInspector]
        private ValueType InspectorValue => m_value.Value;
        
        #endif

        public ValueModule() {
            m_value = new ReactiveProperty<ValueType>();
        }
        
        public void Set(ValueType next) => m_value.Value = next;
        
    }
    
}