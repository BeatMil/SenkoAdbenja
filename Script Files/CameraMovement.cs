using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{

    //config param
    [SerializeField] Vector3 offset;
    [SerializeField] float cameraSpeedVertically;
    [SerializeField] int zoomIn;
    [SerializeField] int zoomOut;

    //cache
    [SerializeField] Transform target;
    Vector3 targetPos;

    private void OnLevelWasLoaded(int level)
    {
        
    }

    private void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Stage05")
        {
            targetPos = target.position;
            transform.position = Vector3.Lerp(transform.position, targetPos, cameraSpeedVertically * Time.deltaTime);
        }
        else
        {
            CameraFollowSenko();
        }
    }

    private void CameraFollowSenko()
    {
        if (target.position.y >= 24)
        {
            targetPos = target.position + new Vector3(offset.x, -offset.y, offset.z);
            Debug.Log("Senko is higher than 1");
        }
        else
        {
            targetPos = target.position + new Vector3(offset.x, offset.y - target.position.y, offset.z);
        }
        transform.position = Vector3.Lerp(transform.position, targetPos, cameraSpeedVertically * Time.deltaTime);
    }

    public void ZoomOut()
    {
        GetComponent<Camera>().orthographicSize = zoomOut;
    }

    public void ZoomIn()
    {
        GetComponent<Camera>().orthographicSize = zoomIn;
    }

 
 
}
