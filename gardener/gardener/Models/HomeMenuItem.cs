using System;
using System.Collections.Generic;
using System.Text;

namespace gardener.Models
{
    public enum MenuItemType
    {
        Rent,
        Selling,
        Rentsell,
        Challengemphous,
        Callsecurity
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
