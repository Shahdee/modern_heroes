using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UIInstaller", menuName = "SO/Installers/UIInstaller")]
public class UIInstaller : ScriptableObjectInstaller<UIInstaller>
{
    [SerializeField] private UICanvasView _canvasView;
    [SerializeField] private MainWindowView _mainWindowView;
    [SerializeField] private BattleWindowView _battleWindowView;
    [SerializeField] private EndWindowView _endWindowView;

    public override void InstallBindings()
    {
        Container.Bind<UICanvasView>().FromComponentInNewPrefab(_canvasView).AsSingle();

        BindWindows();

        Container.BindInterfacesTo<WindowStorage>().AsSingle();
        Container.BindInterfacesTo<UIController>().AsSingle();
        Container.BindInterfacesTo<UICanvas>().AsSingle().NonLazy();
    }

    private void BindWindows()
    {
        BindPrefab(_mainWindowView);
        BindPrefab(_battleWindowView);
        BindPrefab(_endWindowView);

        Container.BindInterfacesTo<MainWindow>().AsSingle();
        Container.BindInterfacesTo<BattleWindow>().AsSingle();
        Container.BindInterfacesTo<EndWIndow>().AsSingle();
    }

    private void BindPrefab<T>(T prefab) where T : MonoBehaviour
    {
        Container.Bind<T>().FromComponentInNewPrefab(prefab).AsSingle();
    }
}