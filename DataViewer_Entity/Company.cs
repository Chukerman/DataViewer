﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataViewer_Entity
{
	public class Company : IEntity
	{
		public Company()
		{
			_ID = 0;
			CompanyName = "";
			LegalRepresentative = "";
			Address = "";
		}

		private int _ID;
		public int ID
		{
			get { return _ID; }
		}

		/// <summary>
		/// 企业名称
		/// </summary>
		private string _CompanyName;
		public string CompanyName
		{
			get { return _CompanyName; }
			set { _CompanyName = value; }
		}

		private string _LegalRepresentative;
		public string LegalRepresentative
		{
			get { return _LegalRepresentative; }
			set { _LegalRepresentative = value; }
		}

		private string _Address;
		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
		}

		public void Save()
		{
			if (ID == 0)
				_ID = DBHelper.InsertCommand("Company_Insert", CommandType.StoredProcedure,
					new SqlParameter("@companyname", CompanyName));
			else
				DBHelper.UpdateDeleteCommand("Company_Update", CommandType.StoredProcedure,
					new SqlParameter("@id", ID),
					new SqlParameter("@companyname", CompanyName));
		}

		private static List<Company> toList(DataTable dt)
		{
			List<Company> result = new List<Company>();
			foreach (DataRow row in dt.Rows)
			{
				Company company = new Company();
				company._ID = Int32.Parse(row["id"].ToString());
				company.CompanyName = row["companyname"].ToString();
				company.LegalRepresentative = row["legalrepresentative"].ToString();
				company.Address = row["address"].ToString();
				result.Add(company);
			}
			return result;
		}

		/// <summary>
		/// 通过ID查找企业
		/// </summary>
		/// <param name="id">所查找的企业ID</param>
		/// <returns>返回待查找的企业, 如果未找到, 返回ID为0的初始化对象</returns>
		public static Company Get_ByID(int id)
		{
			List<Company> temp = toList(DBHelper.SelectCommand("Company_id", CommandType.StoredProcedure,
				new SqlParameter("@id", id)));
			if (temp.Count != 0)
				return temp[0];
			return null;
		}

		/// <summary>
		/// 获取所有的企业机构
		/// </summary>
		/// <returns>如果没有企业, 返回count为0的List</returns>
		public static List<Company> Get_All()
		{
			return toList(DBHelper.SelectCommand("Company_all", CommandType.StoredProcedure));
		}

		public static List<Company> Get_ByFuzzyCompanyName(string companyName)
		{
			return toList(DBHelper.SelectCommand("Company_companynameFuzzy", CommandType.StoredProcedure,
				new SqlParameter("@companyname", companyName)));
		}
	}
}
