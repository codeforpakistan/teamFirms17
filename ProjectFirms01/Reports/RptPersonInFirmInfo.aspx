<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptPersonInFirmInfo.aspx.cs" Inherits="ProjectFirms01.Reports.RptPersonInFirmInfo" %>
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
               Name:
               <asp:TextBox ID="tbName" runat="server" />
               <%--NIC:--%>
               <asp:TextBox ID="tbnic" runat="server" TextMode="Number" Visible="false"/>
               <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>                
               <div>         
                    <rsweb:ReportViewer ID="RpvPartner" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                        <LocalReport ReportPath="RDLCs\RptPersonInOrg.rdlc" EnableHyperlinks="true" >
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                        </DataSources> 
                            </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbFirmsConnectionString %>" SelectCommand="usp_GetOrganizationInfoofPerson" SelectCommandType="StoredProcedure" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tbName" Name="PersonName" PropertyName="Text" Type="String" DefaultValue="null"/>
                            <asp:ControlParameter ControlID="tbnic" Name="Nic" PropertyName="Text" Type="String" DefaultValue="null"/>                            
                        </SelectParameters>                      

                    </asp:SqlDataSource>

                </div>
               </ContentTemplate>
             </asp:UpdatePanel>
    </form>
</body>
</html>
