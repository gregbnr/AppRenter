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
  public class AdapterLesDemandesCl : ArrayAdapter<Demande>
  {

    Activity context;
    List<Demande> lesDemandes;

    public AdapterLesDemandesCl(Activity unContext, List<Demande> desDemandes)
        : base(unContext, Resource.Layout.ItemLesDemandesCl, desDemandes)
    {
      context = unContext;
      lesDemandes = desDemandes;
    }


    public override View GetView(int position, View convertView, ViewGroup parent)
    {
      var view = context.LayoutInflater.Inflate(Resource.Layout.ItemLesDemandesCl, null);
      view.FindViewById<TextView>(Resource.Id.txtIdClientCl).Text = lesDemandes[position].idCl.ToString();
      view.FindViewById<TextView>(Resource.Id.txtIdVoitCl).Text = lesDemandes[position].idVoit.ToString();
      view.FindViewById<TextView>(Resource.Id.txtDateLocCl).Text = lesDemandes[position].dateLoc.ToString();
      view.FindViewById<TextView>(Resource.Id.txtDateFinLocCl).Text = lesDemandes[position].dateFinLoc.ToString();
      return view;
    }


  }
}
