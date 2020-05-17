using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrans : MonoBehaviour
{
    public Transform target;
  
    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(1.15f, target.position.y + 1f, transform.position.z);

        transform.position = Vector3.Lerp(new Vector3(0, target.position.y + 1f, transform.position.z), targetPos, 0.2f);
    }

}
