using Newtonsoft.Json;
using SBEX.BASE.Helpers;
using Streamer.bot.Plugin.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEX.QUOTES
{
    public class Quotes
    {
        public static Random ran = new Random();
        public static string GetQuote(IInlineInvokeProxy cph = null)
        {
            List<Quote> quotes = JsonConvert.DeserializeObject<List<Quote>>(File.ReadAllText("e:\\Text resources\\quotes.txt"));
            string quote = quotes.OrderBy(_ => ran.Next()).ToList().First().Text;
            cph?.SendMessage(quote);
            return quote;
        }
        public static bool DeleteQuote(IInlineInvokeProxy cph, string id)
        {
            List<Quote> quotes = JsonConvert.DeserializeObject<List<Quote>>(File.ReadAllText("e:\\Text resources\\quotes.txt"));
            quotes.Remove(quotes.First(q => q.Id == id));
            File.WriteAllText("e:\\Text resources\\quotes.txt", JsonConvert.SerializeObject(quotes));
            cph?.SendMessage($"Quote {id} has been removed!", true);

            return true;
        }
        public static bool AddQuote(IInlineInvokeProxy cph, string rawInput, string user, string game)
        {
            try
            {
                List<Quote> quotes = JsonConvert.DeserializeObject<List<Quote>>(File.ReadAllText("e:\\Text resources\\quotes.txt"));
                
                if (string.IsNullOrEmpty(rawInput))
                    return false;
                if (quotes == null)
                    quotes = new List<Quote>();
                Quote quote = new Quote();
                string[] splittedInput = rawInput.Split('|');
                quote.User = user;
                quote.Id = (Convert.ToInt32(quotes.Max(c => c.Id)) + 1).ToString();
                if (splittedInput.Length > 1)
                {
                    if (int.TryParse(splittedInput[0], out int cat) && cat == 1)
                    {
                        quote.Text = splittedInput[1];
                        quote.Category = game;
                    }
                    else
                    {
                        quote.Category = String.Empty;
                        quote.Text = splittedInput[1];
                    }

                }
                else
                {
                    quote.Category = String.Empty;
                    quote.Text = splittedInput[0];
                }
                quotes.Add(quote);
                File.WriteAllText("e:\\Text resources\\quotes.txt", JsonConvert.SerializeObject(quotes));
                cph?.SendMessage($"@{user}, your quote has been added with the ID {quote.Id}!", true);
                return true;
            }catch(Exception e)
            {
                cph?.LogError(e.Message);
                cph?.LogError(e.StackTrace);
                cph?.SendMessage($"@{user}, your quote could not be added!", true);
                return false;
            }
        }
    

    }
}
