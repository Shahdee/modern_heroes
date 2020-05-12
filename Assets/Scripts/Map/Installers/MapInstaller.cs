using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MapInstaller", menuName = "SO/Installers/MapInstaller")]
public class MapInstaller : ScriptableObjectInstaller<MapInstaller>
{
    [SerializeField] private TileMapView _tileMapView;

    public override void InstallBindings()
    {
        Container.Bind<TileMapView>().FromComponentInNewPrefab(_tileMapView).AsSingle();
        Container.BindInterfacesTo<MapController>().AsSingle();
    }
}