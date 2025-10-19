using System;
using PulseTD.Core.Map;
using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    public class Heart: MonoBehaviour
    {
        public const string TagName = "Heart";
        
        private MapGrid _mapGrid = null!;

        public int initalHP;
        public int currentHP;

        [Inject]
        public void Init(MapGrid mapGrid)
        {
            _mapGrid = mapGrid;
        }

        // private void Start()
        // {
        //     _mapGrid.Occupy(new Vector2Int(cellX, cellY));
        // }
    }
}