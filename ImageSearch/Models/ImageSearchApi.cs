using Newtonsoft.Json.Linq;

namespace ImageSearch.Models
{
    public class ImageSearchApi
    {

        public ImageSearchApi() { }

        public List<PictureModel> GetImage(string searchTerm)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://contextualwebsearch-websearch-v1.p.rapidapi.com/api/Search/ImageSearchAPI?q={searchTerm}&pageNumber=1&pageSize=10&autoCorrect=true"),
				Headers =
	{
		{ "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
		{ "X-RapidAPI-Host", "contextualwebsearch-websearch-v1.p.rapidapi.com" },
	},
			};
			using (var response = client.SendAsync(request).Result)
				
			{
				response.EnsureSuccessStatusCode();
				var body = response.Content.ReadAsStringAsync().Result;
				var json = JObject.Parse(body)["value"];

				List<PictureModel> images = new List<PictureModel>();

				foreach (var picture in json)
                {
					var pictureModel = new PictureModel();
					pictureModel.Url = (string)picture["url"];
					pictureModel.width = (int)picture["width"];
					pictureModel.height = (int)picture["height"];
					images.Add(pictureModel);

					
			    }

				return images;

				
			}

		}


    }
}
