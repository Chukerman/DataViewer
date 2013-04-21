﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataViewer_Entity;

namespace DataViewer_Web.ManagementPage
{
	public partial class CompanyDetailsPage : System.Web.UI.Page
	{
		protected Company company;
		protected void Page_Load(object sender, EventArgs e)
		{
			int id;
			if (Request.Params["id"] != null && Int32.TryParse(Request.Params["id"].ToString(), out id))
				company = Company.Get_ByID(id);
			else
				Response.Redirect("/ManagementPage/CompanyPage.aspx");
		}
	}
}