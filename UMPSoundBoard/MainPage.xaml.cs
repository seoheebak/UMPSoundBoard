﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UMPSoundBoard.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UMPSoundBoard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> sounds;
        private List<MenuItem> menuItems;
        public MainPage()
        {
            this.InitializeComponent();
            sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(sounds);
            menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    IconFile="Assets/Icons/animals.png",
                    Category = SoundCategory.Animals
                },
                new MenuItem
                {
                    IconFile="Assets/Icons/cartoon.png",
                    Category = SoundCategory.Cartoons
                },
                new MenuItem
                {
                    IconFile="Assets/Icons/taunt.png",
                    Category = SoundCategory.Taunts
                },
                new MenuItem
                {
                    IconFile="Assets/Icons/warning.png",
                    Category = SoundCategory.Warnings
                },

            };
            BackButton.Visibility = Visibility.Collapsed;

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            ContentSplitview.IsPaneOpen = !ContentSplitview.IsPaneOpen;
        }

        private void MenuItemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            SoundManager.GetSoundsByCategory(sounds, menuItem.Category);
            CategoryTextBlock.Text = menuItem.Category.ToString();
            BackButton.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetAllSounds(sounds);
            CategoryTextBlock.Text = "All Sounds";
            BackButton.Visibility = Visibility.Collapsed;
            MenuItemListView.SelectedItem = null;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            SoundMedia.Source = new Uri(this.BaseUri, sound.AudioFile);
        }
    }
}
