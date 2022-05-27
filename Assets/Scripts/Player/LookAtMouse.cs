using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] float _smoothDamp;
    private Vector3 _velocity;
    

    void Start()
    {
            
    }

    void Update()
    {
        var direction = Camera.main.ScreenToWorldPoint(InputGetter.MousePotition) - transform.position;
        direction.z = 0;
        direction.Normalize();
        var vecDir = Vector3.SmoothDamp(transform.up, direction, ref _velocity, _smoothDamp);
        var diserdDir = new Vector3(0, 0, Mathf.Atan2(vecDir.y, vecDir.x) * Mathf.Rad2Deg - 90f);
        transform.rotation = Quaternion.Euler(diserdDir);
    }
}
