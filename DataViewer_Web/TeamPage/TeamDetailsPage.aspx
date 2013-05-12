﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Team_Master.master" AutoEventWireup="true" CodeBehind="TeamDetailsPage.aspx.cs" Inherits="DataViewer_Web.TeamPage.TeamDetailsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Operation" runat="server">
	<li>
		<asp:HyperLink ID="ChangeTeam_HyperLink" runat="server">修改施工单位</asp:HyperLink>
	</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPart" runat="server">
	<form runat="server">
		<div class="row-fluid">
			<div class="offset2 span8">
				<div class="row-fluid">
					<div class="well">
						<div class="row-fluid">
							<div class="span12">
								施工单位名称:　<%=team.TeamName%>
							</div>
						</div>
						<div class="row-fluid">
							<div class="span12">
								法定代表人:　<%=team.LegalRepresentative%>
							</div>
						</div>
						<div class="row-fluid">
							<div class="span12">
								单位地址:　<%=team.Address%>
							</div>
						</div>
						<div class="row-fluid">
							<div class="span12">
								资质等级:　<%=team.TeamLevel%>
							</div>
						</div>
						<div class="row-fluid">
							<div class="span12">
								分包类型:　<%=team.TeamType%>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</form>
</asp:Content>
