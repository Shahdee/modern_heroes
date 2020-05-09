using UnityEngine;
using Zenject;

namespace Game.Player
{
    [CreateAssetMenu(fileName = "PlayerInstaller", menuName = "SO/Installers/PlayerInstaller")]
    public class PlayerInstaller : ScriptableObjectInstaller<PlayerInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}
