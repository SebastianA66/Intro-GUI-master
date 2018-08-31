using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Interacting with scene changes
using UnityEngine.UI; // Interacting with GUI elements
using UnityEngine.EventSystems; //event controlling

public class MenuHandler : MonoBehaviour
{
    //Save data options menu HW 
    #region Variables
    [Header("Options")]
    public bool showOptions;
    public Vector2[] res = new Vector2[8];
    public int resIndex;
    public bool isFullscreen;
    [Header("Keys")]
    public KeyCode holdingKey;
    public KeyCode forward, backward, left, right, jump, crouch, sprint, interact;
    [Header("References")]
    public AudioSource mainAudio;
    public Light dirLight;    
    public Dropdown resDropDown;
    public GameObject mainMenu, optionsMenu;
    public Slider volSlider, brightSlider, ambientSlider;
    
    [Header("KeyBind References")]
    public Text forwardText; // use array to shorten
    public Text backwardText, leftText, rightText, jumpText, crouchText, sprintText, interactText;
    #endregion

    void Start()
    {
        
        mainAudio = GameObject.Find("MainMusic").GetComponent<AudioSource>();
        dirLight = GameObject.Find("DirectionalLight").GetComponent<Light>();
        //ambientSlider.value = RenderSettings.ambientIntensity;

        #region Set Up Keys
        //set out keys to the preset keys we may have saved, else set the keys to default
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
        crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "LeftControl"));
        sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E"));
        #endregion
    }

    public void Ambient()
    {
        RenderSettings.ambientIntensity = ambientSlider.value;  
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ToggleOptions()
    {
        OptionToggle();
    }

    bool OptionToggle()
    {
        if (showOptions)//showOptions == true or showOptions is true
        {
            showOptions = false;
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            return true;
        }
        else
        {
            showOptions = true;
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            volSlider = GameObject.Find("AudioSlider").GetComponent<Slider>();
            volSlider.value = mainAudio.volume;
            brightSlider = GameObject.Find("BrightnessSlider").GetComponent<Slider>();
            brightSlider.value = dirLight.intensity;
            resDropDown = GameObject.Find("Resolution").GetComponent<Dropdown>();
            return false;
        }
    }

    public void Volume()
    {
        mainAudio.volume = volSlider.value;
    }

    public void Brightness()
    {
        dirLight.intensity = brightSlider.value;
    }

    //public void Resolution()
    //{
    //    Resolution[] resolution = Screen.resolutions;
    //    foreach (Resolution res in resolution)
    //    {
    //        print(message: res.width = "x" + res.height);
    //    }
    //
    //    Screen.SetResolution(resolution[0].width, resolution[0].height, true);
    //    //resIndex = resDropDown.value;
    //    //Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullscreen);
    //}
    
    public void Save()
    {
        PlayerPrefs.SetString("Forward", forward.ToString());
        PlayerPrefs.SetString("Backward", backward.ToString());
        PlayerPrefs.SetString("Left", left.ToString());
        PlayerPrefs.SetString("Right", right.ToString());
        PlayerPrefs.SetString("Jump", jump.ToString());
        PlayerPrefs.SetString("Crouch", crouch.ToString());
        PlayerPrefs.SetString("Sprint", sprint.ToString());
        PlayerPrefs.SetString("Interact", interact.ToString());

    }

    public void OnGUI()
    {
        Event e = Event.current;
        if (forward == KeyCode.None)
        {
            Debug.Log("KeyCode: " + e.keyCode);
            if(!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
            {
                forward = e.keyCode;
                holdingKey = KeyCode.None;
                forwardText.text = forward.ToString();
            }
        }
            
    }
    public void Forward()
    {
        if(!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None ))
        {
            holdingKey = forward;
            forward = KeyCode.None;
            forwardText.text = forward.ToString();
        }
    }
}
