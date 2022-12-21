using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform AimTransform;
    public Camera PlayerCamera;

    void LateUpdate()
    {
        //Debug.Log(Input.mousePosition);

        Ray rayToAim = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(rayToAim.origin, rayToAim.direction * 50, Color.yellow);

        Plane _aimPlane = new Plane(-Vector3.forward, Vector3.zero);

        float distanse;
        _aimPlane.Raycast(rayToAim, out distanse);
        Vector3 _intersectionPointWithAimPlane = rayToAim.GetPoint(distanse);
        AimTransform.position = _intersectionPointWithAimPlane;

        Vector3 ToAim = AimTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(ToAim);
    }
}
 