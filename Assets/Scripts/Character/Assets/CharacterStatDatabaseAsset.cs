using UnityEngine;
using System.Collections.Generic;

// namespace Game.Character
// {
    [CreateAssetMenu(menuName = "SO/Database/CharacterStatDatabase", fileName = "CharacterStatDatabase")]
    public class CharacterStatDatabaseAsset : ScriptableObject
    {
        [SerializeField] private List<CharacterStatData> _characterStatData;
        public IReadOnlyList<CharacterStatData> CharacterStatData => _characterStatData;
    }
// }