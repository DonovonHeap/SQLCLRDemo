using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Data.Linq;
using System.Linq;
using Microsoft.SqlServer.Server;
using UserGroupDemo;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic = true)]//(DataAccess = DataAccessKind.None)]//(IsPrecise = true)]//(IsDeterministic = true)]
    public static SqlString GetLatLong(string addressIn)
    {
        //sql
        //SqlDependency
        //return IEnumerable
        #region C#
        if (!addressIn.Contains("+"))
        {
            return null;
        }
        else
        {
            string k = "abc123";
        }
        string[] addressStuff = addressIn.Split('+');
        int zip;
        if (!int.TryParse(addressStuff[1], out zip))
        {
            return null;
        }

        Address a = new Address() { street1 = addressStuff[0], zip = zip.ToString() };
        var s = a.GetFullAddress();
        List<Person> people = new List<Person>();
        for (int i = 0; i < 100; i++)
        {
            Person p = new Person();
            p.FirstName = "Donovon" + i;
            p.LastName = "Heap" + i;
            p.Age = i;
            people.Add(p);
            p.EarnMoney();
        }
        var people2 = people.Where(x => x.Age > 50);

        List<Person> people3 = (from per in people2
                                where per.Age > 75
                                select per).ToList();
        #endregion

        // return new SqlString("440.00, -1100.00");
        string url = "http://localhost/SqlClr/api/values/" + a.zip;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/json; charset=utf-8";
        request.Method = "GET";
        string result;
        var httpResponse = (HttpWebResponse)request.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            result = streamReader.ReadToEnd();
        }
        return new SqlString(result);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString ufnLeadingZerosUser(int value)
    {
        
        string s = value.ToString().PadLeft(8, '0');
        return new SqlString(s);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString ufnRegEx2(string value, string regex)
    {
        // Define a regular expression for repeated words.
        Regex rx = new Regex(regex,
      RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Find matches.
        MatchCollection matches = rx.Matches(value);

        StringBuilder sb = new StringBuilder();

        // Report the number of matches found.
        sb.AppendLine(string.Format("{0} matches found in:\n   {1}",
                              matches.Count,
                              value));


        // Report on each match.
        foreach (Match match in matches)
        {
            GroupCollection groups = match.Groups;
            sb.AppendLine(string.Format("'{0}' repeated at positions {1} and {2}",
                                      groups["word"].Value,
                                      groups[0].Index,
                                      groups[1].Index));
        }
        return new SqlString(sb.ToString());
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean ufnValidateEmail(string email)
    {
        try
        {
            MailAddress m = new MailAddress(email);
           
            return new SqlBoolean(true);
        }
        catch (FormatException f)
        {
            return new SqlBoolean(false);
        }
    }


    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void spGetCustomer(string name)
    {
        using (SqlConnection conn =
            new SqlConnection("context connection = true"))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                $"select top 100 * from person.person c where c.firstname = @Name ", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            SqlContext.Pipe.ExecuteAndSend(cmd);
            
            conn.Close();
        }
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString ufnRegEx(string text, string expr)
    {


        StringBuilder sb = new StringBuilder();
        MatchCollection mc = Regex.Matches(text, expr);
        foreach (Match m in mc)
        {
            sb.AppendLine(m.ToString());
        }
        return new SqlString(sb.ToString());
    }
}
