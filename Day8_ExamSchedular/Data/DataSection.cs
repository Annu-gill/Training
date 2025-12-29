using System;
using System.Collections.Generic;
using System.Text;
using ExamSchedule.Model;

namespace ExamSchedule.Data
{
    public static class DataSection
    {
        private static List<Section> Sections = [];

        static DataSection()
        {
            Sections.Add(new Section { Id = 1, Name = "K22QR" });
            Sections.Add(new Section { Id = 2, Name = "K22DM" });
            Sections.Add(new Section { Id = 3, Name = "K22PJ" });
            Sections.Add(new Section { Id = 4, Name = "K22SA" });
            Sections.Add(new Section { Id = 5, Name = "K22JM" });
        }

        public static List<Section> GetSections()
        {
            return Sections;
        }
    }
}