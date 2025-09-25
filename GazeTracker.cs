using UnityEngine;

public class GazeTracker : MonoBehaviour
{
    public float gazeThreshold = 2f;
    private float gazeTimer = 0f;
    private GameObject currentGazedObject = null;

    public GazeLogger gazeLogger;
    public PopupManager popupManager;

    private bool popupActive = false;

    void Update()
    {
        if (popupActive) return;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject != currentGazedObject)
            {
                currentGazedObject = hit.collider.gameObject;
                gazeTimer = 0f;
            }
            else
            {
                gazeTimer += Time.deltaTime;

                if (gazeTimer >= gazeThreshold)
                {
                    popupManager.ShowPopup(currentGazedObject.name);
                    popupActive = true;
                    gazeTimer = 0f;
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    gazeLogger.LogManualSelection(currentGazedObject.name);
                    gazeTimer = 0f;
                }
            }
        }
        else
        {
            currentGazedObject = null;
            gazeTimer = 0f;
        }
    }

    public void ResetPopupState()
    {
        popupActive = false;
    }
}
