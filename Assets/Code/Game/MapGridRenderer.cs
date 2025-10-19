using PulseTD.Core.Map;
using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    public class MapGridRenderer : MonoBehaviour
    {
        private MapGrid _mapGrid = null!;
        private bool _initialized;

        [Inject]
        public void Init(MapGrid mapGrid)
        {
            _mapGrid = mapGrid;
        }

        private void Update()
        {
            if (_initialized) return;

            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            InitMap();
            _initialized = true;
        }

        private void InitMap()
        {
            var width = _mapGrid.Width;
            var height = _mapGrid.Height;
            var cellSize = _mapGrid.CellSize;
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var color = IsCellEmpty(x, y) ? Color.green : Color.red;
                    // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                    CreateCellVisual(x, y, color, cellSize);
                }
            }
        }

        private bool IsCellEmpty(int x, int y)
        {
            return !_mapGrid.Occupied(new Vector2Int(x, y));
        }

        private void CreateCellVisual(int x, int y, Color color, float size)
        {
            var cellObj = GameObject.CreatePrimitive(PrimitiveType.Quad);
            cellObj.transform.parent = transform;
            cellObj.transform.position = new Vector3(x + size / 2f, y + size / 2f, 0);
            cellObj.transform.localScale = new Vector3(size, size, 1);
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            var r = cellObj.GetComponent<Renderer>();
            r.material = new Material(Shader.Find("Unlit/Color"))
            {
                color = color
            };
        }
    }
}