using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UIInstaller", menuName = "SO/Installers/UIInstaller")]
public class UIInstaller : ScriptableObjectInstaller<UIInstaller>
{
    [SerializeField] private UICanvasView _canvasView;
    [SerializeField] private MainWindowView _mainWindowView;
    [SerializeField] private BattleWindowView _battleWindowView;
    [SerializeField] private EndWindowView _endWindowView;
    [SerializeField] private HealthBarView _healthBarView;

    public override void InstallBindings()
    {
        BindHealthBar();
        BindWindows();

        Container.BindInterfacesTo<WindowStorage>().AsSingle();
        Container.BindInterfacesTo<UIController>().AsSingle();
        Container.BindInterfacesTo<UICanvas>().AsSingle().NonLazy();
    }

    private void BindHealthBar()
    {
        Container.BindInstance(_healthBarView);

        Container.BindInterfacesTo<HealthBarController>().AsSingle();
        Container.BindInterfacesTo<HealthBarFactory>().AsSingle();
        Container.BindInterfacesTo<HealthBarStorage>().AsSingle();
    }

    private void BindWindows()
    {
        BindAsset(_mainWindowView);
        BindAsset(_battleWindowView);
        BindAsset(_endWindowView);
        BindAsset(_canvasView);

        Container.BindInterfacesTo<MainWindow>().AsSingle();
        Container.BindInterfacesTo<BattleWindow>().AsSingle();
        Container.BindInterfacesTo<EndWIndow>().AsSingle();
    }

    private void BindAsset<T>(T prefab) where T : MonoBehaviour
    {
        Container.Bind<T>().FromComponentInNewPrefab(prefab).AsSingle();
    }
}