using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TeamInstaller", menuName = "SO/Installers/TeamInstaller")]
public class TeamInstaller : ScriptableObjectInstaller<TeamInstaller>
{
    [SerializeField] private TeamDatabaseAsset _teamDatabase;

    public override void InstallBindings()
    {
        Container.BindInstance(_teamDatabase);

        Container.BindInterfacesTo<TeamController>().AsSingle();
        Container.BindInterfacesTo<TeamStorage>().AsSingle();
        Container.BindInterfacesTo<TeamFactory>().AsSingle();
    }
}