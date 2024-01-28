using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evenement : MonoBehaviour
{
    public float moveSpeed = 1000f;
    public Vector2 targetPosition = new Vector2(0f, 1f);
    public float teleportDelay = 50f;

    void Start()
    {
        StartCoroutine(TeleportAfterDelay());
    }

    IEnumerator TeleportAfterDelay()
    {
        yield return new WaitForSeconds(teleportDelay);
        StartCoroutine(MoveToPosition(targetPosition));
    }

    IEnumerator MoveToPosition(Vector2 targetPos)
    {
        while (Vector2.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void Bonus(GameObject go)
    {
        Debug.Log("Collision");
        Destroy(go);
    }
}
