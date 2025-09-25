using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel;
    public Text popupText;
    private string currentObjectName;
    public GazeLogger gazeLogger;

    void Start()
    {
        popupPanel.SetActive(false);
    }

    public void ShowPopup(string objectName)
    {
        currentObjectName = objectName;
        popupText.text = $"{objectName}에 관심 있으신가요?";
        popupPanel.SetActive(true);
    }

    public void OnYesClicked()
    {
        gazeLogger.LogPopupResponse(currentObjectName, "Y");
        popupPanel.SetActive(false);
    }

    public void OnNoClicked()
    {
        gazeLogger.LogPopupResponse(currentObjectName, "N");
        popupPanel.SetActive(false);
    }
}
