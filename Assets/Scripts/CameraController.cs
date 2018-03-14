using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float offset = 5.0f;
    public Transform player;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(player.position.x > this.transform.position.x + offset)
        {
            this.transform.position = new Vector3(player.position.x - offset, this.transform.position.y, this.transform.position.z);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, new Vector2((this.transform.position.x + offset), this.transform.position.y));
        Gizmos.DrawLine(this.transform.position, new Vector2((this.transform.position.x - offset), this.transform.position.y));
    }
}
