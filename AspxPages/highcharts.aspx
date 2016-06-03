<%@ Page Title="highcharts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="highcharts.aspx.cs" Inherits="AspxPages.highcharts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/res-highcharts/media/com_demo/css/highslide.min.css" type="text/css">
    <link rel="stylesheet" href="/res-highcharts/joomla/media/templates/highsoft_2015/css/bootstrap.min.css" type="text/css">
    <link rel="stylesheet" href="/res-highcharts/joomla/media/templates/highsoft_2015/css/source-sans-pro.css" type="text/css">
    <link rel="stylesheet" href="/res-highcharts/joomla/media/templates/highsoft_2015/css/font-awesome.css" type="text/css">
    <link rel="stylesheet" href="/res-highcharts/joomla/media/templates/highsoft_2015/css/template.css" type="text/css">
    <link rel="stylesheet" href="/res-highcharts/css/style.css" type="text/css">
    <script async="" src="//www.google-analytics.com/analytics.js"></script>
    <script src="/res-highcharts/joomla/media/com_demo/js/highslide-full.min.js" type="text/javascript"></script>
    <script src="/res-highcharts/joomla/media/com_demo/js/highslide.config.min.js" type="text/javascript"></script>
    <script src="/res-highcharts/lib/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="/res-highcharts/joomla/media/templates/highsoft_2015/js/bootstrap.js" type="text/javascript"></script>
    <script src="/res-highcharts/joomla/media/templates/highsoft_2015/js/modernizr.js" type="text/javascript"></script>
    <script src="/res-highcharts/joomla/media/templates/highsoft_2015/js/script.js" type="text/javascript"></script>
    <script src="/res-highcharts/joomla/media/templates/highsoft_2015/js/jquery.appear.min.js" type="text/javascript"></script>
    <script src="/res-highcharts/js/script.js" type="text/javascript"></script>
    <script src="/res-highcharts/joomla/js/covervid/covervid.js" type="text/javascript"></script>
    <script src="/res-highcharts/joomla/js/covervid/fullscreen.js" type="text/javascript"></script>
    <script src="/res-highcharts/maps/highmaps.js"></script>
    <script src="/res-highcharts/maps/modules/data.js"></script>
    <script src="/res-highcharts/maps/modules/exporting.js"></script>
    <script src="/res-highcharts/mapdata/countries/us/us-all-all.js"></script>

    <div class="chart-container">
	    <div id="container" style="height: 520px; min-width: 310px; width: 800px; margin: 0 auto; text-align:center; line-height: 520px" data-highcharts-chart="0">
	    </div>
    </div>
</asp:Content>
