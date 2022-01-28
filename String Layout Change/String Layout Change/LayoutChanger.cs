using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace String_Layout_Change
{
    public static class LayoutChanger
    {
        private static Layout currentLayout = null;

        public static void SetCurrentLayout(string layoutFilePath)
        {
            if (File.Exists(layoutFilePath))
            {
                var file = File.ReadAllText(layoutFilePath);
                currentLayout = new Layout(file);
            }
            else
            {
                MessageBox.Show($"Unable to find {layoutFilePath} layout file!");
            }
        }

        public static string GetEquivalent(string str)
        {
            if (currentLayout != null)
            {
                string res = "";
                foreach (var s in str)
                {
                    res += currentLayout.GetEquivalent(s.ToString());
                }
                return res;
            }
            else
            {
                MessageBox.Show("Current layout configuration is null");
                return str;
            }
        }

        public class Layout
        {
            private List<LayoutCase> layoutCases = new List<LayoutCase>();

            public Layout(string layoutFile)
            {
                var strings = layoutFile.Split('\n');
                foreach (var s in strings)
                {
                    string[] separator = new string[] { "--" };
                    var sp = s.Split(separator, StringSplitOptions.None);
                    layoutCases.Add(new LayoutCase(sp[0], sp[1]));
                }
            }

            public string GetEquivalent(string s)
            {
                foreach (var lcase in layoutCases)
                {
                    if (s == lcase.c1)
                    {
                        return lcase.c2;
                    }

                    if (s == lcase.c2)
                    {
                        return lcase.c1;
                    }
                }

                return s;
            }
        }

        public class LayoutCase
        {
            public string c1;
            public string c2;

            public LayoutCase(string c1, string c2)
            {
                this.c1 = c1;
                this.c2 = c2;
            }
        }
    }}
