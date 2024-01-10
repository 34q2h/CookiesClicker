using System.Collections.Generic;

namespace CookiesClicker.DTO
{
    public class LeadrsDTO
    {
        public readonly IEnumerable<KeyValuePair<string, int>> Leadrs;
        public LeadrsDTO(IEnumerable<KeyValuePair<string, int>> leadrs) =>
            Leadrs = leadrs;
    }
}