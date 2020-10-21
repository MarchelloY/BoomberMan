using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BoomberController : MonoBehaviour
{
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private GameObject bombPrefab;
    private bool isInMovement;
    
    void Update()
    {
        if (isInMovement)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayerTo(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayerTo(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayerTo(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayerTo(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
    }

    private void MovePlayerTo(Vector2 dir)
    {
        if (Raycast(dir))
        {
            return;
        }

        isInMovement = true;
        var pos = (Vector2) transform.position + dir;
        transform.DOMove(pos, 0.5f).OnComplete(() =>
        {
            isInMovement = false;
        });
    }
    
    private bool Raycast(Vector2 dir)
    {
        var hit = Physics2D.Raycast(transform.position, dir, 1f, raycastMask);
        return hit.collider != null;
    }
}
