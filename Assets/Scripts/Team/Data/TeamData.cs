using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TeamData 
{
    [Serializable]
    public class CharacterOnSceneData
    {
        public ECharacterType CharacterType;
        public GameObject CharacterView;
    }

    public EPlayerType PlayerType;
    public List<CharacterOnSceneData> Characters;
}
