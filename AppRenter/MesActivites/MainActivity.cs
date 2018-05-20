using Android.App;
using Android.Widget;
using Android.OS;
using System.Net;
using System;
using System.Collections.Generic;
using AppRenter.MesModels;
using Newtonsoft.Json;
using Android.Content;
using AppRenter.MesActivites;

namespace AppRenter
{
  [Activity(Label = "AppRenter", MainLauncher = true)]
  public class MainActivity : Activity
  {
    EditText txtLogin;
    EditText txtPwd;
    Button btnConnexion;
    List<Client> lstClient;
    List<Commercial> lstCommercial;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.MainCnx);

      txtLogin = FindViewById<EditText>(Resource.Id.txtLogin);
      txtPwd = FindViewById<EditText>(Resource.Id.txtPwd);
      btnConnexion = FindViewById<Button>(Resource.Id.btnConnexion);
      btnConnexion.Click += BtnConnexion_Click;



    }

    private void BtnConnexion_Click(object sender, EventArgs e)
    {
      WebClient wc = new WebClient();
      WebClient wc2 = new WebClient();

      //Uri url1 = new Uri("http://" + GetString(Resource.String.ip) + "GetAllClients.php");
      //Uri url2 = new Uri("http://" + GetString(Resource.String.ip) + "GetAllCommerciaux.php");
      Uri url1 = new Uri("https://apprenter.000webhostapp.com/GetAllClients.php");
      Uri url2 = new Uri("https://apprenter.000webhostapp.com/GetAllCommerciaux.php");
      wc.DownloadStringAsync(url1);
      wc.DownloadStringCompleted += Wc_DownloadStringCompleted;

      wc2.DownloadStringAsync(url2);
      wc2.DownloadStringCompleted += Wc2_DownloadStringCompleted;
    }

    private void Wc2_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      lstCommercial = JsonConvert.DeserializeObject<List<Commercial>>(e.Result);
      int i = 6;
      foreach (Commercial commercial in lstCommercial)
      {
        if (txtLogin.Text == commercial.loginCom && txtPwd.Text == commercial.pwdCom)
        {
          
          Intent intentMenu2 = new Intent(this, typeof(MainActivityMenuCom));
          string idCom = commercial.idCom;
          intentMenu2.PutExtra("unCommercial", JsonConvert.SerializeObject(commercial));
          StartActivity(intentMenu2);
          //Toast.MakeText(this, commercial.loginCom, ToastLength.Short).Show();
        }
        
      }
    }

   

    private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      lstClient = JsonConvert.DeserializeObject<List<Client>>(e.Result);
      int i = 6;

      foreach (Client client in lstClient)
      {
        if(txtLogin.Text == client.loginCl && txtPwd.Text == client.pwdCl)
        {
          Intent intentMenu = new Intent(this, typeof(MainActivityMenuClient));
          string idClient = client.idCl;
          intentMenu.PutExtra("unClient", JsonConvert.SerializeObject(client));
          StartActivity(intentMenu);
          //Toast.MakeText(this, "ok", ToastLength.Short).Show();
        }
        
      }
      
    }
  }
}

