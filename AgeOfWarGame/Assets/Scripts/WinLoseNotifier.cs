﻿using UnityEngine;

public class WinLoseNotifier : MonoBehaviour {

    public GameObject canvas;
    public GameObject gameWinObject;
    public GameObject gameLoseObject;


    void Start() {
        GameEvents.current.onGameWin += GameWin;
        GameEvents.current.onGameOver += GameOver;
    }

    private void GameWin() {
        this.canvas.SetActive(true);
        this.gameWinObject.SetActive(true);
        this.gameLoseObject.SetActive(false);
        KillAllSoldiers();
    }
    private void GameOver() {
        this.canvas.SetActive(true);
        this.gameWinObject.SetActive(false);
        this.gameLoseObject.SetActive(true);
        KillAllSoldiers();
    }

    public void HideCanvas() {
        this.canvas.SetActive(false);
        this.gameWinObject.SetActive(false);
        this.gameLoseObject.SetActive(false);
    }

    public void KillAllSoldiers() {

        GameObject allPlayerSoldiers = GameObject.Find("PlayerSoldiers");
        GameObject allEnemySoldiers = GameObject.Find("EnemySoldiers");

        foreach (Transform child in allPlayerSoldiers.transform) {
            child.GetComponent<SoldierBehavior>().Explode();
        }

        foreach (Transform child in allEnemySoldiers.transform) {
            child.GetComponent<SoldierBehavior>().Explode();
        }

    }
}
