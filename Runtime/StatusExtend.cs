using R3;
using RinaStatus.Calculator;

namespace RinaStatus {
    public static class StatusExtend {

        /// <summary>
        /// ステータスが特定の値を下回った場合に流れるストリームを提供する
        /// </summary>
        /// <param name="status"></param>
        /// <param name="calculator"></param>
        /// <param name="value"></param>
        /// <typeparam name="ValueType"></typeparam>
        /// <returns></returns>
        public static Observable<Unit> ObserveLessAny<ValueType>(this IStatus<ValueType> status, ICalculator<ValueType> calculator, ValueType value) 
        {
            return status
                .Value
                .Where(x => calculator.Less(x, value))
                .Select(_ => Unit.Default);
        }

        /// <summary>
        /// ステータスが0以下になった際に流れるストリームを提供する
        /// </summary>
        /// <param name="status"></param>
        /// <param name="calculator"></param>
        /// <typeparam name="ValueType"></typeparam>
        /// <returns></returns>
        public static Observable<Unit> ObserveIsZero<ValueType>(this IStatus<ValueType> status, ICalculator<ValueType> calculator) 
        {
            return status
                .ObserveLessAny(calculator, calculator.Zero);
        }
    }
}