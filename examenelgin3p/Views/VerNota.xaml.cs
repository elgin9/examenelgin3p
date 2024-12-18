namespace examenelgin3p.Views;
using Plugin.Maui.Audio;
using examenelgin3p.Models;

public partial class VerNota : ContentPage
{

    Notas nota;
    IAudioPlayer player;
    public VerNota(Notas nota)
    {
        InitializeComponent();
        this.nota = nota;
        lblDescripcion.Text = nota.Descripcion;
    }
    
    private async void OnBtnPictureClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerFoto(nota.Photo_record));
    }

    
    private void OnBtnPlayClicked(object sender, EventArgs e)
    {
        
        Stream stream = new MemoryStream(nota.Audio_record);
        player = AudioManager.Current.CreatePlayer(stream);
        player.Play();
    }

    
    private async void OnBtnEditClicked(object sender, EventArgs e)
    {
        App.nota = this.nota;
        
        await Navigation.PushAsync(new Principal(AudioManager.Current));
    }

    
    private async void OnBtnDeleteClicked(object sender, EventArgs e)
    {
        App.db.Delete(nota.Id_nota);
        await Navigation.PopAsync();
    }

}