using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    
    private PhysicsScene _physicsScene;
    
    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnClick);
    }
    
    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
