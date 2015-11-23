﻿using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine.UI;

public class UIConfigManager : MonoBehaviour {
    public ConfigCreator creator;
    public Toggle ShowStartPointToggle;
    public InputField ConfigNameInputField;
    public Dropdown DrawTimeoutDropdown;
    public Text LevelsLabel;
	public GameObject CannotSavePanel;
	private GameObject BlackImage;

    Config config;

    public void SaveConfig()
    {
		if(!DoesConfigNameExist(config.Name)){
			CannotSavePanel.SetActive(true);
			SetInteractableOfAllSceneObjects(false);
			BlackImage.SetActive(true);
		}
		else{
        	creator.SendMessage("SaveConfig");
		}
    }

    public void SaveAsNewConfig()
    {
		if(!DoesConfigNameExist(config.Name)){
			CannotSavePanel.SetActive(true);
			SetInteractableOfAllSceneObjects(false);
			BlackImage.SetActive(true);
		}
		else{
			creator.SendMessage("SaveAsNewConfig");
		}
    }

	private void SetInteractableOfAllSceneObjects(bool b)
	{
		GameObject canvas = GameObject.Find ("Canvas");
		foreach(var button in canvas.GetComponentsInChildren<Button>()){
			button.interactable = b;
		}
		foreach(var input in canvas.GetComponentsInChildren<InputField>()){
			input.interactable = b;
		}
		foreach(var toggle in canvas.GetComponentsInChildren<Toggle>()){
			toggle.interactable = b;
		}
		foreach(var dropdown in canvas.GetComponentsInChildren<Dropdown>()){
			dropdown.interactable = b;
		}
		foreach(var slider in canvas.GetComponentsInChildren<Slider>()){
			slider.interactable = b;
		}
	}

    public void Cancel()
    {
        creator.SendMessage("Cancel");
    }

    public void Init(Config config)
    {
        ConfigNameInputField.text = config.Name;
        ShowStartPointToggle.isOn = config.DrawStartPoint;

        DrawTimeoutDropdown.onValueChanged.AddListener(i => UpdateDrawTimeout(i));
        ConfigNameInputField.onValueChange.AddListener(s => UpdateName(s));
        ShowStartPointToggle.onValueChanged.AddListener(b => UpdateShowStartPoint(b));

        LevelsLabel.text = config.Levels.Count.ToString();

        creator.LevelAdded += new ConfigCreator.LevelAddHandler(OnAddLevel);
        creator.LevelDeleted += new ConfigCreator.LevelDeleteHandler(OnRemoveLevel);

		CannotSavePanel = GameObject.Find ("CannotSavePanel");
		CannotSavePanel.SetActive(false);

		BlackImage = GameObject.Find ("BlackImage");
		BlackImage.SetActive(false);

        this.config = config;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckInput();
	}

	private void CheckInput()
	{
#if UNITY_ANDROID
		if(Input.touchCount > 0)
		{
			if(CannotSavePanel.activeSelf)
			{
				Touch touch = Input.GetTouch(0);
				if(touch.phase == TouchPhase.Ended){
					CannotSavePanel.SetActive(false);
					SetInteractableOfAllSceneObjects(true);
					BlackImage.SetActive(false);
				}
			}
		}
#endif 
#if UNITY_EDITOR || UNITY_STANDALONE
		if(Input.GetMouseButtonUp(0))
		{
			if(CannotSavePanel.activeSelf)
			{
				CannotSavePanel.SetActive(false);
				SetInteractableOfAllSceneObjects(true);
				BlackImage.SetActive(false);
			}
		}
	}
#endif

	private bool DoesConfigNameExist(string name)
	{
		List<string> configNames = new List<string>();
		string[] configFiles = Directory.GetFiles(Application.persistentDataPath + "/configs/");
		foreach(var file in configFiles)
		{
			XmlTextReader reader = new XmlTextReader(file);
			while(reader.Read ())
			{
				reader.MoveToContent();
				if(reader.NodeType == XmlNodeType.Element && reader.Name == "Name")
				{
					reader.Read();
					configNames.Add(reader.Value);
					break;
				}
			}
			reader.Close();
		}
		
		if(configNames.Find(x => x == name) != null){
			return false;
		}
		return true;
	}

    void UpdateDrawTimeout(int index)
    {
        
        string value = DrawTimeoutDropdown.options[index].text;
        float timeout = float.Parse(value.Split('s')[0]);

        Debug.Log("Draw timeout change " + timeout);
    }

    void UpdateName(string s)
    {
        config.Name = s;
    }

    void UpdateShowStartPoint(bool value)
    {
        config.DrawStartPoint = value;
    }

    void OnAddLevel(int pos)
    {
        LevelsLabel.text = config.Levels.Count.ToString();
    }

    void OnRemoveLevel(int pos)
    {
        LevelsLabel.text = config.Levels.Count.ToString();
    }
}