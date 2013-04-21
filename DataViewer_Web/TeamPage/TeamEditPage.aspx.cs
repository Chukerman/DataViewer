﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataViewer_Entity;

namespace DataViewer_Web.TeamPage
{
	public partial class TeamEditPage : System.Web.UI.Page
	{
		protected Team team = null;
		protected void Page_Load(object sender, EventArgs e)
		{
			int id;
			if (Request.Params["id"] != null && Int32.TryParse(Request.Params["id"].ToString(), out id))
				team = Team.Get_ByID(id);
			if (team != null)
			{
				TeamName_TextBox.Text = team.TeamName;
			}
		}
	}
}