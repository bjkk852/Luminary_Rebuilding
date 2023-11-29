using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause_Exit : Choice
{
    [SerializeField]
    public PauseMenu pauseMenu;
    public override void Work()
    {
        GameManager.Instance.pauseGame();
        GameManager.Instance.uiManager.endMenu();
        GameManager.Instance.GameReset();
    }
    public override void OnPointerHandler(PointerEventData eventData)
    {
        pauseMenu.DeSelectHandler(pauseMenu.currentMenu);
        pauseMenu.currentMenu = index;
        pauseMenu.SelectHandler(pauseMenu.currentMenu);
    }
}
