using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
  [Activity(Label = "MainActivityDemande")]
  public class MainActivityDemande : Activity
  {
    Client client;
    Voiture voiture;
     
    AdapterVoiture adapter;
    EditText txtDateLoc;
    EditText txtDateFinLoc;
    Button btnEnvoiDemande;
    ListView lvDemande;
    List<Voiture> lstVoiture;
    

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      SetContentView(Resource.Layout.MainDemande);

      // Create your application here


      string unClient = Intent.GetStringExtra("unClient");
      client = JsonConvert.DeserializeObject<Client>(unClient);


      string idClient = client.idCl;

      txtDateLoc = FindViewById<EditText>(Resource.Id.txtDateLoc);
      txtDateFinLoc = FindViewById<EditText>(Resource.Id.txtDateFinLoc);
      btnEnvoiDemande = FindViewById<Button>(Resource.Id.btnEnvoiDemande);
      lvDemande = FindViewById<ListView>(Resource.Id.lvDemande);

      btnEnvoiDemande.Click += BtnEnvoiDemande_Click;

      WebClient wc = new WebClient();
      //Uri url = new Uri ("http://" + GetString(Resource.String.ip) + "GetAllVoitures.php"); 
      Uri url = new Uri("https://apprenter.000webhostapp.com/GetAllVoitures.php");
      wc.DownloadStringAsync(url);
      wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
      
      //Toast.MakeText(this, "page demande", ToastLength.Short).Show();


    }

    //Affichage des voitures pour la demande
    private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      lstVoiture = JsonConvert.DeserializeObject<List<Voiture>>(e.Result);
      //Toast.MakeText(this, "voiture au complet", ToastLength.Short).Show();
      adapter = new AdapterVoiture(this, lstVoiture);
      lvDemande.Adapter = adapter;
      lvDemande.ItemClick += LvDemande_ItemClick;
    }

    //Action sur l'item permettant de récupérer l'id de la voiture
    private void LvDemande_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
      voiture = lstVoiture[e.Position];
      string idVoiture = voiture.idVoit;




      //Toast.MakeText(this, voiture.idVoit, ToastLength.Short).Show();
    }



    //Insertion des ID et des dates
    private void BtnEnvoiDemande_Click(object sender, EventArgs e)
    {
      WebClient wcInsert = new WebClient();
      //Uri urlInsert = new Uri("http://" + GetString(Resource.String.ip) + "InsertDemandeLoc.php");
      Uri urlInsert = new Uri("https://apprenter.000webhostapp.com/InsertDemandeLoc.php");
      NameValueCollection parametres = new NameValueCollection();
      parametres.Add("idCl", client.idCl);
      parametres.Add("idVoit", voiture.idVoit);
      parametres.Add("dateLoc", txtDateLoc.Text);
      parametres.Add("dateFinLoc", txtDateFinLoc.Text);

      wcInsert.UploadValuesAsync(urlInsert, "POST", parametres);
      wcInsert.UploadValuesCompleted += WcInsert_UploadValuesCompleted;

    }

    
    private void WcInsert_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
    {
      Toast.MakeText(this, "Demande effectuée", ToastLength.Short).Show();
    }

    
    

    
    
  }
}
