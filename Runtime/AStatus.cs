using System;
using R3;
using RinaStatus.Calculator;
using RinaStatus.Runtime.Value;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;

namespace RinaStatus {
    public abstract class AStatus<ValueType> : SerializedMonoBehaviour, IStatus<ValueType> {
    
        [TitleGroup("値")]
        [Title("元の値")]
        [OdinSerialize]
        protected IValueModule<ValueType> m_rawValue;
        
        [TitleGroup("参照")]
        [OdinSerialize]
        [ReadOnly]
        [LabelText("計算")]
        protected ICalculator<ValueType> m_calculator;

        public ReadOnlyReactiveProperty<ValueType> Value => GetValue();
        
        protected IObjectResolver m_resolver;

        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException();
        }

        protected virtual void Start() {
            
            m_rawValue = m_resolver
                .Resolve<IValueModule<ValueType>>() ?? throw new ArgumentNullException();
            
            m_calculator = m_resolver
                .Resolve<ICalculator<ValueType>>() ?? throw new ArgumentNullException();
            
        }

        [Button("値のセット")]
        public virtual void Set(ValueType next) {
            m_rawValue.Set(next);
        }

        [Button("増加")]
        public virtual void Increase(ValueType next) {
            Set(m_calculator.Add(m_rawValue.Value.CurrentValue, next));
        }

        [Button("減少")]
        public virtual void Decrease(ValueType next) {
            Set(m_calculator.Subtract(m_rawValue.Value.CurrentValue, next));
        }

        protected virtual ReadOnlyReactiveProperty<ValueType> GetValue() => m_rawValue.Value;

    }
}