using System;
using R3;
using RinaCorrection;
using RinaStatus.Runtime.Value;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;

namespace RinaStatus {
    public abstract class ACorrectableStatus<ValueType> : AStatus<ValueType>, ICorrectableStatus<ValueType> {
        
        [TitleGroup("値")]
        [OdinSerialize]
        [Title("補正後の値")]
        protected IValueModule<ValueType> m_correctedValue;
        
        [TitleGroup("参照")]
        [OdinSerialize]
        [ReadOnly]
        protected ICorrectionManager m_correctionManager;
        
        protected override ReadOnlyReactiveProperty<ValueType> GetValue() => m_correctedValue.Value;

        public override void Set(ValueType next) {
            base.Start();

            m_correctedValue = m_resolver
                .Resolve<IValueModule<ValueType>>() ?? throw new ArgumentNullException();
            
            var nextCorrected = CalculateCorrection(m_rawValue.Value.CurrentValue);
            m_correctedValue.Set(nextCorrected);
        }

        private ValueType CalculateCorrection(ValueType rawValue) {
            dynamic value = rawValue;
            dynamic nextCorrected = m_correctionManager.Apply(value);
            return nextCorrected;
        }
    }
}