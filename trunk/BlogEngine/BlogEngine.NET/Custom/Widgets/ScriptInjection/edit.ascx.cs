namespace Widgets.ScriptInjection
{
	using System;
	using System.Web;
	using App_Code.Controls;

	public partial class Edit : WidgetEditBase
	{

		/// <summary>
		/// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Page.IsPostBack)
			{
				return;
			}

			var settings = this.GetSettings();

            this.txtADClient.Text = settings["ADClient"];
            this.txtIPClient.Text = settings["IPClient"];            
            
		}

		/// <summary>
		/// Saves this the basic widget settings such as the Title.
		/// </summary>
		public override void Save()
		{
			var settings = this.GetSettings();

            settings["ADClient"] = this.txtADClient.Text;
            settings["IPClient"] = this.txtIPClient.Text;
			this.SaveSettings(settings);
		}
	}
}