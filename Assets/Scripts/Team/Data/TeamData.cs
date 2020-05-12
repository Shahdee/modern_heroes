using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

[Serializable]
public class TeamData 
{
    public EPlayerType PlayerType;
    public List<ECharacterType> Characters;
    public TileBase SpawnTile;
}
