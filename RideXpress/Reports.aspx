<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/RideXpress.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="RideXpress_StarterKit.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 69%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="first">
        <div class="container">
            <div class="row">
                <div class="auto-style1">
                    <h1>Incident Report List</h1>
                </div>
                <div class="col-xs-3">
                    <a href="~/AddReport.aspx" runat="server" class="btn btn-success" data-toggle="popover" data-title="New Report - Dive 4"
                        data-content="Click here to see the New Incident Report Form. Refer to the Dive 4 Instruction Document"
                        data-trigger="hover" data-placement="bottom">Create New Incident Report</a>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 text-center">
                    <asp:GridView ID="ReportList" runat="server" CssClass="table table-bordered text-left"
                        AutoGenerateColumns="False" OnRowDeleting="ReportList_RowDeleting" DataKeyNames="ReportID">
                        <Columns>
                            <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="ReportID"
                                DataNavigateUrlFormatString="~/EditReport.aspx?ReportID={0}" ControlStyle-CssClass="btn btn-success btn-xs"
                                ItemStyle-CssClass="text-center" />
                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="DeleteButton" CommandName="Delete"
                                        CssClass="btn btn-xs btn-default" Text="Delete"
                                        OnClientClick="if(!confirm('Are you sure you wish to delete this Report?')) return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="NameLabel" Text='<%# GetCarName(Convert.ToInt32(Eval("CarID")))%>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="DateOfIncident" HeaderText="Date of Incident" />
                            <asp:BoundField DataField="ReportName" HeaderText="Report Name" />
                            <asp:BoundField DataField="ReportDescription" HeaderText="Description" />
                            <asp:BoundField DataField="DateOfReport" HeaderText="Date Reported" HtmlEncode="false" DataFormatString="{0:C}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
