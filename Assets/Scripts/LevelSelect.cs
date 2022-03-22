using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public int totalLevel;
    public int unlockedLevel = 1;
    public Text actualPage;
    private LevelButton[] _levelButtons;
    private int _totalPage;
    private int _page;
    private int pageItem = 6;
    public GameObject nextButton;
    public GameObject backButton;
    public GameObject player;

    private void OnEnable()
    {
        _levelButtons = GetComponentsInChildren<LevelButton>();
    }

    public void Start()
    {
        Refresh();
    }

    /// <summary>
    /// Display level scene
    /// </summary>
    /// <param name="level">index of level</param>
    public void StartLevel(int level)
    {
        if (level<=unlockedLevel + 1)
        {
            SceneManager.LoadSceneAsync(level);
        }
    }

    /// <summary>
    /// next page
    /// </summary>
    public void ClickNext()
    {
        _page += 1;
        Refresh();
    }
    
    /// <summary>
    /// Previous page
    /// </summary>
    public void ClickBack()
    {
        _page -= 1;
        Refresh();
    }

    /// <summary>
    /// First page
    /// </summary>
    public void PageOne()
    {
        _page = 0;
        Refresh();
    }
    
    private void CheckButton()
    {
        backButton.SetActive(_page>0);
        nextButton.SetActive(_page<_totalPage);
    }

    /// <summary>
    /// Refresh level menu
    /// </summary>
    public void Refresh()
    {
        unlockedLevel = player.GetComponent<Player>().level;
        _totalPage = (totalLevel - 1) / pageItem;
        var index = _page * pageItem;

        for (var i = 0; i < _levelButtons.Length; i++)
        {
            var level = index + i + 1;
            if (level <= totalLevel)
            {
                _levelButtons[i].gameObject.SetActive(true);
                _levelButtons[i].Setup(level, level <= unlockedLevel);
            }
            else
            {
                _levelButtons[i].gameObject.SetActive(false);
            }
        }
        CheckButton();
        actualPage.text = (_page + 1) + "/" + (_totalPage + 1);
    }
}
