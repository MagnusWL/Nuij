using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        var newPos = player.transform.position + new Vector3(0f, 0f, -5f);
        //newPos.y = -0.95f;
        transform.position = newPos;
    }
}