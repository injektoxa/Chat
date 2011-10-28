namespace Chat.Presentation.Controls.View.Impl
{
    public partial class LogoControl : System.Web.UI.UserControl
    {
        public string PathToImage {private set; get; }
        public string ClassCss {private set; get; }

        public LogoControl(string path, string classCss)
        {
            PathToImage = path;
            ClassCss = classCss;
        }

        public LogoControl(){}
    }
}