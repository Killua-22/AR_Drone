using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{

    public DroneController _droneController;
    
    public Button _takeoffbutton;
    public Image _movejoystick;
    private PlayerInput _playerInput;
    public Image _heightjoystick;
    public Button start_button;
    public Canvas start_screen;
    public Button exit_game;

    // Start is called before the first frame update
    void Start()
    {
        start_button.onClick.AddListener(onClickStartButton);
        _takeoffbutton.onClick.AddListener(OnclickTakeoffButton);
        exit_game.onClick.AddListener(OnClickExitButton);
        _playerInput = _droneController.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();

        float speedX = input.x;
        float speedZ = input.y;

        Vector2 height = _playerInput.actions["ascend"].ReadValue<Vector2>();

        float speedY = height.y;
        float rotateY = height.x;

        _droneController.Move(speedX, speedY, speedZ, rotateY);

        
    }

    void onClickStartButton()
    {
        start_screen.gameObject.SetActive(false);

        _takeoffbutton.gameObject.SetActive(true); 

    }

    void OnclickTakeoffButton()
    {
        if(_droneController.isIdle())
        {
            _droneController.TakeOff();
            _takeoffbutton.gameObject.SetActive(false);
            _movejoystick.gameObject.SetActive(true);
            _heightjoystick.gameObject.SetActive(true);
            exit_game.gameObject.SetActive(true);

        }
    }

    void OnClickExitButton()
    {
        _movejoystick.gameObject.SetActive(false);
        _heightjoystick.gameObject.SetActive(false);
        exit_game.gameObject.SetActive(false);
        start_screen.gameObject.SetActive(true);
        _droneController.gameObject.SetActive(false);
    }

   
}
