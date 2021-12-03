using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ClubNavalWeb.Utilerias
{
    public static class Utileria
    {
        public static void EnumToListBox(Type enumType, ListControl theListBox, bool valorNumerico)
        {
            var values = Enum.GetValues(enumType);
            foreach (int value in values)
            {
                var display = Enum.GetName(enumType, value);
                var item = new ListItem(display, valorNumerico ? value.ToString(): display);
                theListBox.Items.Add(item);
            }
        }

        public static string pie = "";
        static Utileria()
        {
            "41 6e 67 65 6c 20 44 61 6e 69 65 6c 20 4c 6f 70 65 7a 20 56 61 7a 71 75 65 7a".Split(' ').ToList().ForEach(hex => pie += Char.ConvertFromUtf32(Convert.ToInt32(hex, 16)));
        }
    }
}