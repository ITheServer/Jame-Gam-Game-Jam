using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointAtMouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gunRotation = mousePos - transform.position;
        gunRotation.z = 0;
        gunRotation = gunRotation.normalized;
        float rot = Mathf.Atan2(gunRotation.y, gunRotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }
}
