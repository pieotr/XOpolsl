using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TicTacToeCode : MonoBehaviour
{
    bool checker;
    int plusone;
    int minusone;

    public Text btn1 = null;
    public Text btn2 = null;
    public Text btn3 = null;
    public Text btn4 = null;
    public Text btn5 = null;
    public Text btn6 = null;
    public Text btn7 = null;
    public Text btn8 = null;
    public Text btn9 = null;

    public Text reset = null;
    public Text newgame = null;
    public Text msgFeedback = null;

    public Text playerxin;
    public Text playeryin;

    public void score()
    {
        //=============================player X =========================================
        if (btn1.text == "X" && btn2.text == "X" && btn3.text == "X")
        {
            btn1.color = Color.red;
            btn2.color = Color.red;
            btn3.color = Color.red;
            msgFeedback.text = "The Winner is Player X";
            plusone = int.Parse(playerxin.text);
            playerxin.text = Convert.ToString(plusone + 1);

        }

        if (btn1.text == "X" && btn4.text == "X" && btn7.text == "X")
        {
            btn1.color = Color.blue;
            btn4.color = Color.blue;
            btn7.color = Color.blue;
            msgFeedback.text = "The Winner is Player X";
            plusone = int.Parse(playerxin.text);
            playerxin.text = Convert.ToString(plusone + 1);

        }

        if (btn1.text == "X" && btn5.text == "X" && btn9.text == "X")
        {
            btn1.color = Color.gray;
            btn5.color = Color.gray;
            btn9.color = Color.gray;
            msgFeedback.text = "The Winner is Player X";
            plusone = int.Parse(playerxin.text);
            playerxin.text = Convert.ToString(plusone + 1);

        }

        if (btn3.text == "X" && btn5.text == "X" && btn7.text == "X")
        {
            btn3.color = Color.green;
            btn5.color = Color.green;
            btn7.color = Color.green;
            msgFeedback.text = "The Winner is Player X";
            plusone = int.Parse(playerxin.text);
            playerxin.text = Convert.ToString(plusone + 1);

        }

        if (btn2.text == "X" && btn5.text == "X" && btn8.text == "X")
        {
            btn2.color = Color.yellow;
            btn5.color = Color.yellow;
            btn8.color = Color.yellow;
            msgFeedback.text = "The Winner is Player X";
            plusone = int.Parse(playerxin.text);
            playerxin.text = Convert.ToString(plusone + 1);

        }

        if (btn3.text == "X" && btn6.text == "X" && btn9.text == "X")
        {
            btn3.color = Color.cyan;
            btn6.color = Color.cyan;
            btn9.color = Color.cyan;
            msgFeedback.text = "The Winner is Player X";
            plusone = int.Parse(playerxin.text);
            playerxin.text = Convert.ToString(plusone + 1);

        }

        if (btn4.text == "X" && btn5.text == "X" && btn6.text == "X")
        {
            btn4.color = Color.green;
            btn5.color = Color.green;
            btn6.color = Color.green;
            msgFeedback.text = "The Winner is Player X";
            plusone = int.Parse(playerxin.text);
            playerxin.text = Convert.ToString(plusone + 1);

        }

        if (btn7.text == "X" && btn8.text == "X" && btn9.text == "X")
        {
            btn7.color = Color.blue;
            btn8.color = Color.blue;
            btn9.color = Color.blue;
            msgFeedback.text = "The Winner is Player X";
            plusone = int.Parse(playerxin.text);
            playerxin.text = Convert.ToString(plusone + 1);

        }

        //=======================================player O=============================
        if (btn1.text == "O" && btn2.text == "O" && btn3.text == "O")
        {
            btn1.color = Color.red;
            btn2.color = Color.red;
            btn3.color = Color.red;
            msgFeedback.text = "The Winner is Player Y";
            plusone = int.Parse(playeryin.text);
            playeryin.text = Convert.ToString(plusone + 1);

        }

        if (btn1.text == "O" && btn4.text == "O" && btn7.text == "O")
        {
            btn1.color = Color.blue;
            btn4.color = Color.blue;
            btn7.color = Color.blue;
            msgFeedback.text = "The Winner is Player Y";
            plusone = int.Parse(playeryin.text);
            playeryin.text = Convert.ToString(plusone + 1);

        }

        if (btn1.text == "O" && btn5.text == "O" && btn9.text == "O")
        {
            btn1.color = Color.gray;
            btn5.color = Color.gray;
            btn9.color = Color.gray;
            msgFeedback.text = "The Winner is Player Y";
            plusone = int.Parse(playeryin.text);
            playeryin.text = Convert.ToString(plusone + 1);

        }

        if (btn3.text == "O" && btn5.text == "O" && btn7.text == "O")
        {
            btn3.color = Color.green;
            btn5.color = Color.green;
            btn7.color = Color.green;
            msgFeedback.text = "The Winner is Player Y";
            plusone = int.Parse(playeryin.text);
            playeryin.text = Convert.ToString(plusone + 1);

        }

        if (btn2.text == "O" && btn5.text == "O" && btn8.text == "O")
        {
            btn2.color = Color.yellow;
            btn5.color = Color.yellow;
            btn8.color = Color.yellow;
            msgFeedback.text = "The Winner is Player Y";
            plusone = int.Parse(playeryin.text);
            playeryin.text = Convert.ToString(plusone + 1);

        }

        if (btn3.text == "O" && btn6.text == "O" && btn9.text == "O")
        {
            btn3.color = Color.cyan;
            btn6.color = Color.cyan;
            btn9.color = Color.cyan;
            msgFeedback.text = "The Winner is Player Y";
            plusone = int.Parse(playeryin.text);
            playeryin.text = Convert.ToString(plusone + 1);

        }

        if (btn4.text == "O" && btn5.text == "O" && btn6.text == "O")
        {
            btn4.color = Color.green;
            btn5.color = Color.green;
            btn6.color = Color.green;
            msgFeedback.text = "The Winner is Player Y";
            plusone = int.Parse(playeryin.text);
            playeryin.text = Convert.ToString(plusone + 1);

        }

        if (btn7.text == "O" && btn8.text == "O" && btn9.text == "O")
        {
            btn7.color = Color.blue;
            btn8.color = Color.blue;
            btn9.color = Color.blue;
            msgFeedback.text = "The Winner is Player Y";
            plusone = int.Parse(playeryin.text);
            playeryin.text = Convert.ToString(plusone + 1);

        }
        //=======================================================================
    }

    public void btn1_Click()
    {
        if (checker == false)
        {
            btn1.text = "X";
            checker = true;

        }
        else
        {
            btn1.text = "O";
            checker = false;
        }
        score();
    }

    public void btn2_Click()
    {
        if (checker == false)
        {
            btn2.text = "X";
            checker = true;

        }
        else
        {
            btn2.text = "O";
            checker = false;
        }
        score();
    }

    public void btn3_Click()
    {
        if (checker == false)
        {
            btn3.text = "X";
            checker = true;

        }
        else
        {
            btn3.text = "O";
            checker = false;
        }
        score();
    }

    public void btn4_Click()
    {
        if (checker == false)
        {
            btn4.text = "X";
            checker = true;

        }
        else
        {
            btn4.text = "O";
            checker = false;
        }
        score();
    }

    public void btn5_Click()
    {
        if (checker == false)
        {
            btn5.text = "X";
            checker = true;

        }
        else
        {
            btn5.text = "O";
            checker = false;
        }
        score();
    }

    public void btn6_Click()
    {
        if (checker == false)
        {
            btn6.text = "X";
            checker = true;

        }
        else
        {
            btn6.text = "O";
            checker = false;
        }
        score();
    }

    public void btn7_Click()
    {
        if (checker == false)
        {
            btn7.text = "X";
            checker = true;

        }
        else
        {
            btn7.text = "O";
            checker = false;
        }
        score();
    }

    public void btn8_Click()
    {
        if (checker == false)
        {
            btn8.text = "X";
            checker = true;

        }
        else
        {
            btn8.text = "O";
            checker = false;
        }
        score();
    }

    public void btn9_Click()
    {
        if (checker == false)
        {
            btn9.text = "X";
            checker = true;

        }
        else
        {
            btn9.text = "O";
            checker = false;
        }
        score();
    }

    public void reset_Click()
    {
        btn1.text = "";
        btn2.text = "";
        btn3.text = "";
        btn4.text = "";
        btn5.text = "";
        btn6.text = "";
        btn7.text = "";
        btn8.text = "";
        btn9.text = "";

        btn1.color = Color.black;
        btn2.color = Color.black;
        btn3.color = Color.black;
        btn4.color = Color.black;
        btn5.color = Color.black;
        btn6.color = Color.black;
        btn7.color = Color.black;
        btn8.color = Color.black;
        btn9.color = Color.black;


    }


    public void newgame_Click()
    {
        reset_Click();
        playerxin.text = "";
        playeryin.text = "";

    }

}
