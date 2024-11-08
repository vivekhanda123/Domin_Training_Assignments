using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsAtendanceController : ControllerBase
    {
        static List<StuAttendance> attendanceList;
        [HttpGet]
        public List<StuAttendance> Get()
        {
            attendanceList = new List<StuAttendance> {
               new StuAttendance() { StudentID=101,StudentName="Tom", AttendancePercentage=90},
                new StuAttendance() { StudentID=102,StudentName="Jerry", AttendancePercentage=91},
                new StuAttendance() { StudentID=103,StudentName="Honey", AttendancePercentage=92},
                new StuAttendance() { StudentID=104,StudentName="Mickey", AttendancePercentage=93},

          };
            return attendanceList;
        }
    }
}
