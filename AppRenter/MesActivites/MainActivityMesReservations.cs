using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppRenter.MesAdapters;
using AppRenter.MesModels;
using Newtonsoft.Json;

namespace AppRenter.MesActivites
{
  [Activity(Label = "MainActivityMesReservations")]
  public class MainActivityMesReservations : Activity
  {
    Client client;

    AdapterLocation adapter;
    List<Location> lstLocation;
    ListView lvLocation;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.MainMesReservations);

      // Create your application here
      //Toast.MakeText(this, "ok", ToastLength.Short).Show();

      lvLocation = FindViewById<ListView>(Resource.Id.lvLocation);


      string unClient = Intent.GetStringExtra("unClient");
      client = JsonConvert.DeserializeObject<Client>(unClient);

      string idClient = client.idCl;
      //Toast.MakeText(this, idClient.ToString(), ToastLength.Short).Show();


      WebClient wc = new WebClient();
      //Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetAllLocationsById.php?idCl="+idClient);
      Uri url = new Uri("https://apprenter.000webhostapp.com/GetAllLocationsById.php?idCl=" + idClient);
      wc.DownloadStringAsync(url);
      wc.DownloadStringCompleted += Wc_DownloadStringCompleted;



    }

    private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      lstLocation = JsonConvert.DeserializeObject<List<Location>>(e.Result);
      //Toast.MakeText(this, "completed", ToastLength.Short).Show();
      adapter = new AdapterLocation(this, lstLocation);
      lvLocation.Adapter = adapter;

      

    }
  }
}
