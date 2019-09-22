<Query Kind="Statements">
  <Reference Relative="..\..\working\Suggestion\Suggestions\Suggestions.Web\bin\Newtonsoft.Json.dll">D:\bagherani-m\working\Suggestion\Suggestions\Suggestions.Web\bin\Newtonsoft.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

var sb = new StringBuilder();
for (int i = 0; i < 20900; i += 100)
{
	var req = WebRequest.Create($"https://api.profile.ir/api/v1.1/profiles?top=100&skip={i}");
	StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream());
	var data = reader.ReadToEnd();
	var res =(dynamic)Newtonsoft.Json.JsonConvert.DeserializeObject(data);
	var items = (JArray)res.data;
	foreach (var elem in items)
	{
		sb.AppendLine(elem["id"].ToString());
	}
	Thread.Sleep(1000);
}

File.WriteAllText(@"D:\bagherani-m\Projects\profile_ir\usersIDs.txt",sb.ToString());