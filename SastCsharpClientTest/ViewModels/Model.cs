using System.Windows.Media.Imaging;

namespace SastCsharpClientTest.ViewModels
{
    public class Model
    {
        public string NameBox { get; set; } = string.Empty;

        public string DescriptionBox { get; set; } = string.Empty;

        public BitmapImage? ImgUrl { get; set; }

        public int Id { get; set; }
    }
}
