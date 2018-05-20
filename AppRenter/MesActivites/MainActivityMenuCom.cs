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
using Newtonsoft.Json;

namespace AppRenter.MesActivites
{
  [Activity(Label = "MainActivityMenuCom")]
  public class MainActivityMenuCom : Activity
  {
    Button btnDemandeCl;
    Commercial commercial;


    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.MainMenuCommercial);

      // Create your application here
      btnDemandeCl = FindViewById<Button>(Resource.Id.btnDemandeCl);


      btnDemandeCl.Click += BtnDemandeCl_Click;
    }

    private void BtnDemandeCl_Click(object sender, EventArgs e)
    {
      string unCommercial = Intent.GetStringExtra("unCommercial");
      commercial = JsonConvert.DeserializeObject<Commercial>(unCommercial);

      Intent intent = new Intent(this, typeof(MainActivityLesDemandesCl));
      intent.PutExtra("unCommercial", JsonConvert.SerializeObject(commercial));
      StartActivity(intent);
    }
  }
}
