using UnityEngine;

public class TNT : MonoBehaviour
{
    [SerializeField] private float radius = 5f;

    public void Badabum()
    {
        Destroy(this);
        var colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var collider in colliders)
        {
            if (collider.attachedRigidbody == null)
            {
                continue;
            }

            var dir = collider.transform.position - transform.position;
            var dist = dir.magnitude;
            var k = dist / radius;
            collider.attachedRigidbody.AddForce(k * 40f * dir.normalized, ForceMode.Impulse);
        }
    }
}
