<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" CodeFile="DepartmentBrowser.aspx.cs" MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Isle</p>
      <table>            
		      <% foreach (var department in this.model) {%>
        	<tr class="ListItem">
               		 <td>                     
                      <a href='Blah.store'><%=department.name%></a>
                	</td>
       	 </tr>        
           	 
           	 <%
		          }%>
	    </table>            
</asp:Content>
