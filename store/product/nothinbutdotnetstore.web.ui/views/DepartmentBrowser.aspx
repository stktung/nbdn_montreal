<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.dto" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Isle</p>

            <table>            
		      <% foreach (var department in ((IEnumerable<DepartmentItem>)HttpContext.Current.Items["blah"]))
 {

%>
        	<tr class="ListItem">
               		 <td>                     
                  <%=department.name%>
                	</td>
           	 </tr>        
           	 
           	 <%
 }%>
	    </table>            
</asp:Content>
