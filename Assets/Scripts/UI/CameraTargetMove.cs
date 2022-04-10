using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetMove : MonoBehaviour
{
    public float cameraSpeed;
    void Update()
    {
        Vector3 toMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) ;
        float diagonalSpeedReduction = Mathf.Abs(toMove.x * toMove.z) != 0 ? 0.7f : 1f;
        transform.position += toMove * Time.deltaTime * cameraSpeed * diagonalSpeedReduction;
    }
}
