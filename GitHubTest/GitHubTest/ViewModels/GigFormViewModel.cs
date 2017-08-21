using GitHubTest.Models;
using System.Collections.Generic;

namespace GitHubTest.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}