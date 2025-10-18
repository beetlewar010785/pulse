using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    public class Unit : MonoBehaviour
    {
        private PathFollower _pathFollower = null!;
        private bool _pathCalculated;

        public Vector2Int start;
        public Vector2Int end;
        public float speed;

        [Inject]
        public void Init(PathFollower pathFollower)
        {
            _pathFollower = pathFollower;
        }

        private void Update()
        {
            if (!_pathCalculated)
            {
                _pathFollower.CalculatePath(start, end);
                _pathCalculated = true;
            }
            
            _pathFollower.UpdatePosition(Time.deltaTime, speed);
            if (_pathFollower.IsEndReached)
            {
                _pathFollower.ResetPosition();
            }

            transform.position = new Vector3(_pathFollower.Position.x, _pathFollower.Position.y, -1f);
        }
    }
}