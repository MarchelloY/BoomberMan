using UnityEngine;

public class CubeKiller : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            return;
        }

        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit))
        {
            return;
        }

        var rig = hit.collider.attachedRigidbody;
        if (rig != null)
        {
            var dir = (hit.point - transform.position).normalized * 10f;
            rig.AddForceAtPosition(dir,hit.point,ForceMode.Impulse);
            var tnt = rig.gameObject.GetComponent<TNT>();
            if (tnt != null)
            {
                tnt.Badabum();
            }
        }
    }
}
