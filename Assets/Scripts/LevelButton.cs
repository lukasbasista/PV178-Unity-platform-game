using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class LevelButton : MonoBehaviour
{
    public LevelSelect menu;
    public Sprite lockSprite;
    public Sprite soomSprite;
    public Text levelText;
    private int _level;
    private Button _button;
    private Image _image;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    /// <summary>
    /// Display content depends on actual level status;
    /// </summary>
    /// <param name="level">number of level</param>
    /// <param name="isUnlock">true if level is unlocked</param>
    public void Setup(int level, bool isUnlock)
    {
        this._level = level;
        levelText.text = level.ToString();

        if (isUnlock)
        {
            _image.sprite = null;
            _button.enabled = true;
            levelText.gameObject.SetActive(true);
        }
        else
        {
            
            _image.sprite = SceneManager.sceneCountInBuildSettings - 2 >= level ? lockSprite : soomSprite;
            _button.enabled = false;
            levelText.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        menu.StartLevel(_level + 1);
    }
}
