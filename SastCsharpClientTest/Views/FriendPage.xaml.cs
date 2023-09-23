using Newtonsoft.Json;
using SastCsharpClientTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Data;
using SastCsharpClientTest.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SastCsharpClientTest.Views
{
    /// <summary>
    /// FriendPage.xaml 的交互逻辑
    /// </summary>
    public partial class FriendPage : Page
    {
        VM Vm;

        public FriendPage()
        {
            InitializeComponent();

            Vm = new VM();

            SetComboBox();
            this.DataContext = Vm;
        }

        private List<Friend> friends = null!;

        public void SetComboBox()
        {
            string jsonData = File.ReadAllText("D://work//project//SastCsharpClientTest//src//data.json");
            friends = JsonConvert.DeserializeObject<Friend[]>(jsonData)!.ToList();
            FriendOption.ItemsSource = friends.Select(friend => friend.Name);
        }

        public void ChooseFriend(object sender, EventArgs e)
        {
            var comboBox = (sender as ComboBox)!;
            if (comboBox.SelectedItem is null)
                return;
            var friend = friends.First(f => f.Id == comboBox.SelectedIndex +1);
            Vm.NameBox = friend.Name;
            Vm.DescriptionBox = friend.Description;
            Vm.Id = friend.Id;
            Vm.ImgUrl = new BitmapImage(
                new Uri(Path.Combine(Environment.CurrentDirectory, friend.ImgUrl))
            );

            EditButton.Visibility = Visibility.Visible;
            SetTextBoxEnabled(false);
        }

        private void SetTextBoxEnabled(bool isEnabled)
        {
            NameBox.IsEnabled = isEnabled;
            DescriptionBox.IsEnabled = isEnabled;
        }

        private void EditFriend(object sender, RoutedEventArgs e)
        {
            SetTextBoxEnabled(true);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string jsonData1 = File.ReadAllText("src//data.json");

            friends = JsonConvert.DeserializeObject<Friend[]>(jsonData1)!.ToList();

            var model = friends.Where(friend => friend.Id == Vm.Id).FirstOrDefault();
            model!.Name = Vm.NameBox;
            model.Description = Vm.DescriptionBox;

            string jsonData2 = JsonConvert.SerializeObject(friends);
            File.WriteAllText("D://work//project//SastCsharpClientTest//src//data.json", jsonData2);
            SetComboBox();
        }
    }
}
