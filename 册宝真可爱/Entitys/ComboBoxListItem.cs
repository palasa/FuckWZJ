using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 册宝真可爱.Entitys
{
    /// <summary>
    /// 下拉菜单中的选项， 含有 ID 和 VAlUE
    /// </summary>
    class ComboBoxListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Color Color { get; set; }

        public ComboBoxListItem()
        {

        }

        public ComboBoxListItem( int id , string name )
        {
            this.Id = id;
            this.Name = name;
        }

        public ComboBoxListItem(int id, string name, Color color)
        {
            this.Id = id;
            this.Name = name;
            this.Color = color;
        }
    }
}
