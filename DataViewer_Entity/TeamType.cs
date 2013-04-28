﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataViewer_Entity
{
	public class TeamType : IEntity
	{
		public TeamType()
		{
			_ID = 0;
			TypeName = "";
		}

		private int _ID;
		public int ID
		{
			get { return _ID; }
		}

		private string _TypeName;
		public string TypeName
		{
			get { return _TypeName; }
			set { _TypeName = value; }
		}

		public void Save()
		{
			if (ID == 0)
				_ID = DBHelper.InsertCommand("TeamType_Insert", CommandType.StoredProcedure,
					new SqlParameter("@typename", TypeName));
			else
				DBHelper.UpdateDeleteCommand("TeamType_Update", CommandType.StoredProcedure,
					new SqlParameter("@id", ID),
					new SqlParameter("@typename", TypeName));
		}

		public override string ToString()
		{
			return TypeName;
		}

		private static List<TeamType> toList(DataTable dt)
		{
			List<TeamType> result = new List<TeamType>();
			foreach (DataRow row in dt.Rows)
			{
				TeamType teamType = new TeamType();
				teamType._ID = Int32.Parse(row["id"].ToString());
				teamType.TypeName = row["typename"].ToString();
				result.Add(teamType);
			}
			return result;
		}

		public static TeamType Get_ByID(int id)
		{
			List<TeamType> teamTypes = toList(DBHelper.SelectCommand("TeamType_id", CommandType.StoredProcedure,
				new SqlParameter("id", id)));
			if (teamTypes.Count == 0)
				return null;
			return teamTypes[0];
		}
	}
}
