using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerInstaller", menuName = "Installers/PlayerInstaller")]
public class PlayerInstaller : ScriptableObjectInstaller<PlayerInstaller>
{
    public override void InstallBindings()
    {
    }
}