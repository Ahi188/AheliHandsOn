using System;
using System.Collections.Generic;

namespace MenuAPI.DB
{
    public partial class MenuCard
    {
        public MenuCard()
        {
            Dishes = new HashSet<Dishes>();
        }

        public int MenuId { get; set; }
        public string? Cusine { get; set; }

        public virtual ICollection<Dishes> Dishes { get; set; }
    }
}
