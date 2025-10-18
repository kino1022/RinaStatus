using RinaStatus.Calculator;
using RinaStatus.Runtime.Value;
using VContainer;
using VContainer.Unity;

namespace RinaStatus.Installer.Manager {
    /// <summary>
    /// ステータスのシステムを管理するマネージャークラスに対して利用するインストーラー
    /// </summary>
    public class StatusManagerInstaller : IInstaller {
        
        public void Install(IContainerBuilder builder) {

            builder.Register<ICalculator<int>, IntCalculator>(Lifetime.Singleton);
            
            builder.Register<ICalculator<float>, FloatCalculator>(Lifetime.Singleton);

            builder.Register<IValueModule<int>, ValueModule<int>>(Lifetime.Transient);
            
            builder.Register<IValueModule<float>, ValueModule<float>>(Lifetime.Singleton);
        }
    }
}