using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Bomb : MonoBehaviour
{
    [SerializeField] private LayerMask explosiveMask;
    [SerializeField] private GameObject firePrefab;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("boom");
        FireSpawn(Vector3.down);
        FireSpawn(Vector3.left);
        FireSpawn(Vector3.up);
        FireSpawn(Vector3.right);
        var colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f, explosiveMask);
        yield return new WaitForSeconds(0.5f);
        DestroyAllFire();
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player")) SceneManager.LoadScene(sceneBuildIndex: 0);
            Destroy(collider.gameObject);
        }
        Destroy(gameObject);
    }

    private void FireSpawn(Vector3 pos)
    {
        Instantiate(firePrefab, gameObject.transform.position + pos, Quaternion.identity);
    }

    private void DestroyAllFire()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("fire");
        foreach (var gameObject in gameObjects)
        {
            Destroy(gameObject);
        }
    }
}
