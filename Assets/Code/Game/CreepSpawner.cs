using System.Collections;
using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    public class CreepSpawner : MonoBehaviour
    {
        private Creep.Factory _creepFactory = null!;

        public float speed = 1f;
        public float spawnInterval = 5f;

        [Inject]
        public void Init(Creep.Factory creepFactory)
        {
            _creepFactory = creepFactory;
        }

        private void Start()
        {
            var heart = GameObject.FindGameObjectWithTag(Heart.TagName);
            if (heart == null)
            {
                Debug.LogError("No heart found");
                return;
            } 
            StartCoroutine(SpawnLoop(heart.transform.position));
        }

        private IEnumerator SpawnLoop(Vector2 heartPosition)
        {
            while (true)
            {
                SpawnOnce(heartPosition);
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void SpawnOnce(Vector2 heartPosition)
        {
            var creep = _creepFactory.Create();
            creep.transform.SetParent(transform, worldPositionStays: false);
            creep.Initialize(heartPosition, speed);
        }
    }
}