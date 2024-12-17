using UnityEngine;
using UnityEngine.UI;

public class ObjectSelector : MonoBehaviour
{
    private Camera mainCamera;
    public float rayDistance = 10f;

    private Renderer previousRenderer; 
    private Color originalColor;

    public GameObject targetObject;

    private void Awake()
    {
        this.mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Selectable"))
            {
                targetObject = hit.collider.gameObject;

                int num;
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                string mushName = hit.collider.name;

                if (previousRenderer != null && previousRenderer != renderer)
                {
                    previousRenderer.material.color = originalColor;
                    MushroomManager.instance.HideImage();
                    previousRenderer = null;
                }

                if (renderer != null)
                {
                    if (previousRenderer != renderer)
                    {
                        originalColor = renderer.material.color;
                        if(int.TryParse(mushName, out num))
                            MushroomManager.instance.ShowImage(int.Parse(mushName));                       
                        renderer.material.color = Color.red;
                        previousRenderer = renderer;
                    }
                }
            }
            else
            {
                if (previousRenderer != null)
                {
                    previousRenderer.material.color = originalColor;
                    MushroomManager.instance.HideImage();
                    targetObject = null;
                    previousRenderer = null;
                }
            }
        }
        else
        {
            if (previousRenderer != null)
            {
                previousRenderer.material.color = originalColor;
                MushroomManager.instance.HideImage();
                targetObject = null;
            }
        }
    }
}

