using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    // 0 = Rock, 1 = Paper, 2 = Scissors
    int playerSelection;
    int cpuSelection;

    public TMP_Text resultDisplay;
    public GameObject winningParticles, losingParticles;

    public int RandomizeSelection()
    {
        int selection = Random.Range(0, 3);
        return selection;
    }

    public void PlayerSelect(int index)
    {
        playerSelection = index;
        cpuSelection = RandomizeSelection();
        CalculateResults();
    }

    public void CalculateResults()
    {
        if (playerSelection == 0) 
        { 
            if (cpuSelection == 0) resultDisplay.text = "Player: " + GetName(playerSelection) + "\nCPU: " + GetName(cpuSelection) + "\nIt's a tie.";
            if (cpuSelection == 1) {
                resultDisplay.text = "Player: " + GetName(playerSelection) + "\nCPU: " + GetName(cpuSelection) + "\nYou suck.";
                StartCoroutine(ToggleParticles(1));
            }
            if (cpuSelection == 2) {
                resultDisplay.text = "Player: " + GetName(playerSelection) + "\nCPU: " + GetName(cpuSelection) + "\nYou win.";
                StartCoroutine(ToggleParticles(0));
            }
        }

        else if (playerSelection == 1)
        {
            if (cpuSelection == 0) {
                resultDisplay.text = "Player: " + GetName(playerSelection) + "\nCPU: " + GetName(cpuSelection) + "\nYou win.";
                StartCoroutine(ToggleParticles(0));
            }
            if (cpuSelection == 1) resultDisplay.text = "Player: " + GetName(playerSelection) + "\nCPU: " + GetName(cpuSelection) + "\nIt's a tie.";
            if (cpuSelection == 2) {
                resultDisplay.text = "Player: " + GetName(playerSelection) + "\nCPU: " + GetName(cpuSelection) + "\nYou suck.";
                StartCoroutine(ToggleParticles(1));
            }
        } 

        else if (playerSelection == 2)
        {
            if (cpuSelection == 0) {
                resultDisplay.text = "Player: " + GetName(playerSelection) + "\nCPU: " + GetName(cpuSelection) + "\nYou suck.";
                StartCoroutine(ToggleParticles(1));
            }
            if (cpuSelection == 1) {
                resultDisplay.text = "Player: " + GetName(playerSelection) + "\nCPU: " + GetName(cpuSelection) + "\nYou win.";
                StartCoroutine(ToggleParticles(0));
            }
            if (cpuSelection == 2) resultDisplay.text = "Player: " + GetName(playerSelection) + "\nCPU: " + GetName(cpuSelection) + "\nIt's a tie.";
        }
    }

    public string GetName(int id)
    {
        if (id == 0) return "Rock";
        if (id == 1) return "Paper";
        if (id == 2) return "Scissors";
        return "";
    }

    private IEnumerator ToggleParticles(int index)
    {
        winningParticles.SetActive(false);
        losingParticles.SetActive(false);

        if (index == 0)
        {
            winningParticles.SetActive(true);
        } 

        if (index == 1)
        {
            losingParticles.SetActive(true);
        }

        yield return new WaitForSeconds(2.5f);

        winningParticles.SetActive(false);
        losingParticles.SetActive(false);
    }
}
