using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "CharacterInstaller", menuName = "SO/Installers/CharacterInstaller")]
public class CharacterInstaller : ScriptableObjectInstaller<CharacterInstaller>
{
    [SerializeField] private CharacterStatDatabaseAsset _characterStatDatabase;

    public override void InstallBindings()
    {
        Container.BindInstance(_characterStatDatabase);

        Container.BindInterfacesTo<Character>().AsSingle();
        Container.BindInterfacesTo<CharacterFactory>().AsSingle();
        Container.BindInterfacesTo<CharacterModel>().AsSingle();
        Container.BindInterfacesTo<CharacterModelFactory>().AsSingle();
        Container.BindInterfacesTo<CharacterStatDataProvider>().AsSingle();
    }
}