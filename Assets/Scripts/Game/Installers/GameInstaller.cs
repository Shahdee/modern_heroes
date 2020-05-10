using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
            Container.BindInterfacesTo<GameController>().AsSingle();
            Container.BindInterfacesTo<BattleController>().AsSingle();

#if UNITY_STANDALONE || UNITY_EDITOR
            Container.BindInterfacesTo<MouseController>().AsSingle();
#else
            Container.BindInterfacesTo<TouchController>().AsSingle();
#endif

    }
}