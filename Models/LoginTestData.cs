using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.Models
{
    public class LoginTestData
    {
        public LoginData ValidUser { get; set; } = null!;
        public LoginData InvalidUser { get; set; } = null!;
    }
}
