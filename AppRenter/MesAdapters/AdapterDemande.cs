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
using AppRenter.MesModels;

namespace AppRenter.MesAdapters
{
  public class AdapterVoiture : ArrayAdapter<Voiture>
  {

    Activity context;
    List<Voiture> lesVoitures;

    public AdapterVoiture(Activity unContext, List<Voiture> desVoitures)
        : base(unContext, Resource.Layout.ItemDemande, desVoitures)
    {
      context = unContext;
      lesVoitures = desVoitures;
    }


    public override View GetView(int position, View convertView, ViewGroup parent)
    {
      var view = context.LayoutInflater.Inflate(Resource.Layout.ItemDemande, null);
      view.FindViewById<TextView>(Resource.Id.txtIdVoit).Text = lesVoitures[position].idVoit.ToString();
      view.FindViewById<TextView>(Resource.Id.txtNomVoit).Text = lesVoitures[position].nomVoit.ToString();
      view.FindViewById<TextView>(Resource.Id.txtMarqueVoit).Text = lesVoitures[position].marqueVoit.ToString();
      view.FindViewById<TextView>(Resource.Id.txtMatriculeVoit).Text = lesVoitures[position].matriculeVoit.ToString();
      return view;
    }


  }
}
