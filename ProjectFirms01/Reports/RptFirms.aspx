<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptFirms.aspx.cs" Inherits="ProjectFirms01.Reports.RptFirms" %>

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
                <div>         
                    <rsweb:ReportViewer ID="RpvFirms" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                        <LocalReport ReportPath="RDLCs\ReportGetAllFirms.rdlc" EnableHyperlinks="true" >
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                        </DataSources> 
                            </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbFirmsConnectionString %>" SelectCommand="usp_GetAllFirms" SelectCommandType="StoredProcedure" >

                    </asp:SqlDataSource>

                </div>
               </ContentTemplate>
             </asp:UpdatePanel>
    </form>
</body>
</html>
