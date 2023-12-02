using UnityEngine;

public class CamerasGroup : MonoBehaviour
{
    public GameObject[] cameras;
    private int camerasIndex;
    
    public void NextCamera()
    {
        camerasIndex++;

        if (camerasIndex >= 0 && camerasIndex < cameras.Length)
        {
            ActiveCameraIndex();
        }
        else
        {
            camerasIndex = 0;
            ActiveCameraIndex();
        }
    }

    private void ActiveCameraIndex()
    {
        if (cameras is not null)
        {
            foreach(var i in cameras)
            {
                if(i.activeSelf)
                {
                    i.SetActive(false);
                }
            }

            cameras[camerasIndex].SetActive(true);
        }
    }
}
