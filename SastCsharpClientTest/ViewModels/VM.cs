using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace SastCsharpClientTest.ViewModels
{
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void Mydata(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private Model _Model = new Model();

        public string NameBox
        {
            get { return _Model.NameBox; }
            set
            {
                _Model.NameBox = value;
                Mydata("NameBox");
            }
        }

        public string DescriptionBox
        {
            get { return _Model.DescriptionBox; }
            set
            {
                _Model.DescriptionBox = value;
                Mydata("DescriptionBox");
            }
        }

        public BitmapImage ImgUrl
        {
            get { return _Model.ImgUrl!; }
            set
            {
                _Model.ImgUrl = value;
                Mydata("ImgUrl");
            }
        }
        public int Id
        {
            get { return (int)_Model.Id; }
            set
            {
                _Model.Id = value;
                Mydata("Id");
            }
        }
    }
}
