using HR.Entities;
using HR.Managment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HR
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    class ObjectGrid
    {
        public string Name { get; set; }
        public bool isChecked { get; set; }
    }
    public partial class Test : UserControl
    {
        public Test() {
            InitializeComponent();
            FillGrid();
        }

        private void FillGrid() {
            List<Skill> ls = new SkillsServices().ListSkills();
            List<ObjectGrid> LG = new List<ObjectGrid>();
            foreach (var skill in ls) {
                LG.Add(new ObjectGrid { Name = skill.Name, isChecked = false });
            }
        }
    }
}
