<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ScoreKeeper.Web.Views.Home.Index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h2>Please select a game.</h2>
    
    <% using (Html.Form("SelectGame", "Home", FormExtensions.FormMethod.post)){ %>
            
    <%= Html.Select("Game", ViewData.Games, "Name", "ID") %>
        
        <div style="margin:5px 0px 0px 0px">
            <%= Html.SubmitButton("submit", "Submit") %>
        </div>
    
    <%} %>
    

</asp:Content>

