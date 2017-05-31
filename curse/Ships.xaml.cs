﻿using System;
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

namespace Battleship
{
 
    public partial class ShipPlacement : UserControl
    {
        public event EventHandler play;
        
        enum Orientation { VERTICAL, HORIZONTAL};
        Orientation orientation = Orientation.HORIZONTAL;
        SolidColorBrush unselected = new SolidColorBrush(Colors.Black);
        SolidColorBrush selected = new SolidColorBrush(Colors.Green);
        String ship = "";
        int size;
        int numShipsPlaced;
        Path lastShip;
        Path[] ships;
        Polygon lastArrow;
        public Grid[] playerGrid;

        SolidColorBrush[] shipColors = new SolidColorBrush[] {(SolidColorBrush)(new BrushConverter().ConvertFrom("#88cc00")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#33cc33")),
                                                                  (SolidColorBrush)(new BrushConverter().ConvertFrom("#00e64d")),(SolidColorBrush)(new BrushConverter().ConvertFrom("#00cc00")),
                                                                  (SolidColorBrush)(new BrushConverter().ConvertFrom("#00e600")),(SolidColorBrush)(new BrushConverter().ConvertFrom("#33eb33")),
                                                                  (SolidColorBrush)(new BrushConverter().ConvertFrom("#99f599")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#4ded4d")),
                                                                  (SolidColorBrush)(new BrushConverter().ConvertFrom("#7ff27f")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#19e919")) };

        public ShipPlacement()
        {
            InitializeComponent();
            playerGrid = new Grid[] { gridA1, gridA2, gridA3, gridA4, gridA5, gridA6, gridA7,gridA8,gridA9,gridA10,
                                gridB1, gridB2, gridB3, gridB4, gridB5, gridB6, gridB7,gridB8,gridB9,gridB10,
                                gridC1, gridC2, gridC3, gridC4, gridC5, gridC6, gridC7,gridC8,gridC9,gridC10,
                                gridD1, gridD2, gridD3, gridD4, gridD5, gridD6, gridD7,gridD8,gridD9,gridD10,
                                gridE1, gridE2, gridE3, gridE4, gridE5, gridE6, gridE7,gridE8,gridE9,gridE10,
                                gridF1, gridF2, gridF3, gridF4, gridF5, gridF6, gridF7,gridF8,gridF9,gridF10,
                                gridG1, gridG2, gridG3, gridG4, gridG5, gridG6, gridG7,gridG8,gridG9,gridG10,
                                gridH1, gridH2, gridH3, gridH4, gridH5, gridH6, gridH7,gridH8,gridH9,gridH10,
                                gridI1, gridI2, gridI3, gridI4, gridI5, gridI6, gridI7,gridI8,gridI9,gridI10,
                                gridJ1, gridJ2, gridJ3, gridJ4, gridJ5, gridJ6, gridJ7,gridJ8,gridJ9,gridJ10 };
            ships = new Path[] { small, small_Copy, small_Copy1, small_Copy2, destroyer, destroyer_Copy, destroyer_Copy1, cruiser,submarine, carrier };
            reset();
            
        }

  
        private void reset()
        {
            if (lastArrow != null)
            {
                lastArrow.Stroke = unselected;
            }
            lastArrow = rightPoly;
            rightPoly.Stroke = selected;

            foreach (var element in playerGrid)
            {
                element.Tag = "water";
                element.Background = new SolidColorBrush(Colors.White);
            }

            foreach (var element in ships)
            {
                element.IsEnabled = true;
                element.Opacity = 100;
                if (element.Stroke != unselected)
                {
                    element.Stroke = unselected;
                }
            }
            numShipsPlaced = 0;
            lastShip = null;
        }

        private void ship_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Path shipPath = (Path)sender;
            if (!shipPath.IsEnabled)
            {
                return;
            }
            if (lastShip != null)
            {
                lastShip.Stroke = unselected;
            }

            lastShip = shipPath;
            ship = shipPath.Name;
            shipPath.Stroke = selected;

            switch(ship)
            {
                case "carrier":
                    size = 4;
                    break;
                case "submarine":
                case "cruiser":
                    size = 3;
                    break;
                case "destroyer_Copy":
                case "destroyer_Copy1":
                case "destroyer":
                    size = 2;
                    break;
                case "small_Copy":
                case "small_Copy1":
                case "small_Copy2":
                case "small":
                    size = 2;
                    break;


            }
        }

        private void orientationMouseDown(object sender, MouseButtonEventArgs e)
        {
            Polygon arrow = (Polygon)sender;

            lastArrow.Stroke = unselected;
            lastArrow = arrow;
            arrow.Stroke = selected;

            if (arrow.Name.Equals("rightPoly") || arrow.Name.Equals("leftPoly"))
            {
                orientation = Orientation.HORIZONTAL;
            }
            else
            {
                orientation = Orientation.VERTICAL;
            }
        }


        private void gridMouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid square = (Grid)sender;
            int index = -1;
            int temp;
            int counter = 1;
            
            if (lastShip == null)
            {
                MessageBox.Show("You must choose a ship", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (!square.Tag.Equals("water"))
            {
                return;
            }


            index = Array.IndexOf(playerGrid, square);



            if (orientation.Equals(Orientation.HORIZONTAL))
            {
                try {
                    counter = 1;
                    for (int i = 0; i < size; i++)
                    {
               
                        if (index + i <= 99)
                        {
                            if (!playerGrid[index + i].Tag.Equals("water"))
                            {
                                throw new IndexOutOfRangeException("Invalid ship placement, not enough space!");
                            }
                        }
              
                        else
                        {
                            if (!playerGrid[index-counter].Tag.Equals("water"))
                            {
                                throw new IndexOutOfRangeException("Invalid ship placement"); 
                            }
                            counter++;
                        }

                    }
                } catch (IndexOutOfRangeException iore)
                {
                    MessageBox.Show(iore.Message,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            else
            {
                try {
                    counter = 10;
                    for (int i = 0; i < size * 10; i += 10)
                    {
                        if (index + i <= 99)
                        {
                            if (!playerGrid[index + i].Tag.Equals("water"))
                            {
                                throw new IndexOutOfRangeException("Invalid ship placement!");
                            }
                        }
                        else
                        {
                            if (!playerGrid[index - counter].Tag.Equals("water"))
                            {
                                throw new IndexOutOfRangeException("Invalid ship placement! Wrong counter.");
                            }
                            counter += 10;
                        }
                    }
                    if ((index / 10) + (size * 10) > 100)
                    {
                        throw new IndexOutOfRangeException("Invalid ship placement, not enough space!");
                    }
                } catch (IndexOutOfRangeException iore)
                {
                    MessageBox.Show(iore.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            

            if (orientation.Equals(Orientation.HORIZONTAL))
            {

                if ((index + size - 1) % 10 < size - 1)
                {
                    counter = 0;
                    temp = 1;

                    while ((index + counter) % 10 > 1)
                    {
                        playerGrid[index + counter].Background = selectColor();
                        playerGrid[index + counter].Tag = ship;
                        counter++;
                    }
                    for (int i = counter; i < size; i++)
                    {
                        playerGrid[index - temp].Background = selectColor();
                        playerGrid[index - temp].Tag = ship;
                        temp++;
                    }
                }

                else
                {
                    for (int i = 0; i < size; i++)
                    {
                        playerGrid[index + i].Background = selectColor();
                        playerGrid[index + i].Tag = ship;
                    }
                }
            }
            else
            {
 
                if (index + (size * 10) > 100)
                {
                    counter = 0;
                    temp = 10;
                    while ((index / 10 + counter ) % 100 < 10)
                    {
                        playerGrid[index + counter * 10].Background = selectColor();
                        playerGrid[index + counter * 10].Tag = ship;
                        counter++;
                    }
                    for (int i = counter; i < size; i++)
                    {
                        playerGrid[index - temp].Background = selectColor();
                        playerGrid[index - temp].Tag = ship;
                        temp += 10;
                    }
                }

                else
                {
                    counter = 0;
                    for (int i = 0; i  < size * 10; i += 10)
                    {
                        playerGrid[index + i].Background = selectColor();
                        playerGrid[index + i].Tag = ship;
                    }
                }
            }
            lastShip.IsEnabled = false;
            lastShip.Opacity = 0.5;
            lastShip.Stroke = unselected;
            lastShip = null;
            numShipsPlaced++;
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (numShipsPlaced != 10)
            {
                return;
            }
            play(this,e);
        }


        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }


        private void btnRandomize_Click(object sender, RoutedEventArgs e)
        {
            reset();
            Random random = new Random();
            int[] shipSizes = new int[] { 1, 1, 1, 1, 2, 2, 2, 3, 3, 4 };
            string[] shipNames = new string[] { "small", "small_Copy", "small_Copy1", "small_Copy2", "destroyer", "destroyer_Copy", "destroyer_Copy", "cruiser", "submarine",  "carrier" };
            int size, index;
            string ship;
            Orientation orientation;
            bool unavailableIndex = true;
            

            for (int i = 0; i < shipSizes.Length; i++)
            {

                size = shipSizes[i];
                ship = shipNames[i];
                unavailableIndex = true;

                if (random.Next(0, 2) == 0)
                    orientation = Orientation.HORIZONTAL;
                else
                    orientation = Orientation.VERTICAL;

                if (orientation.Equals(Orientation.HORIZONTAL))
                {
                    index = random.Next(0, 100);
                    while (unavailableIndex == true)
                    {
                        unavailableIndex = false;

                        while ((index + size - 1) % 10 < size - 1)
                        {
                            index = random.Next(0, 100);
                        }

                        for (int j = 0; j < size; j++)
                        {
                            if (index + j > 99 || !playerGrid[index + j].Tag.Equals("water"))
                            {
                                index = random.Next(0, 100);
                                unavailableIndex = true;
                                break;
                            }
                        }
                    }
                    for (int j = 0; j < size; j++)
                    {
                        playerGrid[index + j].Tag = ship;
                        playerGrid[index + j].Background = shipColors[i];
                    }
                }
                else
                {
                    index = random.Next(0, 100);
                    while (unavailableIndex == true)
                    {
                        unavailableIndex = false;

                        while (index / 10 + size * 10 > 100)
                        {
                            index = random.Next(0, 100);
                        }

                        for (int j = 0; j < size * 10; j += 10)
                        {
                            if (index + j > 99 || !playerGrid[index + j].Tag.Equals("water"))
                            {
                                index = random.Next(0, 100);
                                unavailableIndex = true;
                                break;
                            }
                        }
                    }
                    for (int j = 0; j < size * 10; j += 10)
                    {
                        playerGrid[index + j].Tag = ship;
                        playerGrid[index + j].Background = shipColors[i];
                    }
                }

            }
            numShipsPlaced = 10;
            foreach (var element in ships)
            {
                element.IsEnabled = false;
                element.Opacity = .5;
                if (element.Stroke != unselected)
                {
                    element.Stroke = unselected;
                }

            }
        }


        private SolidColorBrush selectColor()
        {
            switch (ship)
            {
                case "destroyer":
                    return shipColors[0];
                case "destroyer_Copy":
                    return shipColors[1];
                case "destroyer_Copy1":
                    return shipColors[2];
                case "cruiser":
                    return shipColors[3];
                case "submarine":
                    return shipColors[4];
                case "carrier":
                    return shipColors[5];
                case "small":
                    return shipColors[6];
                case "small_Copy":
                    return shipColors[5];
                case "small_Copy1":
                    return shipColors[5];
                case "small_Copy2":
                    return shipColors[5];


            }
            return shipColors[0];
        }
       
    }
}
