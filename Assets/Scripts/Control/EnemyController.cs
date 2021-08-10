using UnityEngine;

namespace Control
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 5f;
        private GameObject _player;

        // Start is called before the first frame update
        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        private void Update()
        {
            EngagePlayer();
        }

        private void EngagePlayer()
        {
            if (Vector3.Distance(_player.transform.position, gameObject.transform.position) <= chaseDistance)
                print(gameObject.name + " should chase " + _player.name);
        }
    }
}