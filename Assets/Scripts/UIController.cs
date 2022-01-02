using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject borderPanel;
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private GameObject hostButton;
    [SerializeField] private GameObject alertPanel;
    [SerializeField] private Button borderEnableButton;
    [SerializeField] private string enabledColor = "#266C28";
    [SerializeField] private string disabledColor = "#6C2727";
    [SerializeField] private GameObject mirrorPanel;
    [SerializeField] private Button startMirrorSequenceButton;
    [SerializeField] private Button startBorderSequenceButton;
    [SerializeField] private Button releaseButton;
    [SerializeField] private Button alertButton;

    private PlayerNetworkController playerNetworkController;
    private bool isSet = false;
    private bool bordersEnabled;
    private bool alertEnabled = false;
    private float upperBorder;
    private float lowerBorder;
    private Image alertImage;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool doneFading = false;
    private bool sequence = false;
    private bool releaseControl = false;
    private bool borderExperiment = false;

    void Start() {
        alertImage = alertPanel.GetComponent<Image>();
        PlayerNetworkController.OnBorderCrossed += ShowAlert;
    }

    void Update()
    {
        if (fadeIn && !doneFading)
        {
            StartCoroutine(FadeAlertIn());
            doneFading = true;
        }

        if (fadeOut && !doneFading)
        {
            StartCoroutine(FadeAlertOut());
            doneFading = true;
        }
    }

    public void SetUI()
    {
        SetPlayer();
        if (playerNetworkController.Runner.IsServer && !isSet)
        {
            gamePanel.SetActive(true);
            controlPanel.SetActive(true);
            isSet = true;
        }
    }

    public void SwitchHost()
    {
        if (alertEnabled || bordersEnabled)
        {
            Debug.Log("Please disable: alert: " + alertEnabled + " borders: " + bordersEnabled);
            return;
        }
        SetPlayer();
        playerNetworkController.ChangeHost();
    }

    public void StartMirror()
    {
        SetPlayer();
        gamePanel.SetActive(false);
        hostButton.SetActive(true);
        mirrorPanel.SetActive(true);
    }

    public void StartFindBorders()
    {
        SetPlayer();
        playerNetworkController.BorderExperiment = true;
        borderExperiment = true;
        gamePanel.SetActive(false);
        borderPanel.SetActive(true);
        hostButton.SetActive(true);
    }

    public void SetLowerBorder()
    {
        SetPlayer();
        lowerBorder = playerNetworkController.SetLowerBorder();
    }
    
    public void SetUpperBorder()
    {
        SetPlayer();
        upperBorder = playerNetworkController.SetUpperBorder();
    }

    public void EnableBorders()
    {
        SetPlayer();
        playerNetworkController.SetBorders();
        bordersEnabled = !bordersEnabled;
        if (!bordersEnabled)
        {
            SetButtonColor(borderEnableButton, enabledColor);
            borderEnableButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Enable");
        }
        else
        {
            SetButtonColor(borderEnableButton, disabledColor);
            borderEnableButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Disable");
        }
    }

    private void SetButtonColor(Button btn, string col)
    {
        Color newCol;
        if (ColorUtility.TryParseHtmlString(col, out newCol))
        {
            btn.image.color = newCol;
        }
    }
        
    public void ToggleAlert()
    {
        playerNetworkController.SetAlert();
        alertEnabled = !alertEnabled;

        if (!alertEnabled)
        {
            SetButtonColor(alertButton, enabledColor);
            alertButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Alert Start");
        }
        else
        {
            SetButtonColor(alertButton, disabledColor);
            alertButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Alert Stop");
        }
    }

    public void ShowAlert(float value)
    {
        if (!alertEnabled && !playerNetworkController.AlertEnabled) return;
        lowerBorder = playerNetworkController.LowerBorder;
        upperBorder = playerNetworkController.UpperBorder;
        if ((value < lowerBorder || value > upperBorder) && !fadeIn)
        {
            fadeIn = true;
            fadeOut = false;
            doneFading = false;
        }
        else if (!fadeOut)
        {
            fadeOut = true;
            fadeIn = false;
            doneFading = false;
        }
    }

    public void ActivateBaseline1()
    {
        SetPlayer();
        if (playerNetworkController.HostUnchanged)
        {
            playerNetworkController.MirrorMessage = "log baseline1";
        }
        else
        {
            Debug.Log("Please change host first...");
        }
    }

    public void ActivateMirror()
    {
        SetPlayer();
        if (playerNetworkController.HostUnchanged)
        {
            playerNetworkController.MirrorMessage = "log mirror";
        }
        else
        {
            Debug.Log("Please change host first...");
        }
    }

    public void ActivateRemote()
    {
        SetPlayer();
        if (playerNetworkController.HostUnchanged)
        {
            playerNetworkController.MirrorMessage = "log remote";
        }
        else
        {
            Debug.Log("Please change host first...");
        }
    }

    public void ActivateBaseline2()
    {
        SetPlayer();
        if (playerNetworkController.HostUnchanged)
        {
            playerNetworkController.MirrorMessage = "log baseline2";
        }
        else
        {
            Debug.Log("Please change host first...");
        }
    }

    public void StartSequence()
    {
        SetPlayer();
        sequence = !sequence;
        playerNetworkController.MirrorMessage = "sequence " + sequence;
        Button sequenceButton;
        if (borderExperiment)
        {
            sequenceButton = startBorderSequenceButton;
        }
        else
        {
            sequenceButton = startMirrorSequenceButton;
        }
            
        if (!sequence)
        {
            SetButtonColor(sequenceButton, enabledColor);
            sequenceButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Start Sequence");
        }
        else
        {
            SetButtonColor(sequenceButton, disabledColor);
            sequenceButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Stop Sequence");
        }
    }

    public void ReleaseControl()
    {
        SetPlayer();
        playerNetworkController.SetControl();
        releaseControl = !releaseControl;
        if (!releaseControl)
        {
            SetButtonColor(releaseButton, enabledColor);
            releaseButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Release Control");
        }
        else
        {
            SetButtonColor(releaseButton, disabledColor);
            releaseButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Regain Control");
        }
    }

    IEnumerator FadeAlertIn()
    {
        for (float i = 0; i < 0.5f; i += 0.025f)
        {
            Color color = new Color(alertImage.color.r, alertImage.color.g, alertImage.color.b, i);
            alertImage.color = color;
            yield return null;
        }
    }

    IEnumerator FadeAlertOut()
    {
        for (float i = 0.5f; i >= 0; i -= 0.025f)
        {
            Color color = new Color(alertImage.color.r, alertImage.color.g, alertImage.color.b, i);
            alertImage.color = color;
            yield return null;
        }
    }

    private void SetPlayer()
    {
        if (playerNetworkController == null)
        {
            playerNetworkController = FindObjectOfType<PlayerNetworkController>();
        }
    }
}
