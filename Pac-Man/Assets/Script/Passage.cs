using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform connection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 possition = other.transform.position;
        possition.x = this.connection.position.x;
        possition.y = this.connection.position.y;
        other.transform.position = possition;
    }
}
