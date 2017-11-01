<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptGetOrganizationsBwDates.aspx.cs" Inherits="ProjectFirms01.Reports.RptGetOrganizationsBwDates" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asptoolkit" %>

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
                            FromDate:&nbsp;<asp:TextBox runat="server" ID="tbStartDate" Width="120"/>
               <%--<input type="date" id="tbStart" runat="server" class="form-control"/>--%>
                            <asptoolkit:CalendarExtender ID="dtpFrom" runat="server" Enabled="True" TargetControlID="tbStartDate" BehaviorID="ajaxcalendarextender" PopupPosition="BottomRight" Format="dd/MMM/yyyy">
                            </asptoolkit:CalendarExtender>

                            ToDate:&nbsp;<asp:TextBox runat="server" ID="tbEndDate" width="120" />
                        <%--<input type="date" id="tbEnd" runat="server" class="form-control"/>--%>  
                 <asptoolkit:CalendarExtender ID="dtpTo" runat="server" Enabled="True" TargetControlID="tbEndDate" BehaviorID="ajaxcalendarextender" PopupPosition="BottomRight" Format="dd/MMM/yyyy">
                            </asptoolkit:CalendarExtender>

               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>                
                    </ContentTemplate>
             </asp:UpdatePanel>
               <div>         
                    <rsweb:ReportViewer ID="RpvOrgs" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                        <LocalReport ReportPath="RDLCs\ReportRegOrgBwDates.rdlc" EnableHyperlinks="true" >
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                        </DataSources> 
                            </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbFirmsConnectionString %>" SelectCommand="usp_GetOrganizationRegisteredBwDates" SelectCommandType="StoredProcedure" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tbStartDate" Name="FromDate" PropertyName="Text" Type="DateTime" DefaultValue="2016/01/01"/>
                            <asp:ControlParameter ControlID="tbEndDate" Name="ToDate" PropertyName="Text" Type="DateTime" DefaultValue="2016/01/01"/> 
                            <asp:Parameter Name="OrgTypeID" DefaultValue="0" Type="Int32"/>                           
                        </SelectParameters>                       

                    </asp:SqlDataSource>

                </div>

    </form>
    
</body>
</html>
