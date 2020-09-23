using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloEmpty_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloEmpty_Razor.Pages
{
    public class IndexModel : PageModel
    {
        // �� ���ε� ���� �Ͻ�
        [BindProperty]
        public HelloMessage HelloMsg { get; set; }

        public string Noti { get; set; }

        public void OnGet()
        {
            this.HelloMsg = new HelloMessage()
            {
                Message = "Hello Razor Pages"
            };
        }

        public void OnPost()
        {
            this.Noti = "Message Changed";
        }
    }
}
