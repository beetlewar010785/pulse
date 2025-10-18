using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    public class Heart: MonoBehaviour
    {
        private MapGrid _mapGrid = null!;
        
        public int cellX;
        public int cellY;

        [Inject]
        public void Init(MapGrid mapGrid)
        {
            _mapGrid = mapGrid;
        }

        private void Start()
        {
            _mapGrid.Occupy(new Vector2Int(cellX, cellY));
        }
    }
}