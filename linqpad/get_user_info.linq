<Query Kind="Statements">
  <Reference Relative="..\..\working\Suggestion\Suggestions\Suggestions.Web\bin\Newtonsoft.Json.dll">D:\bagherani-m\working\Suggestion\Suggestions\Suggestions.Web\bin\Newtonsoft.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var sb = new StringBuilder();
var userIds = File.ReadAllLines(@"D:\bagherani-m\Projects\profile_ir\usersIDs.txt");

Parallel.ForEach(userIds, userid =>
{
	if (File.Exists($@"D:\bagherani-m\Projects\profile_ir\user_info\{userid}.json"))
		return;

	var profileURL = $"https://api.profile.ir/api/v1.1/profiles/{userid}";
	var req = WebRequest.Create(profileURL);
	StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream());

	var data = reader.ReadToEnd();
	File.WriteAllText($@"D:\bagherani-m\Projects\profile_ir\user_info\{userid}.json", data);

	reader.Close();
	reader.Dispose();
});