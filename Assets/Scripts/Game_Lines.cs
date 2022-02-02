using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Lines : MonoBehaviour
{
    [SerializeField] Game_PlayersController PlayersController;

    [Header("Line Combinations")]
    [SerializeField] GameObject H_T;
    [SerializeField] GameObject H_M;
    [SerializeField] GameObject H_B;
    [SerializeField] GameObject V_L;
    [SerializeField] GameObject V_M;
    [SerializeField] GameObject V_R;
    [SerializeField] GameObject D_LR;
    [SerializeField] GameObject D_RL;

    bool done = false;

    // Update is called once per frame
    void Update()
    {
        if (!done && PlayersController.GameState == "FINISHED")
        {
            string combination = PlayersController.WinningCombination;
            if (combination.Equals("T-L=T-R"))
            {
                H_T.SetActive(true);
            }
            else if (combination.Equals("M-L=M-R"))
            {
                H_M.SetActive(true);
            }
            else if (combination.Equals("B-L=B-R"))
            {
                H_B.SetActive(true);
            }
            else if (combination.Equals("B-L=T-L"))
            {
                V_L.SetActive(true);
            }
            else if (combination.Equals("B-M=T-M"))
            {
                V_M.SetActive(true);
            }
            else if (combination.Equals("B-R=T-R"))
            {
                V_R.SetActive(true);
            }
            else if (combination.Equals("B-L=T-R"))
            {
                D_RL.SetActive(true);
            }
            else if (combination.Equals("B-R=T-L"))
            {
                D_LR.SetActive(true);
            }

            done = true;
        }
    }
}
