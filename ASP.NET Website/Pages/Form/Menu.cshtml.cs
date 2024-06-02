using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ASP.NET_Website.Pages.Form
{
    public class MenuModel : PageModel
    {
		private readonly ILogger<MenuModel> logger;
		public List<Classes.FormInfo> FormInfos = new List<Classes.FormInfo>();
		public MenuModel(ILogger<MenuModel> logger)
		{
			this.logger = logger;
		}
		public void OnGet() // Save the infos into list from DB
		{
			try
			{
				String connectionString = @"Server=.\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;Timeout=2;";
				SqlConnection connection = new SqlConnection(connectionString);

				connection.Open();

				string query = "select * from Datas";
				SqlCommand cmd = new SqlCommand(query, connection);

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Classes.FormInfo formInfo = new Classes.FormInfo();
					formInfo.ID = reader.GetInt32(0);
					formInfo.Name = reader.GetString(1);
					formInfo.Surname = reader.GetString(2);
					formInfo.Birthday = reader.GetDateTime(3);
					FormInfos.Add(formInfo);
				}

				cmd.Dispose();
				connection.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception is " + ex.ToString());
			}
		}
	}
}
