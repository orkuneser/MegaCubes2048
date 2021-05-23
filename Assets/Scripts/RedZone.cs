using UnityEngine;

public class RedZone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();
        if (cube!=null)
        {
            if (!cube.isMainCube && cube.cubeRigidbody.velocity.magnitude<0.1f)
            {
                GameManager.Instance.GameOver();
            }

        }
    }
}
