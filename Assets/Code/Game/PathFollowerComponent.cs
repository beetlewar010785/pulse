using PulseTD.Core.Path;
using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    public class PathFollowerComponent : MonoBehaviour
    {
        private PathFollower _pathFollower = null!;
        private bool _pathCalculated;

        public Vector2 end;
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
                _pathFollower.CalculatePath(transform.position, end);
                _pathCalculated = true;
            }

            _pathFollower.UpdatePosition(Time.deltaTime, speed);

            transform.position = new Vector3(_pathFollower.Position.x, _pathFollower.Position.y, -1f);

            if (!_pathFollower.IsEndReached) return;

            Destroy(gameObject);
        }
    }
}