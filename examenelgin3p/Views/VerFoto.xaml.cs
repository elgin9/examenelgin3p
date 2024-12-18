namespace examenelgin3p.Views;

public partial class VerFoto : ContentPage
{
    public VerFoto(byte[] f)
    {
        InitializeComponent();
        
        Stream stream = new MemoryStream(f);
        foto.Source = ImageSource.FromStream(() => stream);
    }
}