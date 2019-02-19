using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tick_tack_toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string playerTurn = "X";
        int xCount = 0;
        int oCount = 0;
        bool winner = false;
        int gridClickCount = 0;
        int playerXCount = 0;
        int playerOCount = 0;
        int[,] winningCombinatons = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 1, 4, 7 }, { 2, 5, 8 },
                                                { 3, 6, 9}, { 1, 5, 9 }, { 3, 5, 7 } };

        List<int> playerOCombinations = new List<int>();
        List<int> playerXCombinations = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }


        //Event listener for each cell in grid

        private void Button_0_0_Click(object sender, RoutedEventArgs e)
        {
            gridClick(playerTurn, button_0_0, 1);
        }

        private void Button_0_1_Click(object sender, RoutedEventArgs e)
        {
            gridClick(playerTurn, button_0_1, 2);
        }

        private void Button_0_2_Click(object sender, RoutedEventArgs e)
        {
            gridClick(playerTurn, button_0_2, 3);
        }

        private void Button_1_0_Click(object sender, RoutedEventArgs e)
        {
            gridClick(playerTurn, button_1_0, 4);
        }

        private void Button_1_1_Click(object sender, RoutedEventArgs e)
        {
            gridClick(playerTurn, button_1_1, 5);
        }

        private void Button_1_2_Click(object sender, RoutedEventArgs e)
        {
            gridClick(playerTurn, button_1_2, 6);
        }

        private void Button_2_0_Click(object sender, RoutedEventArgs e)
        {
            gridClick(playerTurn, button_2_0, 7);
        }

        private void Button_2_1_Click(object sender, RoutedEventArgs e)
        {
            gridClick(playerTurn, button_2_1, 8);
        }

        private void Button_2_2_Click(object sender, RoutedEventArgs e)
        {
            gridClick(playerTurn, button_2_2, 9);
        }

        //Play Again Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearGame();
        }

        //Reset Button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            clearGame();
            playerXCount = 0;
            playerOCount = 0;
            xScore.Content = "0";
            oScore.Content = "0";

        }

        //Method for when a grid cell is clicked
        public void gridClick(string player, Button gridCell, int gridLoc)
        {
            gridClickCount++; //add one to grid cell count



            //if neither players have clicked on the grid cell and theres no current winner
            if ((!playerOCombinations.Contains(gridLoc) && !playerXCombinations.Contains(gridLoc)) && winner == false)
            {
                if (playerTurn == player)
                {
                    gridCell.Content = player; //Put X or O on the grid cell according to the player.
                    //if grid all grids have been clicked its a draw
                    if (gridClickCount == 9)
                    {
                        playerTurnLable.Content = "It's A Draw.";
                    }
                    else
                    {
                        if (player == "X")
                        {
                            playerTurn = "O";
                            playerTurnLable.Content = "It's O's Turn";
                            playerXCombinations.Add(gridLoc); // add cell location to players List collection
                            checkWinner("X");
                        }
                        else
                        {
                            playerTurn = "X";
                            playerTurnLable.Content = "It's X's Turn";
                            playerOCombinations.Add(gridLoc); // add cell location to players List collection
                            checkWinner("O");
                        }
                    }

                }
            }
        }

        public void checkWinner(string player)
        {
            if (player == "X")
            {
                //Loop through first level of winning combination array
                for (int i = 0; i < 8; i++)
                {
                    //Loop through second level of winning combination array
                    for (int j = 0; j < 3; j++)
                    {
                        //Loop through each item in players List combination
                        foreach (int item in playerXCombinations)
                        {
                            //if values match up
                            if (item == winningCombinatons[i, j])
                            {
                                //add one to player count
                                xCount++;
                                //if player count has reached three they have won the game
                                if (xCount == 3)
                                {
                                    playerTurnLable.Content = "Player X\n\nYou've Won!!";
                                    playerXCount++;
                                    xScore.Content = playerXCount.ToString();
                                    winner = true;
                                }
                            }
                        }
                    }
                    //set player count back to 0 if cound didnt reach 3 before going on to the next winning combination.
                    xCount = 0;
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        foreach (int item in playerOCombinations)
                        {
                            if (item == winningCombinatons[i, j])
                            {
                                oCount++;
                                if (oCount == 3)
                                {
                                    playerTurnLable.Content = "Player O\n\nYou've Won!!";
                                    playerOCount++;
                                    oScore.Content = playerOCount.ToString();
                                    winner = true;
                                }
                            }
                        }
                    }
                    oCount = 0;
                }
            }
        }

        // Method to clear fields on game board (play again)
        public void clearGame()
        {
            playerTurn = "X";
            xCount = 0;
            oCount = 0;
            winner = false;
            gridClickCount = 0;
            playerTurnLable.Content = "It's X's Turn";

            button_0_0.Content = "";
            button_0_1.Content = "";
            button_0_2.Content = "";
            button_1_0.Content = "";
            button_1_1.Content = "";
            button_1_2.Content = "";
            button_2_0.Content = "";
            button_2_1.Content = "";
            button_2_2.Content = "";

            playerXCombinations.Clear();
            playerOCombinations.Clear();

        }


    }
}
