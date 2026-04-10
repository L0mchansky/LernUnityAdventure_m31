using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] Character _character;

    private PlayerCharacterController _playerCharacterController;


    void Awake()
    {
        _character.Initialize(new CharacterControllerDirectionalMover(_character.GetComponent<CharacterController>(), 10), new DirectionalRotator(_character.transform, 500));

        _playerCharacterController = new PlayerCharacterController(_character);
        _playerCharacterController.Enable();
    }


    void Update()
    {
        _playerCharacterController.Update(Time.deltaTime);
    }
}
