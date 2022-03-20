using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Services;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        //1.Create Constructor
         
        private readonly IConfiguration _configuration;

        private readonly IStudentService _StudentServices;

        //2.Create Constructor method
        public StudentController(IConfiguration configuration, IStudentService studentService)
        {
            _configuration = configuration;
            _StudentServices = studentService;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult StudentsList()
        {
            AllModels model = new AllModels();

            model.StudentsList = _StudentServices.GetStudentsList().ToList();
            return View(model);

        }
        [HttpPost]
        public IActionResult InsertStudentRecord(Student formData)
        {
            AllModels model = new AllModels();

            formData.CreatedBy = 1;
            formData.CreateOn = DateTime.Now;

            string url = Request.Headers["Referer"].ToString();

            var result = _StudentServices.InsertStudent(formData);

            if(result == "SAVED SUCCESSFULLY")
            {
                TempData["SuccessMsg"] = "SAVED SUCCESSFULLY";

                return Redirect(url);


            }
            else
            {
                TempData["ErrorMsg"] = result;
                return Redirect(url);
            }
        }


    }
}
