using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Presentation.Utilerias
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
    }
}