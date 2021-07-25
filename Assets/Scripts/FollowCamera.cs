using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    // Update is called once per frame
    private void Update()
    {
        transform.position = target.position;
    }
}