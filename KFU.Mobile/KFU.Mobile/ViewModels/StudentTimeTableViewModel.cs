using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KFU.Mobile.ViewModels
{
    public class StudentTimeTableViewModel
    {
        public string UserId { get; set; }
        public string StudentArabicName { get; set; }
        public string ColleageArabicName { get; set; }
        public string BranchArabicName { get; set; }
        public string CourseArabicName { get; set; }
        public string DayArabicName { get; set; }
        public string SlotFrom { get; set; }
        public string SlotTo { get; set; }
        public string CRN { get; set; }
        public string RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int QuarterId { get; set; }
    }
}