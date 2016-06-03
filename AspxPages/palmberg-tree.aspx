<%@ Page Title="palmberg-tree" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="palmberg-tree.aspx.cs" Inherits="AspxPages.palmberg_tree" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/res-palmberg-tree/css/styles.css">
    <script src="/res-palmberg-tree/js/lib/jquery-1.11.2.min.js"></script>
    <script src="/res-palmberg-tree/js/lib/underscore-min-1.6.js"></script>
    <script src="/res-palmberg-tree/js/lib/d3-3.5.12.min.js"></script>
    <script src="/res-palmberg-tree/js/lib/d3.tip.js"></script>

    <svg>
        <svg>
            <defs>
                <!-- <marker id="triangle" markerWidth="13" markerHeight="13" refx="2" refy="6" orient="auto">
                    <path d="M2,2 L2,11 L10,6 L2,2" style="fill: #000000;" />
                </marker> -->
                <pattern patterUnits="userSpaceOnUse" id="MaryPalmberg" height="1" width="1">
                    <image x="0" y="0" width="64" height="64" xlink:href="/res-palmberg-tree/images/cropped/palmberg.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="EmanuellaIsrael" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/israel.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="EricRichard" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/richard.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="HannahAltman" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/altman.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="JanKoch" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/koch.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="JaneSkinner" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/skinner.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="MaraCole" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/cole.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="GregSchrock" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/schrock.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="ThomasJensen" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/jensen.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="Wagenknechts" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/wagenknechts.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="Truckdriver" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/truck_driver.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="CathyHolmes" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/holmes.jpg"></image>
                </pattern>
                <pattern patterUnits="userSpaceOnUse" id="ClarenceBorck" height="1" width="1">
                    <image x="0" y="0" width="58" height="58" xlink:href="/res-palmberg-tree/images/cropped/borck.jpg"></image>
                </pattern>
            </defs>
        </svg>
    </svg>
    <h5 id="mobile-note" class="hide-desktop show-650"></h5>

    <script src="/res-palmberg-tree/json/tree-data.json"></script>
    <script src="/res-palmberg-tree/js/name-boxes.js"></script>
    <script src="/res-palmberg-tree/js/tooltips.js"></script>
    <script src="/res-palmberg-tree/js/script.js"></script>
</asp:Content>
