using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppRenter.MesActivites;
using AppRenter.MesModels;
using Newtonsoft.Json;

namespace AppRenter
{
  [Activity(Label = "MainActivityMenuClient")]
  public class MainActivityMenuClient : Activity
  {
    Button btnDemande;
    Button btnMesReservations;
    Client client;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      
      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.MainMenuClient);

      // Create your application here

      btnDemande = FindViewById<Button>(Resource.Id.btnDemande);
      btnMesReservations = FindViewById<Button>(Resource.Id.btnMesReservations);

      btnMesReservations.Click += BtnMesReservations_Click;
      btnDemande.Click += BtnDemande_Click;


    }

    private void BtnDemande_Click(object sender, EventArgs e)
    {
      string unClient = Intent.GetStringExtra("unClient");
      client = JsonConvert.DeserializeObject<Client>(unClient);

      Intent intent = new Intent(this, typeof(MainActivityDemande));
      intent.PutExtra("unClient", JsonConvert.SerializeObject(client));
      StartActivity(intent);
    }

    private void BtnMesReservations_Click(object sender, EventArgs e)
    {
      string unClient = Intent.GetStringExtra("unClient");
      client = JsonConvert.DeserializeObject<Client>(unClient);
      
     
      Intent intent = new Intent(this, typeof(MainActivityMesReservations));
      intent.PutExtra("unClient", JsonConvert.SerializeObject(client));
      StartActivity(intent);

      //Toast.MakeText(this, "ok", ToastLength.Short).Show();
    }
  }
}
