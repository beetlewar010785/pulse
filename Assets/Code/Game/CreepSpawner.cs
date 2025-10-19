using System.Collections;
using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    public class CreepSpawner : MonoBehaviour
    {
        private Creep.Factory _creepFactory = null!;

        public Vector2 end;
        public float speed = 1f;
        public float spawnInterval = 5f;

        [Inject]
        public void Init(Creep.Factory creepFactory)
        {
            _creepFactory = creepFactory;
        }

        private void Start()
        {
            StartCoroutine(SpawnLoop());
        }

        private IEnumerator SpawnLoop()
        {
            while (true)
            {
                SpawnOnce();
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void SpawnOnce()
        {
            var creep = _creepFactory.Create();
            creep.transform.SetParent(transform, worldPositionStays: false);
            creep.Initialize(end, speed);
        }
    }
}