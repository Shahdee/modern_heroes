using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "HelperInstaller", menuName = "SO/Installers/HelperInstaller")]
public class HelperInstaller : ScriptableObjectInstaller<HelperInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<CoroutineManager>().AsSingle();
    }
}