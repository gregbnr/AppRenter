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
  [Activity(Label = "Les demandes")]
  public class MainActivityLesDemandesCl : Activity
  {
    ListView lvLesDemandes;
    List<Demande> lstDemandes;
    AdapterLesDemandesCl adapter;
    
    Demande uneDemande;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.MainLesDemandesCl);
      // Create your application here

      lvLesDemandes = FindViewById<ListView>(Resource.Id.lvLesDemandes);

      WebClient wc = new WebClient();
      //Uri url = new Uri ("http://" + GetString(Resource.String.ip) + "GetAllDemandes.php");
      Uri url = new Uri("https://apprenter.000webhostapp.com/GetAllDemandes.php");

      wc.DownloadStringAsync(url);
      wc.DownloadStringCompleted += Wc_DownloadStringCompleted;


    }

    private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      lstDemandes = JsonConvert.DeserializeObject<List<Demande>>(e.Result);
      adapter = new AdapterLesDemandesCl(this, lstDemandes);
      lvLesDemandes.Adapter = adapter;
      lvLesDemandes.ItemClick += LvLesDemandes_ItemClick;
    }

    private void LvLesDemandes_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
      uneDemande = lstDemandes[e.Position];
      WebClient wcInsert = new WebClient();
      //Uri urlInsert = new Uri("http://" + GetString(Resource.String.ip) + "InsertLesDemandesCl.php"); 
      Uri urlInsert = new Uri("https://apprenter.000webhostapp.com/InsertLesDemandesCl.php");
      NameValueCollection parametres = new NameValueCollection();
      parametres.Add("idCl", uneDemande.idCl);
      parametres.Add("idVoit", uneDemande.idVoit);
      parametres.Add("dateLoc", uneDemande.dateLoc);
      parametres.Add("dateFinLoc", uneDemande.dateFinLoc);

      wcInsert.UploadValuesAsync(urlInsert, "POST", parametres);
      wcInsert.UploadValuesCompleted += WcInsert_UploadValuesCompleted;



      //Toast.MakeText(this, uneDemande.idCl, ToastLength.Short).Show();
    }



    private void WcInsert_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
    {
      Toast.MakeText(this, "Insertion effectuée", ToastLength.Short).Show();

    }
  }
}
