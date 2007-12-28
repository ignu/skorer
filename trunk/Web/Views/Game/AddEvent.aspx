<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="ScoreKeeper.Web.Views.Game.AddEvent" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div style="border:solid 2px green; margin: 10px 10px 10px 10px; padding:10px 10px 10px 10px;">
    <% foreach (ScoreKeeper.Core.PlayerScore score in (ViewData["PlayerScores"] as System.Collections.Generic.List<ScoreKeeper.Core.PlayerScore>))
       {%>
    <%=score.Player.NickName %> : <%=score.Score%>,&nbsp; 
    <%} %>
    </div>
    <h2>Add Game Event:</h2>

    <% using (Html.Form("AddEvent", "Game", FormExtensions.FormMethod.post)){ %>
            
    Event:<br />
    <%= Html.Select("SelectedGameEvent",
                            ViewData["GameEvents"] as System.Collections.Generic.List<ScoreKeeper.Core.GameEvent>, 
                "Name", 
                "ID")%>
                <p />
                
    Player:<br />
    <%= Html.Select("SelectedPlayer",
                            ViewData["Players"] as System.Collections.Generic.List<ScoreKeeper.Core.Player>, 
                "NickName", 
                "ID")%><p />
    
    Quantity:<br />                 
    <%=Html.TextBox("Quantity") %>     
    <p />
      
        <div style="margin:5px 0px 0px 0px">
            <%= Html.SubmitButton("submit", "Submit") %>
        </div>
    
    <%} %>



</asp:Content>


