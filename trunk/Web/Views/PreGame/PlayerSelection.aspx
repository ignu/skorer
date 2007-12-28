<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PlayerSelection.aspx.cs" Inherits="ScoreKeeper.Web.Views.PreGame.PlayerSelection" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div style="float:right">
        <h2>Selected Players</h2>
        <% foreach (ScoreKeeper.Core.Player player in (ViewData["SelectedPlayers"] as System.Collections.Generic.List<ScoreKeeper.Core.Player>)) 
          {%>
            <div style="margin:5px 0px 0px 0px">
                <%= player.FirstName + " " + player.LastName + " (" + player.NickName + ")"%>
            </div>
        <%} %>
    
    </div>
    
    <h2>Please select some players.</h2>
       
    <% using (Html.Form("AddPlayer", "PreGame", FormExtensions.FormMethod.post))
       
      { %>
           
    <%= Html.Select("Player", (System.Linq.IQueryable<ScoreKeeper.Core.Player>)ViewData["Players"], "NickName", "ID")%>

        <div style="margin:5px 0px 0px 0px">
            <%= Html.SubmitButton("submit", "Submit") %>
        </div>
    
    <%} %>
    
    <% using (Html.Form("Start", "Game", FormExtensions.FormMethod.post)){ %>
            
    
        
        <div style="margin:5px 0px 0px 0px">
            <%= Html.SubmitButton("submit", "Start Game") %>
        </div>
    
    <%} %>
</asp:Content>
 