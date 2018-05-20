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
  
    public class AdapterLocation : ArrayAdapter<Location>
    {

      Activity context;
      List<Location> lesLocations;

      public AdapterLocation(Activity unContext, List<Location> desLocations)
          : base(unContext, Resource.Layout.ItemReservations, desLocations)
      {
        context = unContext;
        lesLocations = desLocations;
      }


      public override View GetView(int position, View convertView, ViewGroup parent)
      {
        var view = context.LayoutInflater.Inflate(Resource.Layout.ItemReservations, null);
        view.FindViewById<TextView>(Resource.Id.txtIdCl).Text = lesLocations[position].idCl.ToString();
        view.FindViewById<TextView>(Resource.Id.txtIdVoit).Text = lesLocations[position].idVoit.ToString();
        view.FindViewById<TextView>(Resource.Id.txtDateLoc).Text = lesLocations[position].dateLoc.ToString();
        view.FindViewById<TextView>(Resource.Id.txtDateFinLoc).Text = lesLocations[position].dateFinLoc.ToString();
      return view;
      }


    }
  }
