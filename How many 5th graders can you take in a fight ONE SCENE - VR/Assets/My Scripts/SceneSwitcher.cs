using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneSwitcher : MonoBehaviour
{
    // [SerializeField] int nextSceneIndex;
    [SerializeField] Transform teleportPos;
    [SerializeField] bool sceneChange = false;
    [SerializeField] InputActionReference enterKey;
    [SerializeField] GameObject firstFloorLights;
    GameObject player;
    int currentSceneIndex;
    Scene scene;
    [SerializeField] Canvas buttonPromptCanvas;
    Player playerscript;
    Vector3 verticalPos;

    private void Start()
    {
        verticalPos = new Vector3(0f, 0.9f, 0f);
        sceneChange = false;
        buttonPromptCanvas.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerscript = FindObjectOfType<Player>();
        scene = SceneManager.GetActiveScene();
        currentSceneIndex = scene.buildIndex;
        enterKey.action.performed += Teleport;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sceneChange = true;
            buttonPromptCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        sceneChange = false;
        buttonPromptCanvas.enabled = false;
    }

    public void Teleport(InputAction.CallbackContext context)
    {
        if (sceneChange && buttonPromptCanvas == true)
        {
            firstFloorLights.SetActive(false);
            player.transform.position = teleportPos.position + verticalPos;
        }
    }

    // private void Update()
    // {
    //     if (sceneChange == true)
    //     {
    //         if (Input.GetKeyDown(KeyCode.E))
    //         {
    //             Debug.Log("Next room");
    //             Teleport();
    //             // sceneChange = false;
    //         }
    //         // SceneManager.LoadScene(nextSceneIndex);
    //         // Debug.Log(nextSceneIndex + " scene");
    //         // playerscript.DeleteDuplicates();
    //         // StartCoroutine(ChangeScene());
    //     }
    // }


    // IEnumerator ChangeScene()
    // {
    //     SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);
    //     Scene nextScene = SceneManager.GetSceneAt(nextSceneIndex);
    //     SceneManager.MoveGameObjectToScene(player, nextScene);
    //     yield return null;
    //     SceneManager.UnloadSceneAsync(currentSceneIndex);
    // }
}