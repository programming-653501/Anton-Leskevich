﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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


    public partial class MainWindow : Window
    {
        Grid grid = new Grid();

        private Setup setup;
        private ShipPlacement shipPlacement;
        private PlayVSComp playVSComp;
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            playMusic();
            InitializeGame();
        }
      

        private void InitializeGame()
        {

            Content = grid;

            this.MinHeight = 300;
            this.MinWidth = 330;
            this.Height = 300;
            this.Width = 330;


            setup = new Setup();
            grid.Children.Add(setup);


            setup.play += new EventHandler(shipSetup);
        }


        private void shipSetup(object sender, EventArgs e)
        {

            grid.Children.Clear();


            this.MinWidth = 460;
            this.MinHeight = 530;
            this.Width = 460;
            this.Height = 530;


            shipPlacement = new ShipPlacement();


            grid.Children.Add(shipPlacement);

            shipPlacement.play += new EventHandler(playGame);
        }


        private void playGame(object sender, EventArgs e)
        {

            grid.Children.Clear();


            this.MinWidth = 953.286;
            this.MinHeight = 480;
            this.Width = 953.286;
            this.Height = 480;
            
            playVSComp = new PlayVSComp(setup.difficulty, shipPlacement.playerGrid, setup.name);

            grid.Children.Add(playVSComp);
            playVSComp.replay += new EventHandler(replayGame);

        }
        private void replayGame(object sender, EventArgs e)
        {
            //Close playVSComp grid
            grid.Children.Clear();
            InitializeGame();
        }
        private void playMusic()
        {
            mediaPlayer.Open(new Uri(Directory.GetCurrentDirectory() + "\\Sounds\\music.mp3"));
            mediaPlayer.Volume = 0.02;
            mediaPlayer.Play();
            mediaPlayer.MediaEnded += new EventHandler(Media_Ended);
        }
        private void Media_Ended(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }
    }
}
