using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "HitInstaller", menuName = "SO/Installers/HitInstaller")]
public class HitInstaller : ScriptableObjectInstaller<HitInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<HitController>().AsSingle();
    }
}