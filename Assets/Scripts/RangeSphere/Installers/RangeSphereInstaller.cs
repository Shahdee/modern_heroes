using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "RangeSphereInstaller", menuName = "SO/Installers/RangeSphereInstaller")]
public class RangeSphereInstaller : ScriptableObjectInstaller<RangeSphereInstaller>
{
    [SerializeField] private RangeSphereView _rangeSphereView;

    public override void InstallBindings()
    {
        Container.Bind<RangeSphereView>().FromComponentInNewPrefab(_rangeSphereView).AsSingle();
        Container.BindInterfacesTo<RangeSphereController>().AsSingle();
    }
}