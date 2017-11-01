<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptFirmDetails.aspx.cs" Inherits="ProjectFirms01.Reports.RptFirmDetails" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager runat="server" AjaxFrameworkMode="Enabled"  EnablePageMethods="true"
        EnablePartialRendering="true"
        LoadScriptsBeforeUI="true" />
         <asp:UpdatePanel ID="upConstituency" runat="server" >
           <ContentTemplate>
               <asp:TextBox ID="tbFileNo" runat="server" />
               <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>                
               <div>         
                    <rsweb:ReportViewer ID="RpvFirms" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                        <LocalReport ReportPath="RDLCs\ReportGetFirmDetails.rdlc" EnableHyperlinks="true" >
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                            <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="DataSet2" />
                            <rsweb:ReportDataSource DataSourceId="SqlDataSource3" Name="DataSet3" />
                        </DataSources> 
                            </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbFirmsConnectionString %>" SelectCommand="usp_ReportGetOrgInfoUsingFileNo" SelectCommandType="StoredProcedure" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tbFileNo" Name="FileNo" PropertyName="Text" Type="String" DefaultValue="0"/>                            
                        </SelectParameters>                       

                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbFirmsConnectionString %>" SelectCommand="usp_GetPartnersofOrganizationUsingFileNo" SelectCommandType="StoredProcedure" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tbFileNo" Name="FileNo" PropertyName="Text" Type="String" DefaultValue="0"/>
                            <asp:Parameter  Name="ShowAll" Type="Boolean" DefaultValue="False"/>
                        </SelectParameters>                       

                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dbFirmsConnectionString %>" SelectCommand="usp_ReportGetBusinessTypesofFirm" SelectCommandType="StoredProcedure" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tbFileNo" Name="FileNo" PropertyName="Text" Type="String" DefaultValue="0"/>                            
                        </SelectParameters>                      

                    </asp:SqlDataSource>

                </div>
               </ContentTemplate>
             </asp:UpdatePanel>
    </form>
</body>
</html>
