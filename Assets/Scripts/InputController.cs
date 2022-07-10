using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    private Button _redButton;
    private Button _blueButton;
    private Button _greenButton;
    private Button _pauseButton;

    [SerializeField] private GameObject _player;
    private PlayerController _playerController;
    private void Awake()
    {

        _playerController = _player.GetComponent<PlayerController>();
        var root = GetComponent<UIDocument>().rootVisualElement;
        if(root == null)
            Debug.Log("Qualche cosa non va con la UI");
        _redButton = root.Q<Button>("RedButton");
        _blueButton = root.Q<Button>("BlueButton");
        _greenButton = root.Q<Button>("GreenButton");
        _redButton.clicked += () => ChangeColor(Color.red);
        _blueButton.clicked += () => ChangeColor(Color.blue);
        _greenButton.clicked += () => ChangeColor(Color.green);
        //TODO bind pause button
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeColor(Color color)
    {
        _playerController.SetColor(color);  
    }

    private void EnablePause()
    {
        //TODO pause game
    }
}
