<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.dto" %>
<%@ Import Namespace="nothinbutdotnetstore.web.core" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Isle</p>

            <table>            
		      <% foreach (var department in ((IEnumerable<DepartmentItem>)HttpContext.Current.Items["blah"]))
 {

%>
        	<tr class="ListItem">
               		 <td>                     
                  <a href='<%= typeof(ViewSubDepartments).Name %>.store'><%=department.name%></a>
                	</td>
           	 </tr>        
           	 
           	 <%
 }%>
	    </table>            
</asp:Content>
