using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    public class Unit : MonoBehaviour
    {
        private Follower _follower = null!;
        private bool _pathCalculated;

        public Vector2Int start;
        public Vector2Int end;
        public float speed;

        [Inject]
        public void Init(Follower follower)
        {
            _follower = follower;
        }

        private void Update()
        {
            if (!_pathCalculated)
            {
                _follower.CalculatePath(start, end);
                _pathCalculated = true;
            }
            
            _follower.UpdatePosition(Time.deltaTime, speed);
            if (_follower.IsEndReached)
            {
                _follower.ResetPosition();
            }

            transform.position = new Vector3(_follower.Position.x, _follower.Position.y, -1f);
        }
    }
}