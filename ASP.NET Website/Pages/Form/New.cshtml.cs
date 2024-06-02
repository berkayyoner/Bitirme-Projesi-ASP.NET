using ASP.NET_Website.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ASP.NET_Website.Pages.Form
{
    public class NewModel : PageModel
    {
		private readonly ILogger<NewModel> logger;
		public Classes.FormInfo formInfo = new Classes.FormInfo();
		public NewModel(ILogger<NewModel> logger)
		{
			this.logger = logger;
		}
		public string errorMessage = "";
		public string successMessage = "";
		public void OnGet()
        {
        }

		public void OnPost()
		{
			try
			{
				formInfo.Name = Request.Form["name"];
				formInfo.Surname = Request.Form["surname"];
				formInfo.Birthday = Convert.ToDateTime(Request.Form["birthday"]);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}

			if (formInfo.Name.Length == 0 || formInfo.Surname.Length == 0 || formInfo.Birthday == null || formInfo.Name == "Ýsim")
			{
				errorMessage = "Tüm alanlar doldurulmalý.";
				return;
			}

			// Save the new infos into DB
			try
			{
				String connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=\\Gutuphane\\;Integrated Security=True";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "insert into Datas(Names, Surname, Birthday) values (" + formInfo.Name + ", " + formInfo.Surname + ", " + formInfo.Birthday + ")";
					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception is " + ex.ToString());
			}

			formInfo.Name = ""; formInfo.Surname = ""; formInfo.Birthday = DateTime.Now;
			successMessage = "Tüm bilgiler kaydedildi.";
		}
	}
}
