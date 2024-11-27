using UnityEngine;

public class LandDetector : MonoBehaviour
{
    public float rayLength = 0.1f; 
    public LayerMask groundLayer;

    public bool CheckGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayer))
            return true;
        else
            return false;
    }
}
