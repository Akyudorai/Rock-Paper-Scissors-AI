using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    // 0 = Rock, 1 = Paper, 2 = Scissors
    int playerSelection;
    int cpu;

    public TMP_Text resultDisplay;
    public GameObject winningParticles, losingParticles;

    [Header("Components")]
    public TMP_InputField input_TrialCount;
    public TMP_InputField input_Rock, input_Paper, input_Scissors;

    [Header("Results")]
    public int i_Wins;
    public int i_Ties, i_Loss;
    public int i_RockCount, i_PaperCount, i_ScissorCount;


    public void OnBegin()
    {   
        // Reset the results
        i_Wins = i_Ties = i_Loss = i_RockCount = i_PaperCount = i_ScissorCount = 0;
        
        // Loop X number of times dependent on trial count input field
        for (int i = 0; i < int.Parse(input_TrialCount.text); i++) 
        {
            // Randomly select rock, paper, or scissors for player based on probability
            int playerResult = -1;
            float genPlayer = Random.Range(0f, 1f);
            if (genPlayer <= float.Parse(input_Rock.text)) playerResult = 0; // ROCK
            if (genPlayer > float.Parse(input_Rock.text) && genPlayer <= (float.Parse(input_Rock.text) + float.Parse(input_Paper.text))) playerResult = 1; // PAPER
            if (genPlayer > float.Parse(input_Rock.text) + float.Parse(input_Paper.text)) playerResult = 2; // SCISSORS

            // Randomly select rock, paper, or scissors for AI, based on probability
            int cpuResult = RandomizeSelection();

            // Compare the two values   
            CalculateResults(playerResult, cpuResult);       

            // Update Result Display
            resultDisplay.text = "Wins: " + i_Wins + "\tLosses: " + i_Loss + "\tTies: " + i_Ties + 
                "\nRock Selected: " + i_RockCount + " times." + 
                "\nPaper Selected: " + i_PaperCount + " times." + 
                "\nScissor Selected: " + i_ScissorCount + " times.";     
        }
        
    }

    public int RandomizeSelection()
    {
        int selection = Random.Range(0, 3);
        return selection;
    }

    public void UpdateProbabilityChart() 
    {
        if (input_Rock.text == "" || input_Paper.text == "") return;

        //input_Scissors.text = (1 - (float.Parse(input_Rock.text) + float.Parse(input_Scissors.text))); 
    }

    public void CalculateResults(int player, int cpu)
    {
        if (player == 0) 
        {   
            i_RockCount++;
            if (cpu == 0) i_Ties++; //TIE
            if (cpu == 1) i_Loss++; //LOSS
            if (cpu == 2) i_Wins++; //WIN
        }

        else if (player == 1)
        {
            i_PaperCount++;
            if (cpu == 0) i_Wins++; //WIN
            if (cpu == 1) i_Ties++; //TIE
            if (cpu == 2) i_Loss++; //LOSS
        } 

        else if (player == 2)
        {
            i_ScissorCount++;
            if (cpu == 0) i_Loss++; //LOSS
            if (cpu == 1) i_Wins++; //WIN
            if (cpu == 2) i_Ties++; //TIE
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
