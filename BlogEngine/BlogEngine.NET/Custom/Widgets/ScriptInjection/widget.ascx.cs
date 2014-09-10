namespace Widgets.ScriptInjection
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Globalization;
	using System.Text;
	using System.Web;
	using System.Web.UI;
	using App_Code.Controls;
	using BlogEngine.Core;
	using Resources;

	public partial class Widget : WidgetBase
	{

		/// <summary>
		/// This method works as a substitute for Page_Load. You should use this method for
		/// data binding etc. instead of Page_Load.
		/// </summary>
		public override void LoadWidget()
		{
			var settings = this.GetSettings();

            if (settings.ContainsKey("ADClient"))
			{                
                string[] IPAddress = settings["IPClient"].Split(',');
                if (IPAddress.Length > 0)
                {
                    string vistorAddress = GetIpAddress();
                    for (int i = 0; i < IPAddress.Length - 1; i++)
                    {
                        if (vistorAddress.Trim() == IPAddress[0].Trim())
                        {
                            return;
                        }
                    }
                }
                string sCode = settings["ADClient"];
                string swidth = settings["WClient"];
                string sHeight = settings["HClient"];
				StringBuilder sb = new StringBuilder();
                sb.Append(@"<div");
                //sb.Append(" Width='" + swidth + "'");
                //sb.Append(" Height='" + sHeight + "' ");
                sb.Append(@">");
                sb.Append(sCode);
                sb.Append(@"</div>");
				var html = new LiteralControl(sb.ToString());
                this.ADOut.Controls.Add(html);
			}    
		}

		/// <summary>
		/// Gets the name. It must be exactly the same as the folder that contains the widget.
		/// </summary>
		/// <value></value>
		public override string Name
		{
            get { return "ScriptInjection"; }
		}

		/// <summary>
		/// Gets wether or not the widget can be edited.
		/// <remarks>
		/// The only way a widget can be editable is by adding a edit.ascx file to the widget folder.
		/// </remarks>
		/// </summary>
		/// <value></value>
		public override bool IsEditable
		{
			get { return true; }
		}

        /// <summary>
        /// Retrive vistors IP address
        /// </summary>
        /// <returns></returns>
        private string GetIpAddress()
        {
            string address = string.Empty;
            address = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (address == null)
                address = Request.ServerVariables["REMOTE_ADDR"];
            return address;
        }

	}
}