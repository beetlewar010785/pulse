using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    [RequireComponent(typeof(PathFollowerComponent))]
    public class Creep : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Creep>
        {
        }


        public void Initialize(Vector2 end, float speed)
        {
            var pf = GetComponent<PathFollowerComponent>();
            if (pf == null)
            {
                Debug.LogError("Creep: PathFollowerComponent missing on prefab.");
                return;
            }

            pf.end = end;
            pf.speed = speed;
        }
    }
}