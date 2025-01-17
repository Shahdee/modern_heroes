﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapView : MonoBehaviour
{
    public Tilemap TileMap => _tileMap;
    public Grid Grid => _grid;

    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private Grid _grid;
    [SerializeField] private TilemapRenderer _renderer;
    [SerializeField] private BoxCollider _collider;


    public void CompressMap()
    {
        _tileMap.CompressBounds();
    }
}
