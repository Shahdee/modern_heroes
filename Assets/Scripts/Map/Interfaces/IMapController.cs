using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface IMapController 
{
    List<Vector3> GetTeamTiles(TileBase teamTile);
}
