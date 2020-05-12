using UnityEngine;
using System.Collections.Generic;


    [CreateAssetMenu(menuName = "SO/Database/CharacterDatabase", fileName = "CharacterDatabase")]
    public class CharacterDatabaseAsset : ScriptableObject
    {
        [SerializeField] private List<CharacterData> _characterData;
        public IReadOnlyList<CharacterData> Characters => _characterData;
    }
