using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rock_paper_scissors
{
    public partial class rpsApp : Form
    {


        int rounds = 3;
        int timerPerRound = 6;
        bool gameOver = false;

        string[] CPUchoiceList = { "fire", "water", "earth","fire", "water", "earth" };
        int randomNumber = 0;
        Random rnd = new Random();

        string CPUchoice;
        string playerChoice;
        int playerScore;
        int CPUScore;

        public rpsApp()
        {
            InitializeComponent();
            countDownTimer.Enabled = true;
            playerChoice = "none";
            txtCountdown.Text = "5";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rpsApp_Load(object sender, EventArgs e)
        {


        }

        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;
            txtCountdown.Text = timerPerRound.ToString();
            if (timerPerRound < 1)
            {
                countDownTimer.Enabled = false;
                timerPerRound = 6;
                randomNumber = rnd.Next(0, CPUchoiceList.Length);
                CPUchoice = CPUchoiceList[randomNumber];
                switch (CPUchoice)
                {
                    case "earth":
                        picCpu.Image = Properties.Resources.Rock;

                        break;
                    case "fire":
                        picCpu.Image = Properties.Resources.fire;

                        break;
                    case "water":
                        picCpu.Image = Properties.Resources.water;

                        break;
                }
                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if (playerScore > CPUScore)
                    {
                        MessageBox.Show("You are the Chose One!");
                    }
                    else
                    {
                        MessageBox.Show("You aren't ready yet to save the world.");
                    }
                    gameOver = true;
                }
            }

            
            
            txtRounds.Text = "Round: " + rounds;

        }

        private void btnEarth_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.Rock;
            playerChoice = "earth";
        }

        private void btnWater_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.water;
            picPlayer.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            picPlayer.Invalidate();
            playerChoice = "water";
        }

        private void btnFire_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.fire;
            picPlayer.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            playerChoice = "fire";
        }
        private void checkGame()
        {
            if (playerChoice  == "earth" && CPUchoice == "water")
            {
                CPUScore += 1;
                rounds -= 1;
                MessageBox.Show("Cpu wins, they water bended your blood and killed you!");
            }
            else if (playerChoice == "water" && CPUchoice == "earth")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("You win, you water bended their blood and killed them!");
            }
            else if (playerChoice == "fire" && CPUchoice == "water")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("You win, their water bending skills were no match to your fire bending skills that easily evaporated them!");
            }
            else if (playerChoice == "water" && CPUchoice == "fire")
            {
                CPUScore += 1;
                rounds -= 1;
                MessageBox.Show("Cpu win, your water bending skills were no match to their fire bending skills and easily evaporated you!");
            }
            else if (playerChoice == "earth" && CPUchoice == "fire")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("You win, they tried but tis but a scratch!");
            }
            else if (playerChoice == "fire" && CPUchoice == "earth")
            {
                CPUScore += 1;
                rounds -= 1;
                MessageBox.Show("They win, your fire was too weak to stop those chuncky rocks!");
            }
            else if (playerChoice == "water" && CPUchoice == "water")
            {
                MessageBox.Show("you both are at the same skill level with this element!");
            }
            else if (playerChoice == "fire" && CPUchoice == "fire")
            {
                MessageBox.Show("you both are at the same skill level with this element!");
            }
            else if (playerChoice == "earth" && CPUchoice == "earth")
            {
                MessageBox.Show("you both are at the same skill level with this element!");
            }
            else
            {
                MessageBox.Show("You need to make a choice!");
            }
            startNextRound();




        }
        
        private void startNextRound()
        {
            if (gameOver == true)
            {
                return;
            }
            else
            {
             
            }
            txtScore.Text = $"Player:{playerScore} CPU:{CPUScore}";
            playerChoice = "none";

            countDownTimer.Enabled = true;
            picPlayer.Image = Properties.Resources.unknown;
            picCpu.Image = Properties.Resources.unknown;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            CPUScore = 0;
            rounds = 3;
            txtScore.Text = $"Player:{playerScore} CPU:{CPUScore}";
            playerChoice = "none";
            timerPerRound = 6;
            countDownTimer.Enabled = true;
            txtCountdown.Text = timerPerRound.ToString();
            picPlayer.Image = Properties.Resources.unknown;
            picCpu.Image = Properties.Resources.unknown;
            gameOver = false;
        }
    }
}
