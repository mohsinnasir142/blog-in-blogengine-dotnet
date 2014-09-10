<%@ Control Language="C#" AutoEventWireup="true" CodeFile="edit.ascx.cs" Inherits="Widgets.ScriptInjection.Edit" %>

<style type="text/css">
    #body label {display: block; float: left; width: 150px}
    #body input {display: block; float: left; }
</style>


<div id="body">
<label for="<%=txtADClient%>">JavaScript or HTML Code:</label>
<asp:TextBox runat="server" ID="txtADClient" Width="500" Height = "320" style="Resize:none; " TextMode="MultiLine"/>
</br>
</br>
<label>Blocked IP's delimited by ',':</label>
<asp:TextBox runat="server" ID="txtIPClient" Width="500" Height = "45" style="Resize:none; " TextMode="MultiLine"/>
</div>
